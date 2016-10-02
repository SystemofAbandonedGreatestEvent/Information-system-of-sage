using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Information_system_of_sage
{
    public partial class MainForm : Form
    {
        #region 0. 전역변수 및 생성자

        NoteForm note = new NoteForm();
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 1. 메뉴 스트럽 파일
        //
        //새 노트 클릭
        //
        private void menuItemNew_Click(object sender, EventArgs e)  
        {            
            note.Show();
        }
        //
        //새 노트북 클릭
        //
        private void menuItemNewNoteBook_Click(object sender, EventArgs e)
        {

        }
        //
        //파일 첨부 클릭
        //
        private void menuItemFileAttach_Click(object sender, EventArgs e)
        {

        }
        //
        //저장 클릭
        //
        private void menuItemSave_Click(object sender, EventArgs e)
        {

        }
        //
        //인쇄 클릭
        //
        private void menuItemPrint_Click(object sender, EventArgs e)
        {
            printDocument.DocumentName = note.txtNote.Text;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch
                {
                    MessageBox.Show("인쇄하는 도중에 에러가 발생했습니다.",
                        "인쇄오류", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        //
        //인쇄 미리보기클릭
        //
        private void menuItemPreview_Click(object sender, EventArgs e)
        {
            printDocument.DocumentName = note.txtNote.Text;
            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch
                {
                    MessageBox.Show("인쇄하는 도중에 에러가 발생했습니다.",
                        "인쇄오류", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        //
        //페이지 설정 클릭
        //
        private void menuItemPageSetup_Click(object sender, EventArgs e)
        {

        }
        //
        //끝내기 클릭
        //
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region 2. 메뉴 스트럽 편집

        #endregion

        #region 3. 메뉴 스트럽 보기

        #endregion

        #region 4. 메뉴 스트럽 서식

        #endregion

        #region 5. 메뉴 스트럽 도구

        #endregion

        #region 6. 메뉴 스트럽 도움말

        #endregion

        #region 7. 툴 스트럽 메인

        #endregion

        #region 8. 툴 스트럽 리스트

        #endregion

        #region 9. 툴 스트럽 작업

        #endregion

        
    }
}