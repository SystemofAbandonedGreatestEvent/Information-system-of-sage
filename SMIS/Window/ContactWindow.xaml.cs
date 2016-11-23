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
using SMIS.Entities;

namespace SMIS
{
    /// <summary>
    /// ContactWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContactWindow : Window
    {
        DatabaseControl dbcon;
        public ContactWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += Window_MouseLeftButtonDown; ///창이동
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dbcon.fillContectList(UserEntity.id, lsb_contacts);
            
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Owner = Application.Current.MainWindow;
            mw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mw.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            e.Handled = true;
        }

        private void btn_newContact_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
