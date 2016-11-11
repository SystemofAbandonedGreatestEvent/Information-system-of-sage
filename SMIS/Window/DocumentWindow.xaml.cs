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
    /// DocumentWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DocumentWindow : Window
    {
        #region 1.전역 변수 및 생성자
        public DocumentWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += Window_MouseLeftButtonDown; //창이동
            lbl_nowTime.Content = DateTime.Now.ToString("yyyy-MM-dd");  //현재날짜

            /// <summary>
            /// 도구창에 대한 상호 작용 논리
            /// </summary>
            cmb_fontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);   //폰트스타일
            cmb_fontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 }; //폰트사이즈

        }
        #endregion

        //창이동
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            e.Handled = true;
        }

        //메인메뉴로 가기
        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Owner = Application.Current.MainWindow;
            mw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mw.Show();
        }

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

        #region 3. 도구창
        //컨텍스 박스 상태 체크
        private void rtb_editor_SelectionChanged(object sender, RoutedEventArgs e)
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
        }

        //폰트 사이즈 조절
        private void cmb_fontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtb_editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_fontSize.Text);
        }

        //폰트 스타일 변경
        private void cmb_fontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_fontFamily.SelectedItem != null)
                rtb_editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_fontFamily.SelectedItem);
        }

        #endregion

        
    }
}