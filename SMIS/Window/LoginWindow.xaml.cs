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

        public LoginWindow()
        {
            InitializeComponent();
            libarary = Library.GetInstance();
        }
        #endregion

        #region 2. 회원가입 탭

        private void btn_signUp_Click(object sender, RoutedEventArgs e)
        {
            string userId = txt_signupID.Text;
            string password = txt_signupPW.Password;
            
            //db에 저장
            dbcon.Signup(userId, password); 

            MessageBox.Show("sign up completed");

            //textbox 초기화
            txt_signupID.Text = "";
            txt_signupPW.Password = "";
        }

        private void txt_signupID_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsEnableSignup_and_in_btn(0);
        }

        private void txt_signupPW_PasswordChanged(object sender, RoutedEventArgs e)
        {
            IsEnableSignup_and_in_btn(0);
        }
        #endregion

        #region 3. 로그인 탭

        private void txt_signinID_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsEnableSignup_and_in_btn(1);
        }

        private void txt_signinPW_PasswordChanged(object sender, RoutedEventArgs e)
        {
            IsEnableSignup_and_in_btn(1);
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string userId = txt_signinID.Text;
            string password = txt_signinPW.Password;
            
            int loginCheck = dbcon.CheckLogin(userId, password);

            if (loginCheck.Equals(2))   //Id와 Password 둘 다 맞을때
            {
                libarary.Initialization(userId);
                libarary.set_state("1");
                dbcon.UpdateState(libarary.get_Id(), 1);
                this.Hide();
                MainWindow mw = new MainWindow();
                mw.Owner = Application.Current.MainWindow;
                mw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                mw.ShowDialog();
            }
            else if (loginCheck.Equals(1))    //Id만 맞을 때
            {
                MessageBox.Show("wrong password");
            }
            else if (loginCheck.Equals(0)) //Id가 틀릴 때
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
                if (txt_signupID.Text.Length >= 5 && txt_signupPW.Password.Length >= 6)
                {
                    btn_signUp.IsEnabled = true;
                }
                else
                    btn_signUp.IsEnabled = false;
            }
            else
            {
                if (txt_signinID.Text.Length >= 5 && txt_signinPW.Password.Length >= 6)
                {
                    btn_login.IsEnabled = true;
                }
                else
                    btn_login.IsEnabled = false;
            }
        }
    }
}