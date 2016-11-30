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
        string Id; /// 유저의 계정

        public AccountWindow()
        {
            InitializeComponent();
            libarary = Library.GetInstance();
            Id = libarary.get_Id();    ///아이디 받기
            this.MouseLeftButtonDown += Window_MouseLeftButtonDown; ///창이동            
            cmb_state.ItemsSource = libarary.State; ///상태값 불러오기
            cmb_state.SelectedIndex = libarary.get_State();
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
            ViewThumbnail();  ///유저프로필 이미지 뷰

            ViewUserInfo(); ///유저 프로필 정보 뷰
        }

        private void btn_modify_Click(object sender, RoutedEventArgs e) ///유저 프로필 정보 수정버튼
        {
            ///버튼 숨기기 및 보이기
            btn_modify.Visibility = Visibility.Hidden;
            btn_save.Visibility = Visibility.Visible;

            txt_nickname.Text = libarary.get_Nickname();
            txt_comment.Text = libarary.get_Comment();
            txt_phoneNum.Text = libarary.get_PhoneNum();
            txt_companyNum.Text = libarary.get_CompanyNum();
            txt_homeNum.Text = libarary.get_HomeNum();
            txt_Email.Text = libarary.get_Email();

            ///수정텍스트박스 보이기
            txt_nickname.Visibility = Visibility.Visible;
            txt_comment.Visibility = Visibility.Visible;
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

            string[] tempUserInfo = new string[6];
            tempUserInfo[0] = txt_nickname.Text;
            tempUserInfo[1] = txt_comment.Text;
            tempUserInfo[2] = txt_phoneNum.Text;
            tempUserInfo[3] = txt_companyNum.Text;
            tempUserInfo[4] = txt_homeNum.Text;
            tempUserInfo[5] = txt_Email.Text;

            dbcon.UpdateUserInfo(Id, ref tempUserInfo);
            
            txt_nickname.Visibility = Visibility.Hidden;
            txt_comment.Visibility = Visibility.Hidden;
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
                img_thumbnail.Source = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
                img_thumbnail.Tag = ofd.FileName;

                dbcon.UpdateUserImg(Id, FileName);
                ViewThumbnail();
            }
        }

        private void cmb_state_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int state = cmb_state.SelectedIndex;
            libarary.set_state(state.ToString());
            dbcon.UpdateState(Id, state);
        }

        private void ViewThumbnail()  ///유저의 프로필 이미지를 보여줌
        {
            bool IsDefaultThumbnail = dbcon.IsNull_Column_Id("user", "Thumbnail", Id);
            Image img = new Image();

            if (IsDefaultThumbnail)
                //데이터베이스에 썸네일이 저장되있지 않을 경우
                img.Source = new BitmapImage(new Uri("/drawable/defaultprofile.png", UriKind.Relative));
            else
            {
                //데이터베이스에 썸네일이 저장되어 있을 경우
                dbcon.LoadUserImg(Id, img);
            }
            img.Width = 256;
            img.Height = 256;
            img_thumbnail.Source = img.Source;
        }

        private void ViewUserInfo() ///유저의 정보를 라벨에 보여주기
        {
            libarary.set_userInfo(libarary.get_userId());

            lbl_nickname.Content = libarary.get_Nickname();
            lbl_account.Content = libarary.get_userId();
            lbl_comment.Content = libarary.get_Comment();
            lbl_phoneNum.Content = libarary.get_PhoneNum();
            lbl_companyNum.Content = libarary.get_CompanyNum();
            lbl_homeNum.Content = libarary.get_HomeNum();
            lbl_Email.Content = libarary.get_Email();
        }


    }
}