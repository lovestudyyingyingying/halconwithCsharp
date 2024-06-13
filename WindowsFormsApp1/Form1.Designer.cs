namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.uibtnTest = new Sunny.UI.UIButton();
            this.btnFitWindow = new Sunny.UI.UIButton();
            this.btnDrawRoi = new Sunny.UI.UIButton();
            this.btnCreateModel = new Sunny.UI.UIButton();
            this.btnFindModel = new Sunny.UI.UIButton();
            this.btnSaveModel = new Sunny.UI.UIButton();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.btnFindCircle = new Sunny.UI.UIButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.uiButton5 = new Sunny.UI.UIButton();
            this.uiButton6 = new Sunny.UI.UIButton();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.cmbCircleFilter = new Sunny.UI.UIComboBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.cmbMode = new Sunny.UI.UIComboBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.btnMeaCircle = new Sunny.UI.UIButton();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.numDis = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.numThreshold = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.numCircleWidth = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.numCircleTall = new Sunny.UI.UIDoubleUpDown();
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.cmbLineFilter = new Sunny.UI.UIComboBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.cmbLineMode = new Sunny.UI.UIComboBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.btnMeaLine = new Sunny.UI.UIButton();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.numLineDis = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.numLineThreshold = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.numLineWidth = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.numLineTall = new Sunny.UI.UIDoubleUpDown();
            this.btnWriteLineROI = new Sunny.UI.UIButton();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnequ_histo = new Sunny.UI.UIButton();
            this.btnGaussFilter = new Sunny.UI.UIButton();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.numCoefficient = new Sunny.UI.UIDoubleUpDown();
            this.btnMedianFilter = new Sunny.UI.UIButton();
            this.btnMeanImage = new Sunny.UI.UIButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.numMaxThreshold = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel15 = new Sunny.UI.UILabel();
            this.numMinThreshold = new Sunny.UI.UIDoubleUpDown();
            this.btnThredshold = new Sunny.UI.UIButton();
            this.imageContorl1 = new WindowsFormsApp1.ImageContorl();
            this.btnBinaryThreshold = new Sunny.UI.UIButton();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.uiGroupBox4.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uibtnTest
            // 
            this.uibtnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uibtnTest, "uibtnTest");
            this.uibtnTest.Name = "uibtnTest";
            this.uibtnTest.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uibtnTest.Click += new System.EventHandler(this.uibtnTest_Click);
            // 
            // btnFitWindow
            // 
            this.btnFitWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnFitWindow, "btnFitWindow");
            this.btnFitWindow.Name = "btnFitWindow";
            this.btnFitWindow.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFitWindow.Click += new System.EventHandler(this.btnFitWindow_Click);
            // 
            // btnDrawRoi
            // 
            this.btnDrawRoi.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDrawRoi, "btnDrawRoi");
            this.btnDrawRoi.Name = "btnDrawRoi";
            this.btnDrawRoi.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDrawRoi.Click += new System.EventHandler(this.btnDrawRoi_Click);
            // 
            // btnCreateModel
            // 
            this.btnCreateModel.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnCreateModel, "btnCreateModel");
            this.btnCreateModel.Name = "btnCreateModel";
            this.btnCreateModel.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateModel.Click += new System.EventHandler(this.btnCreateModel_Click);
            // 
            // btnFindModel
            // 
            this.btnFindModel.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnFindModel, "btnFindModel");
            this.btnFindModel.Name = "btnFindModel";
            this.btnFindModel.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFindModel.Click += new System.EventHandler(this.btnFindModel_Click);
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSaveModel, "btnSaveModel");
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiTabControl1);
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFindCircle
            // 
            this.btnFindCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnFindCircle, "btnFindCircle");
            this.btnFindCircle.Name = "btnFindCircle";
            this.btnFindCircle.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFindCircle.Click += new System.EventHandler(this.btnFindCircle_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.uiButton4);
            this.uiGroupBox2.Controls.Add(this.uiButton5);
            this.uiGroupBox2.Controls.Add(this.uiButton6);
            resources.ApplyResources(this.uiGroupBox2, "uiGroupBox2");
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton4
            // 
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uiButton4, "uiButton4");
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton4.Click += new System.EventHandler(this.uiButton4_Click);
            // 
            // uiButton5
            // 
            this.uiButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uiButton5, "uiButton5");
            this.uiButton5.Name = "uiButton5";
            this.uiButton5.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton5.Click += new System.EventHandler(this.uiButton5_Click);
            // 
            // uiButton6
            // 
            this.uiButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uiButton6, "uiButton6");
            this.uiButton6.Name = "uiButton6";
            this.uiButton6.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton6.Click += new System.EventHandler(this.uiButton6_Click);
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.cmbCircleFilter);
            this.uiGroupBox3.Controls.Add(this.uiLabel6);
            this.uiGroupBox3.Controls.Add(this.cmbMode);
            this.uiGroupBox3.Controls.Add(this.uiLabel5);
            this.uiGroupBox3.Controls.Add(this.btnMeaCircle);
            this.uiGroupBox3.Controls.Add(this.uiLabel4);
            this.uiGroupBox3.Controls.Add(this.numDis);
            this.uiGroupBox3.Controls.Add(this.uiLabel3);
            this.uiGroupBox3.Controls.Add(this.numThreshold);
            this.uiGroupBox3.Controls.Add(this.uiLabel2);
            this.uiGroupBox3.Controls.Add(this.numCircleWidth);
            this.uiGroupBox3.Controls.Add(this.uiLabel1);
            this.uiGroupBox3.Controls.Add(this.numCircleTall);
            this.uiGroupBox3.Controls.Add(this.btnFindCircle);
            resources.ApplyResources(this.uiGroupBox3, "uiGroupBox3");
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCircleFilter
            // 
            this.cmbCircleFilter.DataSource = null;
            this.cmbCircleFilter.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.cmbCircleFilter, "cmbCircleFilter");
            this.cmbCircleFilter.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cmbCircleFilter.Items.AddRange(new object[] {
            resources.GetString("cmbCircleFilter.Items"),
            resources.GetString("cmbCircleFilter.Items1"),
            resources.GetString("cmbCircleFilter.Items2")});
            this.cmbCircleFilter.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmbCircleFilter.Name = "cmbCircleFilter";
            this.cmbCircleFilter.SymbolSize = 24;
            this.cmbCircleFilter.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbCircleFilter.Watermark = "";
            // 
            // uiLabel6
            // 
            resources.ApplyResources(this.uiLabel6, "uiLabel6");
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Name = "uiLabel6";
            // 
            // cmbMode
            // 
            this.cmbMode.DataSource = null;
            this.cmbMode.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.cmbMode, "cmbMode");
            this.cmbMode.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cmbMode.Items.AddRange(new object[] {
            resources.GetString("cmbMode.Items"),
            resources.GetString("cmbMode.Items1"),
            resources.GetString("cmbMode.Items2"),
            resources.GetString("cmbMode.Items3")});
            this.cmbMode.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.SymbolSize = 24;
            this.cmbMode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbMode.Watermark = "";
            // 
            // uiLabel5
            // 
            resources.ApplyResources(this.uiLabel5, "uiLabel5");
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Name = "uiLabel5";
            // 
            // btnMeaCircle
            // 
            this.btnMeaCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnMeaCircle, "btnMeaCircle");
            this.btnMeaCircle.Name = "btnMeaCircle";
            this.btnMeaCircle.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMeaCircle.Click += new System.EventHandler(this.btnMeaCircle_Click);
            // 
            // uiLabel4
            // 
            resources.ApplyResources(this.uiLabel4, "uiLabel4");
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Name = "uiLabel4";
            // 
            // numDis
            // 
            resources.ApplyResources(this.numDis, "numDis");
            this.numDis.Name = "numDis";
            this.numDis.ShowText = false;
            this.numDis.Step = 1D;
            this.numDis.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numDis.Value = 10D;
            // 
            // uiLabel3
            // 
            resources.ApplyResources(this.uiLabel3, "uiLabel3");
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Name = "uiLabel3";
            // 
            // numThreshold
            // 
            resources.ApplyResources(this.numThreshold, "numThreshold");
            this.numThreshold.Name = "numThreshold";
            this.numThreshold.ShowText = false;
            this.numThreshold.Step = 1D;
            this.numThreshold.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numThreshold.Value = 10D;
            // 
            // uiLabel2
            // 
            resources.ApplyResources(this.uiLabel2, "uiLabel2");
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Name = "uiLabel2";
            // 
            // numCircleWidth
            // 
            resources.ApplyResources(this.numCircleWidth, "numCircleWidth");
            this.numCircleWidth.Name = "numCircleWidth";
            this.numCircleWidth.ShowText = false;
            this.numCircleWidth.Step = 1D;
            this.numCircleWidth.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numCircleWidth.Value = 10D;
            // 
            // uiLabel1
            // 
            resources.ApplyResources(this.uiLabel1, "uiLabel1");
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Name = "uiLabel1";
            // 
            // numCircleTall
            // 
            resources.ApplyResources(this.numCircleTall, "numCircleTall");
            this.numCircleTall.Name = "numCircleTall";
            this.numCircleTall.ShowText = false;
            this.numCircleTall.Step = 1D;
            this.numCircleTall.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numCircleTall.Value = 10D;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.cmbLineFilter);
            this.uiGroupBox4.Controls.Add(this.uiLabel7);
            this.uiGroupBox4.Controls.Add(this.cmbLineMode);
            this.uiGroupBox4.Controls.Add(this.uiLabel8);
            this.uiGroupBox4.Controls.Add(this.btnMeaLine);
            this.uiGroupBox4.Controls.Add(this.uiLabel9);
            this.uiGroupBox4.Controls.Add(this.numLineDis);
            this.uiGroupBox4.Controls.Add(this.uiLabel10);
            this.uiGroupBox4.Controls.Add(this.numLineThreshold);
            this.uiGroupBox4.Controls.Add(this.uiLabel11);
            this.uiGroupBox4.Controls.Add(this.numLineWidth);
            this.uiGroupBox4.Controls.Add(this.uiLabel12);
            this.uiGroupBox4.Controls.Add(this.numLineTall);
            this.uiGroupBox4.Controls.Add(this.btnWriteLineROI);
            resources.ApplyResources(this.uiGroupBox4, "uiGroupBox4");
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLineFilter
            // 
            this.cmbLineFilter.DataSource = null;
            this.cmbLineFilter.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.cmbLineFilter, "cmbLineFilter");
            this.cmbLineFilter.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cmbLineFilter.Items.AddRange(new object[] {
            resources.GetString("cmbLineFilter.Items"),
            resources.GetString("cmbLineFilter.Items1"),
            resources.GetString("cmbLineFilter.Items2")});
            this.cmbLineFilter.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmbLineFilter.Name = "cmbLineFilter";
            this.cmbLineFilter.SymbolSize = 24;
            this.cmbLineFilter.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbLineFilter.Watermark = "";
            // 
            // uiLabel7
            // 
            resources.ApplyResources(this.uiLabel7, "uiLabel7");
            this.uiLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel7.Name = "uiLabel7";
            // 
            // cmbLineMode
            // 
            this.cmbLineMode.DataSource = null;
            this.cmbLineMode.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.cmbLineMode, "cmbLineMode");
            this.cmbLineMode.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cmbLineMode.Items.AddRange(new object[] {
            resources.GetString("cmbLineMode.Items"),
            resources.GetString("cmbLineMode.Items1"),
            resources.GetString("cmbLineMode.Items2"),
            resources.GetString("cmbLineMode.Items3")});
            this.cmbLineMode.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmbLineMode.Name = "cmbLineMode";
            this.cmbLineMode.SymbolSize = 24;
            this.cmbLineMode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbLineMode.Watermark = "";
            // 
            // uiLabel8
            // 
            resources.ApplyResources(this.uiLabel8, "uiLabel8");
            this.uiLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel8.Name = "uiLabel8";
            // 
            // btnMeaLine
            // 
            this.btnMeaLine.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnMeaLine, "btnMeaLine");
            this.btnMeaLine.Name = "btnMeaLine";
            this.btnMeaLine.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMeaLine.Click += new System.EventHandler(this.btnMeaLine_Click);
            // 
            // uiLabel9
            // 
            resources.ApplyResources(this.uiLabel9, "uiLabel9");
            this.uiLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel9.Name = "uiLabel9";
            // 
            // numLineDis
            // 
            this.numLineDis.DecimalPlaces = 0;
            resources.ApplyResources(this.numLineDis, "numLineDis");
            this.numLineDis.Name = "numLineDis";
            this.numLineDis.ShowText = false;
            this.numLineDis.Step = 1D;
            this.numLineDis.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numLineDis.Value = 10D;
            // 
            // uiLabel10
            // 
            resources.ApplyResources(this.uiLabel10, "uiLabel10");
            this.uiLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel10.Name = "uiLabel10";
            // 
            // numLineThreshold
            // 
            this.numLineThreshold.DecimalPlaces = 0;
            resources.ApplyResources(this.numLineThreshold, "numLineThreshold");
            this.numLineThreshold.Name = "numLineThreshold";
            this.numLineThreshold.ShowText = false;
            this.numLineThreshold.Step = 1D;
            this.numLineThreshold.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numLineThreshold.Value = 10D;
            // 
            // uiLabel11
            // 
            resources.ApplyResources(this.uiLabel11, "uiLabel11");
            this.uiLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel11.Name = "uiLabel11";
            // 
            // numLineWidth
            // 
            this.numLineWidth.DecimalPlaces = 0;
            resources.ApplyResources(this.numLineWidth, "numLineWidth");
            this.numLineWidth.Name = "numLineWidth";
            this.numLineWidth.ShowText = false;
            this.numLineWidth.Step = 1D;
            this.numLineWidth.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numLineWidth.Value = 10D;
            // 
            // uiLabel12
            // 
            resources.ApplyResources(this.uiLabel12, "uiLabel12");
            this.uiLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel12.Name = "uiLabel12";
            // 
            // numLineTall
            // 
            this.numLineTall.DecimalPlaces = 0;
            resources.ApplyResources(this.numLineTall, "numLineTall");
            this.numLineTall.Name = "numLineTall";
            this.numLineTall.ShowText = false;
            this.numLineTall.Step = 1D;
            this.numLineTall.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numLineTall.Value = 10D;
            // 
            // btnWriteLineROI
            // 
            this.btnWriteLineROI.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnWriteLineROI, "btnWriteLineROI");
            this.btnWriteLineROI.Name = "btnWriteLineROI";
            this.btnWriteLineROI.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWriteLineROI.Click += new System.EventHandler(this.btnWriteLineROI_Click);
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.uiTabControl1, "uiTabControl1");
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnMeanImage);
            this.tabPage1.Controls.Add(this.uiLabel13);
            this.tabPage1.Controls.Add(this.btnMedianFilter);
            this.tabPage1.Controls.Add(this.btnGaussFilter);
            this.tabPage1.Controls.Add(this.numCoefficient);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnequ_histo);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnequ_histo
            // 
            this.btnequ_histo.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnequ_histo, "btnequ_histo");
            this.btnequ_histo.Name = "btnequ_histo";
            this.btnequ_histo.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnGaussFilter
            // 
            this.btnGaussFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnGaussFilter, "btnGaussFilter");
            this.btnGaussFilter.Name = "btnGaussFilter";
            this.btnGaussFilter.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGaussFilter.Click += new System.EventHandler(this.btnGaussFilter_Click);
            // 
            // uiLabel13
            // 
            resources.ApplyResources(this.uiLabel13, "uiLabel13");
            this.uiLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel13.Name = "uiLabel13";
            // 
            // numCoefficient
            // 
            this.numCoefficient.DecimalPlaces = 0;
            resources.ApplyResources(this.numCoefficient, "numCoefficient");
            this.numCoefficient.Name = "numCoefficient";
            this.numCoefficient.ShowText = false;
            this.numCoefficient.Step = 1D;
            this.numCoefficient.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numCoefficient.Value = 3D;
            // 
            // btnMedianFilter
            // 
            this.btnMedianFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnMedianFilter, "btnMedianFilter");
            this.btnMedianFilter.Name = "btnMedianFilter";
            this.btnMedianFilter.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMedianFilter.Click += new System.EventHandler(this.btnMedianFilter_Click);
            // 
            // btnMeanImage
            // 
            this.btnMeanImage.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnMeanImage, "btnMeanImage");
            this.btnMeanImage.Name = "btnMeanImage";
            this.btnMeanImage.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMeanImage.Click += new System.EventHandler(this.btnMeanImage_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnBinaryThreshold);
            this.tabPage3.Controls.Add(this.btnThredshold);
            this.tabPage3.Controls.Add(this.uiLabel14);
            this.tabPage3.Controls.Add(this.numMaxThreshold);
            this.tabPage3.Controls.Add(this.uiLabel15);
            this.tabPage3.Controls.Add(this.numMinThreshold);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uiLabel14
            // 
            resources.ApplyResources(this.uiLabel14, "uiLabel14");
            this.uiLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel14.Name = "uiLabel14";
            // 
            // numMaxThreshold
            // 
            this.numMaxThreshold.DecimalPlaces = 0;
            resources.ApplyResources(this.numMaxThreshold, "numMaxThreshold");
            this.numMaxThreshold.Name = "numMaxThreshold";
            this.numMaxThreshold.ShowText = false;
            this.numMaxThreshold.Step = 1D;
            this.numMaxThreshold.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numMaxThreshold.Value = 200D;
            // 
            // uiLabel15
            // 
            resources.ApplyResources(this.uiLabel15, "uiLabel15");
            this.uiLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel15.Name = "uiLabel15";
            // 
            // numMinThreshold
            // 
            this.numMinThreshold.DecimalPlaces = 0;
            resources.ApplyResources(this.numMinThreshold, "numMinThreshold");
            this.numMinThreshold.Name = "numMinThreshold";
            this.numMinThreshold.ShowText = false;
            this.numMinThreshold.Step = 1D;
            this.numMinThreshold.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numMinThreshold.Value = 100D;
            // 
            // btnThredshold
            // 
            this.btnThredshold.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnThredshold, "btnThredshold");
            this.btnThredshold.Name = "btnThredshold";
            this.btnThredshold.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnThredshold.Click += new System.EventHandler(this.btnThredshold_Click);
            // 
            // imageContorl1
            // 
            resources.ApplyResources(this.imageContorl1, "imageContorl1");
            this.imageContorl1.Name = "imageContorl1";
            // 
            // btnBinaryThreshold
            // 
            this.btnBinaryThreshold.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnBinaryThreshold, "btnBinaryThreshold");
            this.btnBinaryThreshold.Name = "btnBinaryThreshold";
            this.btnBinaryThreshold.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBinaryThreshold.Click += new System.EventHandler(this.btnBinaryThreshold_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uiGroupBox4);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.btnSaveModel);
            this.Controls.Add(this.btnFindModel);
            this.Controls.Add(this.btnCreateModel);
            this.Controls.Add(this.btnDrawRoi);
            this.Controls.Add(this.btnFitWindow);
            this.Controls.Add(this.imageContorl1);
            this.Controls.Add(this.uibtnTest);
            this.Name = "Form1";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox4.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton uibtnTest;
        private ImageContorl imageContorl1;
        private Sunny.UI.UIButton btnFitWindow;
        private Sunny.UI.UIButton btnDrawRoi;
        private Sunny.UI.UIButton btnCreateModel;
        private Sunny.UI.UIButton btnFindModel;
        private Sunny.UI.UIButton btnSaveModel;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIButton btnFindCircle;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UIDoubleUpDown numCircleTall;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIDoubleUpDown numCircleWidth;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIDoubleUpDown numThreshold;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIDoubleUpDown numDis;
        private Sunny.UI.UIButton btnMeaCircle;
        private Sunny.UI.UIComboBox cmbMode;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIComboBox cmbCircleFilter;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIGroupBox uiGroupBox4;
        private Sunny.UI.UIComboBox cmbLineFilter;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIComboBox cmbLineMode;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UIButton btnMeaLine;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIDoubleUpDown numLineDis;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UIDoubleUpDown numLineThreshold;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UIDoubleUpDown numLineWidth;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UIDoubleUpDown numLineTall;
        private Sunny.UI.UIButton btnWriteLineROI;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UIButton btnGaussFilter;
        private Sunny.UI.UIDoubleUpDown numCoefficient;
        private Sunny.UI.UIButton btnequ_histo;
        private Sunny.UI.UIButton btnMedianFilter;
        private Sunny.UI.UIButton btnMeanImage;
        private System.Windows.Forms.TabPage tabPage3;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UIDoubleUpDown numMaxThreshold;
        private Sunny.UI.UILabel uiLabel15;
        private Sunny.UI.UIDoubleUpDown numMinThreshold;
        private Sunny.UI.UIButton btnThredshold;
        private Sunny.UI.UIButton btnBinaryThreshold;
    }
}

