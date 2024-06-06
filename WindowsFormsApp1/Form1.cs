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

namespace WindowsFormsApp1
{
    public partial class Form1 : UIForm
    {
        private HImage hImage = new HImage();
        private HObject himgBinarization,
            ModelImage;
        HRegion hRegion = new HRegion();
        HTuple myModel;

        //匹配三角形
        private HTuple MatchRow1,
            MatchRow2,
            MatchCol1,
            MatchCol2;

        //找圆测量模型
        private HTuple MetrologyHandle,
            MetrologyRow,
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
                HOperatorSet.ReadShapeModel(
                    Directory.GetCurrentDirectory() + @"/MagnetModel.shm",
                    out myModel
                );
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
            if (!hImage.IsInitialized())
                return;
            HObject rgbImage = new HImage();
            HOperatorSet.Rgb1ToGray(hImage, out rgbImage);
            HOperatorSet.Threshold(rgbImage, out himgBinarization, 250, 255);
            HObject hImage1;
            // hImage =  hImage.PaintRegion(hRegion, new HTuple(255, 255, 255), "fill");
            HOperatorSet.ReduceDomain(hImage, himgBinarization, out hImage1);
            // 将图像设置到控件中
            hImage = new HImage(hImage1);
            imageContorl1.SetImage(hImage);
            hRegion.Dispose();
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

        HRegion regionAff = new HRegion();

