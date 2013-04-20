namespace MahjongScroeBoard
{
    partial class ManualScoreBoard
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
            this.label1 = new System.Windows.Forms.Label();
            this.winnerName = new System.Windows.Forms.ComboBox();
            this.selfMo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.paoMember = new System.Windows.Forms.ComboBox();
            this.fanNumber = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.ManualInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "获胜者:";
            // 
            // winnerName
            // 
            this.winnerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.winnerName.FormattingEnabled = true;
            this.winnerName.Location = new System.Drawing.Point(64, 8);
            this.winnerName.Name = "winnerName";
            this.winnerName.Size = new System.Drawing.Size(121, 20);
            this.winnerName.TabIndex = 1;
            // 
            // selfMo
            // 
            this.selfMo.AutoSize = true;
            this.selfMo.Location = new System.Drawing.Point(193, 10);
            this.selfMo.Name = "selfMo";
            this.selfMo.Size = new System.Drawing.Size(48, 16);
            this.selfMo.TabIndex = 2;
            this.selfMo.Text = "自摸";
            this.selfMo.UseVisualStyleBackColor = true;
            this.selfMo.CheckedChanged += new System.EventHandler(this.selfMo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "点炮者:";
            // 
            // paoMember
            // 
            this.paoMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paoMember.FormattingEnabled = true;
            this.paoMember.Location = new System.Drawing.Point(64, 62);
            this.paoMember.Name = "paoMember";
            this.paoMember.Size = new System.Drawing.Size(121, 20);
            this.paoMember.TabIndex = 4;
            // 
            // fanNumber
            // 
            this.fanNumber.FormattingEnabled = true;
            this.fanNumber.Location = new System.Drawing.Point(64, 35);
            this.fanNumber.Name = "fanNumber";
            this.fanNumber.Size = new System.Drawing.Size(121, 20);
            this.fanNumber.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "番数:";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(60, 106);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 21);
            this.okBtn.TabIndex = 7;
            this.okBtn.Text = "确定";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(141, 106);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 21);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ManualInfo
            // 
            this.ManualInfo.AutoSize = true;
            this.ManualInfo.ForeColor = System.Drawing.Color.Red;
            this.ManualInfo.Location = new System.Drawing.Point(16, 90);
            this.ManualInfo.Name = "ManualInfo";
            this.ManualInfo.Size = new System.Drawing.Size(0, 12);
            this.ManualInfo.TabIndex = 9;
            // 
            // ManualScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 134);
            this.Controls.Add(this.ManualInfo);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.fanNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.paoMember);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selfMo);
            this.Controls.Add(this.winnerName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 172);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 172);
            this.Name = "ManualScoreBoard";
            this.Text = "Mahjong Score Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManualScoreBoard_FormClosing);
            this.Load += new System.EventHandler(this.ManualScoreBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox winnerName;
        private System.Windows.Forms.CheckBox selfMo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox paoMember;
        private System.Windows.Forms.ComboBox fanNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label ManualInfo;
    }
}