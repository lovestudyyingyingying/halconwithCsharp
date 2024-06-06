using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class ImageContorl : UserControl
    {
        public ImageContorl()
        {
            InitializeComponent();
            CreateHalconWindow();
        }

        //缩放图像
        private void hWindowControl1_HMouseWheel(object sender, HMouseEventArgs e)
        {
            HTuple Zoom,
                Row,
                Col,
                Button;
            HTuple Row0,
                Column0,
                Row00,
                Column00,
                Ht,
                Wt,
                r1,
                c1,
                r2,
                c2;
            if (e.Delta > 0)
            {
                Zoom = 1.5;
            }
            else
            {
                Zoom = 0.5;
            }
            HOperatorSet.GetMposition(WindowID, out Row, out Col, out Button);
            HOperatorSet.GetPart(WindowID, out Row0, out Column0, out Row00, out Column00);
            Ht = Row00 - Row0;
            Wt = Column00 - Column0;
            if (Ht * Wt < 32000 * 32000 || Zoom == 1.5) //普通版halcon能处理的图像最大尺寸是32K*32K。如果无限缩小原图像，导致显示的图像超出限制，则会造成程序崩溃
            {
                r1 = (Row0 + ((1 - (1.0 / Zoom)) * (Row - Row0)));
                c1 = (Column0 + ((1 - (1.0 / Zoom)) * (Col - Column0)));
                r2 = r1 + (Ht / Zoom);
                c2 = c1 + (Wt / Zoom);
                HOperatorSet.SetPart(WindowID, r1, c1, r2, c2);
                HOperatorSet.ClearWindow(WindowID);
                HOperatorSet.DispObj(hImage, WindowID);
                foreach (var item in regeionList)
                {
                    HOperatorSet.DispObj(item, WindowID);
                }
                PaintCross();
            }
        }

        //鼠标按下，记录当前坐标值
        private void hWindowControl1_HMouseDown(object sender, HMouseEventArgs e)
        {
            HTuple Row,
                Column,
                Button;
            HOperatorSet.GetMposition(WindowID, out Row, out Column, out Button);
            RowDown = Row; //鼠标按下时的行坐标
            ColDown = Column; //鼠标按下时的列坐标
        }

       
        //鼠标移动，实时显示当前坐标与灰度值
        private void hWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        {
            try
            {
                if (!hImage.IsInitialized())
                    return;
                HTuple Row,
                    Column,
                    Button,
                    pointGray;
                HOperatorSet.GetMposition(WindowID, out Row, out Column, out Button); //获取当前鼠标的坐标值
                if (
                    ImageHeight != null
                    && (Row > 0 && Row < ImageHeight)
                    && (Column > 0 && Column < ImageWidth)
                ) //设置3个条件项，防止程序崩溃。
                {
                    HOperatorSet.GetGrayval(hImage, Row, Column, out pointGray); //获取当前点的灰度值
                }
                else
                {
                    pointGray = "_";
                }
                String str = String.Format("Row:{0}  Column:{1}  Gray:{2}", Row, Column, pointGray); //格式化字符串

                uiLabel1.Text = str;
                //在label控件上显示数值
                if (e.Button == MouseButtons.Left)
                {
                    HTuple row1,
                        col1,
                        row2,
                        col2,
                        Row1,
                        Column1;
                    HOperatorSet.GetMposition(WindowID, out Row1, out Column1, out Button);
                    double RowMove = Row1 - RowDown; //鼠标弹起时的行坐标减去按下时的行坐标，得到行坐标的移动值
                    double ColMove = Column1 - ColDown; //鼠标弹起时的列坐标减去按下时的列坐标，得到列坐标的移动值
                    HOperatorSet.GetPart(WindowID, out row1, out col1, out row2, out col2); //得到当前的窗口坐标
                    HOperatorSet.SetPart(
                        WindowID,
                        row1 - RowMove,
                        col1 - ColMove,
                        row2 - RowMove,
                        col2 - ColMove
                    ); //这里可能有些不好理解。以左上角原点为参考点
                    HOperatorSet.ClearWindow(WindowID);
                    if (ImageHeight != null)
                    {
                        HOperatorSet.DispObj(hImage, WindowID);
                        foreach (var item in regeionList)
                        {
                            HOperatorSet.DispObj(item, WindowID);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请加载一张图片");
                    }
                    PaintCross();

                }
            }
            catch (HOperatorException) { }
        }

        HImage hImage = new HImage();
        HRegion hRegion = new HRegion();

        HTuple WindowID,
            ImageWidth,
            ImageHeight;
        private double RowDown; //鼠标按下时的行坐标
        private double ColDown; //鼠标按下时的列坐标
        List<HObject> regeionList = new List<HObject>(); // 存放所有需要展示的Regin

        private ContextMenuStrip hv_MenuStrip;

        private ToolStripMenuItem fit_strip;

        private ToolStripMenuItem saveImg_strip;

        private ToolStripMenuItem saveWindow_strip;

        private ToolStripMenuItem barVisible_strip;

        private ToolStripMenuItem blnCross_strip;

        private ToolStripMenuItem histogram_strip;
        public void CreateHalconWindow()
        {
            // ///图片控件为winform中的PictureBox控件时/
            //HTuple FatherWindow = this.hWindowControl1.Handle;
            //HOperatorSet.SetWindowAttr("background_color", "green");
            //HOperatorSet.OpenWindow(0, 0, this.hWindowControl1.Width, this.hWindowControl1.Height, FatherWindow, "visible", "", out WindowID);
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                //hv_window = hWindowControl1.HalconWindow;
                //fit_strip = new ToolStripMenuItem("适应图像显示");
                //fit_strip.Click += delegate
                //{
                //    DispImageFit(hWindowControl1);
                //};

                WindowID = hWindowControl1.HalconWindow;
                //barVisible_strip = new ToolStripMenuItem("显示图像信息");
                //barVisible_strip.CheckOnClick = true;
                //barVisible_strip.CheckedChanged += barVisible_strip_CheckedChanged;
                blnCross_strip = new ToolStripMenuItem("显示隐藏十字");
                blnCross_strip.CheckOnClick = true;
                blnCross_strip.Click += (obj, sender) => { PaintCross(); };
                        //saveImg_strip = new ToolStripMenuItem("保存原始图像");
                        //saveImg_strip.Click += delegate
                        //{
                        //    SaveImage();
                        //};
                        //saveWindow_strip = new ToolStripMenuItem("保存缩略图像");
                        //saveWindow_strip.Click += delegate
                        //{
                        //    SaveWindowDump();
                        //};
                        histogram_strip = new ToolStripMenuItem("显示直方图(H)");
                histogram_strip.CheckOnClick = true;
                histogram_strip.Checked = false;
                hv_MenuStrip = new ContextMenuStrip();
               // hv_MenuStrip.Items.Add(fit_strip);
                //hv_MenuStrip.Items.Add(barVisible_strip);
                hv_MenuStrip.Items.Add(blnCross_strip);
                //hv_MenuStrip.Items.Add(new ToolStripSeparator());
                //hv_MenuStrip.Items.Add(saveImg_strip);
                //hv_MenuStrip.Items.Add(saveWindow_strip);
                //barVisible_strip.Enabled = true;
                //fit_strip.Enabled = false;
                //histogram_strip.Enabled = false;
                //saveImg_strip.Enabled = false;
                //saveWindow_strip.Enabled = false;
                hWindowControl1.ContextMenuStrip = hv_MenuStrip;


            }
        }
        private void PaintCross()
        {
            if (blnCross_strip.Checked)
            {
                HXLDCont hXLDCont = new HXLDCont();
                hWindowControl1.HalconWindow.SetColor("green");
                HRegion regions = new HRegion((HTuple)0, (HTuple)0, (HTuple)ImageHeight, (HTuple)ImageWidth);
                HOperatorSet.AreaCenter(regions, out var _, out var row, out var column);
                row = ImageHeight / 2;
                column = ImageWidth / 2;
                hWindowControl1.HalconWindow.DispLine(row - 5, column, row + 5, column);
                hWindowControl1.HalconWindow.DispLine(row, column - 5, row, column + 5);
                hWindowControl1.HalconWindow.DispLine((double)row, (double)column + 50.0, (double)row, (double)column * 2.0);
                hWindowControl1.HalconWindow.DispLine((double)row, 0.0, (double)row, (double)column - 50.0);
                hWindowControl1.HalconWindow.DispLine(0.0, (double)column, (double)row - 50.0, (double)column);
                hWindowControl1.HalconWindow.DispLine((double)row + 50.0, (double)column, (double)row * 2.0, (double)column);
            }
        }
        public void SetImage(HImage hImage)
        {
            this.hImage = hImage;
            WindowID = hWindowControl1.HalconWindow; //将Halcon窗口对象与控件进行关联
            //hImage.GetImageSize(out  ImageWidth, out ImageHeight);//获取图像尺寸
            DisplayImage();
        }

        public void SetImage(HObject hImage)
        {
            this.hImage = new HImage(hImage);
            WindowID = hWindowControl1.HalconWindow; //将Halcon窗口对象与控件进行关联
            //hImage.GetImageSize(out  ImageWidth, out ImageHeight);//获取图像尺寸

            DisplayImage();
        }

        private void DisplayImage()
        {
            regeionList.Clear();
            hWindowControl1.HalconWindow.SetColor("red");
            HTuple win_Width, win_Height, win_Col, win_Row, cwin_Width, cwin_Height;
            HOperatorSet.ClearWindow(WindowID);
            HOperatorSet.GetImageSize(hImage, out ImageWidth, out ImageHeight );//获取图片大小规格
            HOperatorSet.GetWindowExtents(WindowID, out win_Row, out win_Col, out win_Width, out win_Height);//获取窗体大小规格
            cwin_Height = 1.0 * win_Height / win_Width * ImageWidth;//宽不变计算高          
            if (cwin_Height > ImageHeight)//宽不变高能容纳
            {
                cwin_Height = 1.0 * (cwin_Height - ImageHeight) / 2;
                HOperatorSet.SetPart(WindowID, -cwin_Height, 0, cwin_Height + ImageHeight, ImageWidth);//设置窗体的规格
            }
            else//高不变宽能容纳
            {
                cwin_Width = 1.0 * win_Width / win_Height * ImageHeight;//高不变计算宽
                cwin_Width = 1.0 * (cwin_Width - ImageWidth) / 2;
                HOperatorSet.SetPart(WindowID, 0, -cwin_Width, ImageHeight, cwin_Width + ImageWidth);//设置窗体的规格
            }
            HOperatorSet.DispObj(hImage, WindowID);//显示图片
        }

        private void ImageContorl_Load(object sender, EventArgs e) { }

        public HRegion DrawROI(RoiType roiType)
        {
            //DisplayImage();
            HTuple ROI_row1,
                ROI_column1,
                ROI_row2,
                ROI_column2,
                circle_radius = new HTuple();
            // hWindowControl1.Focus();
            switch (roiType)
            {
                case RoiType.Retangle:
                    HOperatorSet.DrawRectangle1(
                        hWindowControl1.HalconWindow,
                        out ROI_row1,
                        out ROI_column1,
                        out ROI_row2,
                        out ROI_column2
                    );
                    //HRegion ROI = new HRegion();
                    hRegion.GenRectangle1(ROI_row1, ROI_column1, ROI_row2, ROI_column2);
                    break;
                case RoiType.Circle:
                    HOperatorSet.DrawCircle(
                        WindowID,
                        out ROI_row1,
                        out ROI_column1,
                        out circle_radius
                    );
                    hRegion.GenCircle(ROI_row1, ROI_column1, circle_radius);
                    break;
                default:
                    break;
            }

            hWindowControl1.HalconWindow.SetColor("red");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
            DisplayRegoin(hRegion);
            return hRegion;
        }

        public HRegion DrawROI(
            RoiType roiType,
            out HTuple centerRow,
            out HTuple centerCol,
            out HTuple radius
        )
        {
            //DisplayImage();
            HTuple ROI_row1,
                ROI_column1,
                ROI_row2,
                ROI_column2,
                circle_radius = new HTuple();
            //hWindowControl1.Focus();
            switch (roiType)
            {
                case RoiType.Retangle:
                    HOperatorSet.DrawRectangle1(
                        hWindowControl1.HalconWindow,
                        out ROI_row1,
                        out ROI_column1,
                        out ROI_row2,
                        out ROI_column2
                    );
                    //HRegion ROI = new HRegion();
                    hRegion.GenRectangle1(ROI_row1, ROI_column1, ROI_row2, ROI_column2);
                    break;
                case RoiType.Circle:
                    HOperatorSet.DrawCircle(
                        WindowID,
                        out ROI_row1,
                        out ROI_column1,
                        out circle_radius
                    );
                    hRegion.GenCircle(ROI_row1, ROI_column1, circle_radius);
                    break;
                default:
                    ROI_row1 = new HTuple();
                    ROI_column1 = new HTuple();

                    break;
            }
            centerRow = ROI_row1;
            centerCol = ROI_column1;
            radius = circle_radius;
            hWindowControl1.HalconWindow.SetColor("red");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
            // hImage.PaintRegion(ROI, new HTuple(255, 0, 0), "fill");
            DisplayRegoin(hRegion);

            return hRegion;
        }

        public HRegion DrawROI(
            RoiType roiType,
            out HTuple row1,
            out HTuple row2,
            out HTuple col1,
            out HTuple col2
        )
        {
            //DisplayImage();
            HTuple ROI_row1 = new HTuple(),
                ROI_column1 = new HTuple(),
                ROI_row2 = new HTuple(),
                ROI_column2 = new HTuple(),
                circle_radius = new HTuple();
            // hWindowControl1.Focus();
            switch (roiType)
            {
                case RoiType.Retangle:
                    HOperatorSet.DrawRectangle1(
                        hWindowControl1.HalconWindow,
                        out ROI_row1,
                        out ROI_column1,
                        out ROI_row2,
                        out ROI_column2
                    );
                    //HRegion ROI = new HRegion();
                    hRegion.GenRectangle1(ROI_row1, ROI_column1, ROI_row2, ROI_column2);
                    break;
                case RoiType.Circle:
                    HOperatorSet.DrawCircle(
                        WindowID,
                        out ROI_row1,
                        out ROI_column1,
                        out circle_radius
                    );
                    hRegion.GenCircle(ROI_row1, ROI_column1, circle_radius);
                    break;
                default:
                    break;
            }
            row1 = ROI_row1;
            row2 = ROI_row2;
            col1 = ROI_column1;
            col2 = ROI_column2;

            hWindowControl1.HalconWindow.SetColor("red");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
            DisplayRegoin(hRegion);
            return hRegion;
        }

        public void DrawLine(out double row1,out double col1,out double row2,out double col2)
        {
            hWindowControl1.HalconWindow.DrawLine(out row1 ,out col1,out row2,out col2 );
            HOperatorSet.GenRegionLine(out HObject regionLines, row1, col1, row2, col2);
            DisplayRegoin(regionLines);

        }
        public void DisplayRegoin(HObject hregions)
        {
            regeionList.Add(hregions);
            HOperatorSet.DispObj(hregions, WindowID);
        }
       
    }

    public enum RoiType
    {
        Retangle,
        Circle
    }
}
