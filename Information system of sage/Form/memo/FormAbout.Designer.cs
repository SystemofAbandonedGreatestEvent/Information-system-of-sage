namespace Information_system_of_sage
{
    partial class FormAbout
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
            this.btnClose = new System.Windows.Forms.Button();
            this.spltCntnr = new System.Windows.Forms.SplitContainer();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.pctbLogo = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spltCntnr)).BeginInit();
            this.spltCntnr.Panel1.SuspendLayout();
            this.spltCntnr.Panel2.SuspendLayout();
            this.spltCntnr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(377, 366);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "확인";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // spltCntnr
            // 
            this.spltCntnr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltCntnr.Location = new System.Drawing.Point(0, 0);
            this.spltCntnr.Name = "spltCntnr";
            this.spltCntnr.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltCntnr.Panel1
            // 
            this.spltCntnr.Panel1.Controls.Add(this.pctbLogo);
            // 
            // spltCntnr.Panel2
            // 
            this.spltCntnr.Panel2.Controls.Add(this.lblVersion);
            this.spltCntnr.Panel2.Controls.Add(this.lblOrganization);
            this.spltCntnr.Size = new System.Drawing.Size(464, 401);
            this.spltCntnr.SplitterDistance = 108;
            this.spltCntnr.SplitterWidth = 2;
            this.spltCntnr.TabIndex = 1;
            // 
            // lblOrganization
            // 
            this.lblOrganization.AutoSize = true;
            this.lblOrganization.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrganization.Location = new System.Drawing.Point(12, 18);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(40, 13);
            this.lblOrganization.TabIndex = 0;
            this.lblOrganization.Text = "Sage";
            // 
            // pctbLogo
            // 
            this.pctbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctbLogo.Location = new System.Drawing.Point(0, 0);
            this.pctbLogo.Name = "pctbLogo";
            this.pctbLogo.Size = new System.Drawing.Size(464, 108);
            this.pctbLogo.TabIndex = 0;
            this.pctbLogo.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 41);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(49, 12);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "버전 0.1";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 401);
            this.Controls.Add(this.spltCntnr);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.Text = "프로그램 정보";
            this.spltCntnr.Panel1.ResumeLayout(false);
            this.spltCntnr.Panel2.ResumeLayout(false);
            this.spltCntnr.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltCntnr)).EndInit();
            this.spltCntnr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer spltCntnr;
        private System.Windows.Forms.PictureBox pctbLogo;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.Label lblVersion;
    }
}