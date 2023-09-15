
namespace R10546040FuzzySetNamespace
{
    partial class MyForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Input Universes");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Output Universe");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.btnAddUniverse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.trvMain = new System.Windows.Forms.TreeView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.chtMainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.prgMain = new System.Windows.Forms.PropertyGrid();
            this.btnAddFuzzySet = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbxFuzzySetList = new System.Windows.Forms.ComboBox();
            this.cbxUnaryOperator = new System.Windows.Forms.ComboBox();
            this.btnAddUnaryOperatedFS = new System.Windows.Forms.Button();
            this.cbxBinaryOperator = new System.Windows.Forms.ComboBox();
            this.btnAddBinaryOperatedFS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.rbtnTsukamoto = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rbtnSugeno = new System.Windows.Forms.RadioButton();
            this.prgSystem = new System.Windows.Forms.PropertyGrid();
            this.rbtnMamdani = new System.Windows.Forms.RadioButton();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.FuzzySetPage = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.tbUnaryParameters = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBinaryParameters = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RulesPage = new System.Windows.Forms.TabPage();
            this.ckbCut = new System.Windows.Forms.CheckBox();
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.btnInferencing = new System.Windows.Forms.Button();
            this.dgvConditions = new System.Windows.Forms.DataGridView();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.EquationPage = new System.Windows.Forms.TabPage();
            this.btnAddEquation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lsbEquation = new System.Windows.Forms.ListBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.chtTsukamotoOutput = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelResolution = new System.Windows.Forms.Label();
            this.domainResolution = new System.Windows.Forms.DomainUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.chartController1 = new Steema.TeeChart.ChartController();
            this.teeChart = new Steema.TeeChart.TChart();
            this.surface1 = new Steema.TeeChart.Styles.Surface();
            this.btnGetCrispInputOutputResponse = new System.Windows.Forms.Button();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.btnInferTsukamoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chtMainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.FuzzySetPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.RulesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).BeginInit();
            this.EquationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtTsukamotoOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddUniverse
            // 
            this.btnAddUniverse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUniverse.Enabled = false;
            this.btnAddUniverse.Location = new System.Drawing.Point(6, 3);
            this.btnAddUniverse.Name = "btnAddUniverse";
            this.btnAddUniverse.Size = new System.Drawing.Size(255, 41);
            this.btnAddUniverse.TabIndex = 0;
            this.btnAddUniverse.Text = "Add A Universe";
            this.btnAddUniverse.UseVisualStyleBackColor = true;
            this.btnAddUniverse.Click += new System.EventHandler(this.btnAddUniverse_Click);
            // 
            // trvMain
            // 
            this.trvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvMain.ImageIndex = 1;
            this.trvMain.ImageList = this.images;
            this.trvMain.Location = new System.Drawing.Point(6, 47);
            this.trvMain.Name = "trvMain";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "Input";
            treeNode3.Text = "Input Universes";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "Output";
            treeNode4.Text = "Output Universe";
            this.trvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.trvMain.SelectedImageIndex = 0;
            this.trvMain.Size = new System.Drawing.Size(255, 148);
            this.trvMain.TabIndex = 1;
            this.trvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMain_AfterSelect);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "Cross.png");
            this.images.Images.SetKeyName(1, "Diamond.png");
            this.images.Images.SetKeyName(2, "Triangle.png");
            // 
            // chtMainChart
            // 
            this.chtMainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtMainChart.Location = new System.Drawing.Point(0, 0);
            this.chtMainChart.Name = "chtMainChart";
            this.chtMainChart.Size = new System.Drawing.Size(690, 375);
            this.chtMainChart.TabIndex = 2;
            this.chtMainChart.Text = "MainChart";
            // 
            // prgMain
            // 
            this.prgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgMain.Location = new System.Drawing.Point(3, 47);
            this.prgMain.Name = "prgMain";
            this.prgMain.Size = new System.Drawing.Size(276, 148);
            this.prgMain.TabIndex = 6;
            // 
            // btnAddFuzzySet
            // 
            this.btnAddFuzzySet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFuzzySet.Location = new System.Drawing.Point(265, 17);
            this.btnAddFuzzySet.Name = "btnAddFuzzySet";
            this.btnAddFuzzySet.Size = new System.Drawing.Size(236, 27);
            this.btnAddFuzzySet.TabIndex = 7;
            this.btnAddFuzzySet.Text = "Add Fuzzy Set";
            this.btnAddFuzzySet.UseVisualStyleBackColor = true;
            this.btnAddFuzzySet.Click += new System.EventHandler(this.btnAddFuzzySet_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(3, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(276, 41);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbxFuzzySetList
            // 
            this.cbxFuzzySetList.FormattingEnabled = true;
            this.cbxFuzzySetList.Items.AddRange(new object[] {
            "Triangular Fuzzy Set",
            "Trapezoidal Fuzzy Set",
            "Gaussian Fuzzy Set",
            "Bell Fuzzy Set",
            "Sigmoidal Fuzzy Set",
            "Left-Right Fuzzy Set",
            "S Fuzzy Set",
            "Z Fuzzy Set",
            "pi Fuzzy Set",
            "two side pi Fuzzy Set",
            "Step Up Fuzzy Set",
            "Step Down Fuzzy Set"});
            this.cbxFuzzySetList.Location = new System.Drawing.Point(15, 19);
            this.cbxFuzzySetList.Name = "cbxFuzzySetList";
            this.cbxFuzzySetList.Size = new System.Drawing.Size(244, 24);
            this.cbxFuzzySetList.TabIndex = 9;
            this.cbxFuzzySetList.Text = "Fuzzy Set";
            // 
            // cbxUnaryOperator
            // 
            this.cbxUnaryOperator.FormattingEnabled = true;
            this.cbxUnaryOperator.Items.AddRange(new object[] {
            "Negation",
            "Value-Cut",
            "Very (Concentration)",
            "More or less (Dilation)",
            "Extremely",
            "Intensification",
            "Diminisher",
            "Scale"});
            this.cbxUnaryOperator.Location = new System.Drawing.Point(15, 64);
            this.cbxUnaryOperator.Name = "cbxUnaryOperator";
            this.cbxUnaryOperator.Size = new System.Drawing.Size(244, 24);
            this.cbxUnaryOperator.TabIndex = 10;
            this.cbxUnaryOperator.Text = "Unary Operator";
            this.cbxUnaryOperator.SelectedIndexChanged += new System.EventHandler(this.cbxUnaryOperator_SelectedIndexChanged);
            // 
            // btnAddUnaryOperatedFS
            // 
            this.btnAddUnaryOperatedFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUnaryOperatedFS.Location = new System.Drawing.Point(265, 50);
            this.btnAddUnaryOperatedFS.Name = "btnAddUnaryOperatedFS";
            this.btnAddUnaryOperatedFS.Size = new System.Drawing.Size(236, 46);
            this.btnAddUnaryOperatedFS.TabIndex = 11;
            this.btnAddUnaryOperatedFS.Text = "Add Unary Operated FS";
            this.btnAddUnaryOperatedFS.UseVisualStyleBackColor = true;
            this.btnAddUnaryOperatedFS.Click += new System.EventHandler(this.btnAddUnaryOperatedFS_Click);
            // 
            // cbxBinaryOperator
            // 
            this.cbxBinaryOperator.FormattingEnabled = true;
            this.cbxBinaryOperator.Items.AddRange(new object[] {
            "Intersection",
            "Union",
            "AlgebraicSum",
            "BoundedSum",
            "DrasticSum",
            "AlgebraicProduct",
            "BoundedProduct",
            "DrasticProduct",
            "SchweizerSklarTnorm",
            "YagerTnorm",
            "DubiosPradeTnorm",
            "HamacherTnorm",
            "FrankTnorm",
            "SugenoTnorm",
            "DombiTnorm"});
            this.cbxBinaryOperator.Location = new System.Drawing.Point(15, 116);
            this.cbxBinaryOperator.Name = "cbxBinaryOperator";
            this.cbxBinaryOperator.Size = new System.Drawing.Size(244, 24);
            this.cbxBinaryOperator.TabIndex = 12;
            this.cbxBinaryOperator.Text = "Binary Operator";
            this.cbxBinaryOperator.SelectedIndexChanged += new System.EventHandler(this.cbxBinaryOperator_SelectedIndexChanged);
            // 
            // btnAddBinaryOperatedFS
            // 
            this.btnAddBinaryOperatedFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBinaryOperatedFS.Location = new System.Drawing.Point(265, 102);
            this.btnAddBinaryOperatedFS.Name = "btnAddBinaryOperatedFS";
            this.btnAddBinaryOperatedFS.Size = new System.Drawing.Size(236, 46);
            this.btnAddBinaryOperatedFS.TabIndex = 13;
            this.btnAddBinaryOperatedFS.Text = "Add Binary Operated FS";
            this.btnAddBinaryOperatedFS.UseVisualStyleBackColor = true;
            this.btnAddBinaryOperatedFS.Click += new System.EventHandler(this.btnAddBinaryOperatedFS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(30, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Click to accept the selected FuzzySet_1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Location = new System.Drawing.Point(260, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Click to accept the selected FuzzySet_2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Size = new System.Drawing.Size(1257, 717);
            this.splitContainer1.SplitterDistance = 559;
            this.splitContainer1.TabIndex = 16;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl);
            this.splitContainer2.Size = new System.Drawing.Size(559, 717);
            this.splitContainer2.SplitterDistance = 349;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer3.Panel1.Controls.Add(this.rbtnTsukamoto);
            this.splitContainer3.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer3.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer3.Panel1.Controls.Add(this.rbtnSugeno);
            this.splitContainer3.Panel1.Controls.Add(this.prgSystem);
            this.splitContainer3.Panel1.Controls.Add(this.rbtnMamdani);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer3.Size = new System.Drawing.Size(559, 349);
            this.splitContainer3.SplitterDistance = 143;
            this.splitContainer3.TabIndex = 0;
            // 
            // rbtnTsukamoto
            // 
            this.rbtnTsukamoto.AutoSize = true;
            this.rbtnTsukamoto.Location = new System.Drawing.Point(10, 105);
            this.rbtnTsukamoto.Name = "rbtnTsukamoto";
            this.rbtnTsukamoto.Size = new System.Drawing.Size(88, 20);
            this.rbtnTsukamoto.TabIndex = 2;
            this.rbtnTsukamoto.Text = "Tsukamoto";
            this.rbtnTsukamoto.UseVisualStyleBackColor = true;
            this.rbtnTsukamoto.CheckedChanged += new System.EventHandler(this.rbtnTsukamoto_CheckedChanged);
            this.rbtnTsukamoto.Click += new System.EventHandler(this.FuzzySystemChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(555, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = global::R10546040FuzzySetNamespace.Properties.Resources.Triangle;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(63, 24);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::R10546040FuzzySetNamespace.Properties.Resources.Diamond;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(58, 24);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::R10546040FuzzySetNamespace.Properties.Resources.Triangle;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::R10546040FuzzySetNamespace.Properties.Resources.Diamond;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // rbtnSugeno
            // 
            this.rbtnSugeno.AutoSize = true;
            this.rbtnSugeno.Location = new System.Drawing.Point(10, 79);
            this.rbtnSugeno.Name = "rbtnSugeno";
            this.rbtnSugeno.Size = new System.Drawing.Size(69, 20);
            this.rbtnSugeno.TabIndex = 1;
            this.rbtnSugeno.Text = "Sugeno";
            this.rbtnSugeno.UseVisualStyleBackColor = true;
            this.rbtnSugeno.CheckedChanged += new System.EventHandler(this.rbtnSugeno_CheckedChanged);
            this.rbtnSugeno.Click += new System.EventHandler(this.FuzzySystemChanged);
            // 
            // prgSystem
            // 
            this.prgSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgSystem.Location = new System.Drawing.Point(104, 52);
            this.prgSystem.Name = "prgSystem";
            this.prgSystem.Size = new System.Drawing.Size(447, 84);
            this.prgSystem.TabIndex = 3;
            // 
            // rbtnMamdani
            // 
            this.rbtnMamdani.AutoSize = true;
            this.rbtnMamdani.Checked = true;
            this.rbtnMamdani.Location = new System.Drawing.Point(10, 53);
            this.rbtnMamdani.Name = "rbtnMamdani";
            this.rbtnMamdani.Size = new System.Drawing.Size(80, 20);
            this.rbtnMamdani.TabIndex = 0;
            this.rbtnMamdani.TabStop = true;
            this.rbtnMamdani.Text = "Mamdani";
            this.rbtnMamdani.UseVisualStyleBackColor = true;
            this.rbtnMamdani.CheckedChanged += new System.EventHandler(this.rbtnMamdani_CheckedChanged);
            this.rbtnMamdani.Click += new System.EventHandler(this.FuzzySystemChanged);
            // 
            // splitContainer6
            // 
            this.splitContainer6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.trvMain);
            this.splitContainer6.Panel1.Controls.Add(this.btnAddUniverse);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.prgMain);
            this.splitContainer6.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer6.Size = new System.Drawing.Size(559, 202);
            this.splitContainer6.SplitterDistance = 268;
            this.splitContainer6.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.FuzzySetPage);
            this.tabControl.Controls.Add(this.RulesPage);
            this.tabControl.Controls.Add(this.EquationPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(555, 360);
            this.tabControl.TabIndex = 0;
            // 
            // FuzzySetPage
            // 
            this.FuzzySetPage.Controls.Add(this.splitContainer5);
            this.FuzzySetPage.Location = new System.Drawing.Point(4, 25);
            this.FuzzySetPage.Name = "FuzzySetPage";
            this.FuzzySetPage.Padding = new System.Windows.Forms.Padding(3);
            this.FuzzySetPage.Size = new System.Drawing.Size(527, 314);
            this.FuzzySetPage.TabIndex = 0;
            this.FuzzySetPage.Text = "Fuzzy Sets";
            this.FuzzySetPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(3, 3);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.cbxFuzzySetList);
            this.splitContainer5.Panel1.Controls.Add(this.btnAddFuzzySet);
            this.splitContainer5.Panel1.Controls.Add(this.cbxUnaryOperator);
            this.splitContainer5.Panel1.Controls.Add(this.btnAddUnaryOperatedFS);
            this.splitContainer5.Panel1.Controls.Add(this.cbxBinaryOperator);
            this.splitContainer5.Panel1.Controls.Add(this.btnAddBinaryOperatedFS);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.label2);
            this.splitContainer5.Panel2.Controls.Add(this.label1);
            this.splitContainer5.Panel2.Controls.Add(this.tbUnaryParameters);
            this.splitContainer5.Panel2.Controls.Add(this.label4);
            this.splitContainer5.Panel2.Controls.Add(this.tbBinaryParameters);
            this.splitContainer5.Panel2.Controls.Add(this.label3);
            this.splitContainer5.Size = new System.Drawing.Size(521, 308);
            this.splitContainer5.SplitterDistance = 170;
            this.splitContainer5.TabIndex = 0;
            // 
            // tbUnaryParameters
            // 
            this.tbUnaryParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUnaryParameters.Location = new System.Drawing.Point(278, 14);
            this.tbUnaryParameters.Name = "tbUnaryParameters";
            this.tbUnaryParameters.Size = new System.Drawing.Size(123, 23);
            this.tbUnaryParameters.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Unary Operator Parameters";
            // 
            // tbBinaryParameters
            // 
            this.tbBinaryParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBinaryParameters.Location = new System.Drawing.Point(278, 56);
            this.tbBinaryParameters.Name = "tbBinaryParameters";
            this.tbBinaryParameters.Size = new System.Drawing.Size(123, 23);
            this.tbBinaryParameters.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Binary Operator Parameters";
            // 
            // RulesPage
            // 
            this.RulesPage.Controls.Add(this.ckbCut);
            this.RulesPage.Controls.Add(this.dgvRules);
            this.RulesPage.Controls.Add(this.btnInferencing);
            this.RulesPage.Controls.Add(this.dgvConditions);
            this.RulesPage.Controls.Add(this.btnAddRule);
            this.RulesPage.Location = new System.Drawing.Point(4, 25);
            this.RulesPage.Name = "RulesPage";
            this.RulesPage.Size = new System.Drawing.Size(547, 331);
            this.RulesPage.TabIndex = 1;
            this.RulesPage.Text = "If-then Rules";
            this.RulesPage.UseVisualStyleBackColor = true;
            // 
            // ckbCut
            // 
            this.ckbCut.AutoSize = true;
            this.ckbCut.Checked = true;
            this.ckbCut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCut.Location = new System.Drawing.Point(111, 197);
            this.ckbCut.Name = "ckbCut";
            this.ckbCut.Size = new System.Drawing.Size(45, 20);
            this.ckbCut.TabIndex = 4;
            this.ckbCut.Text = "Cut";
            this.ckbCut.UseVisualStyleBackColor = true;
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToAddRows = false;
            this.dgvRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Location = new System.Drawing.Point(18, 55);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowHeadersWidth = 51;
            this.dgvRules.RowTemplate.Height = 24;
            this.dgvRules.Size = new System.Drawing.Size(513, 120);
            this.dgvRules.TabIndex = 0;
            this.dgvRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellClick);
            // 
            // btnInferencing
            // 
            this.btnInferencing.Location = new System.Drawing.Point(18, 189);
            this.btnInferencing.Name = "btnInferencing";
            this.btnInferencing.Size = new System.Drawing.Size(87, 34);
            this.btnInferencing.TabIndex = 3;
            this.btnInferencing.Text = "Infer";
            this.btnInferencing.UseVisualStyleBackColor = true;
            this.btnInferencing.Click += new System.EventHandler(this.btnInferencing_Click);
            // 
            // dgvConditions
            // 
            this.dgvConditions.AllowUserToAddRows = false;
            this.dgvConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditions.Location = new System.Drawing.Point(18, 233);
            this.dgvConditions.Name = "dgvConditions";
            this.dgvConditions.RowHeadersWidth = 51;
            this.dgvConditions.RowTemplate.Height = 24;
            this.dgvConditions.Size = new System.Drawing.Size(513, 83);
            this.dgvConditions.TabIndex = 1;
            this.dgvConditions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditions_CellClick);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Location = new System.Drawing.Point(18, 11);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(87, 34);
            this.btnAddRule.TabIndex = 2;
            this.btnAddRule.Text = "Add Rule";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // EquationPage
            // 
            this.EquationPage.Controls.Add(this.btnAddEquation);
            this.EquationPage.Controls.Add(this.label5);
            this.EquationPage.Controls.Add(this.lsbEquation);
            this.EquationPage.Location = new System.Drawing.Point(4, 22);
            this.EquationPage.Name = "EquationPage";
            this.EquationPage.Size = new System.Drawing.Size(527, 317);
            this.EquationPage.TabIndex = 2;
            this.EquationPage.Text = "Output Equations";
            this.EquationPage.UseVisualStyleBackColor = true;
            // 
            // btnAddEquation
            // 
            this.btnAddEquation.Location = new System.Drawing.Point(305, 53);
            this.btnAddEquation.Name = "btnAddEquation";
            this.btnAddEquation.Size = new System.Drawing.Size(137, 49);
            this.btnAddEquation.TabIndex = 2;
            this.btnAddEquation.Text = "Add Equation";
            this.btnAddEquation.UseVisualStyleBackColor = true;
            this.btnAddEquation.Click += new System.EventHandler(this.btnAddEquation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Sugeno Output";
            // 
            // lsbEquation
            // 
            this.lsbEquation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbEquation.FormattingEnabled = true;
            this.lsbEquation.ItemHeight = 16;
            this.lsbEquation.Items.AddRange(new object[] {
            "(0) Y = 0.1 X + 6.4",
            "(1) Y = - 0.5 X + 4",
            "(2) Y = X - 2",
            "(3) Z = - X + Y + 1",
            "(4) Z = - Y + 3",
            "(5) Z = - X + 3",
            "(6) Z = X + Y + 2"});
            this.lsbEquation.Location = new System.Drawing.Point(31, 53);
            this.lsbEquation.Name = "lsbEquation";
            this.lsbEquation.Size = new System.Drawing.Size(242, 164);
            this.lsbEquation.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.chtMainChart);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer7);
            this.splitContainer4.Panel2.Controls.Add(this.labelResolution);
            this.splitContainer4.Panel2.Controls.Add(this.domainResolution);
            this.splitContainer4.Panel2.Controls.Add(this.button1);
            this.splitContainer4.Panel2.Controls.Add(this.chartController1);
            this.splitContainer4.Panel2.Controls.Add(this.teeChart);
            this.splitContainer4.Panel2.Controls.Add(this.btnGetCrispInputOutputResponse);
            this.splitContainer4.Size = new System.Drawing.Size(694, 717);
            this.splitContainer4.SplitterDistance = 379;
            this.splitContainer4.TabIndex = 3;
            // 
            // chtTsukamotoOutput
            // 
            chartArea2.Name = "ChartArea1";
            this.chtTsukamotoOutput.ChartAreas.Add(chartArea2);
            this.chtTsukamotoOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtTsukamotoOutput.Location = new System.Drawing.Point(0, 0);
            this.chtTsukamotoOutput.Name = "chtTsukamotoOutput";
            this.chtTsukamotoOutput.Size = new System.Drawing.Size(610, 305);
            this.chtTsukamotoOutput.TabIndex = 6;
            this.chtTsukamotoOutput.Text = "chart1";
            this.chtTsukamotoOutput.Visible = false;
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(15, 37);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(86, 16);
            this.labelResolution.TabIndex = 5;
            this.labelResolution.Text = "3D Resolution";
            // 
            // domainResolution
            // 
            this.domainResolution.Items.Add("30");
            this.domainResolution.Items.Add("40");
            this.domainResolution.Items.Add("50");
            this.domainResolution.Items.Add("60");
            this.domainResolution.Location = new System.Drawing.Point(16, 59);
            this.domainResolution.Name = "domainResolution";
            this.domainResolution.Size = new System.Drawing.Size(86, 23);
            this.domainResolution.TabIndex = 4;
            this.domainResolution.Text = "30";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chartController1
            // 
            this.chartController1.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16;
            this.chartController1.Chart = this.teeChart;
            this.chartController1.LabelValues = true;
            this.chartController1.Location = new System.Drawing.Point(0, 0);
            this.chartController1.Name = "chartController1";
            this.chartController1.Size = new System.Drawing.Size(694, 25);
            this.chartController1.TabIndex = 2;
            this.chartController1.Text = "chartController1";
            // 
            // teeChart
            // 
            this.teeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.teeChart.Aspect.Chart3DPercent = 100;
            this.teeChart.Aspect.Orthogonal = false;
            this.teeChart.Aspect.Perspective = 50;
            this.teeChart.Aspect.Zoom = 63;
            this.teeChart.Aspect.ZoomFloat = 63D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.teeChart.Axes.Bottom.Title.Caption = "InputUniverse1";
            this.teeChart.Axes.Bottom.Title.Lines = new string[] {
        "InputUniverse1"};
            // 
            // 
            // 
            this.teeChart.Axes.Depth.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            this.teeChart.Axes.Depth.Title.Caption = "InputUniverse2";
            this.teeChart.Axes.Depth.Title.Lines = new string[] {
        "InputUniverse2"};
            this.teeChart.Axes.Depth.Visible = true;
            // 
            // 
            // 
            this.teeChart.Axes.DepthTop.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.teeChart.Axes.Left.Title.Caption = "OutputUniverse1";
            this.teeChart.Axes.Left.Title.Lines = new string[] {
        "OutputUniverse1"};
            // 
            // 
            // 
            this.teeChart.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.teeChart.Axes.Top.Visible = false;
            this.teeChart.Location = new System.Drawing.Point(151, 34);
            this.teeChart.Name = "teeChart";
            this.teeChart.Series.Add(this.surface1);
            this.teeChart.Size = new System.Drawing.Size(533, 290);
            this.teeChart.TabIndex = 1;
            // 
            // surface1
            // 
            // 
            // 
            // 
            this.surface1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.surface1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.surface1.ColorEach = false;
            this.surface1.IrregularGrid = true;
            this.surface1.NumXValues = 30;
            this.surface1.NumZValues = 30;
            this.surface1.PaletteMin = 0D;
            this.surface1.PaletteStep = 0D;
            this.surface1.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
            this.surface1.Title = "surface1";
            // 
            // 
            // 
            this.surface1.XValues.DataMember = "X";
            // 
            // 
            // 
            this.surface1.YValues.DataMember = "Y";
            // 
            // 
            // 
            this.surface1.ZValues.DataMember = "Z";
            // 
            // btnGetCrispInputOutputResponse
            // 
            this.btnGetCrispInputOutputResponse.Location = new System.Drawing.Point(13, 94);
            this.btnGetCrispInputOutputResponse.Name = "btnGetCrispInputOutputResponse";
            this.btnGetCrispInputOutputResponse.Size = new System.Drawing.Size(121, 64);
            this.btnGetCrispInputOutputResponse.TabIndex = 0;
            this.btnGetCrispInputOutputResponse.Text = "Get Crisp Input-Output Response";
            this.btnGetCrispInputOutputResponse.UseVisualStyleBackColor = true;
            this.btnGetCrispInputOutputResponse.Click += new System.EventHandler(this.btnGetCrispInputOutputResponse_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            // 
            // splitContainer7
            // 
            this.splitContainer7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 25);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.btnInferTsukamoto);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.chtTsukamotoOutput);
            this.splitContainer7.Size = new System.Drawing.Size(694, 309);
            this.splitContainer7.SplitterDistance = 76;
            this.splitContainer7.TabIndex = 6;
            // 
            // btnInferTsukamoto
            // 
            this.btnInferTsukamoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInferTsukamoto.Location = new System.Drawing.Point(0, 0);
            this.btnInferTsukamoto.Name = "btnInferTsukamoto";
            this.btnInferTsukamoto.Size = new System.Drawing.Size(72, 305);
            this.btnInferTsukamoto.TabIndex = 0;
            this.btnInferTsukamoto.Text = "Inference All Crisp Inputs";
            this.btnInferTsukamoto.UseVisualStyleBackColor = true;
            this.btnInferTsukamoto.Click += new System.EventHandler(this.btnInferTsukamoto_Click);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 717);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MyForm";
            this.Text = "Fuzzy Inference System";
            ((System.ComponentModel.ISupportInitialize)(this.chtMainChart)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.FuzzySetPage.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.RulesPage.ResumeLayout(false);
            this.RulesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).EndInit();
            this.EquationPage.ResumeLayout(false);
            this.EquationPage.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtTsukamotoOutput)).EndInit();
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddUniverse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TreeView trvMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtMainChart;
        private System.Windows.Forms.PropertyGrid prgMain;
        private System.Windows.Forms.Button btnAddFuzzySet;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbxFuzzySetList;
        private System.Windows.Forms.ComboBox cbxUnaryOperator;
        private System.Windows.Forms.Button btnAddUnaryOperatedFS;
        private System.Windows.Forms.ComboBox cbxBinaryOperator;
        private System.Windows.Forms.Button btnAddBinaryOperatedFS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage FuzzySetPage;
        private System.Windows.Forms.TextBox tbBinaryParameters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUnaryParameters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.Button btnInferencing;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.DataGridView dgvConditions;
        private System.Windows.Forms.DataGridView dgvRules;
        private System.Windows.Forms.CheckBox ckbCut;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.TabPage RulesPage;
        private System.Windows.Forms.RadioButton rbtnTsukamoto;
        private System.Windows.Forms.RadioButton rbtnSugeno;
        private System.Windows.Forms.RadioButton rbtnMamdani;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Button btnGetCrispInputOutputResponse;
        private Steema.TeeChart.ChartController chartController1;
        private Steema.TeeChart.TChart teeChart;
        private Steema.TeeChart.Styles.Surface surface1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PropertyGrid prgSystem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.TabPage EquationPage;
        private System.Windows.Forms.Button btnAddEquation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lsbEquation;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.DomainUpDown domainResolution;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtTsukamotoOutput;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Button btnInferTsukamoto;
    }
}

