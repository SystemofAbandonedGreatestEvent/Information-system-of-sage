namespace Information_system_of_sage
{
    partial class FrmReplace
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
            this.chkCase = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.lblReplace = new System.Windows.Forms.Label();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.rdoDown = new System.Windows.Forms.RadioButton();
            this.rdoUp = new System.Windows.Forms.RadioButton();
            this.gbDirection = new System.Windows.Forms.GroupBox();
            this.gbDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCase
            // 
            this.chkCase.AutoSize = true;
            this.chkCase.Location = new System.Drawing.Point(12, 102);
            this.chkCase.Name = "chkCase";
            this.chkCase.Size = new System.Drawing.Size(115, 16);
            this.chkCase.TabIndex = 10;
            this.chkCase.Text = "대소문자구분(&C)";
            this.chkCase.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(90, 19);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(210, 21);
            this.txtFind.TabIndex = 8;
            this.txtFind.TextChanged += new System.EventHandler(this.findTextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(312, 17);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(94, 23);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "다음찾기(&F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(12, 22);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(72, 12);
            this.lblFind.TabIndex = 6;
            this.lblFind.Text = "찾을내용(&N)";
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(12, 51);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(71, 12);
            this.lblReplace.TabIndex = 12;
            this.lblReplace.Text = "바꿀내용(&P)";
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(90, 48);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(210, 21);
            this.txtReplace.TabIndex = 13;
            this.txtReplace.TextChanged += new System.EventHandler(this.findTextChanged);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Enabled = false;
            this.btnReplaceAll.Location = new System.Drawing.Point(312, 75);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(94, 23);
            this.btnReplaceAll.TabIndex = 14;
            this.btnReplaceAll.Text = "모두바꾸기(&A)";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Enabled = false;
            this.btnReplace.Location = new System.Drawing.Point(312, 46);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(94, 23);
            this.btnReplace.TabIndex = 15;
            this.btnReplace.Text = "바꾸기(&R)";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // rdoDown
            // 
            this.rdoDown.AutoSize = true;
            this.rdoDown.Location = new System.Drawing.Point(82, 22);
            this.rdoDown.Name = "rdoDown";
            this.rdoDown.Size = new System.Drawing.Size(77, 16);
            this.rdoDown.TabIndex = 1;
            this.rdoDown.TabStop = true;
            this.rdoDown.Text = "아래로(&D)";
            this.rdoDown.UseVisualStyleBackColor = true;
            // 
            // rdoUp
            // 
            this.rdoUp.AutoSize = true;
            this.rdoUp.Location = new System.Drawing.Point(6, 22);
            this.rdoUp.Name = "rdoUp";
            this.rdoUp.Size = new System.Drawing.Size(65, 16);
            this.rdoUp.TabIndex = 0;
            this.rdoUp.TabStop = true;
            this.rdoUp.Text = "위로(&U)";
            this.rdoUp.UseVisualStyleBackColor = true;
            // 
            // gbDirection
            // 
            this.gbDirection.Controls.Add(this.rdoDown);
            this.gbDirection.Controls.Add(this.rdoUp);
            this.gbDirection.ForeColor = System.Drawing.SystemColors.Desktop;
            this.gbDirection.Location = new System.Drawing.Point(135, 79);
            this.gbDirection.Name = "gbDirection";
            this.gbDirection.Size = new System.Drawing.Size(165, 50);
            this.gbDirection.TabIndex = 16;
            this.gbDirection.TabStop = false;
            this.gbDirection.Text = "방향";
            // 
            // FrmReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 141);
            this.Controls.Add(this.gbDirection);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.chkCase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblFind);
            this.Name = "FrmReplace";
            this.Text = "바꾸기";
            this.gbDirection.ResumeLayout(false);
            this.gbDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCase;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.RadioButton rdoDown;
        private System.Windows.Forms.RadioButton rdoUp;
        private System.Windows.Forms.GroupBox gbDirection;
    }
}