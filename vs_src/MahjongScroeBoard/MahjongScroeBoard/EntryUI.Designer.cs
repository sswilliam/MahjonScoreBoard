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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.thridPartyCheck = new System.Windows.Forms.CheckBox();
            this.thirdPartyName = new System.Windows.Forms.TextBox();
            this.dongRadio = new System.Windows.Forms.RadioButton();
            this.xiRadio = new System.Windows.Forms.RadioButton();
            this.nanRadio = new System.Windows.Forms.RadioButton();
            this.beiRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // dongBtn
            // 
            this.dongBtn.Enabled = false;
            this.dongBtn.Location = new System.Drawing.Point(174, 82);
            this.dongBtn.Name = "dongBtn";
            this.dongBtn.Size = new System.Drawing.Size(55, 51);
            this.dongBtn.TabIndex = 0;
            this.dongBtn.Text = "东";
            this.dongBtn.UseVisualStyleBackColor = true;
            // 
            // nanbtn
            // 
            this.nanbtn.Enabled = false;
            this.nanbtn.Location = new System.Drawing.Point(235, 138);
            this.nanbtn.Name = "nanbtn";
            this.nanbtn.Size = new System.Drawing.Size(55, 51);
            this.nanbtn.TabIndex = 1;
            this.nanbtn.Text = "南";
            this.nanbtn.UseVisualStyleBackColor = true;
            // 
            // xiBtn
            // 
            this.xiBtn.Enabled = false;
            this.xiBtn.Location = new System.Drawing.Point(174, 194);
            this.xiBtn.Name = "xiBtn";
            this.xiBtn.Size = new System.Drawing.Size(55, 51);
            this.xiBtn.TabIndex = 2;
            this.xiBtn.Text = "西";
            this.xiBtn.UseVisualStyleBackColor = true;
            // 
            // beiBtn
            // 
            this.beiBtn.Enabled = false;
            this.beiBtn.Location = new System.Drawing.Point(113, 138);
            this.beiBtn.Name = "beiBtn";
            this.beiBtn.Size = new System.Drawing.Size(55, 51);
            this.beiBtn.TabIndex = 4;
            this.beiBtn.Text = "北";
            this.beiBtn.UseVisualStyleBackColor = true;
            // 
            // dongName
            // 
            this.dongName.Location = new System.Drawing.Point(153, 58);
            this.dongName.Name = "dongName";
            this.dongName.Size = new System.Drawing.Size(100, 21);
            this.dongName.TabIndex = 5;
            // 
            // xiName
            // 
            this.xiName.Location = new System.Drawing.Point(153, 260);
            this.xiName.Name = "xiName";
            this.xiName.Size = new System.Drawing.Size(100, 21);
            this.xiName.TabIndex = 6;
            // 
            // nanName
            // 
            this.nanName.Location = new System.Drawing.Point(302, 155);
            this.nanName.Name = "nanName";
            this.nanName.Size = new System.Drawing.Size(100, 21);
            this.nanName.TabIndex = 7;
            // 
            // beiName
            // 
            this.beiName.Location = new System.Drawing.Point(7, 155);
            this.beiName.Name = "beiName";
            this.beiName.Size = new System.Drawing.Size(100, 21);
            this.beiName.TabIndex = 8;
            // 
            // fightBtn
            // 
            this.fightBtn.Location = new System.Drawing.Point(134, 329);
            this.fightBtn.Name = "fightBtn";
            this.fightBtn.Size = new System.Drawing.Size(137, 38);
            this.fightBtn.TabIndex = 9;
            this.fightBtn.Text = "开战";
            this.fightBtn.UseVisualStyleBackColor = true;
            this.fightBtn.Click += new System.EventHandler(this.fightBtn_Click);
            // 
            // entryInfo
            // 
            this.entryInfo.AutoSize = true;
            this.entryInfo.ForeColor = System.Drawing.Color.Red;
            this.entryInfo.Location = new System.Drawing.Point(132, 312);
            this.entryInfo.Name = "entryInfo";
            this.entryInfo.Size = new System.Drawing.Size(0, 12);
            this.entryInfo.TabIndex = 10;
            this.entryInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(63, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "请按照QQ的桌子顺序填入选手名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "~~~七星阁打造神奇QQ竞技平台~~~";
            // 
            // thridPartyCheck
            // 
            this.thridPartyCheck.AutoSize = true;
            this.thridPartyCheck.Location = new System.Drawing.Point(96, 290);
            this.thridPartyCheck.Name = "thridPartyCheck";
            this.thridPartyCheck.Size = new System.Drawing.Size(84, 16);
            this.thridPartyCheck.TabIndex = 13;
            this.thridPartyCheck.Text = "第三方裁判";
            this.thridPartyCheck.UseVisualStyleBackColor = true;
            this.thridPartyCheck.CheckedChanged += new System.EventHandler(this.thridPartyCheck_CheckedChanged);
            // 
            // thirdPartyName
            // 
            this.thirdPartyName.Location = new System.Drawing.Point(187, 288);
            this.thirdPartyName.Name = "thirdPartyName";
            this.thirdPartyName.Size = new System.Drawing.Size(142, 21);
            this.thirdPartyName.TabIndex = 14;
            // 
            // dongRadio
            // 
            this.dongRadio.AutoSize = true;
            this.dongRadio.Location = new System.Drawing.Point(260, 59);
            this.dongRadio.Name = "dongRadio";
            this.dongRadio.Size = new System.Drawing.Size(47, 16);
            this.dongRadio.TabIndex = 15;
            this.dongRadio.TabStop = true;
            this.dongRadio.Text = "裁判";
            this.dongRadio.UseVisualStyleBackColor = true;
            // 
            // xiRadio
            // 
            this.xiRadio.AutoSize = true;
            this.xiRadio.Location = new System.Drawing.Point(260, 261);
            this.xiRadio.Name = "xiRadio";
            this.xiRadio.Size = new System.Drawing.Size(47, 16);
            this.xiRadio.TabIndex = 16;
            this.xiRadio.TabStop = true;
            this.xiRadio.Text = "裁判";
            this.xiRadio.UseVisualStyleBackColor = true;
            // 
            // nanRadio
            // 
            this.nanRadio.AutoSize = true;
            this.nanRadio.Location = new System.Drawing.Point(329, 179);
            this.nanRadio.Name = "nanRadio";
            this.nanRadio.Size = new System.Drawing.Size(47, 16);
            this.nanRadio.TabIndex = 17;
            this.nanRadio.TabStop = true;
            this.nanRadio.Text = "裁判";
            this.nanRadio.UseVisualStyleBackColor = true;
            // 
            // beiRadio
            // 
            this.beiRadio.AutoSize = true;
            this.beiRadio.Location = new System.Drawing.Point(31, 179);
            this.beiRadio.Name = "beiRadio";
            this.beiRadio.Size = new System.Drawing.Size(47, 16);
            this.beiRadio.TabIndex = 18;
            this.beiRadio.TabStop = true;
            this.beiRadio.Text = "裁判";
            this.beiRadio.UseVisualStyleBackColor = true;
            // 
            // EntryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 390);
            this.Controls.Add(this.beiRadio);
            this.Controls.Add(this.nanRadio);
            this.Controls.Add(this.xiRadio);
            this.Controls.Add(this.dongRadio);
            this.Controls.Add(this.thirdPartyName);
            this.Controls.Add(this.thridPartyCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.MaximumSize = new System.Drawing.Size(430, 428);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 428);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox thridPartyCheck;
        private System.Windows.Forms.TextBox thirdPartyName;
        private System.Windows.Forms.RadioButton dongRadio;
        private System.Windows.Forms.RadioButton xiRadio;
        private System.Windows.Forms.RadioButton nanRadio;
        private System.Windows.Forms.RadioButton beiRadio;
    }
}

