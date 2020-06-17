namespace OSS_EXP4
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonAddMax = new System.Windows.Forms.Button();
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.RRListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DPListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SRTListView = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SPNListView = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "轮转调度RR";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "优先数调度DP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "最短进程优先(SPN)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "最短剩余时间优先(SRT)";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(405, 114);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(94, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "创建一个进程";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonAddMax
            // 
            this.buttonAddMax.Location = new System.Drawing.Point(405, 182);
            this.buttonAddMax.Name = "buttonAddMax";
            this.buttonAddMax.Size = new System.Drawing.Size(94, 23);
            this.buttonAddMax.TabIndex = 5;
            this.buttonAddMax.Text = "创建十个进程";
            this.buttonAddMax.UseVisualStyleBackColor = true;
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Location = new System.Drawing.Point(405, 252);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(94, 23);
            this.buttonSimulate.TabIndex = 6;
            this.buttonSimulate.Text = "开始调度";
            this.buttonSimulate.UseVisualStyleBackColor = true;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(68, 65);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(118, 17);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // RRListView
            // 
            this.RRListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.RRListView.HideSelection = false;
            this.RRListView.Location = new System.Drawing.Point(12, 35);
            this.RRListView.Name = "RRListView";
            this.RRListView.Size = new System.Drawing.Size(374, 240);
            this.RRListView.TabIndex = 8;
            this.RRListView.UseCompatibleStateImageBehavior = false;
            this.RRListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 54;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "进度";
            this.columnHeader2.Width = 154;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "优先数";
            this.columnHeader3.Width = 58;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "剩余运行时间";
            this.columnHeader4.Width = 104;
            // 
            // DPListView
            // 
            this.DPListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.DPListView.HideSelection = false;
            this.DPListView.Location = new System.Drawing.Point(543, 35);
            this.DPListView.Name = "DPListView";
            this.DPListView.Size = new System.Drawing.Size(374, 240);
            this.DPListView.TabIndex = 9;
            this.DPListView.UseCompatibleStateImageBehavior = false;
            this.DPListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 54;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "进度";
            this.columnHeader6.Width = 154;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "优先数";
            this.columnHeader7.Width = 58;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "剩余运行时间";
            this.columnHeader8.Width = 104;
            // 
            // SRTListView
            // 
            this.SRTListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.SRTListView.HideSelection = false;
            this.SRTListView.Location = new System.Drawing.Point(12, 350);
            this.SRTListView.Name = "SRTListView";
            this.SRTListView.Size = new System.Drawing.Size(374, 240);
            this.SRTListView.TabIndex = 10;
            this.SRTListView.UseCompatibleStateImageBehavior = false;
            this.SRTListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ID";
            this.columnHeader9.Width = 54;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "进度";
            this.columnHeader10.Width = 154;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "优先数";
            this.columnHeader11.Width = 58;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "剩余运行时间";
            this.columnHeader12.Width = 104;
            // 
            // SPNListView
            // 
            this.SPNListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.SPNListView.HideSelection = false;
            this.SPNListView.Location = new System.Drawing.Point(533, 350);
            this.SPNListView.Name = "SPNListView";
            this.SPNListView.Size = new System.Drawing.Size(374, 240);
            this.SPNListView.TabIndex = 11;
            this.SPNListView.UseCompatibleStateImageBehavior = false;
            this.SPNListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "ID";
            this.columnHeader13.Width = 54;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "进度";
            this.columnHeader14.Width = 154;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "优先数";
            this.columnHeader15.Width = 58;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "剩余运行时间";
            this.columnHeader16.Width = 104;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 627);
            this.Controls.Add(this.SPNListView);
            this.Controls.Add(this.SRTListView);
            this.Controls.Add(this.DPListView);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.RRListView);
            this.Controls.Add(this.buttonSimulate);
            this.Controls.Add(this.buttonAddMax);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonAddMax;
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListView RRListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView DPListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView SRTListView;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ListView SPNListView;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
    }
}

