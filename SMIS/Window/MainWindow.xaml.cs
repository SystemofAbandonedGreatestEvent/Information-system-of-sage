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
        Library.WindowPoint P;
        
       public MainWindow()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += Window_MouseLeftButtonDown;
        }
       
       private void btn_document_Click(object sender, RoutedEventArgs e)
        {            
            this.Hide();
            DocumentWindow dw = new DocumentWindow();
            dw.Owner = Application.Current.MainWindow;
            dw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dw.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)  //창 드래그이동
        {
            this.DragMove();
            e.Handled = true;
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)   //프로그램 종료
        {
            this.Close();
        }
    }
}
