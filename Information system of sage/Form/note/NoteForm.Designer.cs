namespace Information_system_of_sage
{
    partial class NoteForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_New = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_PageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Find = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_FindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Replace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Time = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Font = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_WordWrap = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Font = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Status = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_About = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_File,
            this.menu_Edit,
            this.menu_Font,
            this.menu_View,
            this.menu_Help});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(624, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menu_File
            // 
            this.menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_New,
            this.mi_Open,
            this.mi_Save,
            this.mi_SaveAs,
            this.toolStripMenuItem1,
            this.mi_PageSetup,
            this.mi_Print,
            this.toolStripMenuItem2,
            this.mi_Exit});
            this.menu_File.Name = "menu_File";
            this.menu_File.Size = new System.Drawing.Size(57, 20);
            this.menu_File.Text = "파일(&F)";
            // 
            // mi_New
            // 
            this.mi_New.Name = "mi_New";
            this.mi_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mi_New.Size = new System.Drawing.Size(194, 22);
            this.mi_New.Text = "새로만들기(&N)";
            this.mi_New.Click += new System.EventHandler(this.mi_New_Click);
            // 
            // mi_Open
            // 
            this.mi_Open.Name = "mi_Open";
            this.mi_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mi_Open.Size = new System.Drawing.Size(194, 22);
            this.mi_Open.Text = "열기(&O)";
            this.mi_Open.Click += new System.EventHandler(this.mi_Open_Click);
            // 
            // mi_Save
            // 
            this.mi_Save.Name = "mi_Save";
            this.mi_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mi_Save.Size = new System.Drawing.Size(194, 22);
            this.mi_Save.Text = "저장(&S)";
            this.mi_Save.Click += new System.EventHandler(this.mi_Save_Click);
            // 
            // mi_SaveAs
            // 
            this.mi_SaveAs.Name = "mi_SaveAs";
            this.mi_SaveAs.Size = new System.Drawing.Size(194, 22);
            this.mi_SaveAs.Text = "다른 이름으로 저장(&A)";
            this.mi_SaveAs.Click += new System.EventHandler(this.mi_SaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
            // 
            // mi_PageSetup
            // 
            this.mi_PageSetup.Name = "mi_PageSetup";
            this.mi_PageSetup.Size = new System.Drawing.Size(194, 22);
            this.mi_PageSetup.Text = "페이지설정(&U)";
            this.mi_PageSetup.Click += new System.EventHandler(this.mi_PageSetup_Click);
            // 
            // mi_Print
            // 
            this.mi_Print.Name = "mi_Print";
            this.mi_Print.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mi_Print.Size = new System.Drawing.Size(194, 22);
            this.mi_Print.Text = "인쇄(&P)";
            this.mi_Print.Click += new System.EventHandler(this.mi_Print_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 6);
            // 
            // mi_Exit
            // 
            this.mi_Exit.Name = "mi_Exit";
            this.mi_Exit.Size = new System.Drawing.Size(194, 22);
            this.mi_Exit.Text = "끝내기(&E)";
            this.mi_Exit.Click += new System.EventHandler(this.mi_Exit_Click);
            // 
            // menu_Edit
            // 
            this.menu_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Undo,
            this.toolStripMenuItem6,
            this.mi_Cut,
            this.mi_Copy,
            this.mi_Paste,
            this.mi_Delete,
            this.toolStripMenuItem3,
            this.mi_Find,
            this.mi_FindNext,
            this.mi_Replace,
            this.toolStripMenuItem4,
            this.mi_SelectAll,
            this.mi_Time});
            this.menu_Edit.Name = "menu_Edit";
            this.menu_Edit.Size = new System.Drawing.Size(57, 20);
            this.menu_Edit.Text = "편집(&E)";
            // 
            // mi_Undo
            // 
            this.mi_Undo.Enabled = false;
            this.mi_Undo.Name = "mi_Undo";
            this.mi_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mi_Undo.Size = new System.Drawing.Size(180, 22);
            this.mi_Undo.Text = "실행취소(&U)";
            this.mi_Undo.Click += new System.EventHandler(this.mi_Undo_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(177, 6);
            // 
            // mi_Cut
            // 
            this.mi_Cut.Enabled = false;
            this.mi_Cut.Name = "mi_Cut";
            this.mi_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mi_Cut.Size = new System.Drawing.Size(180, 22);
            this.mi_Cut.Text = "잘라내기(&X)";
            this.mi_Cut.Click += new System.EventHandler(this.mi_Cut_Click);
            // 
            // mi_Copy
            // 
            this.mi_Copy.Enabled = false;
            this.mi_Copy.Name = "mi_Copy";
            this.mi_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mi_Copy.Size = new System.Drawing.Size(180, 22);
            this.mi_Copy.Text = "복사하기(&C)";
            this.mi_Copy.Click += new System.EventHandler(this.mi_Copy_Click);
            // 
            // mi_Paste
            // 
            this.mi_Paste.Name = "mi_Paste";
            this.mi_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mi_Paste.Size = new System.Drawing.Size(180, 22);
            this.mi_Paste.Text = "붙여넣기(&P)";
            this.mi_Paste.Click += new System.EventHandler(this.mi_Paste_Click);
            // 
            // mi_Delete
            // 
            this.mi_Delete.Enabled = false;
            this.mi_Delete.Name = "mi_Delete";
            this.mi_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mi_Delete.Size = new System.Drawing.Size(180, 22);
            this.mi_Delete.Text = "삭제하기(&D)";
            this.mi_Delete.Click += new System.EventHandler(this.mi_Delete_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // mi_Find
            // 
            this.mi_Find.Enabled = false;
            this.mi_Find.Name = "mi_Find";
            this.mi_Find.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mi_Find.Size = new System.Drawing.Size(180, 22);
            this.mi_Find.Text = "찾기(&F)";
            this.mi_Find.Click += new System.EventHandler(this.mi_Find_Click);
            // 
            // mi_FindNext
            // 
            this.mi_FindNext.Enabled = false;
            this.mi_FindNext.Name = "mi_FindNext";
            this.mi_FindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mi_FindNext.Size = new System.Drawing.Size(180, 22);
            this.mi_FindNext.Text = "다음찾기(&N)";
            this.mi_FindNext.Click += new System.EventHandler(this.mi_FindNext_Click);
            // 
            // mi_Replace
            // 
            this.mi_Replace.Name = "mi_Replace";
            this.mi_Replace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mi_Replace.Size = new System.Drawing.Size(180, 22);
            this.mi_Replace.Text = "바꾸기(&R)";
            this.mi_Replace.Click += new System.EventHandler(this.mi_Replace_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
            // 
            // mi_SelectAll
            // 
            this.mi_SelectAll.Name = "mi_SelectAll";
            this.mi_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mi_SelectAll.Size = new System.Drawing.Size(180, 22);
            this.mi_SelectAll.Text = "모두선택(&A)";
            this.mi_SelectAll.Click += new System.EventHandler(this.mi_SelectAll_Click);
            // 
            // mi_Time
            // 
            this.mi_Time.Name = "mi_Time";
            this.mi_Time.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mi_Time.Size = new System.Drawing.Size(180, 22);
            this.mi_Time.Text = "시간/날짜(&D)";
            this.mi_Time.Click += new System.EventHandler(this.mi_Time_Click);
            // 
            // menu_Font
            // 
            this.menu_Font.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_WordWrap,
            this.mi_Font});
            this.menu_Font.Name = "menu_Font";
            this.menu_Font.Size = new System.Drawing.Size(60, 20);
            this.menu_Font.Text = "서식(&O)";
            // 
            // mi_WordWrap
            // 
            this.mi_WordWrap.Checked = true;
            this.mi_WordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mi_WordWrap.Name = "mi_WordWrap";
            this.mi_WordWrap.Size = new System.Drawing.Size(153, 22);
            this.mi_WordWrap.Text = "자동줄바꿈(&W)";
            this.mi_WordWrap.Click += new System.EventHandler(this.mi_WordWrap_Click);
            // 
            // mi_Font
            // 
            this.mi_Font.Name = "mi_Font";
            this.mi_Font.Size = new System.Drawing.Size(153, 22);
            this.mi_Font.Text = "글꼴(&F)";
            this.mi_Font.Click += new System.EventHandler(this.mi_Font_Click);
            // 
            // menu_View
            // 
            this.menu_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Status});
            this.menu_View.Name = "menu_View";
            this.menu_View.Size = new System.Drawing.Size(59, 20);
            this.menu_View.Text = "보기(&V)";
            // 
            // mi_Status
            // 
            this.mi_Status.Name = "mi_Status";
            this.mi_Status.Size = new System.Drawing.Size(153, 22);
            this.mi_Status.Text = "상태 표시줄(&S)";
            this.mi_Status.Click += new System.EventHandler(this.mi_Status_Click);
            // 
            // menu_Help
            // 
            this.menu_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Help,
            this.toolStripMenuItem5,
            this.mi_About});
            this.menu_Help.Name = "menu_Help";
            this.menu_Help.Size = new System.Drawing.Size(72, 20);
            this.menu_Help.Text = "도움말(&H)";
            // 
            // mi_Help
            // 
            this.mi_Help.Name = "mi_Help";
            this.mi_Help.Size = new System.Drawing.Size(155, 22);
            this.mi_Help.Text = "도움말 보기(&H)";
            this.mi_Help.Click += new System.EventHandler(this.mi_Help_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 6);
            // 
            // mi_About
            // 
            this.mi_About.Name = "mi_About";
            this.mi_About.Size = new System.Drawing.Size(155, 22);
            this.mi_About.Text = "메모장 정보(&A)";
            this.mi_About.Click += new System.EventHandler(this.mi_About_Click);
            // 
            // txtNote
            // 
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Location = new System.Drawing.Point(0, 24);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNote.Size = new System.Drawing.Size(624, 417);
            this.txtNote.TabIndex = 1;
            this.txtNote.TextChanged += new System.EventHandler(this.txtMemo_TextChanged);
            this.txtNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMemo_KeyUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.txt";
            this.openFileDialog1.Filter = "텍스트문서(*.txt)|*.txt|모든파일(*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "*txt";
            this.saveFileDialog1.Filter = "텍스트문서(*.txt)|*.txt|모든파일(*.*)|*.*";
            // 
            // fontDialog1
            // 
            this.fontDialog1.ShowColor = true;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Enabled = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.tssTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel1.Text = "Maker : Naram";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(207, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel3.Text = "Line 1, Col 1";
            this.toolStripStatusLabel3.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(207, 17);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // tssTime
            // 
            this.tssTime.Name = "tssTime";
            this.tssTime.Size = new System.Drawing.Size(31, 17);
            this.tssTime.Text = "시계";
            this.tssTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "NoteForm";
            this.Text = "제목없음";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menu_File;
        private System.Windows.Forms.ToolStripMenuItem menu_Edit;
        private System.Windows.Forms.ToolStripMenuItem menu_Font;
        private System.Windows.Forms.ToolStripMenuItem menu_View;
        private System.Windows.Forms.ToolStripMenuItem menu_Help;
        private System.Windows.Forms.ToolStripMenuItem mi_New;
        private System.Windows.Forms.ToolStripMenuItem mi_Open;
        private System.Windows.Forms.ToolStripMenuItem mi_Save;
        private System.Windows.Forms.ToolStripMenuItem mi_SaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mi_PageSetup;
        private System.Windows.Forms.ToolStripMenuItem mi_Print;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mi_Exit;
        private System.Windows.Forms.ToolStripMenuItem mi_Undo;
        private System.Windows.Forms.ToolStripMenuItem mi_Cut;
        private System.Windows.Forms.ToolStripMenuItem mi_Copy;
        private System.Windows.Forms.ToolStripMenuItem mi_Paste;
        private System.Windows.Forms.ToolStripMenuItem mi_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mi_Find;
        private System.Windows.Forms.ToolStripMenuItem mi_FindNext;
        private System.Windows.Forms.ToolStripMenuItem mi_Replace;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mi_SelectAll;
        private System.Windows.Forms.ToolStripMenuItem mi_WordWrap;
        private System.Windows.Forms.ToolStripMenuItem mi_Font;
        private System.Windows.Forms.ToolStripMenuItem mi_Status;
        private System.Windows.Forms.ToolStripMenuItem mi_Help;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mi_About;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        public System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tssTime;
        private System.Windows.Forms.ToolStripMenuItem mi_Time;
    }
}