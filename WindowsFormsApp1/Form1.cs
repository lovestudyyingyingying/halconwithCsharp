using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DataBase;
using WindowsFormsApp1.DataBase.Table;
using Sunny.UI;
using HalconDotNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Common;
using System.IO;
using static System.Windows.Forms.LinkLabel;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Sunny.UI.Win32;

namespace WindowsFormsApp1
{
    public partial class Form1 : UIForm
    {
        private HImage hImage = new HImage();
        private HImage himgBinarization,
            ModelImage;
        HRegion hRegion = new HRegion();
        HShapeModel myModel = new HShapeModel();

        //匹配三角形
        private HTuple MatchRow1,
            MatchRow2,
            MatchCol1,
            MatchCol2;
        HMetrologyModel MetrologyHandle = new HMetrologyModel();

        //找圆测量模型
        private HTuple MetrologyRow,
            MetrologyCol,
            MetrologyRadius;

        //直线测量
        private double lineRow1,
            lineCol1,
            lineRow2,
            lineCol2;

        public Form1()
        {
            InitializeComponent();
            if (File.Exists(Directory.GetCurrentDirectory() + @"/MagnetModel.shm"))
            {
                //File.Delete(Directory.GetCurrentDirectory() + @"/MagnetModel.shm");
                myModel.ReadShapeModel(Directory.GetCurrentDirectory() + @"/MagnetModel.shm");
                //MessageBox.Show("保存模板成功！");
            }
        }

        //创建Halcon窗口


        private void uibtnTest_Click(object sender, EventArgs e)
        {
            hImage.ReadImage("D:\\img\\30-light.bmp");
            imageContorl1.SetImage(hImage);
        }

        private void btnBinarization_Click(object sender, EventArgs e)
        {
            //if (!hImage.IsInitialized())
            //    return;
            //HObject rgbImage = new HImage();
            //HOperatorSet.Rgb1ToGray(hImage, out rgbImage);
            //HOperatorSet.Threshold(rgbImage, out himgBinarization, 250, 255);
            //HObject hImage1;
            //// hImage =  hImage.PaintRegion(hRegion, new HTuple(255, 255, 255), "fill");
            //HOperatorSet.ReduceDomain(hImage, himgBinarization, out hImage1);
            //// 将图像设置到控件中
            //hImage = new HImage(hImage1);
            //imageContorl1.SetImage(hImage);
            //hRegion.Dispose();
        }

        private void btnFitWindow_Click(object sender, EventArgs e)
        {
            imageContorl1.SetImage(hImage);
        }

        private void btnequ_histo_Click(object sender, EventArgs e)
        {
            hImage = hImage.EquHistoImage();
            imageContorl1.SetImage(hImage);
        }

        /// <summary>
        /// halcon区域类型，表示一部分区域
        /// </summary>
        HRegion regionAff = new HRegion();

