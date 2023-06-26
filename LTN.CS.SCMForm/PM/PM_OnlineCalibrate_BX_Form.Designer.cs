namespace LTN.CS.SCMForm.PM
{
    partial class PM_OnlineCalibrate_BX_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.txt_PondNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCol_I_IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_POND_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_MAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_STANDARDWEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATEWEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_WEIGHT_DEVIATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_query = new LTN.CS.Core.Helper.GToolStripButton();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_export = new LTN.CS.Core.Helper.GToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PondNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1152, 52);
            this.panelControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.date_EndTime);
            this.layoutControl1.Controls.Add(this.date_StartTime);
            this.layoutControl1.Controls.Add(this.txt_PondNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(1);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1148, 48);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = null;
            this.date_EndTime.Location = new System.Drawing.Point(322, 12);
            this.date_EndTime.Margin = new System.Windows.Forms.Padding(1);
            this.date_EndTime.Name = "date_EndTime";
            this.date_EndTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.date_EndTime.Properties.Appearance.Options.UseFont = true;
            this.date_EndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Size = new System.Drawing.Size(182, 26);
            this.date_EndTime.StyleController = this.layoutControl1;
            this.date_EndTime.TabIndex = 2;
            // 
            // date_StartTime
            // 
            this.date_StartTime.EditValue = null;
            this.date_StartTime.Location = new System.Drawing.Point(80, 12);
            this.date_StartTime.Margin = new System.Windows.Forms.Padding(1);
            this.date_StartTime.Name = "date_StartTime";
            this.date_StartTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.date_StartTime.Properties.Appearance.Options.UseFont = true;
            this.date_StartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Size = new System.Drawing.Size(170, 26);
            this.date_StartTime.StyleController = this.layoutControl1;
            this.date_StartTime.TabIndex = 0;
            // 
            // txt_PondNo
            // 
            this.txt_PondNo.Location = new System.Drawing.Point(576, 12);
            this.txt_PondNo.Margin = new System.Windows.Forms.Padding(1);
            this.txt_PondNo.Name = "txt_PondNo";
            this.txt_PondNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_PondNo.Properties.Appearance.Options.UseFont = true;
            this.txt_PondNo.Size = new System.Drawing.Size(103, 26);
            this.txt_PondNo.StyleController = this.layoutControl1;
            this.txt_PondNo.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1131, 50);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txt_PondNo;
            this.layoutControlItem3.Location = new System.Drawing.Point(496, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(175, 30);
            this.layoutControlItem3.Text = "磅号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.date_StartTime;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(242, 30);
            this.layoutControlItem4.Text = "开始时间";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.date_EndTime;
            this.layoutControlItem5.Location = new System.Drawing.Point(242, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(254, 30);
            this.layoutControlItem5.Text = "结束时间";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(64, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(671, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(440, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.gcl_main.Location = new System.Drawing.Point(0, 90);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(1);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(1152, 428);
            this.gcl_main.TabIndex = 2;
            this.gcl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvw_main.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_main.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvw_main.Appearance.Row.Options.UseFont = true;
            this.gvw_main.Appearance.Row.Options.UseTextOptions = true;
            this.gvw_main.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvw_main.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvw_main.Appearance.ViewCaption.Options.UseFont = true;
            this.gvw_main.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gvw_main.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCol_I_IntId,
            this.T_CALIBRATE_NO,
            this.T_POND_NO,
            this.T_CALIBRATE_TIME,
            this.T_CALIBRATE_MAN,
            this.T_STANDARDWEIGHT,
            this.T_CALIBRATEWEIGHT,
            this.T_WEIGHT_DEVIATION});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            // 
            // gCol_I_IntId
            // 
            this.gCol_I_IntId.Caption = "主键";
            this.gCol_I_IntId.FieldName = "i_intId";
            this.gCol_I_IntId.Name = "gCol_I_IntId";
            // 
            // T_CALIBRATE_NO
            // 
            this.T_CALIBRATE_NO.Caption = "校准记录编号";
            this.T_CALIBRATE_NO.FieldName = "t_calibrate_no";
            this.T_CALIBRATE_NO.Name = "T_CALIBRATE_NO";
            this.T_CALIBRATE_NO.Visible = true;
            this.T_CALIBRATE_NO.VisibleIndex = 0;
            this.T_CALIBRATE_NO.Width = 330;
            // 
            // T_POND_NO
            // 
            this.T_POND_NO.Caption = "磅号";
            this.T_POND_NO.FieldName = "t_pond_no";
            this.T_POND_NO.Name = "T_POND_NO";
            this.T_POND_NO.Visible = true;
            this.T_POND_NO.VisibleIndex = 1;
            this.T_POND_NO.Width = 100;
            // 
            // T_CALIBRATE_TIME
            // 
            this.T_CALIBRATE_TIME.Caption = "校准时间";
            this.T_CALIBRATE_TIME.FieldName = "t_calibrate_time";
            this.T_CALIBRATE_TIME.Name = "T_CALIBRATE_TIME";
            this.T_CALIBRATE_TIME.Visible = true;
            this.T_CALIBRATE_TIME.VisibleIndex = 2;
            this.T_CALIBRATE_TIME.Width = 175;
            // 
            // T_CALIBRATE_MAN
            // 
            this.T_CALIBRATE_MAN.Caption = "校准人员";
            this.T_CALIBRATE_MAN.FieldName = "t_calibrate_man";
            this.T_CALIBRATE_MAN.Name = "T_CALIBRATE_MAN";
            this.T_CALIBRATE_MAN.Visible = true;
            this.T_CALIBRATE_MAN.VisibleIndex = 3;
            this.T_CALIBRATE_MAN.Width = 100;
            // 
            // T_STANDARDWEIGHT
            // 
            this.T_STANDARDWEIGHT.Caption = "标准重量（kg）";
            this.T_STANDARDWEIGHT.FieldName = "t_standardWeight";
            this.T_STANDARDWEIGHT.Name = "T_STANDARDWEIGHT";
            this.T_STANDARDWEIGHT.Visible = true;
            this.T_STANDARDWEIGHT.VisibleIndex = 4;
            this.T_STANDARDWEIGHT.Width = 130;
            // 
            // T_CALIBRATEWEIGHT
            // 
            this.T_CALIBRATEWEIGHT.Caption = "对磅实际重量（kg）";
            this.T_CALIBRATEWEIGHT.FieldName = "t_calibrateWeight";
            this.T_CALIBRATEWEIGHT.Name = "T_CALIBRATEWEIGHT";
            this.T_CALIBRATEWEIGHT.Visible = true;
            this.T_CALIBRATEWEIGHT.VisibleIndex = 5;
            this.T_CALIBRATEWEIGHT.Width = 170;
            // 
            // T_WEIGHT_DEVIATION
            // 
            this.T_WEIGHT_DEVIATION.Caption = "偏差（kg）";
            this.T_WEIGHT_DEVIATION.FieldName = "t_weight_deviation";
            this.T_WEIGHT_DEVIATION.Name = "T_WEIGHT_DEVIATION";
            this.T_WEIGHT_DEVIATION.Visible = true;
            this.T_WEIGHT_DEVIATION.VisibleIndex = 6;
            this.T_WEIGHT_DEVIATION.Width = 100;
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_query.Image = global::LTN.CS.SCMForm.Properties.Resources.Query1_32;
            this.btn_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(65, 35);
            this.btn_query.Text = "查询";
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_query,
            this.btn_export});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 52);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1152, 38);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_export
            // 
            this.btn_export.Image = global::LTN.CS.SCMForm.Properties.Resources.Excel_32;
            this.btn_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(60, 35);
            this.btn_export.Text = "导出";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // PM_OnlineCalibrate_BX_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 518);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PM_OnlineCalibrate_BX_Form";
            this.ShowIcon = false;
            this.Text = "棒线在线秤校磅记录";
            this.Shown += new System.EventHandler(this.PM_OnlineCalibrate_BX_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PondNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_PondNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_IntId;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn T_POND_NO;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_MAN;
        private DevExpress.XtraGrid.Columns.GridColumn T_STANDARDWEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATEWEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn T_WEIGHT_DEVIATION;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Core.Helper.GToolStripButton btn_query;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_export;
    }
}