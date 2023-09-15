
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Input Universes");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Output Universe");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.tbUnaryParameters = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBinaryParameters = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.ckbCut = new System.Windows.Forms.CheckBox();
            this.btnInferencing = new System.Windows.Forms.Button();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.dgvConditions = new System.Windows.Forms.DataGridView();
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddUniverse
            // 
            this.btnAddUniverse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUniverse.Enabled = false;
            this.btnAddUniverse.Location = new System.Drawing.Point(3, 10);
            this.btnAddUniverse.Name = "btnAddUniverse";
            this.btnAddUniverse.Size = new System.Drawing.Size(242, 41);
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
            this.trvMain.Location = new System.Drawing.Point(3, 57);
            this.trvMain.Name = "trvMain";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "Input";
            treeNode1.Text = "Input Universes";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Output";
            treeNode2.Text = "Output Universe";
            this.trvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.trvMain.SelectedImageIndex = 0;
            this.trvMain.Size = new System.Drawing.Size(242, 270);
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
            this.chtMainChart.Size = new System.Drawing.Size(653, 400);
            this.chtMainChart.TabIndex = 2;
            this.chtMainChart.Text = "MainChart";
            // 
            // prgMain
            // 
            this.prgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgMain.Location = new System.Drawing.Point(3, 57);
            this.prgMain.Name = "prgMain";
            this.prgMain.Size = new System.Drawing.Size(265, 270);
            this.prgMain.TabIndex = 6;
            // 
            // btnAddFuzzySet
            // 
            this.btnAddFuzzySet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFuzzySet.Location = new System.Drawing.Point(265, 18);
            this.btnAddFuzzySet.Name = "btnAddFuzzySet";
            this.btnAddFuzzySet.Size = new System.Drawing.Size(228, 27);
            this.btnAddFuzzySet.TabIndex = 7;
            this.btnAddFuzzySet.Text = "Add Fuzzy Set";
            this.btnAddFuzzySet.UseVisualStyleBackColor = true;
            this.btnAddFuzzySet.Click += new System.EventHandler(this.btnAddFuzzySet_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(3, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(265, 41);
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
            "pi Fuzzy Set"});
            this.cbxFuzzySetList.Location = new System.Drawing.Point(15, 20);
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
            this.cbxUnaryOperator.Location = new System.Drawing.Point(15, 65);
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
            this.btnAddUnaryOperatedFS.Location = new System.Drawing.Point(265, 51);
            this.btnAddUnaryOperatedFS.Name = "btnAddUnaryOperatedFS";
            this.btnAddUnaryOperatedFS.Size = new System.Drawing.Size(228, 46);
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
            this.cbxBinaryOperator.Location = new System.Drawing.Point(15, 117);
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
            this.btnAddBinaryOperatedFS.Location = new System.Drawing.Point(265, 103);
            this.btnAddBinaryOperatedFS.Name = "btnAddBinaryOperatedFS";
            this.btnAddBinaryOperatedFS.Size = new System.Drawing.Size(228, 46);
            this.btnAddBinaryOperatedFS.TabIndex = 13;
            this.btnAddBinaryOperatedFS.Text = "Add Binary Operated FS";
            this.btnAddBinaryOperatedFS.UseVisualStyleBackColor = true;
            this.btnAddBinaryOperatedFS.Click += new System.EventHandler(this.btnAddBinaryOperatedFS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(35, 118);
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
            this.label2.Location = new System.Drawing.Point(265, 118);
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
            this.splitContainer1.Size = new System.Drawing.Size(1192, 709);
            this.splitContainer1.SplitterDistance = 531;
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
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(531, 709);
            this.splitContainer2.SplitterDistance = 338;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.trvMain);
            this.splitContainer3.Panel1.Controls.Add(this.btnAddUniverse);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.prgMain);
            this.splitContainer3.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer3.Size = new System.Drawing.Size(531, 338);
            this.splitContainer3.SplitterDistance = 252;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 363);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(519, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fuzzy Sets";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.splitContainer5.Size = new System.Drawing.Size(513, 328);
            this.splitContainer5.SplitterDistance = 160;
            this.splitContainer5.TabIndex = 0;
            // 
            // tbUnaryParameters
            // 
            this.tbUnaryParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUnaryParameters.Location = new System.Drawing.Point(283, 33);
            this.tbUnaryParameters.Name = "tbUnaryParameters";
            this.tbUnaryParameters.Size = new System.Drawing.Size(115, 23);
            this.tbUnaryParameters.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Unary Operator Parameters";
            // 
            // tbBinaryParameters
            // 
            this.tbBinaryParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBinaryParameters.Location = new System.Drawing.Point(283, 75);
            this.tbBinaryParameters.Name = "tbBinaryParameters";
            this.tbBinaryParameters.Size = new System.Drawing.Size(115, 23);
            this.tbBinaryParameters.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Binary Operator Parameters";
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
            this.splitContainer4.Size = new System.Drawing.Size(657, 709);
            this.splitContainer4.SplitterDistance = 404;
            this.splitContainer4.TabIndex = 3;
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
            // dgvConditions
            // 
            this.dgvConditions.AllowUserToAddRows = false;
            this.dgvConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditions.Location = new System.Drawing.Point(18, 233);
            this.dgvConditions.Name = "dgvConditions";
            this.dgvConditions.RowTemplate.Height = 24;
            this.dgvConditions.Size = new System.Drawing.Size(485, 86);
            this.dgvConditions.TabIndex = 1;
            this.dgvConditions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditions_CellClick);
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToAddRows = false;
            this.dgvRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Location = new System.Drawing.Point(18, 55);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowTemplate.Height = 24;
            this.dgvRules.Size = new System.Drawing.Size(485, 120);
            this.dgvRules.TabIndex = 0;
            this.dgvRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ckbCut);
            this.tabPage2.Controls.Add(this.dgvRules);
            this.tabPage2.Controls.Add(this.btnInferencing);
            this.tabPage2.Controls.Add(this.dgvConditions);
            this.tabPage2.Controls.Add(this.btnAddRule);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(519, 334);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "If-then Rules";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 709);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
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
        private System.Windows.Forms.TabPage tabPage2;
    }
}

