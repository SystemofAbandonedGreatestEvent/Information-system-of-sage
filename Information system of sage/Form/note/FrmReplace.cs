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
    public partial class FrmReplace : Form
    {
        private NoteForm dnn = null;    //메인 폼을 가르키는 객체

        public FrmReplace() //매개변수 없는 생성자
        {
            InitializeComponent();
        }

        public FrmReplace(NoteForm objMainFrom) //매개변수 있는 생성자
        {
            dnn = objMainFrom;
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)  //다음찾기버튼기능구현
        {
            if (!FindText())
            {
                MessageBox.Show(
                    this.txtFind.Text + "을(를)찾을수없습니다.",
                    "메모장",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private bool FindText() // 찾기전용메서드: 찾지못하면false
        {
            int nFind;
            int nLen;
            string strTempText;
            string strTempFind;

            if (chkCase.Checked) // 대/소문자구분
            {
                strTempText = dnn.txtNote.Text; // 찾을대상
                strTempFind = txtFind.Text; // 찾을단어
            }
            else
            {
                strTempText = dnn.txtNote.Text.ToLower(); // 소문자
                strTempFind = txtFind.Text.ToLower(); // 소문자
            }
            nLen = txtFind.Text.Length; // 텍스트길이
            
            // 위로/ 아래로검색
            if (rdoUp.Checked)
            {
                if (dnn.txtNote.SelectionStart -
                    dnn.txtNote.SelectionLength < 0)
                {
                    nFind = -1;
                }
                else
                {
                    nFind = strTempText.LastIndexOf(strTempFind,
                        dnn.txtNote.SelectionStart -
                        dnn.txtNote.SelectionLength);
                }
            }
            else   // 아래로
            {
                nFind = strTempText.IndexOf(strTempFind,
                    dnn.txtNote.SelectionStart +
                    dnn.txtNote.SelectionLength);
            }

            if (nFind == -1)  // 비교
            { 
                return false;
            }
            else
            {
                dnn.txtNote.SelectionStart = nFind;
                dnn.txtNote.SelectionLength = nLen;
                dnn.txtNote.Focus();

                return true;
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)   // 바꾸기 버튼기 능구현
        {
            if (!FindText())  // 텍스트가 발견되지 않으면 - false 면
            {
                MessageBox.Show(this.txtFind.Text + "을(를) 찾을수없습니다.",
                    "메모장", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                // 텍스트변경
                dnn.txtNote.SelectedText = this.txtReplace.Text;
                // 선택효과
                dnn.txtNote.SelectionStart = dnn.txtNote.SelectionStart -
                        txtReplace.Text.Length;
                dnn.txtNote.SelectionLength = txtReplace.Text.Length;
            }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)    //모두 바꾸기 버튼 기능구현
        {
            while (FindText()) // 텍스트가발견되는것은모두바꿔라 - true면
            {
                dnn.txtNote.SelectedText = this.txtReplace.Text;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)    // 취소버튼기능구현
        {
            this.Close();
        }

        private void findTextChanged(object sender, EventArgs e)
        {
            this.btnFind.Enabled = true;
            this.btnReplace.Enabled = true;
            this.btnReplace.Enabled = true;
        }

    }
}