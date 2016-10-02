using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Information_system_of_sage
{
    public partial class NoteForm : Form
    {
        #region 1. 전역변수 및 생성자
        
        //텍스트가 변경되었는지 여부 확인하기 위한 용도
        private bool _IsTextChanged;

        //텍스트 박스에 글자가 입력되면(변화가 있으면)
        private void txtMemo_TextChanged(object sender, EventArgs e)
        {
            _IsTextChanged = true;  //텍스트 변경되었을 경우 적용
            mi_Undo.Enabled = true; //취소매뉴 활성화
            mi_Cut.Enabled = true;  //잘라내기 메뉴 활성화
            mi_Copy.Enabled = true; //복사하기 메뉴 활성화
            mi_Delete.Enabled = true;   //삭제하기 메뉴 활성화
            mi_Find.Enabled = true; //찾기 메뉴 활성화
            mi_FindNext.Enabled = true; //다음 찾기 메뉴 활성화
        }

        public NoteForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 2. 메뉴 스트립 파일

        //새로 만들기 버튼 클릭시
        private void mi_New_Click(object sender, EventArgs e)
        {
            SaveOrClearOrCancel("New"); //매개변수로 New 전달
        }

        //메뉴에서 열기 버튼 클릭시
        private void mi_Open_Click(object sender, EventArgs e)
        {
            if (_IsTextChanged)  //파일에 변화가 있으면
            {
                SaveOrClearOrCancel("Open");    //매개변수로 Open 전달
            }
            else
            {
                OpenText(); //변화가 없으면 그대로 유지
            }
        }

        //메뉴에서 저장 버튼 클릭시
        private void mi_Save_Click(object sender, EventArgs e)
        {
            SaveText();
        }

        //메뉴에서 다른 이름으로 저장하기 버튼 클릭시
        private void mi_SaveAs_Click(object sender, EventArgs e)
        {
            DialogResult objDr = saveFileDialog1.ShowDialog();  //텍스트 내용 변경되던 아니든 무조건 저장하기 창 띄워 줌
            if (objDr != DialogResult.Cancel)  //취소 버튼이 아니면
            {
                string strFileName = saveFileDialog1.FileName;
                SaveFile(strFileName);  //파일이름 매개변수로 저장하기 호출
            }
        }

        //메뉴에서 페이지 설정 클릭시
        private void mi_PageSetup_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = txtNote.Text; //문서 지정
            pageSetupDialog1.Document = this.printDocument1;
            pageSetupDialog1.ShowDialog();  //페이지 설정 창 띄우기
        }

        //메뉴에서 인쇄 버튼 클릭시
        private void mi_Print_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = txtNote.Text;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument1.Print();
                }
                catch
                {
                    MessageBox.Show("인쇄하는 도중에 에러가 발생했습니다.",
                        "인쇄오류", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringReader objSr = new StringReader(this.txtNote.Text);

            //현재 문서의 글꼴과 사이즈
            Font printFont = new Font(txtNote.Font.Name, txtNote.Font.Size);
            float linesPerPage = 0; //페이지 라인 수
            float yPos = 0; //페이지 상단에서 떨어진 위치(문자열 출력)
            int count = 0;   //페이지 줄 번호

            float leftMargin = e.MarginBounds.Left; //왼쪽 여백
            float topMargin = e.MarginBounds.Top;   //오른쪽 여백

            string line = null; //각 행의 데이터 저장
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics); //페이지 당 라인 수 계산

            while (count < linesPerPage && ((line = objSr.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black,
                    leftMargin, yPos, new StringFormat());
                count++;
            }
            if (line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            objSr.Close();
        }

        //메뉴에서 끝내기 버튼 클릭시
        private void mi_Exit_Click(object sender, EventArgs e)
        {
            if (_IsTextChanged)
            {
                DialogResult objDr = MessageBox.Show(this.Text + "" +
                    "파일의 내용이 변경되었습니다.\r\n" +
                    "변견된 내용을 저장하시겠습니까?", "메모장",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation);

                switch (objDr)
                {
                    case DialogResult.Yes:
                        SaveText();
                        this.Close();
                        break;
                    case DialogResult.No:
                        this.Close();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                this.Close(); //Application.Exit()
            }
        }

        private void SaveOrClearOrCancel(string strFlag)
        {
            if (_IsTextChanged)  //텍스트 박스 내용이 변경되었으면 메세지박스 호출
            {
                DialogResult obiDr = MessageBox.Show("파일내용이 변경되었습니다.\r\n" +
                    "변경된 내용을 저장하시겠습니까?",
                    "메모장",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation);

                switch (obiDr)
                {
                    case DialogResult.Yes:  //Yes클릭하면 - 저장 할 거면
                        SaveText(); //텍스트 저장
                        if (strFlag == "New")
                            ClearText();
                        else
                            OpenText(); //열기                   
                        break;
                    case DialogResult.No:   //No클릭하면 - 자징 안할거면
                        if (strFlag == "New")
                            ClearText();
                        else
                            OpenText();
                        break;
                    case DialogResult.Cancel:   //취소버튼이면 그대로 둔다
                        break;
                }
            }
            else  //텍스트 박스 내용이 변경되지 않았으면 새로만들기
            {
                ClearText();
            }
        }

        private void OpenText()
        {
            DialogResult objDr = openFileDialog1.ShowDialog();  //열기 대화상자

            if (objDr != DialogResult.Cancel)    //ShowDialog() 취소버튼이 아니라면
            {
                string strFileName = openFileDialog1.FileName;  //열기 대화상자에서 입력한 파일명으로 객체 생성
                StreamReader objSr = new StreamReader(strFileName); //해당 파일에서 처음부터 끝까지 Read
                this.txtNote.Text = objSr.ReadToEnd();  //읽어서 텍스트 박스에 붙임
                objSr.Close();

                _IsTextChanged = false; //변경여부를 다시 초기화
                this.Text = strFileName;    //제목에 파일명 출력
            }
        }

        private void ClearText()
        {
            this.txtNote.ResetText();   //텍스트 박스 리셋 호출
            this.Text = "제목없음"; //제목 다시 설정
            _IsTextChanged = false; //다시 설정
        }

        private void SaveText()
        {
            if (this.Text == "제목없음") //한번도 저장되지 않은 문서라면
            {
                DialogResult objDr = saveFileDialog1.ShowDialog();
                if (objDr != DialogResult.Cancel)  //Yes버튼 클릭하면 - 저장할거면
                {
                    string strFlieName = saveFileDialog1.FileName;  //대화상자에서 입력한 파일명
                    SaveFile(strFlieName);  //저장기능 메소드 호출 - 매개변수는 파일명
                }
            }
            else
            {
                string strFlieName = this.Text;
                SaveFile(strFlieName);
            }
        }

        //저장될 파일의 전체 경로를 매개변수로 함
        private void SaveFile(string strFileName)   //저장하는 메소드 기능
        {
            StreamWriter objSw = new StreamWriter(strFileName);
            objSw.Write(this.txtNote.Text);
            objSw.Flush();  //스트림의 내용 비움
            objSw.Close();

            _IsTextChanged = false; //저장하고 나서 다시 false로 설정
            this.Text = strFileName;
        }
        #endregion

        #region 3. 메뉴 스트립 편집
        //메뉴 스트립 편집

        private void mi_Undo_Click(object sender, EventArgs e)
        {
            if (this.txtNote.CanUndo)    //이전 작업 내용을 취소 할 수 있으면
            {
                this.txtNote.Undo();    //Undo 실행 취소
            }
        }

        private void mi_Cut_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtNote.SelectedText);  //선택된 부분을 클립 보드로 이동
        }

        private void mi_Copy_Click(object sender, EventArgs e)  //복사하기 메뉴 구현
        {
            this.txtNote.Copy();    //복사
        }

        private void mi_Paste_Click(object sender, EventArgs e) //붙여넣기 메뉴 구현
        {
            this.txtNote.Paste();   //붙여넣기
        }

        private void mi_Delete_Click(object sender, EventArgs e)    //삭제하기 구현
        {
            this.txtNote.SelectedText = String.Empty;   //삭제
        }

        private void mi_Find_Click(object sender, EventArgs e)
        {
            FrmFind f = new FrmFind(this);
            f.Show();
        }

        private void mi_FindNext_Click(object sender, EventArgs e)  //다음찾기 메뉴 구현
        {
            mi_Find_Click(null, null);
        }

        private void mi_Replace_Click(object sender, EventArgs e)   //바꾸기 메뉴 구현
        {
            FrmReplace r = new FrmReplace(this);
            r.Show();
        }

        private void mi_SelectAll_Click(object sender, EventArgs e) //모두 선택 기능 구현
        {
            this.txtNote.SelectAll();
        }

        private void mi_Time_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 4. 메뉴 스트립 서식
        private void mi_WordWrap_Click(object sender, EventArgs e)  //자동 줄 바꿈 기능 구현
        {
            // WordWrap 은  bool 값 
            // 참이면 거짓으로, 거짓이면 참으로 변환
            this.txtNote.WordWrap = !(this.txtNote.WordWrap);  //토글 기능
            this.mi_WordWrap.Checked = !(this.mi_WordWrap.Checked);

        }

        private void mi_Font_Click(object sender, EventArgs e)  //글꼴 메뉴 구현
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {             // DialogResult가 Cancel  이 아니면
                txtNote.Font = fontDialog1.Font;  // 글자 크기, 글자 체 
            }
            //사용자가 지정한 Color를 텍스트 박스에 설정
            txtNote.ForeColor = fontDialog1.Color;  //글자 색 지정
        }
        #endregion

        #region 5. 메뉴 스트립 보기

        //보기 메뉴에서 상태 표시줄 클릭시
        private void mi_Status_Click(object sender, EventArgs e)
        {
            if (this.statusStrip1.Visible) // 토글 기능
            {
                this.statusStrip1.Visible = false;  // 보여져 있으면 안보이게
                this.mi_Status.Checked = false;
            }
            else   // 안보이면 보이게 해 주고
            {
                this.statusStrip1.Visible = true;
                this.mi_Status.Checked = true;
                //int intLine = Library.GetLineAndColumn(txtMemo).Line;
                //int intColumn = Library.GetLineAndColumn(txtMemo).Column;

                //string strMsg = String.Format(
                //      "Line {0}, Col {1}", intLine, intColumn);

                //this.toolStripStatusLabel2.Text = strMsg;
            }

        }

        private void txtMemo_KeyUp(object sender, KeyEventArgs e)
        {
            //int intLine = Library.GetLineAndColumn(txtMemo).Line;
            //int intColumn = Library.GetLineAndColumn(txtMemo).Column;
            //string strMsg = String.Format(
            //    "Line {0}, Col {1}", intLine, intColumn);
            //this.toolStripStatusLabel3.Text = strMsg;
        }
        #endregion

        #region 6. 메뉴 스트립 도움말
        private void mi_Help_Click(object sender, EventArgs e)  //도움말 항목 메뉴 링크 구현
        {
            // 시스템(Windows)의 디렉터리 경로 얻어오기
            string strDirectory = System.Environment.SystemDirectory;
            // Help 폴더 안의 Notepad.chm 파일 경로는 상위 폴더 + 현재 파일
            strDirectory = strDirectory.Substring(0, strDirectory.LastIndexOf("\\"));
            // 한 단계 상위 경로 폴더 뽑아내기
            strDirectory += @"\Help.htm";   // 차후 이 파일은 만들어 저장해야 함
            // 파일이 있는지 확인 후 도움말 띄우기
            if (System.IO.File.Exists(strDirectory))
            {
                Help.ShowHelp(this, strDirectory);
            }
            else
            {
                MessageBox.Show(strDirectory +
                    "도움말 파일이 없습니다.", "메모장",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mi_About_Click(object sender, EventArgs e)
        {
            // 새 인스턴스 fa 생성
            FormAbout fa = new FormAbout();

            // Modal 대화상자 폼으로 폼 닫아야지 메인 메뉴로 이동이 가능
            fa.ShowDialog();  // [1]

            // Modal-Less 폼으로 폼 에 관계없이 메인으로 이동 가능
            // fa.Show();   // [2]

        }
        #endregion

        #region 7. 스테이터스 스트립
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Status Bar 의 5번째 레이블에 현재 시간 출력
            tssTime.Text = String.Format("{0}시 {1}분 {2}초"
                , DateTime.Now.Hour, DateTime.Now.Minute
                , DateTime.Now.Second);
        }
        #endregion
    }
}