using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// ContactWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContactWindow : Window
    {
        DatabaseControl dbcon = new DatabaseControl();
        Library libarary;
        public ContactWindow()
        {
            InitializeComponent();
            libarary = Library.GetInstance();
            this.MouseLeftButtonDown += Window_MouseLeftButtonDown; ///창이동
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewContectList();
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
            string friendId = txt_newContact.Text;
            if (!friendId.Equals(""))
                dbcon.AddContect(libarary.get_userId(), friendId);
            ViewContectList();
        }

        private void ViewContectList()
        {
            lsb_contacts.Items.Clear();
            dbcon.FillContectList(libarary.get_userId(), lsb_contacts);
        }

        private void lsb_contacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lsb_contacts.SelectedItems.Count == 1)
            {
                string friendId = lsb_contacts.SelectedItem.ToString();
                libarary.set_friendInfo(friendId);

                if (libarary.get_friendNickname().Equals(""))
                    lbl_friendNickname.Content = libarary.get_friendId();
                else
                    lbl_friendNickname.Content = libarary.get_friendNickname();
                lbl_friendComment.Content = libarary.get_friendComment();
                //dbcon.LoadUserImg(friendId, img_friendThumbnail);
                //dbcon.GetData(libarary.get_userId(), libarary.get_friendId(), dtg_Message);
                lsb_message.Items.Clear();
                dbcon.FillMessageList(libarary.get_userId(), libarary.get_friendId(), lsb_message);
            }
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "원하시는 파일을 선택합니다. (크기제한 100Mb)";
            ofd.Filter = "All(*.*)|*.*";
            ofd.InitialDirectory = @"C:\";
            if (ofd.ShowDialog() == true)
            {
                string FileName = ofd.FileName;

                dbcon.UploadFile(libarary.get_userId(), libarary.get_friendId(), FileName);
            }
            //dbcon.GetData(libarary.get_userId(), libarary.get_friendId(), dtg_Message);
            lsb_message.Items.Clear();
            dbcon.FillMessageList(libarary.get_userId(), libarary.get_friendId(), lsb_message);

        }

        private void btn_download_Click(object sender, RoutedEventArgs e)
        {
            if (lsb_message.SelectedItems.Count == 1)
            {
                string list = lsb_message.SelectedItem.ToString();
                string[] spstring = list.Split(' ');
                string Id = spstring[1];

                SaveFileDialog dfd = new SaveFileDialog();
                dfd.InitialDirectory = @"C:\";
                dfd.Filter = "All(*.*)|(*.*)";
                if (dfd.ShowDialog() == true)
                {
                    string strFileName = dfd.FileName;
                    dbcon.DownloadFile(Id, strFileName);
                    
                }
            }
        }
    }
}
