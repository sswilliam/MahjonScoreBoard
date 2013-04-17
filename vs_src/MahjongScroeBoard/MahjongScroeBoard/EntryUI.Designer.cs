namespace MahjongScroeBoard
{
    partial class EntryUI
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
            this.dongBtn = new System.Windows.Forms.Button();
            this.nanbtn = new System.Windows.Forms.Button();
            this.xiBtn = new System.Windows.Forms.Button();
            this.beiBtn = new System.Windows.Forms.Button();
            this.dongName = new System.Windows.Forms.TextBox();
            this.xiName = new System.Windows.Forms.TextBox();
            this.nanName = new System.Windows.Forms.TextBox();
            this.beiName = new System.Windows.Forms.TextBox();
            this.fightBtn = new System.Windows.Forms.Button();
            this.entryInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dongBtn
            // 
            this.dongBtn.Enabled = false;
            this.dongBtn.Location = new System.Drawing.Point(174, 44);
            this.dongBtn.Name = "dongBtn";
            this.dongBtn.Size = new System.Drawing.Size(55, 55);
            this.dongBtn.TabIndex = 0;
            this.dongBtn.Text = "东";
            this.dongBtn.UseVisualStyleBackColor = true;
            // 
            // nanbtn
            // 
            this.nanbtn.Enabled = false;
            this.nanbtn.Location = new System.Drawing.Point(235, 105);
            this.nanbtn.Name = "nanbtn";
            this.nanbtn.Size = new System.Drawing.Size(55, 55);
            this.nanbtn.TabIndex = 1;
            this.nanbtn.Text = "南";
            this.nanbtn.UseVisualStyleBackColor = true;
            // 
            // xiBtn
            // 
            this.xiBtn.Enabled = false;
            this.xiBtn.Location = new System.Drawing.Point(174, 166);
            this.xiBtn.Name = "xiBtn";
            this.xiBtn.Size = new System.Drawing.Size(55, 55);
            this.xiBtn.TabIndex = 2;
            this.xiBtn.Text = "西";
            this.xiBtn.UseVisualStyleBackColor = true;
            // 
            // beiBtn
            // 
            this.beiBtn.Enabled = false;
            this.beiBtn.Location = new System.Drawing.Point(113, 105);
            this.beiBtn.Name = "beiBtn";
            this.beiBtn.Size = new System.Drawing.Size(55, 55);
            this.beiBtn.TabIndex = 4;
            this.beiBtn.Text = "北";
            this.beiBtn.UseVisualStyleBackColor = true;
            // 
            // dongName
            // 
            this.dongName.Location = new System.Drawing.Point(153, 18);
            this.dongName.Name = "dongName";
            this.dongName.Size = new System.Drawing.Size(100, 20);
            this.dongName.TabIndex = 5;
            this.dongName.Text = "aa";
            // 
            // xiName
            // 
            this.xiName.Location = new System.Drawing.Point(153, 237);
            this.xiName.Name = "xiName";
            this.xiName.Size = new System.Drawing.Size(100, 20);
            this.xiName.TabIndex = 6;
            this.xiName.Text = "cc";
            // 
            // nanName
            // 
            this.nanName.Location = new System.Drawing.Point(302, 123);
            this.nanName.Name = "nanName";
            this.nanName.Size = new System.Drawing.Size(100, 20);
            this.nanName.TabIndex = 7;
            this.nanName.Text = "bb";
            // 
            // beiName
            // 
            this.beiName.Location = new System.Drawing.Point(7, 123);
            this.beiName.Name = "beiName";
            this.beiName.Size = new System.Drawing.Size(100, 20);
            this.beiName.TabIndex = 8;
            this.beiName.Text = "dd";
            // 
            // fightBtn
            // 
            this.fightBtn.Location = new System.Drawing.Point(135, 297);
            this.fightBtn.Name = "fightBtn";
            this.fightBtn.Size = new System.Drawing.Size(137, 41);
            this.fightBtn.TabIndex = 9;
            this.fightBtn.Text = "开战";
            this.fightBtn.UseVisualStyleBackColor = true;
            this.fightBtn.Click += new System.EventHandler(this.fightBtn_Click);
            // 
            // entryInfo
            // 
            this.entryInfo.AutoSize = true;
            this.entryInfo.ForeColor = System.Drawing.Color.Red;
            this.entryInfo.Location = new System.Drawing.Point(132, 272);
            this.entryInfo.Name = "entryInfo";
            this.entryInfo.Size = new System.Drawing.Size(0, 13);
            this.entryInfo.TabIndex = 10;
            this.entryInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EntryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 347);
            this.Controls.Add(this.entryInfo);
            this.Controls.Add(this.fightBtn);
            this.Controls.Add(this.beiName);
            this.Controls.Add(this.nanName);
            this.Controls.Add(this.xiName);
            this.Controls.Add(this.dongName);
            this.Controls.Add(this.beiBtn);
            this.Controls.Add(this.xiBtn);
            this.Controls.Add(this.nanbtn);
            this.Controls.Add(this.dongBtn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 385);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 385);
            this.Name = "EntryUI";
            this.Text = "Mahjone Score Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EntryUI_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dongBtn;
        private System.Windows.Forms.Button nanbtn;
        private System.Windows.Forms.Button xiBtn;
        private System.Windows.Forms.Button beiBtn;
        private System.Windows.Forms.TextBox dongName;
        private System.Windows.Forms.TextBox xiName;
        private System.Windows.Forms.TextBox nanName;
        private System.Windows.Forms.TextBox beiName;
        private System.Windows.Forms.Button fightBtn;
        private System.Windows.Forms.Label entryInfo;
    }
}

