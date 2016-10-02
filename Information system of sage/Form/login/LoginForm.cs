using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Information_system_of_sage.login;

namespace Information_system_of_sage
{
    public partial class LoginForm : Form
    {
        private string realPassWord;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            string strDirectory = Library.findDrawableDiretory();
            strDirectory += @"\login.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Load(strDirectory);

            tbCntrl_Login.SelectedIndex = 1;
        }
        
        private void txtIdAndtxtPassword_Changed(object sender, EventArgs e)
        {
            btnLogin_Enable();           
        }

        private void btnLogin_Enable()
        {
            if ((mtxtLoginId.TextLength > 0) && (mtxtLoginPassword.TextLength > 5))
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }

            if (mtxtLoginPassword.TextLength < 1)
            {
                realPassWord += mtxtLoginPassword.Text;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Accounts accouts = new Accounts();
            if (opAccount.opUser(mtxtLoginId.Text, mtxtLoginPassword.Text) == 0)
            {
                NoteForm f = new NoteForm();
                f.Show();
                this.Close();
            }
            else
            {
                int access = accouts.getAccounts(mtxtLoginId.Text, mtxtLoginPassword.Text);
                if (access == 1)
                {
                   NoteForm f = new NoteForm();
                   f.ShowDialog();
                   this.Close();
                }
                else if (access == 0)
                {
                    NoteForm f = new NoteForm();
                    f.Show();
                    this.Close();
                }
                else if (access == -1)
                {
                    MessageBox.Show("존재하지않는 계정입니다", "메세지",
                        MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("올바르지 않은 비밀번호입니다", "메세지",
                        MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
            }            
        }        
    }
}