        private void uiButton5_Click(object sender, EventArgs e)
        {
            regionAff.GenRectangle1(new HTuple(100), 100, 300, 200);
            imageContorl1.DisplayRegoin(regionAff);
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            //根据计算的矩阵变换
            HHomMat2D hHomMat2D = new HHomMat2D();
            hHomMat2D.VectorAngleToRigid(
                new HTuple(100),
                new HTuple(100),
                new HTuple(0),
                200,
                200,
                45
            );
            regionAff = hHomMat2D.AffineTransRegion(regionAff, "nearest_neighbor");
            imageContorl1.DisplayRegoin(regionAff);
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            HHomMat2D hHomMat2D = new HHomMat2D();
            hHomMat2D = hHomMat2D.HomMat2dRotate(new HTuple(45), new HTuple(200), 150);
            regionAff = hHomMat2D.AffineTransRegion(regionAff, "nearest_neighbor");
            imageContorl1.DisplayRegoin(regionAff);
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            hRegion = imageContorl1.DrawROI(
                RoiType.Retangle,
                out MatchRow1,
                out MatchCol1,
                out MatchRow2,
                out MatchCol2
            );
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void MeaCircle()
        {
            HMetrologyModel MetroModel = new HMetrologyModel();
            HTuple CircleResult;
            try
            {
                HTuple Circle_Info = new HTuple(new double[] { centerRow, centerCol, radius });
                MetroModel.AddMetrologyObjectGeneric(
                    new HTuple("circle"),
                    Circle_Info,
                    new HTuple(numCircleTall.Value),
                    new HTuple(numCircleWidth.Value),
                    new HTuple(1),
                    new HTuple(numThreshold.Value),
                    new HTuple("measure_transition", "measure_select", "measure_distance"),
                    new HTuple(
                        RParam.SetMeasModel(cmbMode.Text),
                        RParam.SetMeasSelect(cmbCircleFilter.Text),
                        numDis.Value
                    )
                );
                MetroModel.ApplyMetrologyModel(hImage);
                var outXld = MetroModel.GetMetrologyObjectMeasures(
                    "all",
                    "all",
                    out HTuple outR,
                    out HTuple outC
                );
                CircleResult = MetroModel.GetMetrologyObjectResult(
                    new HTuple("all"),
                    new HTuple("all"),
                    new HTuple("result_type"),
                    new HTuple("all_param")
                );
                if (CircleResult.TupleLength() >= 3)
                {
                    var centerY = Math.Round(CircleResult[0].D, 4);
                    var centerX = Math.Round(CircleResult[1].D, 4);
                    var radius1 = Math.Round(CircleResult[2].D, 4);
                    UIMessageBox.Show($"sucess！Y:{centerY},X:{centerX},Radius:{radius1}");
                    //绘制结果圆
                    HOperatorSet.GenCircleContourXld(
                        out HObject ResultXLD,
                        centerY,
                        centerX,
                        radius1,
                        0,
                        6.28318,
                        "positive",
                        1
                    );
                    imageContorl1.DisplayRegoin(ResultXLD);
                    //绘制结果点
                    HOperatorSet.GenCrossContourXld(
                        out HObject MeasCross,
                        outR,
                        outC,
                        5,
                        new HTuple(45).TupleRad()
                    );
                    imageContorl1.DisplayRegoin(MeasCross);
                }
                imageContorl1.DisplayRegoin(outXld);
            }
            catch (Exception ee)
            {
                UIMessageBox.ShowError(ee.Message);
            }
        }

        HTuple centerRow;
        HTuple centerCol;
        HTuple radius;

        private void btnMeaCircle_Click(object sender, EventArgs e)
        {
            if (imageContorl1.hDrawingObject.IsInitialized())
            {
                var doubleArr = imageContorl1.hDrawingObject
                    .GetDrawingObjectParams(new HTuple("row", "column", "radius"))
                    .DArr;
                centerRow = doubleArr[0];
                centerCol = doubleArr[1];
                radius = doubleArr[2];
                imageContorl1.SetImage(hImage);
                MeaCircle();
                imageContorl1.hDrawingObject.ClearDrawingObject();
            }
        }

        private void btnWriteLineROI_Click(object sender, EventArgs e)
        {
            imageContorl1.DrawROI(RoiType.Line);
        }

        private void uiButton2_Click(object sender, EventArgs e) { }

        private void btnGaussFilter_Click(object sender, EventArgs e)
        {
            try
            {
                hImage = hImage.GaussFilter((int)numCoefficient.Value);
                imageContorl1.SetImage(hImage);
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
            }
        }

        private void btnMedianFilter_Click(object sender, EventArgs e)
        {
            try
            {
                hImage = hImage.MedianImage("circle",(int)numCoefficient.Value,"mirrored");
                imageContorl1.SetImage(hImage);
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
            }
        }

        private void btnMeanImage_Click(object sender, EventArgs e)
        {
            try
            {
                hImage = hImage.MeanImage((int)numCoefficient.Value, (int)numCoefficient.Value);
                imageContorl1.SetImage(hImage);
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
            }
        }

        private void btnThredshold_Click(object sender, EventArgs e)
        {
            hImage.GetImageSize(out HTuple width, out HTuple height);
            hImage = hImage.Threshold(numMinThreshold.Value, numMaxThreshold.Value).RegionToBin(255, 0, width, height);
            imageContorl1.SetImage(hImage);

        }

        private void btnBinaryThreshold_Click(object sender, EventArgs e)
        {
            hImage.GetImageSize(out HTuple width, out HTuple height);

            hImage = hImage.BinaryThreshold("max_separability","light",out HTuple usedThreshold).RegionToBin(255, 0, width, height);
            imageContorl1.SetImage(hImage);

        }

        private void btnMeaLine_Click(object sender, EventArgs e)
        {
            if (imageContorl1.hDrawingObject.IsInitialized())
            {
                try
                {
                    HMetrologyModel MetroModel = new HMetrologyModel();

                    var lineInfo = imageContorl1.hDrawingObject.GetDrawingObjectParams(
                        new HTuple("row1", "column1", "row2", "column2")
                    );
                    MetroModel.AddMetrologyObjectGeneric(
                        new HTuple("line"), // 参数1: 对象类型 ("line" 表示线)
                        lineInfo, // 参数2: 几何参数 (如起点和终点坐标)
                        new HTuple(numLineTall.Value), //搜索框高度
                        new HTuple(numLineWidth.Value), // 搜索框宽度
                        new HTuple(1), //滤波 (filter) 用于控制边缘检测的滤波
                        new HTuple(numLineThreshold.Value), // 边缘阈值
                        new HTuple("measure_transition", "measure_select", "measure_distance"), // 参数7: 测量控制参数 (例如测量转换、测量选择等)
                        new HTuple(
                            RParam.SetMeasModel(cmbLineMode.Text),
                            RParam.SetMeasSelect(cmbLineFilter.Text),
                            10
                        ) // 参数8: 测量控制参数的值 (对应参数7中指定的控制参数) 从黑到白，从白到黑，所有之类， 边缘选择， distance,搜索的间距
                    );

                    MetroModel.SetMetrologyObjectParam(0, "min_score", 0.1);
                    /// 分数阈值
                    MetroModel.ApplyMetrologyModel(hImage);
                    var outXld = MetroModel.GetMetrologyObjectMeasures(
                        "all",
                        "all",
                        out HTuple outR, //点
                        out HTuple outC
                    );
                    var lineResult = MetroModel.GetMetrologyObjectResult(
                        new HTuple("all"),
                        new HTuple("all"),
                        new HTuple("result_type"),
                        new HTuple("all_param")
                    );
                    var result = MetroModel.GetMetrologyObjectResultContour("all", "all", 1.5);
                    imageContorl1.SetImage(hImage);
                    imageContorl1.DisplayRegoin(result);
                    imageContorl1.DisplayRegoin(outXld);
                    imageContorl1.hDrawingObject.ClearDrawingObject();
                }
                catch (Exception ee)
                {
                    UIMessageBox.Show(ee.Message);
                }
            }
        }

        private void btnFindCircle_Click(object sender, EventArgs e)
        {
            imageContorl1.DrawROI();
            // MeaCircle();
        }

        private void btnFindModel_Click(object sender, EventArgs e)
        {
            FindModel();
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if (!hRegion.IsInitialized())
                return;
            ModelImage = hImage.ReduceDomain(hRegion);
            //HOperatorSet.InspectShapeModel(ModelImage, out ModelImages, out ModelRegions, 4, 20);

            myModel.CreateShapeModel(
                ModelImage,
                "auto",
                0,
                (new HTuple(360)).TupleRad(),
                "auto",
                "auto",
                "use_polarity",
                "auto",
                "auto"
            );
            FindModel();
            GC.Collect();
        }

        private void btndymicBinarization_Click(object sender, EventArgs e)
        {
            //if (!hImage.IsInitialized())
            //    return;
            //HObject rgbImage = new HImage();
            //HOperatorSet.Rgb1ToGray(hImage, out rgbImage);
            //HOperatorSet.BinaryThreshold(
            //    rgbImage,
            //    out himgBinarization,
            //    "max_separability",
            //    "light",
            //    out HTuple usedThreshold
            //);
            //HRegion hRegion = new HRegion(himgBinarization);
            //HObject hImage1 = new HImage();
            //// hImage =  hImage.PaintRegion(hRegion, new HTuple(255, 255, 255), "fill");
            //HOperatorSet.ReduceDomain(rgbImage, hRegion, out hImage1);
            //// 将图像设置到控件中
            //hImage = new HImage(hImage1);
            //imageContorl1.SetImage(hImage);
            //hRegion.Dispose();
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (myModel != null)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"/MagnetModel.shm"))
                {
                    File.Delete(Directory.GetCurrentDirectory() + @"/MagnetModel.shm");
                    HOperatorSet.WriteShapeModel(
                        myModel,
                        Directory.GetCurrentDirectory() + @"/MagnetModel.shm"
                    );
                    MessageBox.Show("保存模板成功！");
                }
                else
                {
                    HOperatorSet.WriteShapeModel(
                        myModel,
                        Directory.GetCurrentDirectory() + @"/MagnetModel.shm"
                    );
                    MessageBox.Show("保存模板成功！");
                }
            }
            else
            {
                MessageBox.Show("请先创建模板！");
                return;
            }
        }

        private void btnRoiCircle_Click(object sender, EventArgs e) { }

        private void uiButton1_Click(object sender, EventArgs e) { }

        public void FindModel()
        {
            HTuple row,
                col,
                angle,
                score = new HTuple();
            HXLDCont ModelContours;
            // 在图像中找到形状模型
            myModel.FindShapeModel(
                hImage,
                0,
                (new HTuple(360)).TupleRad(),
                0.5,
                10,
                0.5,
                "least_squares",
                0,
                0.9,
                out row,
                out col,
                out angle,
                out score
            );

            for (int i = 0; i < score.Length; i++)
            {
                // 获取并显示形状模型的轮廓

                ModelContours = myModel.GetShapeModelContours(1);

                HOperatorSet.GenRectangle1(
                    out HObject rectangle,
                    MatchRow1,
                    MatchRow2,
                    MatchCol1,
                    MatchCol2
                );
                HOperatorSet.AreaCenter(
                    rectangle,
                    out HTuple area,
                    out HTuple RefRow,
                    out HTuple RefCol
                );
                HHomMat2D homMatrec = new HHomMat2D();
                homMatrec.VectorAngleToRigid(
                    RefRow,
                    RefCol,
                    0,
                    row.TupleSelect(i),
                    col.TupleSelect(i),
                    angle.TupleSelect(i)
                );
                HHomMat2D homMat2D = new HHomMat2D();
                homMat2D.VectorAngleToRigid(
                    0,
                    0,
                    0,
                    row.TupleSelect(i),
                    col.TupleSelect(i),
                    angle.TupleSelect(i)
                );

                HOperatorSet.AffineTransContourXld(
                    ModelContours,
                    out HObject transformedContours,
                    homMat2D
                );
                HOperatorSet.AffineTransRegion(
                    rectangle,
                    out HObject regionAffineTrans,
                    homMatrec,
                    "nearest_neighbor"
                );
                // 生成一个旋转矩形以表示找到的形状模型
                //HOperatorSet.SmallestRectangle1Xld(transformedContours, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple  column2);
                //HOperatorSet.GenRectangle1(out HObject rectangle, row1, column1, row2, column2);

                // 显示结果
                imageContorl1.DisplayRegoin(transformedContours);
                imageContorl1.DisplayRegoin(regionAffineTrans);

                //imageContorl1.DisplayRegoin(point);
            }
        }
    }
}
