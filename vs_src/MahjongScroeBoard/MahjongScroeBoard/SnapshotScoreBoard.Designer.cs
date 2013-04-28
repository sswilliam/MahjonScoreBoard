namespace MahjongScroeBoard
{
    partial class SnapshotScoreBoard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.snapshotContent = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.beiScore = new System.Windows.Forms.TextBox();
            this.xiScore = new System.Windows.Forms.TextBox();
            this.nanScore = new System.Windows.Forms.TextBox();
            this.dongScore = new System.Windows.Forms.TextBox();
            this.beiName = new System.Windows.Forms.TextBox();
            this.xiName = new System.Windows.Forms.TextBox();
            this.nanName = new System.Windows.Forms.TextBox();
            this.dongName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.snapshotInfo = new System.Windows.Forms.Label();
            this.retakeBtn = new System.Windows.Forms.Button();
            this.fanbox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotContent)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.snapshotContent);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 463);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "截图";
            // 
            // snapshotContent
            // 
            this.snapshotContent.Location = new System.Drawing.Point(7, 20);
            this.snapshotContent.Name = "snapshotContent";
            this.snapshotContent.Size = new System.Drawing.Size(410, 436);
            this.snapshotContent.TabIndex = 0;
            this.snapshotContent.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.beiScore);
            this.groupBox2.Controls.Add(this.xiScore);
            this.groupBox2.Controls.Add(this.nanScore);
            this.groupBox2.Controls.Add(this.dongScore);
            this.groupBox2.Controls.Add(this.beiName);
            this.groupBox2.Controls.Add(this.xiName);
            this.groupBox2.Controls.Add(this.nanName);
            this.groupBox2.Controls.Add(this.dongName);
            this.groupBox2.Location = new System.Drawing.Point(1, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "成绩";
            // 
            // beiScore
            // 
            this.beiScore.Location = new System.Drawing.Point(304, 46);
            this.beiScore.Name = "beiScore";
            this.beiScore.Size = new System.Drawing.Size(84, 20);
            this.beiScore.TabIndex = 7;
            // 
            // xiScore
            // 
            this.xiScore.Location = new System.Drawing.Point(213, 46);
            this.xiScore.Name = "xiScore";
            this.xiScore.Size = new System.Drawing.Size(84, 20);
            this.xiScore.TabIndex = 6;
            // 
            // nanScore
            // 
            this.nanScore.Location = new System.Drawing.Point(122, 46);
            this.nanScore.Name = "nanScore";
            this.nanScore.Size = new System.Drawing.Size(84, 20);
            this.nanScore.TabIndex = 5;
            // 
            // dongScore
            // 
            this.dongScore.Location = new System.Drawing.Point(31, 46);
            this.dongScore.Name = "dongScore";
            this.dongScore.Size = new System.Drawing.Size(84, 20);
            this.dongScore.TabIndex = 4;
            // 
            // beiName
            // 
            this.beiName.Enabled = false;
            this.beiName.Location = new System.Drawing.Point(304, 20);
            this.beiName.Name = "beiName";
            this.beiName.Size = new System.Drawing.Size(84, 20);
            this.beiName.TabIndex = 3;
            // 
            // xiName
            // 
            this.xiName.Enabled = false;
            this.xiName.Location = new System.Drawing.Point(213, 20);
            this.xiName.Name = "xiName";
            this.xiName.Size = new System.Drawing.Size(84, 20);
            this.xiName.TabIndex = 2;
            // 
            // nanName
            // 
            this.nanName.Enabled = false;
            this.nanName.Location = new System.Drawing.Point(122, 20);
            this.nanName.Name = "nanName";
            this.nanName.Size = new System.Drawing.Size(84, 20);
            this.nanName.TabIndex = 1;
            // 
            // dongName
            // 
            this.dongName.Enabled = false;
            this.dongName.Location = new System.Drawing.Point(31, 20);
            this.dongName.Name = "dongName";
            this.dongName.Size = new System.Drawing.Size(84, 20);
            this.dongName.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fanbox);
            this.groupBox3.Location = new System.Drawing.Point(1, 551);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "番种";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(234, 683);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 33);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(334, 683);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 33);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // snapshotInfo
            // 
            this.snapshotInfo.AutoSize = true;
            this.snapshotInfo.ForeColor = System.Drawing.Color.Red;
            this.snapshotInfo.Location = new System.Drawing.Point(5, 654);
            this.snapshotInfo.Name = "snapshotInfo";
            this.snapshotInfo.Size = new System.Drawing.Size(0, 13);
            this.snapshotInfo.TabIndex = 5;
            // 
            // retakeBtn
            // 
            this.retakeBtn.Location = new System.Drawing.Point(12, 683);
            this.retakeBtn.Name = "retakeBtn";
            this.retakeBtn.Size = new System.Drawing.Size(75, 33);
            this.retakeBtn.TabIndex = 6;
            this.retakeBtn.Text = "重拍";
            this.retakeBtn.UseVisualStyleBackColor = true;
            this.retakeBtn.Click += new System.EventHandler(this.retakeBtn_Click);
            // 
            // fanbox
            // 
            this.fanbox.Location = new System.Drawing.Point(7, 20);
            this.fanbox.Multiline = true;
            this.fanbox.Name = "fanbox";
            this.fanbox.Size = new System.Drawing.Size(409, 74);
            this.fanbox.TabIndex = 0;
            // 
            // SnapshotScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 722);
            this.Controls.Add(this.retakeBtn);
            this.Controls.Add(this.snapshotInfo);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(445, 760);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(445, 760);
            this.Name = "SnapshotScoreBoard";
            this.Text = "Mahjong Score Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SnapshotScoreBoard_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.snapshotContent)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox snapshotContent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox dongName;
        private System.Windows.Forms.TextBox beiName;
        private System.Windows.Forms.TextBox xiName;
        private System.Windows.Forms.TextBox nanName;
        private System.Windows.Forms.TextBox beiScore;
        private System.Windows.Forms.TextBox xiScore;
        private System.Windows.Forms.TextBox nanScore;
        private System.Windows.Forms.TextBox dongScore;
        private System.Windows.Forms.Label snapshotInfo;
        private System.Windows.Forms.Button retakeBtn;
        private System.Windows.Forms.TextBox fanbox;

    }
}