        private void uiButton5_Click(object sender, EventArgs e)
        {
            regionAff.GenRectangle1(new HTuple(100), 100, 300, 200);
            imageContorl1.DisplayRegoin(regionAff);
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            //HHomMat2D hHomMat2D = new HHomMat2D();
            //hHomMat2D= hHomMat2D.HomMat2dTranslate(new HTuple(100), 100);
            //regionAff = hHomMat2D.AffineTransRegion(regionAff, "nearest_neighbor");
            //imageContorl1.DisplayRegoin(regionAff);

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

        private void btnFindCircle_Click_1(object sender, EventArgs e)
        {
            HTuple Parameter = new HTuple();
            HObject ResultContour = null;
            HOperatorSet.ApplyMetrologyModel(hImage, MetrologyHandle);
            HOperatorSet.GetMetrologyObjectResult(
                MetrologyHandle,
                "all",
                "all",
                "result_type",
                "all_param",
                out HTuple CircleResult
            );
            HOperatorSet.GenEmptyObj(out ResultContour);
            ResultContour.Dispose();
            HOperatorSet.GetMetrologyObjectResultContour(
                out ResultContour,
                MetrologyHandle,
                "all",
                "all",
                1
            );

            double CenterX = 0,
                CenterY = 0,
                Radius = 0;
            if (CircleResult.TupleLength() >= 3)
            {
                CenterY = Math.Round(CircleResult[0].D, 4);
                CenterX = Math.Round(CircleResult[1].D, 4);
                Radius = Math.Round(CircleResult[2].D, 4);
            }

            //显示图像及轮廓
            UIMessageBox.ShowSuccess($"圆查找成功！X:{CenterX},Y:{CenterY},半径:{Radius}");
            imageContorl1.SetImage(hImage);
            imageContorl1.DisplayRegoin(ResultContour);
        }

        private void btnMeasLine_Click(object sender, EventArgs e)
        {
            HMetrologyModel MetroModel = new HMetrologyModel();

            imageContorl1.DrawLine(out lineRow1, out lineCol1, out lineRow2, out lineCol2); //画直线
            HTuple lineInfo = (new HTuple(new double[] { lineRow1, lineCol1, lineRow2, lineCol2 }));
            //降低直线拟合的最低得分
            MetroModel.AddMetrologyObjectGeneric(
                new HTuple("line"), // 参数1: 对象类型 ("line" 表示线)
                lineInfo, // 参数2: 几何参数 (如起点和终点坐标)
                new HTuple(20), //搜索宽度，匹配框有多宽
                new HTuple(10), // 搜索框的间隔，*有效搜索高度
                new HTuple(1), //滤波 (filter) 用于控制边缘检测的滤波
                new HTuple(10), // 边缘阈值
                new HTuple("measure_transition", "measure_select", "measure_distance"), // 参数7: 测量控制参数 (例如测量转换、测量选择等)
                new HTuple("all", "first", 10) // 参数8: 测量控制参数的值 (对应参数7中指定的控制参数) 从黑到白，从白到黑，所有之类， 边缘选择， distance,搜索的间距
            );

            MetroModel.SetMetrologyObjectParam(0, "min_score", 0.1);
            /// 分数阈值
            MetroModel.ApplyMetrologyModel(hImage);
            var outXld = MetroModel.GetMetrologyObjectMeasures(
                "all",
                "all",
                out HTuple outR,
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
        }

        private void btnFindModel_Click(object sender, EventArgs e)
        {
            FindModel();
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if (!hRegion.IsInitialized())
                return;
            HObject ModelImages,
                ModelRegions;
            HOperatorSet.ReduceDomain(hImage, hRegion, out ModelImage);

            HOperatorSet.InspectShapeModel(ModelImage, out ModelImages, out ModelRegions, 4, 20);

            HOperatorSet.CreateShapeModel(
                ModelImage,
                "auto",
                0,
                (new HTuple(360)).TupleRad(),
                "auto",
                "auto",
                "use_polarity",
                "auto",
                "auto",
                out myModel
            );
            FindModel();
            GC.Collect();
        }

        private void btndymicBinarization_Click(object sender, EventArgs e)
        {
            if (!hImage.IsInitialized())
                return;
            HObject rgbImage = new HImage();
            HOperatorSet.Rgb1ToGray(hImage, out rgbImage);
            HOperatorSet.BinaryThreshold(
                rgbImage,
                out himgBinarization,
                "max_separability",
                "light",
                out HTuple usedThreshold
            );
            HRegion hRegion = new HRegion(himgBinarization);
            HObject hImage1 = new HImage();
            // hImage =  hImage.PaintRegion(hRegion, new HTuple(255, 255, 255), "fill");
            HOperatorSet.ReduceDomain(rgbImage, hRegion, out hImage1);
            // 将图像设置到控件中
            hImage = new HImage(hImage1);
            imageContorl1.SetImage(hImage);
            hRegion.Dispose();
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

        private void uiButton1_Click(object sender, EventArgs e)
        {
            imageContorl1.DrawROI(
                RoiType.Circle,
                out MetrologyRow,
                out MetrologyCol,
                out MetrologyRadius
            );
            HOperatorSet.CreateMetrologyModel(out MetrologyHandle);
            HTuple Circle1Param = null,
                Circle2Param = null,
                Circle1Index,
                Circle2Index;
            Circle1Param = new HTuple();
            Circle1Param = Circle1Param.TupleConcat(MetrologyRow);
            Circle1Param = Circle1Param.TupleConcat(MetrologyCol);
            Circle1Param = Circle1Param.TupleConcat(MetrologyRadius - 5);

            Circle2Param = new HTuple();
            Circle2Param = Circle2Param.TupleConcat(MetrologyRow);
            Circle2Param = Circle2Param.TupleConcat(MetrologyCol);
            Circle2Param = Circle2Param.TupleConcat(MetrologyRadius + 5);
            HOperatorSet.AddMetrologyObjectGeneric(
                MetrologyHandle,
                "circle",
                Circle1Param,
                20,
                5,
                1,
                30,
                new HTuple(),
                new HTuple(),
                out Circle1Index
            );
            HOperatorSet.AddMetrologyObjectGeneric(
                MetrologyHandle,
                "circle",
                Circle2Param,
                20,
                5,
                1,
                30,
                new HTuple(),
                new HTuple(),
                out Circle2Index
            );

            //获取测量模型里的模型轮廓
            HObject ModelContour;
            HOperatorSet.GenEmptyObj(out ModelContour);
            ModelContour.Dispose();
            HOperatorSet.GetMetrologyObjectModelContour(
                out ModelContour,
                MetrologyHandle,
                "all",
                1.5
            );

            //获取测量模型里的测量区域
            HObject MeasureContour;
            HOperatorSet.GenEmptyObj(out MeasureContour);
            MeasureContour.Dispose();

            HTuple Row = null,
                Column = null;
            HOperatorSet.GetMetrologyObjectMeasures(
                out MeasureContour,
                MetrologyHandle,
                Circle1Index.TupleConcat(Circle2Index),
                "all",
                out Row,
                out Column
            );

            imageContorl1.DisplayRegoin(ModelContour);
            imageContorl1.DisplayRegoin(MeasureContour);
        }

        public void FindModel()
        {
            HTuple row,
                col,
                angle,
                score = new HTuple();
            HObject ModelContours;
            // 在图像中找到形状模型
            HOperatorSet.FindShapeModel(
                hImage,
                myModel,
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

                HOperatorSet.GetShapeModelContours(out ModelContours, myModel, 1);

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
