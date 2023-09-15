namespace R10546040THKuoAss07
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPermutationGAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCreateBinaryGA = new System.Windows.Forms.ToolStripButton();
            this.tsbCreatePermutationGA = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenFilePer = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsbOpenFileBi = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1045, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neToolStripMenuItem,
            this.newPermutationGAToolStripMenuItem,
            this.openToolStripMenuItem});
            this.filesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // neToolStripMenuItem
            // 
            this.neToolStripMenuItem.Name = "neToolStripMenuItem";
            this.neToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.neToolStripMenuItem.Text = "New Binary GA";
            this.neToolStripMenuItem.Click += new System.EventHandler(this.neToolStripMenuItem_Click);
            // 
            // newPermutationGAToolStripMenuItem
            // 
            this.newPermutationGAToolStripMenuItem.Name = "newPermutationGAToolStripMenuItem";
            this.newPermutationGAToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.newPermutationGAToolStripMenuItem.Text = "New Permutation GA";
            this.newPermutationGAToolStripMenuItem.Click += new System.EventHandler(this.newPermutationGAToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreateBinaryGA,
            this.tsbCreatePermutationGA,
            this.tsbOpenFileBi,
            this.tsbOpenFilePer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1045, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbCreateBinaryGA
            // 
            this.tsbCreateBinaryGA.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsbCreateBinaryGA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCreateBinaryGA.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tsbCreateBinaryGA.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateBinaryGA.Image")));
            this.tsbCreateBinaryGA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateBinaryGA.Name = "tsbCreateBinaryGA";
            this.tsbCreateBinaryGA.Size = new System.Drawing.Size(100, 22);
            this.tsbCreateBinaryGA.Text = "New Binary GA";
            this.tsbCreateBinaryGA.Click += new System.EventHandler(this.tsbCreateBinaryGA_Click);
            // 
            // tsbCreatePermutationGA
            // 
            this.tsbCreatePermutationGA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tsbCreatePermutationGA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCreatePermutationGA.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tsbCreatePermutationGA.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreatePermutationGA.Image")));
            this.tsbCreatePermutationGA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreatePermutationGA.Name = "tsbCreatePermutationGA";
            this.tsbCreatePermutationGA.Size = new System.Drawing.Size(137, 22);
            this.tsbCreatePermutationGA.Text = "New Permutation GA";
            this.tsbCreatePermutationGA.Click += new System.EventHandler(this.tsbCreatePermutationGA_Click);
            // 
            // tsbOpenFilePer
            // 
            this.tsbOpenFilePer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tsbOpenFilePer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOpenFilePer.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tsbOpenFilePer.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenFilePer.Image")));
            this.tsbOpenFilePer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenFilePer.Name = "tsbOpenFilePer";
            this.tsbOpenFilePer.Size = new System.Drawing.Size(143, 22);
            this.tsbOpenFilePer.Text = "Open Permutation GA";
            this.tsbOpenFilePer.Click += new System.EventHandler(this.tsbOpenFile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1045, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 485);
            this.panel1.TabIndex = 4;
            // 
            // tsbOpenFileBi
            // 
            this.tsbOpenFileBi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tsbOpenFileBi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOpenFileBi.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tsbOpenFileBi.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenFileBi.Image")));
            this.tsbOpenFileBi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenFileBi.Name = "tsbOpenFileBi";
            this.tsbOpenFileBi.Size = new System.Drawing.Size(106, 22);
            this.tsbOpenFileBi.Text = "Open Binary GA";
            this.tsbOpenFileBi.Click += new System.EventHandler(this.tsbOpenFileBi_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 556);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MyGASolver";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCreateBinaryGA;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton tsbOpenFilePer;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton tsbCreatePermutationGA;
        private System.Windows.Forms.ToolStripMenuItem newPermutationGAToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbOpenFileBi;
    }
}

