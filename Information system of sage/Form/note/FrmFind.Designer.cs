namespace Information_system_of_sage
{
    partial class FrmFind
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
            this.lblFind = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkCase = new System.Windows.Forms.CheckBox();
            this.gbDirection = new System.Windows.Forms.GroupBox();
            this.rdoDown = new System.Windows.Forms.RadioButton();
            this.rdoUp = new System.Windows.Forms.RadioButton();
            this.gbDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(12, 28);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(72, 12);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "찾을내용(&N)";
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(313, 23);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(94, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "다음찾기(&F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(90, 25);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(210, 21);
            this.txtFind.TabIndex = 2;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(313, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkCase
            // 
            this.chkCase.AutoSize = true;
            this.chkCase.Location = new System.Drawing.Point(14, 82);
            this.chkCase.Name = "chkCase";
            this.chkCase.Size = new System.Drawing.Size(115, 16);
            this.chkCase.TabIndex = 4;
            this.chkCase.Text = "대소문자구분(&C)";
            this.chkCase.UseVisualStyleBackColor = true;
            // 
            // gbDirection
            // 
            this.gbDirection.Controls.Add(this.rdoDown);
            this.gbDirection.Controls.Add(this.rdoUp);
            this.gbDirection.ForeColor = System.Drawing.SystemColors.Desktop;
            this.gbDirection.Location = new System.Drawing.Point(135, 59);
            this.gbDirection.Name = "gbDirection";
            this.gbDirection.Size = new System.Drawing.Size(165, 50);
            this.gbDirection.TabIndex = 5;
            this.gbDirection.TabStop = false;
            this.gbDirection.Text = "방향";
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
            // FrmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 121);
            this.Controls.Add(this.gbDirection);
            this.Controls.Add(this.chkCase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblFind);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFind";
            this.Text = "찾기";
            this.gbDirection.ResumeLayout(false);
            this.gbDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkCase;
        private System.Windows.Forms.GroupBox gbDirection;
        private System.Windows.Forms.RadioButton rdoDown;
        private System.Windows.Forms.RadioButton rdoUp;
    }
}