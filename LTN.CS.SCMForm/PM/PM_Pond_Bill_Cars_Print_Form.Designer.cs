namespace LTN.CS.SCMForm.PM
{
    partial class PM_Pond_Bill_Cars_Print_Form
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCol_I_INTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_WGTLISTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_CARNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_MATERIALNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_PLANNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.开始时间 = new DevExpress.XtraLayout.LayoutControlItem();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_CarName = new DevExpress.XtraEditors.TextEdit();
            this.txt_PlanNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_MaterialName = new DevExpress.XtraEditors.TextEdit();
            this.txt_WgtlistNo = new DevExpress.XtraEditors.TextEdit();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.车号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.委托单号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.品名 = new DevExpress.XtraLayout.LayoutControlItem();
            this.磅单号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.结束时间 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.gToolStripButton1 = new LTN.CS.Core.Helper.GToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.开始时间)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaterialName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WgtlistNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.车号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.委托单号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.品名)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.磅单号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.结束时间)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 140);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1137, 314);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Load += new System.EventHandler(this.gridControl1_Load);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.FixedLine.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Honeydew;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("宋体", 9F);
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("宋体", 12F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCol_I_INTID,
            this.gCol_C_WGTLISTNO,
            this.gCol_C_CARNAME,
            this.gCol_C_MATERIALNAME,
            this.gridColumn3,
            this.gCol_C_PLANNO,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = " ";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gCol_I_INTID
            // 
            this.gCol_I_INTID.Caption = "主键";
            this.gCol_I_INTID.FieldName = "IntId";
            this.gCol_I_INTID.Name = "gCol_I_INTID";
            // 
            // gCol_C_WGTLISTNO
            // 
            this.gCol_C_WGTLISTNO.Caption = "磅单号";
            this.gCol_C_WGTLISTNO.FieldName = "WgtlistNo";
            this.gCol_C_WGTLISTNO.Name = "gCol_C_WGTLISTNO";
            this.gCol_C_WGTLISTNO.Visible = true;
            this.gCol_C_WGTLISTNO.VisibleIndex = 1;
            this.gCol_C_WGTLISTNO.Width = 182;
            // 
            // gCol_C_CARNAME
            // 
            this.gCol_C_CARNAME.Caption = "车牌号";
            this.gCol_C_CARNAME.FieldName = "CarName";
            this.gCol_C_CARNAME.Name = "gCol_C_CARNAME";
            this.gCol_C_CARNAME.Visible = true;
            this.gCol_C_CARNAME.VisibleIndex = 3;
            this.gCol_C_CARNAME.Width = 139;
            // 
            // gCol_C_MATERIALNAME
            // 
            this.gCol_C_MATERIALNAME.Caption = "品名";
            this.gCol_C_MATERIALNAME.FieldName = "MaterialName";
            this.gCol_C_MATERIALNAME.Name = "gCol_C_MATERIALNAME";
            this.gCol_C_MATERIALNAME.Visible = true;
            this.gCol_C_MATERIALNAME.VisibleIndex = 4;
            this.gCol_C_MATERIALNAME.Width = 171;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "打印次数";
            this.gridColumn3.FieldName = "PrintNum";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            this.gridColumn3.Width = 85;
            // 
            // gCol_C_PLANNO
            // 
            this.gCol_C_PLANNO.Caption = "委托单号";
            this.gCol_C_PLANNO.FieldName = "PlanNo";
            this.gCol_C_PLANNO.Name = "gCol_C_PLANNO";
            this.gCol_C_PLANNO.Visible = true;
            this.gCol_C_PLANNO.VisibleIndex = 2;
            this.gCol_C_PLANNO.Width = 217;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "打印人";
            this.gridColumn12.FieldName = "Printer";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 5;
            this.gridColumn12.Width = 109;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "打印时间";
            this.gridColumn13.FieldName = "PrintTime";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 6;
            this.gridColumn13.Width = 171;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "打印ip";
            this.gridColumn1.FieldName = "ComputerIp";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 144;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Root1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1120, 100);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // Root1
            // 
            this.Root1.CustomizationFormText = "Root";
            this.Root1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root1.GroupBordersVisible = false;
            this.Root1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.开始时间,
            this.车号,
            this.委托单号,
            this.品名,
            this.磅单号,
            this.结束时间});
            this.Root1.Location = new System.Drawing.Point(0, 0);
            this.Root1.Name = "Root1";
            this.Root1.Size = new System.Drawing.Size(1100, 80);
            this.Root1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root1.Text = "Root";
            this.Root1.TextVisible = false;
            // 
            // 开始时间
            // 
            this.开始时间.Control = this.date_StartTime;
            this.开始时间.CustomizationFormText = "开始时间";
            this.开始时间.Location = new System.Drawing.Point(686, 0);
            this.开始时间.Name = "开始时间";
            this.开始时间.Size = new System.Drawing.Size(394, 30);
            this.开始时间.TextSize = new System.Drawing.Size(64, 19);
            // 
            // date_StartTime
            // 
            this.date_StartTime.EditValue = null;
            this.date_StartTime.Location = new System.Drawing.Point(775, 22);
            this.date_StartTime.Margin = new System.Windows.Forms.Padding(4);
            this.date_StartTime.Name = "date_StartTime";
            this.date_StartTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.date_StartTime.Properties.Appearance.Options.UseFont = true;
            this.date_StartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.DisplayFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.date_StartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.EditFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.date_StartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Size = new System.Drawing.Size(323, 26);
            this.date_StartTime.StyleController = this.layoutControl1;
            this.date_StartTime.TabIndex = 10;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.date_StartTime);
            this.layoutControl1.Controls.Add(this.txt_CarName);
            this.layoutControl1.Controls.Add(this.txt_PlanNo);
            this.layoutControl1.Controls.Add(this.txt_MaterialName);
            this.layoutControl1.Controls.Add(this.txt_WgtlistNo);
            this.layoutControl1.Controls.Add(this.date_EndTime);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(30, 157, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1137, 92);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_CarName
            // 
            this.txt_CarName.Location = new System.Drawing.Point(89, 52);
            this.txt_CarName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CarName.Name = "txt_CarName";
            this.txt_CarName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_CarName.Properties.Appearance.Options.UseFont = true;
            this.txt_CarName.Size = new System.Drawing.Size(246, 26);
            this.txt_CarName.StyleController = this.layoutControl1;
            this.txt_CarName.TabIndex = 6;
            // 
            // txt_PlanNo
            // 
            this.txt_PlanNo.Location = new System.Drawing.Point(406, 22);
            this.txt_PlanNo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PlanNo.Name = "txt_PlanNo";
            this.txt_PlanNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_PlanNo.Properties.Appearance.Options.UseFont = true;
            this.txt_PlanNo.Size = new System.Drawing.Size(298, 26);
            this.txt_PlanNo.StyleController = this.layoutControl1;
            this.txt_PlanNo.TabIndex = 8;
            // 
            // txt_MaterialName
            // 
            this.txt_MaterialName.Location = new System.Drawing.Point(89, 22);
            this.txt_MaterialName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaterialName.Name = "txt_MaterialName";
            this.txt_MaterialName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_MaterialName.Properties.Appearance.Options.UseFont = true;
            this.txt_MaterialName.Size = new System.Drawing.Size(246, 26);
            this.txt_MaterialName.StyleController = this.layoutControl1;
            this.txt_MaterialName.TabIndex = 7;
            // 
            // txt_WgtlistNo
            // 
            this.txt_WgtlistNo.Location = new System.Drawing.Point(406, 52);
            this.txt_WgtlistNo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_WgtlistNo.Name = "txt_WgtlistNo";
            this.txt_WgtlistNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_WgtlistNo.Properties.Appearance.Options.UseFont = true;
            this.txt_WgtlistNo.Size = new System.Drawing.Size(298, 26);
            this.txt_WgtlistNo.StyleController = this.layoutControl1;
            this.txt_WgtlistNo.TabIndex = 9;
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = null;
            this.date_EndTime.Location = new System.Drawing.Point(775, 52);
            this.date_EndTime.Margin = new System.Windows.Forms.Padding(4);
            this.date_EndTime.Name = "date_EndTime";
            this.date_EndTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.date_EndTime.Properties.Appearance.Options.UseFont = true;
            this.date_EndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.DisplayFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.date_EndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.EditFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.date_EndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Size = new System.Drawing.Size(323, 26);
            this.date_EndTime.StyleController = this.layoutControl1;
            this.date_EndTime.TabIndex = 11;
            // 
            // 车号
            // 
            this.车号.Control = this.txt_CarName;
            this.车号.CustomizationFormText = "车号";
            this.车号.Location = new System.Drawing.Point(0, 30);
            this.车号.Name = "车号";
            this.车号.Size = new System.Drawing.Size(317, 30);
            this.车号.TextSize = new System.Drawing.Size(64, 19);
            // 
            // 委托单号
            // 
            this.委托单号.Control = this.txt_PlanNo;
            this.委托单号.CustomizationFormText = "委托单号";
            this.委托单号.Location = new System.Drawing.Point(317, 0);
            this.委托单号.Name = "委托单号";
            this.委托单号.Size = new System.Drawing.Size(369, 30);
            this.委托单号.TextSize = new System.Drawing.Size(64, 19);
            // 
            // 品名
            // 
            this.品名.Control = this.txt_MaterialName;
            this.品名.CustomizationFormText = "品名";
            this.品名.Location = new System.Drawing.Point(0, 0);
            this.品名.Name = "品名";
            this.品名.Size = new System.Drawing.Size(317, 30);
            this.品名.TextSize = new System.Drawing.Size(64, 19);
            // 
            // 磅单号
            // 
            this.磅单号.Control = this.txt_WgtlistNo;
            this.磅单号.CustomizationFormText = "磅单号";
            this.磅单号.Location = new System.Drawing.Point(317, 30);
            this.磅单号.Name = "磅单号";
            this.磅单号.Size = new System.Drawing.Size(369, 30);
            this.磅单号.TextSize = new System.Drawing.Size(64, 19);
            // 
            // 结束时间
            // 
            this.结束时间.Control = this.date_EndTime;
            this.结束时间.CustomizationFormText = "结束时间";
            this.结束时间.Location = new System.Drawing.Point(686, 30);
            this.结束时间.Name = "结束时间";
            this.结束时间.Size = new System.Drawing.Size(394, 30);
            this.结束时间.TextSize = new System.Drawing.Size(64, 19);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gToolStripButton1});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 92);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1137, 48);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // gToolStripButton1
            // 
            this.gToolStripButton1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gToolStripButton1.Image = global::LTN.CS.SCMForm.Properties.Resources.Query_24;
            this.gToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gToolStripButton1.Name = "gToolStripButton1";
            this.gToolStripButton1.Size = new System.Drawing.Size(68, 45);
            this.gToolStripButton1.Text = "查询";
            this.gToolStripButton1.ToolTipText = "查询";
            this.gToolStripButton1.Click += new System.EventHandler(this.gToolStripButton1_Click);
            // 
            // PM_Pond_Bill_Cars_Print_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 454);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "PM_Pond_Bill_Cars_Print_Form";
            this.Text = "汽车磅单打印记录";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.开始时间)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaterialName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WgtlistNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.车号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.委托单号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.品名)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.磅单号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.结束时间)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup Root1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private DevExpress.XtraEditors.TextEdit txt_CarName;
        private DevExpress.XtraEditors.TextEdit txt_PlanNo;
        private DevExpress.XtraEditors.TextEdit txt_MaterialName;
        private DevExpress.XtraEditors.TextEdit txt_WgtlistNo;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraLayout.LayoutControlItem 开始时间;
        private DevExpress.XtraLayout.LayoutControlItem 车号;
        private DevExpress.XtraLayout.LayoutControlItem 委托单号;
        private DevExpress.XtraLayout.LayoutControlItem 品名;
        private DevExpress.XtraLayout.LayoutControlItem 磅单号;
        private DevExpress.XtraLayout.LayoutControlItem 结束时间;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_INTID;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_WGTLISTNO;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_CARNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_MATERIALNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_PLANNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton gToolStripButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}