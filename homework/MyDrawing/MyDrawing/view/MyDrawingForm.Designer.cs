using MyDrawing.view;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace MyDrawing
{
    partial class MyDrawingForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyDrawingForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.desciptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSelectionPanel = new System.Windows.Forms.Panel();
            this.displayDrawingDataGridView = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.w = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addDrawingButton = new System.Windows.Forms.Button();
            this.manageDrawingDataGroupBox = new System.Windows.Forms.GroupBox();
            this.wLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.hLabel = new System.Windows.Forms.Label();
            this.shapeLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.shapeComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.terminatorButton = new System.Windows.Forms.ToolStripButton();
            this.decisionButton = new System.Windows.Forms.ToolStripButton();
            this.processButton = new System.Windows.Forms.ToolStripButton();
            this.pointerButton = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.loadButton = new System.Windows.Forms.ToolStripButton();
            this.drawAreaPanel = new MyDrawing.view.DoubleBufferedPanel();
            this.formLabel = new System.Windows.Forms.Label();
            this.anchorLabel = new System.Windows.Forms.Label();
            this.textPositionLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayDrawingDataGridView)).BeginInit();
            this.manageDrawingDataGroupBox.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.drawAreaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desciptionToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1268, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // desciptionToolStripMenuItem
            // 
            this.desciptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.desciptionToolStripMenuItem.Name = "desciptionToolStripMenuItem";
            this.desciptionToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.desciptionToolStripMenuItem.Text = "說明";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.aboutToolStripMenuItem.Text = "關於";
            // 
            // pageSelectionPanel
            // 
            this.pageSelectionPanel.AutoScroll = true;
            this.pageSelectionPanel.AutoScrollMargin = new System.Drawing.Size(0, 5);
            this.pageSelectionPanel.AutoScrollMinSize = new System.Drawing.Size(10, 720);
            this.pageSelectionPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pageSelectionPanel.Location = new System.Drawing.Point(0, 52);
            this.pageSelectionPanel.Name = "pageSelectionPanel";
            this.pageSelectionPanel.Size = new System.Drawing.Size(150, 618);
            this.pageSelectionPanel.TabIndex = 1;
            // 
            // displayDrawingDataGridView
            // 
            this.displayDrawingDataGridView.AllowUserToAddRows = false;
            this.displayDrawingDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.displayDrawingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayDrawingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deleteButton,
            this.id,
            this.shape,
            this.note,
            this.x,
            this.y,
            this.h,
            this.w});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.displayDrawingDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.displayDrawingDataGridView.Location = new System.Drawing.Point(7, 82);
            this.displayDrawingDataGridView.MultiSelect = false;
            this.displayDrawingDataGridView.Name = "displayDrawingDataGridView";
            this.displayDrawingDataGridView.ReadOnly = true;
            this.displayDrawingDataGridView.RowHeadersVisible = false;
            this.displayDrawingDataGridView.RowHeadersWidth = 20;
            this.displayDrawingDataGridView.RowTemplate.Height = 24;
            this.displayDrawingDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.displayDrawingDataGridView.Size = new System.Drawing.Size(312, 537);
            this.displayDrawingDataGridView.TabIndex = 3;
            this.displayDrawingDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DisplayDrawingDataGridView_CellContentClick);
            // 
            // deleteButton
            // 
            this.deleteButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deleteButton.HeaderText = "刪除";
            this.deleteButton.MinimumWidth = 6;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.ReadOnly = true;
            this.deleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteButton.Text = "刪除";
            this.deleteButton.UseColumnTextForButtonValue = true;
            this.deleteButton.Width = 40;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 20;
            // 
            // shape
            // 
            this.shape.HeaderText = "形狀";
            this.shape.MinimumWidth = 6;
            this.shape.Name = "shape";
            this.shape.ReadOnly = true;
            this.shape.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.shape.Width = 60;
            // 
            // note
            // 
            this.note.HeaderText = "文字";
            this.note.MinimumWidth = 6;
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.note.Width = 90;
            // 
            // x
            // 
            this.x.HeaderText = "X";
            this.x.MinimumWidth = 6;
            this.x.Name = "x";
            this.x.ReadOnly = true;
            this.x.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.x.Width = 25;
            // 
            // y
            // 
            this.y.HeaderText = "Y";
            this.y.MinimumWidth = 6;
            this.y.Name = "y";
            this.y.ReadOnly = true;
            this.y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.y.Width = 25;
            // 
            // h
            // 
            this.h.HeaderText = "H";
            this.h.MinimumWidth = 6;
            this.h.Name = "h";
            this.h.ReadOnly = true;
            this.h.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.h.Width = 25;
            // 
            // w
            // 
            this.w.HeaderText = "W";
            this.w.MinimumWidth = 6;
            this.w.Name = "w";
            this.w.ReadOnly = true;
            this.w.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.w.Width = 25;
            // 
            // addDrawingButton
            // 
            this.addDrawingButton.Location = new System.Drawing.Point(7, 19);
            this.addDrawingButton.Name = "addDrawingButton";
            this.addDrawingButton.Size = new System.Drawing.Size(50, 50);
            this.addDrawingButton.TabIndex = 5;
            this.addDrawingButton.Text = "新增";
            this.addDrawingButton.UseVisualStyleBackColor = true;
            this.addDrawingButton.Click += new System.EventHandler(this.AddDrawingButton_Click);
            // 
            // manageDrawingDataGroupBox
            // 
            this.manageDrawingDataGroupBox.Controls.Add(this.wLabel);
            this.manageDrawingDataGroupBox.Controls.Add(this.widthTextBox);
            this.manageDrawingDataGroupBox.Controls.Add(this.yTextBox);
            this.manageDrawingDataGroupBox.Controls.Add(this.yLabel);
            this.manageDrawingDataGroupBox.Controls.Add(this.heightTextBox);
            this.manageDrawingDataGroupBox.Controls.Add(this.hLabel);
            this.manageDrawingDataGroupBox.Controls.Add(this.shapeLabel);
            this.manageDrawingDataGroupBox.Controls.Add(this.xLabel);
            this.manageDrawingDataGroupBox.Controls.Add(this.xTextBox);
            this.manageDrawingDataGroupBox.Controls.Add(this.noteLabel);
            this.manageDrawingDataGroupBox.Controls.Add(this.noteTextBox);
            this.manageDrawingDataGroupBox.Controls.Add(this.shapeComboBox);
            this.manageDrawingDataGroupBox.Controls.Add(this.displayDrawingDataGridView);
            this.manageDrawingDataGroupBox.Controls.Add(this.addDrawingButton);
            this.manageDrawingDataGroupBox.Location = new System.Drawing.Point(920, 52);
            this.manageDrawingDataGroupBox.Name = "manageDrawingDataGroupBox";
            this.manageDrawingDataGroupBox.Size = new System.Drawing.Size(332, 633);
            this.manageDrawingDataGroupBox.TabIndex = 0;
            this.manageDrawingDataGroupBox.TabStop = false;
            this.manageDrawingDataGroupBox.Text = "資料顯示";
            // 
            // wLabel
            // 
            this.wLabel.AutoSize = true;
            this.wLabel.Font = new System.Drawing.Font("新細明體", 9F);
            this.wLabel.Location = new System.Drawing.Point(264, 52);
            this.wLabel.Name = "wLabel";
            this.wLabel.Size = new System.Drawing.Size(16, 12);
            this.wLabel.TabIndex = 17;
            this.wLabel.Text = "W";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(283, 48);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(33, 22);
            this.widthTextBox.TabIndex = 16;
            this.widthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(283, 19);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(33, 22);
            this.yTextBox.TabIndex = 15;
            this.yTextBox.TextChanged += new System.EventHandler(this.YTextBox_TextChanged);
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Font = new System.Drawing.Font("新細明體", 9F);
            this.yLabel.Location = new System.Drawing.Point(266, 24);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(13, 12);
            this.yLabel.TabIndex = 14;
            this.yLabel.Text = "Y";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(225, 47);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(33, 22);
            this.heightTextBox.TabIndex = 13;
            this.heightTextBox.TextChanged += new System.EventHandler(this.HeightTextBox_TextChanged);
            // 
            // hLabel
            // 
            this.hLabel.AutoSize = true;
            this.hLabel.Font = new System.Drawing.Font("新細明體", 9F);
            this.hLabel.Location = new System.Drawing.Point(206, 52);
            this.hLabel.Name = "hLabel";
            this.hLabel.Size = new System.Drawing.Size(13, 12);
            this.hLabel.TabIndex = 12;
            this.hLabel.Text = "H";
            // 
            // shapeLabel
            // 
            this.shapeLabel.AutoSize = true;
            this.shapeLabel.Font = new System.Drawing.Font("新細明體", 9F);
            this.shapeLabel.Location = new System.Drawing.Point(63, 24);
            this.shapeLabel.Name = "shapeLabel";
            this.shapeLabel.Size = new System.Drawing.Size(29, 12);
            this.shapeLabel.TabIndex = 11;
            this.shapeLabel.Text = "形狀";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Font = new System.Drawing.Font("新細明體", 9F);
            this.xLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xLabel.Location = new System.Drawing.Point(206, 24);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(13, 12);
            this.xLabel.TabIndex = 10;
            this.xLabel.Text = "X";
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(225, 19);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(33, 22);
            this.xTextBox.TabIndex = 9;
            this.xTextBox.TextChanged += new System.EventHandler(this.XTextBox_TextChanged);
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Font = new System.Drawing.Font("新細明體", 9F);
            this.noteLabel.Location = new System.Drawing.Point(63, 51);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(29, 12);
            this.noteLabel.TabIndex = 8;
            this.noteLabel.Text = "文字";
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(98, 47);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(98, 22);
            this.noteTextBox.TabIndex = 7;
            this.noteTextBox.TextChanged += new System.EventHandler(this.NoteTextBox_TextChanged);
            // 
            // shapeComboBox
            // 
            this.shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shapeComboBox.FormattingEnabled = true;
            this.shapeComboBox.Items.AddRange(new object[] {
            "Start",
            "Terminator",
            "Decision",
            "Process"});
            this.shapeComboBox.Location = new System.Drawing.Point(98, 21);
            this.shapeComboBox.Name = "shapeComboBox";
            this.shapeComboBox.Size = new System.Drawing.Size(98, 20);
            this.shapeComboBox.TabIndex = 6;
            this.shapeComboBox.SelectedIndexChanged += new System.EventHandler(this.ShapeComboBox_SelectedIndexChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startButton,
            this.terminatorButton,
            this.decisionButton,
            this.processButton,
            this.pointerButton,
            this.lineButton,
            this.undoButton,
            this.redoButton,
            this.saveButton,
            this.loadButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip.Size = new System.Drawing.Size(1268, 27);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip";
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(24, 24);
            this.startButton.Text = "DrawStart";
            this.startButton.ToolTipText = "Start";
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // terminatorButton
            // 
            this.terminatorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.terminatorButton.Image = ((System.Drawing.Image)(resources.GetObject("terminatorButton.Image")));
            this.terminatorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.terminatorButton.Name = "terminatorButton";
            this.terminatorButton.Size = new System.Drawing.Size(24, 24);
            this.terminatorButton.Text = "DrawTerminator";
            this.terminatorButton.ToolTipText = "Terminator";
            this.terminatorButton.Click += new System.EventHandler(this.TerminatorButton_Click);
            // 
            // decisionButton
            // 
            this.decisionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.decisionButton.Image = ((System.Drawing.Image)(resources.GetObject("decisionButton.Image")));
            this.decisionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.decisionButton.Name = "decisionButton";
            this.decisionButton.Size = new System.Drawing.Size(24, 24);
            this.decisionButton.Text = "DrawDecision";
            this.decisionButton.ToolTipText = "Decision";
            this.decisionButton.Click += new System.EventHandler(this.DecisionButton_Click);
            // 
            // processButton
            // 
            this.processButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.processButton.Image = ((System.Drawing.Image)(resources.GetObject("processButton.Image")));
            this.processButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(24, 24);
            this.processButton.Text = "DrawProcess";
            this.processButton.ToolTipText = "Process";
            this.processButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // pointerButton
            // 
            this.pointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointerButton.Image = ((System.Drawing.Image)(resources.GetObject("pointerButton.Image")));
            this.pointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointerButton.Name = "pointerButton";
            this.pointerButton.Size = new System.Drawing.Size(24, 24);
            this.pointerButton.Text = "Pointer";
            this.pointerButton.Click += new System.EventHandler(this.PointerButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(24, 24);
            this.lineButton.Text = "DrawLine";
            this.lineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Enabled = false;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(24, 24);
            this.undoButton.Text = "Undo";
            this.undoButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Enabled = false;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(24, 24);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.Control;
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(24, 24);
            this.saveButton.Text = "Save";
            this.saveButton.ToolTipText = "Save";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadButton.Image = ((System.Drawing.Image)(resources.GetObject("loadButton.Image")));
            this.loadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(24, 24);
            this.loadButton.Text = "Load";
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // drawAreaPanel
            // 
            this.drawAreaPanel.Controls.Add(this.textPositionLabel);
            this.drawAreaPanel.Controls.Add(this.formLabel);
            this.drawAreaPanel.Controls.Add(this.anchorLabel);
            this.drawAreaPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.drawAreaPanel.Location = new System.Drawing.Point(156, 52);
            this.drawAreaPanel.Name = "drawAreaPanel";
            this.drawAreaPanel.Size = new System.Drawing.Size(762, 618);
            this.drawAreaPanel.TabIndex = 2;
            this.drawAreaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawAreaPanel_Paint);
            this.drawAreaPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawAreaPanel_MouseDown);
            this.drawAreaPanel.MouseEnter += new System.EventHandler(this.DrawAreaPanel_MouseEnter);
            this.drawAreaPanel.MouseLeave += new System.EventHandler(this.DrawAreaPanel_MouseLeave);
            this.drawAreaPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawAreaPanel_MouseMove);
            this.drawAreaPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawAreaPanel_MouseUp);
            // 
            // formLabel
            // 
            this.formLabel.AutoSize = true;
            this.formLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.formLabel.Location = new System.Drawing.Point(0, 0);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(61, 12);
            this.formLabel.TabIndex = 2;
            this.formLabel.Text = "MyDrawing";
            // 
            // anchorLabel
            // 
            this.anchorLabel.AutoSize = true;
            this.anchorLabel.Font = new System.Drawing.Font("新細明體", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.anchorLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.anchorLabel.Location = new System.Drawing.Point(0, 0);
            this.anchorLabel.Name = "anchorLabel";
            this.anchorLabel.Size = new System.Drawing.Size(8, 2);
            this.anchorLabel.TabIndex = 1;
            this.anchorLabel.Text = "anchor";
            // 
            // textPositionLabel
            // 
            this.textPositionLabel.AutoSize = true;
            this.textPositionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.textPositionLabel.Location = new System.Drawing.Point(0, 0);
            this.textPositionLabel.Name = "textPositionLabel";
            this.textPositionLabel.Size = new System.Drawing.Size(31, 12);
            this.textPositionLabel.TabIndex = 3;
            this.textPositionLabel.Text = "(0, 0)";
            // 
            // MyDrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 670);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.manageDrawingDataGroupBox);
            this.Controls.Add(this.drawAreaPanel);
            this.Controls.Add(this.pageSelectionPanel);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MyDrawingForm";
            this.Text = "MyDrawing";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayDrawingDataGridView)).EndInit();
            this.manageDrawingDataGroupBox.ResumeLayout(false);
            this.manageDrawingDataGroupBox.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.drawAreaPanel.ResumeLayout(false);
            this.drawAreaPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip;
        private ToolStripMenuItem desciptionToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Panel pageSelectionPanel;
        private DataGridView displayDrawingDataGridView;
        private Button addDrawingButton;
        private GroupBox manageDrawingDataGroupBox;
        private ComboBox shapeComboBox;
        private Label noteLabel;
        private TextBox noteTextBox;
        private Label xLabel;
        private TextBox xTextBox;
        private Label wLabel;
        private TextBox widthTextBox;
        private TextBox yTextBox;
        private Label yLabel;
        private TextBox heightTextBox;
        private Label hLabel;
        private Label shapeLabel;
        private DataGridViewButtonColumn deleteButton;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn shape;
        private DataGridViewTextBoxColumn note;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn y;
        private DataGridViewTextBoxColumn h;
        private DataGridViewTextBoxColumn w;
        private ToolStrip toolStrip;
        private ToolStripButton startButton;
        private ToolStripButton terminatorButton;
        private ToolStripButton decisionButton;
        private ToolStripButton processButton;
        private ToolStripButton pointerButton;
        private ToolStripButton lineButton;
        private ToolStripButton undoButton;
        private ToolStripButton redoButton;
        private DoubleBufferedPanel drawAreaPanel;
        private Label anchorLabel;
        private ToolStripButton saveButton;
        private ToolStripButton loadButton;
        private Label formLabel;
        private Label textPositionLabel;
    }
}

