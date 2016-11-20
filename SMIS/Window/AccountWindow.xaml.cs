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
using Microsoft.Win32;

namespace SMIS
{
    /// <summary>
    /// AccountWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AccountWindow : Window
    {
        #region 1. 전역 변수 및 생성자
        DatabaseControl dbcon = new DatabaseControl();
        Library libarary;
        string account; /// 유저의 계정
        string[] userinfo = new string[6];  ///userinfo[0~5]: 닉네임, 상태메시지, 휴대폰 번호, 회사 번호, 집전화 번호, 이메일

        public AccountWindow()
        {
            InitializeComponent();
            libarary = Library.GetInstance();
            account = libarary.get_userID();    ///유저아이디 받기
            this.MouseLeftButtonDown += Window_MouseLeftButtonDown; ///창이동            
            cmb_state.ItemsSource = libarary.state; ///상태값 불러오기            
        }
        #endregion

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            e.Handled = true;
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Owner = Application.Current.MainWindow;
            mw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mw.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)    ///창 로드시
        {
            ViewUserProfile();  ///유저프로필 이미지 뷰

            ViewUserInfo(); ///유저 프로필 정보 뷰
        }   

        private void btn_modify_Click(object sender, RoutedEventArgs e) ///유저 프로필 정보 수정버튼
        {
            ///버튼 숨기기 및 보이기
            btn_modify.Visibility = Visibility.Hidden;
            btn_save.Visibility = Visibility.Visible;

            txt_nickname.Text = userinfo[0];
            txt_statemessage.Text = userinfo[1];
            txt_phoneNum.Text = userinfo[2];
            txt_companyNum.Text = userinfo[3];
            txt_homeNum.Text = userinfo[4];
            txt_Email.Text = userinfo[5];

            ///수정텍스트박스 보이기
            txt_nickname.Visibility = Visibility.Visible;
            txt_statemessage.Visibility = Visibility.Visible;
            txt_phoneNum.Visibility = Visibility.Visible;
            txt_companyNum.Visibility = Visibility.Visible;
            txt_homeNum.Visibility = Visibility.Visible;
            txt_Email.Visibility = Visibility.Visible;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)   ///유저 프로필 정보 저장
        {
            ///버튼 숨기기 및 보이기
            btn_save.Visibility = Visibility.Hidden;
            btn_modify.Visibility = Visibility.Visible;
            String sql = UpdateuserinfoSql();

            if (sql != "unknown")
                dbcon.CreactUpdateDelete(sql);

            txt_nickname.Visibility = Visibility.Hidden;
            txt_statemessage.Visibility = Visibility.Hidden;
            txt_phoneNum.Visibility = Visibility.Hidden;
            txt_companyNum.Visibility = Visibility.Hidden;
            txt_homeNum.Visibility = Visibility.Hidden;
            txt_Email.Visibility = Visibility.Hidden;

            ViewUserInfo();
        }

        private void btn_profileChage_Click(object sender, RoutedEventArgs e)   ///유저 프로필 사진 수정버튼
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "원하시는 프로필 사진을 선택합니다. 사진 크기(256 x 256)";
            ofd.Filter = "All(*.*)|*.*|jpg(*.jpg)|*.jpg|png(*.png)|*.png";
            ofd.InitialDirectory = @"C:\";
            if (ofd.ShowDialog() == true)
            {
                string FileName = ofd.FileName;
                img_profile.Source = new BitmapImage(new Uri(ofd.FileName,UriKind.Absolute));
                img_profile.Tag = ofd.FileName;
                
                dbcon.UpdateUserImg(account, FileName);
                ViewUserProfile();
            }
        }

        private String UpdateuserinfoSql()  ///유저정보 db업데이트 쿼리
        {
            string tempNickname, tempStatemessage, tempPhonenum, tempCompanynum, temphomenum, tempEmail;
            bool flag = false;

            tempNickname = txt_nickname.Text;
            tempStatemessage = txt_statemessage.Text;
            tempPhonenum = txt_phoneNum.Text;
            tempCompanynum = txt_companyNum.Text;
            temphomenum = txt_homeNum.Text;
            tempEmail = txt_Email.Text;

            String sql = "update user set ";
            if (tempNickname != "")
            {
                sql += "NickName = '" + txt_nickname.Text + "'";
                flag = true;
            }
            if (tempStatemessage != "")
            {
                checkUpdatequarry(ref flag, ref sql);
                sql += "Statemessage = '" + txt_statemessage.Text + "'";
            }
            if (tempPhonenum != "")
            {
                checkUpdatequarry(ref flag, ref sql);
                sql += "PhoneNum = '" + txt_phoneNum.Text + "'";
            }
            if (tempCompanynum != "")
            {
                checkUpdatequarry(ref flag, ref sql);
                sql += "CompanyNum = '" + txt_companyNum.Text + "'";
            }
            if (temphomenum != "")
            {
                checkUpdatequarry(ref flag, ref sql);
                sql += "HomeNum = '" + txt_homeNum.Text + "'";
            }
            if (tempEmail != "")
            {
                checkUpdatequarry(ref flag, ref sql);
                sql += "Email = '" + txt_Email.Text + "'";
            }
            sql += " where ID='" + account + "'";

            if (tempNickname != "" && tempStatemessage != "" && tempPhonenum != "" && tempCompanynum != "" &&
                temphomenum != "" && tempEmail != "")
                sql = "unknown";
            return sql;
        }   

        private static void checkUpdatequarry(ref bool flag, ref string sql)    ///여러 update쿼리시 ,설정
        {
            if (flag == true)
                sql += ", ";
            else
                flag = true;
        }

        private void ViewUserProfile()  ///유저의 프로필 이미지를 보여줌
        {
            bool IsDefaultprofileImg = dbcon.IsNull_UserImg(account);
            Image img = new Image();

            if (!IsDefaultprofileImg)
                img.Source = new BitmapImage(new Uri("/drawable/defaultprofile.png", UriKind.Relative));
            else
            {
                dbcon.LoadUserImg(account, img);
            }
            img.Width = 256;
            img.Height = 256;
            img_profile.Source = img.Source;
        }

        private void ViewUserInfo() ///유저의 정보를 라벨에 보여주기
        {
            String sql = "select * from user where ID='" + account + "'";

            dbcon.LoadUserInfo(account, sql, ref userinfo);

            lbl_nickname.Content = userinfo[0];
            lbl_account.Content = account;
            lbl_statemessage.Content = userinfo[1];
            lbl_phoneNum.Content = userinfo[2];
            lbl_companyNum.Content = userinfo[3];
            lbl_homeNum.Content = userinfo[4];
            lbl_Email.Content = userinfo[5];
        }
    }
}