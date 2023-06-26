namespace LTN.CS.SCMForm.SM
{
    partial class SM_BeltNumber_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SM_BeltNumber_Form));
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Beltno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Beltname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BITNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BeltFINo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BeltVINo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateMember = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateMember = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_insert = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_confirm = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_BitNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_BeltName = new DevExpress.XtraEditors.TextEdit();
            this.txt_BeltNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_BeltFINo = new DevExpress.XtraEditors.TextEdit();
            this.txt_BeltVINo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BitNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltFINo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltVINo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcl_main.Location = new System.Drawing.Point(0, 136);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(4);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(818, 489);
            this.gcl_main.TabIndex = 34;
            this.gcl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.GroupFooter.Options.UseFont = true;
            this.gvw_main.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_main.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvw_main.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvw_main.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.Row.Options.UseFont = true;
            this.gvw_main.Appearance.Row.Options.UseTextOptions = true;
            this.gvw_main.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvw_main.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.ViewCaption.Options.UseFont = true;
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.Beltno,
            this.Beltname,
            this.BITNO,
            this.BeltFINo,
            this.BeltVINo,
            this.CreateTime,
            this.CreateMember,
            this.UpdateTime,
            this.UpdateMember});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsCustomization.AllowFilter = false;
            this.gvw_main.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvw_main.OptionsSelection.MultiSelect = true;
            this.gvw_main.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowFooter = true;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.OptionsView.ShowViewCaption = true;
            this.gvw_main.ViewCaption = "皮带位号配置信息";
            this.gvw_main.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvw_main_FocusedRowChanged);
            // 
            // id
            // 
            this.id.Caption = "皮带Id";
            this.id.FieldName = "BeltId.I_Intid";
            this.id.Name = "id";
            // 
            // Beltno
            // 
            this.Beltno.Caption = "皮带编号";
            this.Beltno.FieldName = "BeltId.C_Beltno";
            this.Beltno.Name = "Beltno";
            this.Beltno.OptionsColumn.AllowEdit = false;
            this.Beltno.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "realcarrierno", "{0}")});
            this.Beltno.Visible = true;
            this.Beltno.VisibleIndex = 1;
            this.Beltno.Width = 117;
            // 
            // Beltname
            // 
            this.Beltname.Caption = "皮带名称";
            this.Beltname.FieldName = "BeltId.C_Beltname";
            this.Beltname.Name = "Beltname";
            this.Beltname.Visible = true;
            this.Beltname.VisibleIndex = 2;
            this.Beltname.Width = 200;
            // 
            // BITNO
            // 
            this.BITNO.Caption = "累积量位号";
            this.BITNO.FieldName = "BITNO";
            this.BITNO.Name = "BITNO";
            this.BITNO.Visible = true;
            this.BITNO.VisibleIndex = 3;
            this.BITNO.Width = 130;
            // 
            // BeltFINo
            // 
            this.BeltFINo.Caption = "瞬时位号";
            this.BeltFINo.FieldName = "C_BeltFINo";
            this.BeltFINo.Name = "BeltFINo";
            this.BeltFINo.Visible = true;
            this.BeltFINo.VisibleIndex = 4;
            this.BeltFINo.Width = 130;
            // 
            // BeltVINo
            // 
            this.BeltVINo.Caption = "速度位号";
            this.BeltVINo.FieldName = "C_BeltVINo";
            this.BeltVINo.Name = "BeltVINo";
            this.BeltVINo.Visible = true;
            this.BeltVINo.VisibleIndex = 5;
            this.BeltVINo.Width = 130;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "创建时间";
            this.CreateTime.FieldName = "C_CreateTime";
            this.CreateTime.GroupFormat.FormatString = "G";
            this.CreateTime.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 6;
            this.CreateTime.Width = 200;
            // 
            // CreateMember
            // 
            this.CreateMember.Caption = "创建人员";
            this.CreateMember.FieldName = "C_CreateUserName";
            this.CreateMember.Name = "CreateMember";
            this.CreateMember.Visible = true;
            this.CreateMember.VisibleIndex = 7;
            this.CreateMember.Width = 100;
            // 
            // UpdateTime
            // 
            this.UpdateTime.Caption = "修改时间";
            this.UpdateTime.FieldName = "C_UpdateTime";
            this.UpdateTime.GroupFormat.FormatString = "G";
            this.UpdateTime.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.Visible = true;
            this.UpdateTime.VisibleIndex = 8;
            this.UpdateTime.Width = 110;
            // 
            // UpdateMember
            // 
            this.UpdateMember.Caption = "修改人员";
            this.UpdateMember.FieldName = "C_UpdateUserName";
            this.UpdateMember.Name = "UpdateMember";
            this.UpdateMember.Visible = true;
            this.UpdateMember.VisibleIndex = 9;
            this.UpdateMember.Width = 110;
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_insert,
            this.btn_update,
            this.btn_delete,
            this.btn_confirm,
            this.btn_cancel});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 98);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(818, 38);
            this.gToolStrip1.TabIndex = 35;
            this.gToolStrip1.Text = "gToolStrip3";
            // 
            // btn_insert
            // 
            this.btn_insert.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_insert.Image = ((System.Drawing.Image)(resources.GetObject("btn_insert.Image")));
            this.btn_insert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(61, 35);
            this.btn_insert.Text = "新增";
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_update.Image = ((System.Drawing.Image)(resources.GetObject("btn_update.Image")));
            this.btn_update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(61, 35);
            this.btn_update.Text = "修改";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.Image")));
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(61, 35);
            this.btn_delete.Text = "删除";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_confirm.Image")));
            this.btn_confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(61, 35);
            this.btn_confirm.Text = "确认";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.Image")));
            this.btn_cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(61, 35);
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(818, 98);
            this.panelControl1.TabIndex = 33;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(814, 94);
            this.groupControl2.TabIndex = 27;
            this.groupControl2.Text = "数据操作";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_BitNo);
            this.layoutControl1.Controls.Add(this.txt_BeltName);
            this.layoutControl1.Controls.Add(this.txt_BeltNo);
            this.layoutControl1.Controls.Add(this.txt_BeltFINo);
            this.layoutControl1.Controls.Add(this.txt_BeltVINo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 28);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(243, 334, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(810, 64);
            this.layoutControl1.TabIndex = 22;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_BitNo
            // 
            this.txt_BitNo.Location = new System.Drawing.Point(611, 12);
            this.txt_BitNo.Name = "txt_BitNo";
            this.txt_BitNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_BitNo.Properties.Appearance.Options.UseFont = true;
            this.txt_BitNo.Size = new System.Drawing.Size(170, 26);
            this.txt_BitNo.StyleController = this.layoutControl1;
            this.txt_BitNo.TabIndex = 25;
            // 
            // txt_BeltName
            // 
            this.txt_BeltName.Location = new System.Drawing.Point(352, 12);
            this.txt_BeltName.Name = "txt_BeltName";
            this.txt_BeltName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_BeltName.Properties.Appearance.Options.UseFont = true;
            this.txt_BeltName.Size = new System.Drawing.Size(172, 26);
            this.txt_BeltName.StyleController = this.layoutControl1;
            this.txt_BeltName.TabIndex = 24;
            // 
            // txt_BeltNo
            // 
            this.txt_BeltNo.Location = new System.Drawing.Point(95, 12);
            this.txt_BeltNo.Name = "txt_BeltNo";
            this.txt_BeltNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_BeltNo.Properties.Appearance.Options.UseFont = true;
            this.txt_BeltNo.Size = new System.Drawing.Size(170, 26);
            this.txt_BeltNo.StyleController = this.layoutControl1;
            this.txt_BeltNo.TabIndex = 23;
            // 
            // txt_BeltFINo
            // 
            this.txt_BeltFINo.Location = new System.Drawing.Point(95, 42);
            this.txt_BeltFINo.Name = "txt_BeltFINo";
            this.txt_BeltFINo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_BeltFINo.Properties.Appearance.Options.UseFont = true;
            this.txt_BeltFINo.Size = new System.Drawing.Size(170, 26);
            this.txt_BeltFINo.StyleController = this.layoutControl1;
            this.txt_BeltFINo.TabIndex = 26;
            // 
            // txt_BeltVINo
            // 
            this.txt_BeltVINo.Location = new System.Drawing.Point(352, 42);
            this.txt_BeltVINo.Name = "txt_BeltVINo";
            this.txt_BeltVINo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_BeltVINo.Properties.Appearance.Options.UseFont = true;
            this.txt_BeltVINo.Size = new System.Drawing.Size(172, 26);
            this.txt_BeltVINo.StyleController = this.layoutControl1;
            this.txt_BeltVINo.TabIndex = 27;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(793, 90);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txt_BeltNo;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(257, 30);
            this.layoutControlItem3.Text = "皮带编号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 19);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_BeltName;
            this.layoutControlItem1.Location = new System.Drawing.Point(257, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(259, 30);
            this.layoutControlItem1.Text = "皮带名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_BitNo;
            this.layoutControlItem2.Location = new System.Drawing.Point(516, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(257, 60);
            this.layoutControlItem2.Text = "累计量位号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 60);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(773, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txt_BeltFINo;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(137, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(257, 30);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "瞬时位号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(80, 19);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txt_BeltVINo;
            this.layoutControlItem5.Location = new System.Drawing.Point(257, 30);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(137, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(259, 30);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "速度位号";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(80, 19);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // SM_BeltNumber_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 625);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Name = "SM_BeltNumber_Form";
            this.Text = "皮带位号配置";
            this.Shown += new System.EventHandler(this.SM_BeltNumber_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_BitNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltFINo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltVINo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn Beltno;
        private DevExpress.XtraGrid.Columns.GridColumn Beltname;
        private DevExpress.XtraGrid.Columns.GridColumn BITNO;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn CreateMember;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateMember;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_insert;
        private Core.Helper.GToolStripButton btn_update;
        private Core.Helper.GToolStripButton btn_delete;
        private Core.Helper.GToolStripButton btn_confirm;
        private Core.Helper.GToolStripButton btn_cancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_BeltNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txt_BitNo;
        private DevExpress.XtraEditors.TextEdit txt_BeltName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn BeltFINo;
        private DevExpress.XtraGrid.Columns.GridColumn BeltVINo;
        private DevExpress.XtraEditors.TextEdit txt_BeltFINo;
        private DevExpress.XtraEditors.TextEdit txt_BeltVINo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}