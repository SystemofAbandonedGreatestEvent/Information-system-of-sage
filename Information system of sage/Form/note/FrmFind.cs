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
    public partial class FrmFind : Form
    {
        public FrmFind()
        {
            InitializeComponent();
        }

        private NoteForm dnn;   //메인 폼을 가리키는 객체

        public FrmFind(NoteForm objMainForm)
        {
            dnn = objMainForm;
            InitializeComponent();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            this.btnFind.Enabled = true;    //텍스트박스에 글이 하나라도 입력되면 다음 찾기 버튼 활성화

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!FindText())
            {
                MessageBox.Show(
                    this.txtFind.Text + "을(를)찾을수없습니다.", "메모장",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool FindText() //bool 타입의 메소드
        {
            int nFind;
            int nLen;
            string strTempText;
            string strTempFind;

            if (chkCase.Checked)
            {
                strTempText = dnn.txtNote.Text; //찾을대상
                strTempFind = txtFind.Text; //찾을단어
            }
            else
            {
                strTempText = dnn.txtNote.Text.ToLower();   //소문자
                strTempFind = txtFind.Text.ToLower();   //소문자
            }
            nLen = txtFind.Text.Length; //텍스트길이

            //위로/아래로검색
            if (rdoUp.Checked)
            {
                if (dnn.txtNote.SelectionStart - dnn.txtNote.SelectionLength < 0)
                {
                    nFind = -1;
                }
                else
                {
                    nFind = strTempText.LastIndexOf(strTempFind,
                        dnn.txtNote.SelectionStart - dnn.txtNote.SelectionLength);
                }
            }
            else  //아래로
            {
                nFind = strTempText.LastIndexOf(strTempFind,
                         dnn.txtNote.SelectionStart + dnn.txtNote.SelectionLength);
            }
            
            //비교
            if (nFind == -1)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
