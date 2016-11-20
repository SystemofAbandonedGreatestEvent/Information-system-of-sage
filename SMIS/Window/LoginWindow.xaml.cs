using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SMIS
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        #region 1. 전역 변수 및 생성자
        
        DatabaseControl dbcon = new DatabaseControl();
        Library libarary;
        bool IDCheck = false;
        bool PWCheck = false;
        bool IDLogCheck = false;
        bool PWLogCheck = false;

        public LoginWindow()
        {
            InitializeComponent();
            libarary = Library.GetInstance();
        }
        #endregion

        #region 2. 회원가입 탭

        private void btn_signUp_Click(object sender, RoutedEventArgs e)
        {
            string ID = txt_signupID.Text;
            string PW = txt_signupPW.Password;
            string sql = "insert into user (ID, Password) values ('" + ID + "', '" + PW + "')";
            dbcon.CreactUpdateDelete(sql);

            MessageBox.Show("sign up completed...");
            txt_signupID.Text = "";
            txt_signupPW.Password = "";
        }

        private void txt_signupID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_signupID.Text.Length < 5)
            {
                IDCheck = false;
                IsEnableSignup_and_in_btn(0);
            }
            else
            {
                IDCheck = true;
                IsEnableSignup_and_in_btn(0);
            }
        }

        private void txt_signupPW_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txt_signupPW.Password.Length < 6)
            {
                PWCheck = false;
                IsEnableSignup_and_in_btn(0);
            }
            else
            {
                PWCheck = true;
                IsEnableSignup_and_in_btn(0);
            }
        }
        #endregion

        #region 3. 로그인 탭
        private void txt_signinID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_signinID.Text.Length < 5)
            {
                IDLogCheck = false;
                IsEnableSignup_and_in_btn(1);
            }
            else
            {
                IDLogCheck = true;
                IsEnableSignup_and_in_btn(1);
            }
        }

        private void txt_signinPW_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txt_signinPW.Password.Length < 6)
            {
                PWLogCheck = false;
                IsEnableSignup_and_in_btn(1);
            }
            else
            {
                PWLogCheck = true;
                IsEnableSignup_and_in_btn(1);
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string ID = txt_signinID.Text;
            string PW = txt_signinPW.Password;
            String sql = "select * from user where ID='"+ID+"'";
            int loginCheck = dbcon.CheckLogin(ID, PW, sql);

            if (loginCheck.Equals(0))   //ID와 Password 둘 다 맞을때
            {
                libarary.set_userID(ID);
                this.Hide();
                MainWindow mw = new MainWindow();
                mw.Owner = Application.Current.MainWindow;
                mw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                mw.ShowDialog();
            }
            else if (loginCheck.Equals(-1))    //ID가 맞을 때
            {
                MessageBox.Show("wrong password");
            }
            else if (loginCheck.Equals(-2)) //ID가 틀릴 때
            {
                MessageBox.Show("Please enter existing ID");
            }
            else   //시스템 에러
                MessageBox.Show("system err");
        }
        
        #endregion

        private void IsEnableSignup_and_in_btn(int UporIn)
        {
            if (UporIn.Equals(0))
            {
                if (IDCheck == true && PWCheck == true)
                {
                    btn_signUp.IsEnabled = true;
                }
                else
                {
                    btn_signUp.IsEnabled = false;
                }
            }
            else if (UporIn.Equals(1))
            {
                if (IDLogCheck == true && PWLogCheck == true)
                {
                    btn_login.IsEnabled = true;
                }
                else
                {
                    btn_login.IsEnabled = false;
                }
            }
            else
                MessageBox.Show("err: wrong string input");
        }
    }
}