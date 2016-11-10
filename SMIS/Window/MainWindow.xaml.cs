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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SMIS
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 1. 전역변수 및 생성자
        Library.WindowPoint P;
        
       public MainWindow()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += Window_MouseLeftButtonDown;
        }
        #endregion

        //창 드래그이동
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)  
        {
            this.DragMove();
            e.Handled = true;
        }

        //프로그램 종료
        private void btn_exit_Click(object sender, RoutedEventArgs e)   
        {
            this.Close();
        }

        //계정관리창 열기
        private void btn_account_Click(object sender, RoutedEventArgs e)    
        {
            this.Hide();
            AccountWindow aw = new AccountWindow();
            aw.Owner = Application.Current.MainWindow;
            aw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            aw.Show();
        }

        //문서관리창 열기
        private void btn_document_Click(object sender, RoutedEventArgs e)   
        {            
            this.Hide();
            DocumentWindow dw = new DocumentWindow();
            dw.Owner = Application.Current.MainWindow;
            dw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dw.Show();
        }

        //연락관리창 열기
        private void btn_contact_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ContactWindow cw = new ContactWindow();
            cw.Owner = Application.Current.MainWindow;
            cw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            cw.Show();
        }
    }
}
