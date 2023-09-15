namespace R10546040THKuoAss11
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rtbHiddenLayerNeuronNumbers = new System.Windows.Forms.RichTextBox();
            this.ckbAnimate = new System.Windows.Forms.CheckBox();
            this.btnClassificationTest = new System.Windows.Forms.Button();
            this.btnTrainToEnd = new System.Windows.Forms.Button();
            this.btnTrainAnEpoch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.chtProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgPrintPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.docMLP = new System.Drawing.Printing.PrintDocument();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRMSE = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.labelCorrectness = new System.Windows.Forms.Label();
            this.labelConfusionMatrix = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1157, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 19);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.OpenCALFile);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tsbPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1157, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton1.Text = "Open .cal File";
            this.toolStripButton1.Click += new System.EventHandler(this.OpenCALFile);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1157, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1157, 569);
            this.splitContainer1.SplitterDistance = 474;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.rtbHiddenLayerNeuronNumbers);
            this.splitContainer2.Panel1.Controls.Add(this.ckbAnimate);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(474, 569);
            this.splitContainer2.SplitterDistance = 267;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // rtbHiddenLayerNeuronNumbers
            // 
            this.rtbHiddenLayerNeuronNumbers.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbHiddenLayerNeuronNumbers.Location = new System.Drawing.Point(22, 92);
            this.rtbHiddenLayerNeuronNumbers.Margin = new System.Windows.Forms.Padding(4);
            this.rtbHiddenLayerNeuronNumbers.Name = "rtbHiddenLayerNeuronNumbers";
            this.rtbHiddenLayerNeuronNumbers.Size = new System.Drawing.Size(193, 127);
            this.rtbHiddenLayerNeuronNumbers.TabIndex = 2;
            this.rtbHiddenLayerNeuronNumbers.Text = "3";
            // 
            // ckbAnimate
            // 
            this.ckbAnimate.AutoSize = true;
            this.ckbAnimate.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ckbAnimate.Location = new System.Drawing.Point(22, 227);
            this.ckbAnimate.Margin = new System.Windows.Forms.Padding(4);
            this.ckbAnimate.Name = "ckbAnimate";
            this.ckbAnimate.Size = new System.Drawing.Size(76, 20);
            this.ckbAnimate.TabIndex = 1;
            this.ckbAnimate.Text = "Animate";
            this.ckbAnimate.UseVisualStyleBackColor = true;
            // 
            // btnClassificationTest
            // 
            this.btnClassificationTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClassificationTest.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClassificationTest.Location = new System.Drawing.Point(23, 161);
            this.btnClassificationTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnClassificationTest.Name = "btnClassificationTest";
            this.btnClassificationTest.Size = new System.Drawing.Size(200, 47);
            this.btnClassificationTest.TabIndex = 4;
            this.btnClassificationTest.Text = "Classification Test";
            this.btnClassificationTest.UseVisualStyleBackColor = true;
            this.btnClassificationTest.Click += new System.EventHandler(this.btnClassificationTest_Click);
            // 
            // btnTrainToEnd
            // 
            this.btnTrainToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrainToEnd.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTrainToEnd.Location = new System.Drawing.Point(23, 73);
            this.btnTrainToEnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrainToEnd.Name = "btnTrainToEnd";
            this.btnTrainToEnd.Size = new System.Drawing.Size(200, 47);
            this.btnTrainToEnd.TabIndex = 3;
            this.btnTrainToEnd.Text = "Train To End";
            this.btnTrainToEnd.UseVisualStyleBackColor = true;
            this.btnTrainToEnd.Click += new System.EventHandler(this.btnTrainToEnd_Click);
            // 
            // btnTrainAnEpoch
            // 
            this.btnTrainAnEpoch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrainAnEpoch.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTrainAnEpoch.Location = new System.Drawing.Point(23, 14);
            this.btnTrainAnEpoch.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrainAnEpoch.Name = "btnTrainAnEpoch";
            this.btnTrainAnEpoch.Size = new System.Drawing.Size(200, 47);
            this.btnTrainAnEpoch.TabIndex = 2;
            this.btnTrainAnEpoch.Text = "Train An Epoch";
            this.btnTrainAnEpoch.UseVisualStyleBackColor = true;
            this.btnTrainAnEpoch.Click += new System.EventHandler(this.btnTrainAnEpoch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReset.Location = new System.Drawing.Point(11, 14);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(204, 47);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(11, 69);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(204, 211);
            this.propertyGrid1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.chtProgress);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitContainer3.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel2_Paint);
            this.splitContainer3.Size = new System.Drawing.Size(678, 569);
            this.splitContainer3.SplitterDistance = 286;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // chtProgress
            // 
            chartArea4.AxisX.Title = "Epoch";
            chartArea4.AxisY.Title = "RMSE";
            chartArea4.Name = "ChartArea1";
            this.chtProgress.ChartAreas.Add(chartArea4);
            this.chtProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Alignment = System.Drawing.StringAlignment.Center;
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend4.Name = "Legend1";
            this.chtProgress.Legends.Add(legend4);
            this.chtProgress.Location = new System.Drawing.Point(0, 0);
            this.chtProgress.Margin = new System.Windows.Forms.Padding(4);
            this.chtProgress.Name = "chtProgress";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Epoch RMS of Errors";
            this.chtProgress.Series.Add(series4);
            this.chtProgress.Size = new System.Drawing.Size(674, 282);
            this.chtProgress.TabIndex = 0;
            this.chtProgress.Text = "chart1";
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            this.dlgOpen.Filter = "Cal file|*.cal|all files|*.*";
            this.dlgOpen.Title = "Choose a .cal file to open.";
            // 
            // dlgPrintPreview
            // 
            this.dlgPrintPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.dlgPrintPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.dlgPrintPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.dlgPrintPreview.Document = this.docMLP;
            this.dlgPrintPreview.Enabled = true;
            this.dlgPrintPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgPrintPreview.Icon")));
            this.dlgPrintPreview.Name = "dlgPrintPreview";
            this.dlgPrintPreview.Visible = false;
            // 
            // docMLP
            // 
            this.docMLP.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.docMLP_PrintPage);
            // 
            // tsbPrint
            // 
            this.tsbPrint.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(64, 22);
            this.tsbPrint.Text = "Print MLP";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hidden Layer Neuron Numbers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(26, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data Set :";
            // 
            // labelRMSE
            // 
            this.labelRMSE.AutoSize = true;
            this.labelRMSE.Location = new System.Drawing.Point(27, 131);
            this.labelRMSE.Name = "labelRMSE";
            this.labelRMSE.Size = new System.Drawing.Size(56, 16);
            this.labelRMSE.TabIndex = 5;
            this.labelRMSE.Text = "RMSE = ";
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.btnReset);
            this.splitContainer4.Panel1.Controls.Add(this.propertyGrid1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.labelConfusionMatrix);
            this.splitContainer4.Panel2.Controls.Add(this.labelCorrectness);
            this.splitContainer4.Panel2.Controls.Add(this.labelRMSE);
            this.splitContainer4.Panel2.Controls.Add(this.btnTrainAnEpoch);
            this.splitContainer4.Panel2.Controls.Add(this.btnClassificationTest);
            this.splitContainer4.Panel2.Controls.Add(this.btnTrainToEnd);
            this.splitContainer4.Size = new System.Drawing.Size(474, 297);
            this.splitContainer4.SplitterDistance = 227;
            this.splitContainer4.TabIndex = 0;
            // 
            // labelCorrectness
            // 
            this.labelCorrectness.AutoSize = true;
            this.labelCorrectness.Location = new System.Drawing.Point(27, 212);
            this.labelCorrectness.Name = "labelCorrectness";
            this.labelCorrectness.Size = new System.Drawing.Size(93, 16);
            this.labelCorrectness.TabIndex = 6;
            this.labelCorrectness.Text = "Correctness = ";
            // 
            // labelConfusionMatrix
            // 
            this.labelConfusionMatrix.AutoSize = true;
            this.labelConfusionMatrix.Location = new System.Drawing.Point(27, 233);
            this.labelConfusionMatrix.Name = "labelConfusionMatrix";
            this.labelConfusionMatrix.Size = new System.Drawing.Size(115, 16);
            this.labelConfusionMatrix.TabIndex = 7;
            this.labelConfusionMatrix.Text = "Confusion Matrix :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 641);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MLP System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtProgress)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtProgress;
        private System.Windows.Forms.Button btnClassificationTest;
        private System.Windows.Forms.Button btnTrainToEnd;
        private System.Windows.Forms.Button btnTrainAnEpoch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.CheckBox ckbAnimate;
        private System.Windows.Forms.RichTextBox rtbHiddenLayerNeuronNumbers;
        private System.Windows.Forms.PrintPreviewDialog dlgPrintPreview;
        private System.Drawing.Printing.PrintDocument docMLP;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label labelRMSE;
        private System.Windows.Forms.Label labelConfusionMatrix;
        private System.Windows.Forms.Label labelCorrectness;
    }
}

