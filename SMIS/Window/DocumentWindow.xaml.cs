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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SMIS
{
    /// <summary>
    /// DocumentWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DocumentWindow : Window
    {
        #region 1.전역 변수 및 생성자

        DatabaseControl dbcon = new DatabaseControl();
        Library libarary;
        string account; /// 유저의 계정
        bool IsContentChage = false;
        bool IsfileExist = false;
        string tempTitle = null;

        public DocumentWindow()
        {
            InitializeComponent();
            libarary = Library.GetInstance();
            account = libarary.get_userID();

            this.MouseLeftButtonDown += Window_MouseLeftButtonDown; ///창이동
            lbl_nowTime.Content = DateTime.Now.ToString("yyyy-MM-dd");  ///현재날짜
            dbcon.fillCategoryList(account, cmb_selectCategory);

            /// <summary>
            /// 도구창에 대한 상호 작용 논리
            /// </summary>
            cmb_fontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);   ///폰트스타일
            cmb_fontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 }; ///폰트사이즈

        }
        #endregion

        ///창이동
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            e.Handled = true;
        }

        ///메인메뉴로 가기
        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Owner = Application.Current.MainWindow;
            mw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mw.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TreeViewItem root = new TreeViewItem();
            dbcon.LoadCategory(trv_category);

        }

        #region 2. 분류 및 태그

        private void txt_tag_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_tag.BorderThickness = new Thickness(1);
            txt_tag.Text = "";
        }

        private void txt_tag_LostFocus(object sender, RoutedEventArgs e)
        {
            txt_tag.BorderThickness = new Thickness(0);
            txt_tag.Text = "태그 추가";
        }
        #endregion

        #region 3. 도구창

        private void rtb_editor_SelectionChanged(object sender, RoutedEventArgs e)  ///컨택스 박스 상태 체크
        {
            object temp = rtb_editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtb_editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtb_editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_underline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtb_editor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmb_fontFamily.SelectedItem = temp;
            temp = rtb_editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_fontSize.Text = temp.ToString();

            IsContentChage = true;
        }

        private void cmb_fontSize_TextChanged(object sender, TextChangedEventArgs e)    ///폰트 사이즈 조절
        {
            rtb_editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_fontSize.Text);
        }

        private void cmb_fontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)    ///폰트 스타일 변경
        {
            if (cmb_fontFamily.SelectedItem != null)
                rtb_editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_fontFamily.SelectedItem);
        }

        private void txt_title_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txt_title.Text != "제목")
                IsContentChage = true;
        }

        private void txt_tag_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txt_tag.Text != "태그")
                IsContentChage = true;
        }

        private void cmb_selectCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsContentChage = true;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_selectCategory.Text.Equals(""))
            {
                MessageBox.Show("분류선택");
                cmb_selectCategory.Focus();
                return;
            }
            if (txt_title.Text.Equals("제목"))
            {
                MessageBox.Show("제목을 입력");
                txt_title.Focus();
                return;
            }

            libarary.set_documentName(txt_title.Text);
            string[] DocumentInfo = new string[4];
            DocumentInfo[0] = account;
            DocumentInfo[1] = txt_title.Text;
            DocumentInfo[2] = cmb_selectCategory.Text;
            DocumentInfo[3] = txt_tag.Text;
            TextRange textRange = new TextRange(rtb_editor.Document.ContentStart, rtb_editor.Document.ContentEnd);
            String content = textRange.Text;


            if (IsfileExist.Equals(false))
            {
                if (IsContentChage.Equals(false))
                { return; }

                dbcon.SaveDocument(ref DocumentInfo, content);
                tempTitle = dbcon.SelectDocument(account, DocumentInfo[1]);
            }
            else
            {
                if (IsContentChage.Equals(false))
                { return; }

                dbcon.UpdateDocument(ref DocumentInfo, content, tempTitle);
            }
            IsfileExist = true;
            IsContentChage = false;
        }

        #endregion
        
    }
}