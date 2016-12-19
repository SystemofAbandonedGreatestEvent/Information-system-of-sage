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
        string Id; // 유저의 계정
        string path = "root";
        string parentId = "0";
        bool IsfileExist = false;
        string docId;
        public DocumentWindow()
        {
            InitializeComponent();
            libarary = Library.GetInstance();
            Id = libarary.get_Id();

            this.MouseLeftButtonDown += Window_MouseLeftButtonDown; //창이동
            lbl_nowTime.Content = DateTime.Now.ToString("yyyy-MM-dd");  //현재날짜받기
            dbcon.fillCmbCategory(Id, cmb_selectCategory);

            // 도구창에 대한 상호 작용 논리
            cmb_fontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);   //폰트스타일
            cmb_fontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 }; ///폰트사이즈
            cmb_fontFamily.SelectedIndex = 153;
            cmb_fontSize.SelectedIndex = 4;
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

        //창 로드
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*TreeViewItem root = new TreeViewItem();
            dbcon.LoadCategory(trv_category);*/
            lsb_category.Items.Clear();
            string userId = libarary.get_userId();
            dbcon.LoadCategoryList(Id, userId, parentId, lsb_category);
        }

        //Category 리스트 더블클릭
        private void lsb_category_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lsb_category.SelectedItems.Count == 1)
            {
                string item = lsb_category.SelectedItem.ToString();
                string isdoc = item.Substring(item.LastIndexOf('\t') + 1);
                if (isdoc.Equals("파일"))
                {
                    docId = item.Substring(0, item.LastIndexOf('|'));
                    string[] docData = new string[3];
                    dbcon.SelectDocument(docId, ref docData);
                    txt_title.Text = docData[0];
                    txt_tag.Text = docData[1];
                    FlowDocument objFdoc = new FlowDocument();
                    Paragraph objPara = new Paragraph();
                    objPara.Inlines.Add(new Run(docData[2]));
                    objFdoc.Blocks.Add(objPara);
                    rtb_editor.Document = objFdoc;
                    IsfileExist = true;
                    btn_save.Visibility = Visibility.Collapsed;
                    btn_update.Visibility = Visibility.Visible;
                }
                else
                {
                    string temp = lsb_category.SelectedItem.ToString();
                    lsb_category.Items.Clear();

                    if (temp.Equals(".."))
                    {
                        path = path.Substring(0, path.LastIndexOf('\\'));
                    }
                    else
                    {
                        path += ("\\" + temp);
                    }
                    if (path != "root")
                        lsb_category.Items.Add("..");

                    parentId = dbcon.GetParentId(Id, path);
                    string userid = libarary.get_userId();
                    dbcon.LoadCategoryList(Id, userid, parentId, lsb_category);

                    txt_title.Text = "제목 없음";
                    txt_tag.Text = "태그 추가";
                    rtb_editor.Document.Blocks.Clear();
                    IsfileExist = false;
                    btn_update.Visibility = Visibility.Collapsed;
                    btn_save.Visibility = Visibility.Visible;
                }
            }
        }

        CreateCategoryWindow ccw = null;

        private void mi_categoryCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ccw == null)
            {
                ccw = new CreateCategoryWindow();
                ccw.OnChildTextInputEvent += new
                    CreateCategoryWindow.OnChildTextInputHandler(ccw_OnChildTextInputEvent);
                ccw.Owner = this;
                ccw.ShowDialog();
            }
        }

        void ccw_OnChildTextInputEvent(string Parameters)
        {
            if (ccw != null)
            {
                ccw.Close();
                ccw.OnChildTextInputEvent -= new
                    CreateCategoryWindow.OnChildTextInputHandler(ccw_OnChildTextInputEvent);
                ccw = null;
            }
            dbcon.AddCategory(Id, parentId, Parameters);
            reLoadCategoryList();
        }

        private void mi_categoryDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lsb_category.SelectedItems.Count == 1)
            {
                string childname = lsb_category.SelectedItem.ToString();
                string childId = dbcon.GetChildId(Id, childname, parentId);
                dbcon.DeleteCategory(Id, childId);
                reLoadCategoryList();
            }
        }

        private void reLoadCategoryList()
        {
            lsb_category.Items.Clear();

            if (path != "root")
                lsb_category.Items.Add("..");
            string userId = libarary.get_userId();
            dbcon.LoadCategoryList(Id, userId, parentId, lsb_category);
        }

        #region 2. 분류 및 태그

        //제목에 포커스을 얻을 때
        private void txt_title_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_title.Text = "";
        }

        //제목이 포커스를 잃을때
        private void txt_title_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_title.Text.Equals(""))
                txt_title.Text = "제목 없음";
        }

        //태그가 포커스를 얻을 때
        private void txt_tag_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_tag.BorderThickness = new Thickness(1);
            txt_tag.Text = "";
        }

        //태그가 포커스를 잃을 때
        private void txt_tag_LostFocus(object sender, RoutedEventArgs e)
        {
            txt_tag.BorderThickness = new Thickness(0);
            txt_tag.Text = "태그 추가";
        }
        #endregion

        #region 3. 도구창

        //리치박스 변경
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

        //문서 세이브 버튼 클릭
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            /*if (cmb_selectCategory.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("분류선택");
                cmb_selectCategory.Focus();
                return;
            }*/

            string[] DocumentInfo = new string[6];

            if (txt_title.Text.Equals(""))
                DocumentInfo[0] = "제목 없음";
            else
                DocumentInfo[0] = txt_title.Text;
            //DocumentInfo[1] = cmb_selectCategory.SelectedValue.ToString();
            string a = path.Substring(path.LastIndexOf('\\') + 1);
            DocumentInfo[1] = a;
            DocumentInfo[2] = txt_tag.Text;

            TextRange textRange = new TextRange(rtb_editor.Document.ContentStart, rtb_editor.Document.ContentEnd);
            DocumentInfo[3] = textRange.Text;
            DocumentInfo[4] = libarary.get_userId();
            DocumentInfo[5] = parentId;
            dbcon.SaveDocument(Id, ref DocumentInfo);
            libarary.set_documentInfo(ref DocumentInfo);
            reLoadCategoryList();
            /*string PreparationDate = "";
            if (IsfileExist.Equals(false))
            {
              
            }
            else
            {
                dbcon.UpdateDocument(Id, PreparationDate, ref DocumentInfo);
            }
            IsfileExist = true; 
            IsContentChage = false;*/
        }

        //문서 업데이트 버튼 클릭
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            string[] DocumentInfo = new string[6];

            if (txt_title.Text.Equals(""))
                DocumentInfo[0] = "제목 없음";
            else
                DocumentInfo[0] = txt_title.Text;
            string a = path.Substring(path.LastIndexOf('\\') + 1);
            DocumentInfo[1] = a;
            DocumentInfo[2] = txt_tag.Text;

            TextRange textRange = new TextRange(rtb_editor.Document.ContentStart, rtb_editor.Document.ContentEnd);
            DocumentInfo[3] = textRange.Text;
            DocumentInfo[4] = libarary.get_userId();
            DocumentInfo[5] = parentId;
            dbcon.UpdateDocument(docId, ref DocumentInfo);
            libarary.set_documentInfo(ref DocumentInfo);
            reLoadCategoryList();
        }

        #endregion

        private void IsChage()
        {

        }

        private void mi_documentDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lsb_category.SelectedItems.Count == 1)
            {
                string item = lsb_category.SelectedItem.ToString();
                string docId = item.Substring(0, item.LastIndexOf('|'));
                dbcon.DelectDocument(docId);
                reLoadCategoryList();
            }
        }

        private void txt_search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_search.Text == "검색")
                txt_search.Text = "";
        }

        private void txt_search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_search.Text.Equals(""))
                txt_search.Text = "검색";
            
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            string tag = txt_search.Text;
            lsb_category.Items.Clear();
            string userId = libarary.get_userId();
            if (tag.Equals(""))
                dbcon.LoadCategoryList(Id, userId, parentId, lsb_category);
            else
            {
                dbcon.SearchTag(userId, tag, lsb_category);
                path = "root";
                parentId = "0";
            }
            
        }
    }
}