using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Windows.Media.Imaging;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace SMIS
{
    /// <summary>
    /// Common DataBase Controler
    /// </summary>
    public partial class DatabaseControl
    {
        // Database 연동     
        private static string strConn = "Server=sylvester.ipdisk.co.kr;Database=smis;Uid=root;Pwd=noble@2718;";
        private MySqlConnection conn = new MySqlConnection(strConn);
        private MySqlConnection con = new MySqlConnection(strConn);

        public void ConnectionTest()
        {
            try
            {
                conn.Open();
                if (conn.Ping() == true)
                {
                    MessageBox.Show("Connected to DB OK...");
                }
                else
                {
                    MessageBox.Show("Connected to DB filed...");
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }   //Database 연결테스트

        public void CreactUpdateDelete(string sql)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void UpdateState(string strId, int state)
        {
            try
            {
                conn.Open();
                string sql;
                if (state == 1)
                    sql = "update user set State = '1' where Id = '" + strId + "'";
                else if (state == 2)
                    sql = "update user set State = '2' where Id = '" + strId + "'";
                else if (state == 3)
                    sql = "update user set State = '3' where Id = '" + strId + "'";
                else
                    sql = "update user set State = '0' where Id = '" + strId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool IsNull_Column_Id(string table, string col, string Id)
        {
            bool IsNull = true;

            try
            {
                con.Open();
                string sql = "select isnull(" + col + ") from " + table + " where Id = '" + Id + "'";
                MySqlCommand _cmd = new MySqlCommand(sql, con);
                MySqlDataReader _rdr = _cmd.ExecuteReader();
                while (_rdr.Read())
                {
                    int tempIsNull = _rdr.GetInt16(0);
                    if (tempIsNull.Equals(0)) //DB에 값이 있으면
                        IsNull = false;
                }
                _rdr.Close();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return IsNull;
        }

        public bool IsNull_Column_UserId(string table, string col, string strUserId)
        {
            bool IsNull = true;

            try
            {
                con.Open();
                string sql = "select isnull(" + col + ") from " + table + " where UserId = '" + strUserId + "'";
                MySqlCommand _cmd = new MySqlCommand(sql, con);
                MySqlDataReader _rdr = _cmd.ExecuteReader();
                while (_rdr.Read())
                {
                    int tempIsNull = _rdr.GetInt16(0);
                    if (tempIsNull.Equals(0)) //DB에 값이 있으면
                        IsNull = false;
                }
                _rdr.Close();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return IsNull;
        }
    }

    /// <summary>
    /// LoginWindow와의 상호작용하는 DataBase 컨트롤러
    /// </summary>
    public partial class DatabaseControl
    {
        public void Signup(string strUserId, string strPassword)
        {
            try
            {
                conn.Open();
                string sql = "insert into user (UserId, Password) values ('" + strUserId + "', '" + strPassword + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public int CheckLogin(string strUserId, string strPassword)
        {
            int checkState = 0;

            try
            {
                conn.Open();
                string sql = "select * from user where UserId='" + strUserId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string tempUserId, tempPassword;

                    tempUserId = rdr.GetString("UserId");
                    tempPassword = rdr.GetString("Password");

                    if (strUserId.Equals(tempUserId) && strPassword.Equals(tempPassword))
                    {
                        checkState = 2;
                    }
                    else
                        checkState = 1;
                }
                rdr.Close();
                conn.Close();
            }
            catch
            {
                checkState = 0;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return checkState;
        }
    }

    /// <summary>
    /// AccountWindow와의 상호작용하는 DataBase 컨트롤러
    /// </summary>
    public partial class DatabaseControl
    {
        public void LoadUserInfo(string strUserId, ref string[] userinfo)
        {
            try
            {
                conn.Open();
                string sql = "select * from user where UserId='" + strUserId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string[] tempUserInfo = new string[9];
                    string[] column = { "Id", "NickName", "State", "Comment",
                        "Address", "Email", "PhoneNum", "HomeNum", "CompanyNum" };

                    for (int i = 0; i < 9; i++)
                    {
                        if (!IsNull_Column_UserId("user", column[i], strUserId))
                            tempUserInfo[i] = rdr.GetString(column[i]);
                    }

                    for (int i = 0; i < 9; i++)
                        userinfo[i] = tempUserInfo[i];
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void LoadUserImg(string strId, Image img)
        {
            try
            {
                conn.Open();
                string sql = "select Thumbnail from user where Id = '" + strId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    byte[] buf = (byte[])rdr[0];
                    MemoryStream stream = new MemoryStream(buf);
                    BitmapImage imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = stream;
                    imageSource.EndInit();
                    img.Source = imageSource;
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void UpdateUserInfo(string Id, ref string[] UserInfo)
        {
            string sql = "update user set ";
            string[] column = { "NickName", "Comment",
                "PhoneNum","CompanyNum", "HomeNum", "Email" };
            bool IsSecend = false;

            for (int i = 0; i < 6; i++)
            {
                if (UserInfo[i].Equals("")) continue;   //유저정보가 Null일 경우, 넘김

                if (IsSecend == true)   //두번째 값일 때부터 ","를 넣어줌
                    sql += ", ";
                sql += column[i] + " = '" + UserInfo[i] + "'";
                IsSecend = true;
            }
            sql += " where Id='" + Id + "'";    //쿼리문 조건절

            if (UserInfo[0].Equals("") && UserInfo[1].Equals("") && UserInfo[2].Equals("") && UserInfo[3].Equals("") &&
                            UserInfo[4].Equals("") && UserInfo[5].Equals("")) return;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void UpdateUserImg(string strId, string strFileName)
        {
            FileStream fs;
            BinaryReader br;
            byte[] ImageData;
            fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);

            try
            {
                conn.Open();
                string sql = "update user set Thumbnail =@Thumbnail where Id = '" + strId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@Thumbnail", MySqlDbType.MediumBlob);
                cmd.Parameters["@Thumbnail"].Value = ImageData;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                br.Close();
                fs.Close();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }

    /// <summary>
    /// DocumentWindow와의 상호작용하는 DataBase 컨트롤러
    /// </summary>
    public partial class DatabaseControl
    {
        public void LoadCategoryTree(string strId,TreeView trvCategory)
        {
            try
            {
                trvCategory.Items.Clear();
                conn.Open();
                string sql = "select * from category where Id = '" + strId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    //레코드에서 부모 Key를 가져옴
                    string tempParentKey = rdr.GetInt32("ParentId").ToString();
                    //Items 콜렉션과 부모 Key를 가지고 함수 호출
                    TreeViewItem triParent = SerchNode(trvCategory.Items, tempParentKey);
                    
                    //레코드에서 자신의 Key을 가져옴
                    string tempKey = rdr.GetInt32("ChildId").ToString();
                   
                    //레코드에서 자신의 Item 이름을 가져옴
                    string tempCategryName = rdr.GetString("Name");

                    TreeViewItem triChild = new TreeViewItem();
                    triChild.ItemsSource = tempCategryName;

                    //부모노드에 추가
                    triParent.Items.Add(triChild);
                    //bool Exist = IsExist(trvCategory, temLocation + "\\" + tempCategryName, "\\");
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /*private bool IsExist(TreeView trv, string path, params string[] Splitter)
        {
            string[] a = path.Split(Splitter, StringSplitOptions.None);
            foreach (ItemCollection objTreeviewItem in trv.Items)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (objTreeviewItem.ToString().Equals("text"))
                    {

                    }
                }
                //here you have your treeview item.
            }
            for (int i = 0; i < trv.Items.Count; i++)
            {
                //trv_category.Items.GetItemAt(i);
            }
        }*/

        private TreeViewItem SerchNode(ItemCollection objItems, string strKey)
        {   
            //Nodes의 node를 가지고 찾을 때까지 반복합니다.
            foreach (TreeViewItem objTreeviewItem in objItems)
            {
                if (objTreeviewItem.ToString().Equals(strKey)) return objTreeviewItem;

                //없을 경우 하위 Nodes를 가지고 다시 SerchNode를 호출합니다.
                TreeViewItem fineItem = SerchNode(objTreeviewItem., strKey);

                //하위노드 검색 결과를 비교하여 Null이 아닐경우(찾을 경우) Item을 리턴합니다.
                if (fineItem != null) return fineItem;
            }
            //검색 결과 조건에 맞는 Node가 없을 경우 Null을 리턴합니다.
            return null;
        }

        public void fillCategoryList(string strId, ComboBox cmb_selectCategory)
        {
            try
            {
                conn.Open();
                string sql = "select * from category where Id = '" + strId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string name = rdr.GetString("Name");
                    cmb_selectCategory.Items.Add(name);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void SaveDocument(string strId, ref string[] docInfo)
        {
            try
            {
                conn.Open();
                string sql = "insert into document (Title, Sort, Tag, Writer, RecentModifyDate, Content) values('" + docInfo[0] +
                                "', '" + docInfo[1] + "', '" + docInfo[2] + "', '" + docInfo[4] + "', CURRENT_TIMESTAMP, '" + docInfo[3] + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public string SelectDocument(string ID, string title)
        {
            string sql = "select * from Document where Writer ='" + ID + "'and Title = '" + title + "'";
            string tempTitle;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tempTitle = rdr.GetString("Title");
                    return tempTitle;
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return "";
        }

        public void UpdateDocument(string strId, string strPreparationDate, ref string[] docInfo)
        {

            string sql = "update Document set Title = '" + docInfo[0] + "'," +
                "Sort = '" + docInfo[1] +
                "', Tag = '" + docInfo[2] +
                "', RecentModifyDate = CURRENT_TIMESTAMP," +
                " Content = '" + docInfo[3] + "'" +
                " where Id = '" + strId + "' and PreparationDate = '" + strPreparationDate + "'";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }

    /// <summary>
    /// ContactWindow와의 상호작용하는 DataBase 컨트롤러
    /// </summary>
    public partial class DatabaseControl
    {
        public void AddContect(string strUserId, string strFriendId)
        {
            if (!IsNull_Column_UserId("user", "UserId", strFriendId))
            {
                try
                {
                    conn.Open();
                    string sql = "insert into friends (UserId, FriendId) values('" + strUserId + "', '" + strFriendId + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Close();
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            else
                MessageBox.Show("존재하지않는 아이디입니다.");
        }

        public void FillContectList(string strId, ListBox lsbContacts)
        {
            try
            {
                conn.Open();
                string sql = "select * from friends where UserId = '" + strId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string tempFriendId;
                    tempFriendId = rdr.GetString("FriendId");

                    lsbContacts.Items.Add(tempFriendId);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void SelectContect(string strFriendId, ref string[] friendInfo)
        {
            try
            {
                conn.Open();
                string sql = "select * from user" +
                    " where UserId = '" + strFriendId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string tempFriendId;
                    string tempFriendNickname;
                    string tempFriendComment;
                    tempFriendId = rdr.GetString("UserId");
                    tempFriendNickname = rdr.GetString("Nickname");
                    tempFriendComment = rdr.GetString("Comment");

                    friendInfo[0] = tempFriendId;
                    friendInfo[1] = tempFriendNickname;
                    friendInfo[2] = tempFriendComment;
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void UploadFile(string strUserId, string strFriendId, string strFileName)
        {
            FileStream fs;
            BinaryReader br;
            byte[] Data;
            fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            Data = br.ReadBytes((int)fs.Length);

            try
            {
                conn.Open();
                string sql = "insert into message (Sid, SenderSid, Content) " +
                    "values('" + strFriendId + "', '" + strUserId + "', @Content)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlParameter contentParam = new MySqlParameter("@Content", MySqlDbType.MediumBlob);
                contentParam.Value = Data;
                cmd.Parameters.Add(contentParam);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                br.Close();
                fs.Close();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void DownloadFile(string strId, string strFileName)
        {
            FileStream fs;
            BinaryWriter bw;
            try
            {
                conn.Open();
                string sql = "select Content from message where Id = '" + strId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    byte[] buf = (byte[])rdr[0];
                    fs = new FileStream(strFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    bw = new BinaryWriter(fs);
                    bw.Write(buf);
                    bw.Close();
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void GetData(string strUserid, string strFriendId, DataGrid dtg_Message)
        {
            string sql = "select Id, SendTime from message " +
                "where Sid = '" + strFriendId + "' or SenderSid = '" + strUserid + "'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(dt);
            dtg_Message.DataContext = dt;
        }

        public void FillMessageList(string strUserid, string strFriendId, ListBox lsbMessage)
        {
            try
            {
                conn.Open();
                string sql = "select Id, SendTime from message " +
                "where (Sid = '" + strFriendId + "' and SenderSid = '" + strUserid + "') or" +
                "(Sid = '" + strUserid + "' and SenderSid = '" + strFriendId + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string tempId;
                    string tempSendTime;
                    tempId = rdr.GetString("Id");
                    tempSendTime = rdr.GetString("SendTime");
                    string item = string.Format("Id: {0}   |   SendTime: {1}", tempId, tempSendTime);
                    lsbMessage.Items.Add(item);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
