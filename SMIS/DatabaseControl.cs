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

namespace SMIS
{
    public class DatabaseControl
    {
        Library library;

        /// <summary>
        /// Database 연동
        /// </summary>
        private static String strConn = "Server=sylvester.ipdisk.co.kr;Database=smis;Uid=root;Pwd=noble@2718;";
        private MySqlConnection conn = new MySqlConnection(strConn);
        private MySqlConnection con = new MySqlConnection(strConn);

        /// <summary>
        /// Database 연결테스트
        /// </summary>
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
        }

        /// <summary>
        /// Database에 대한 CRUE
        /// </summary>
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

        public int CheckLogin(string ID, string PW, String sql)
        {
            int flag = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string tempID, tempPassword;
                    tempID = rdr.GetString("ID");
                    tempPassword = rdr.GetString("Password");

                    if (ID.Equals(tempID) && PW.Equals(tempPassword))
                    {
                        return flag = 0;
                    }
                    else if (tempID.Equals(ID) && tempPassword != PW)
                    {
                        return flag = -1;
                    }
                }
                rdr.Close();
                conn.Close();
                return flag = -2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return flag - 2;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void LoadUserInfo(string ID, String sql, ref string[] userinfo)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string tempnickname = null;
                    string tempstatemessage = null;
                    string tempphoneNum = null;
                    string tempcompanyNum = null;
                    string temphomeNum = null;
                    string tempEmail = null;

                    if (!IsNull_Column("user", "NickName", ID))
                        tempnickname = rdr.GetString("NickName");
                    if (!IsNull_Column("user", "StateMessage", ID))
                        tempstatemessage = rdr.GetString("StateMessage");
                    if (!IsNull_Column("user", "PhoneNum", ID))
                        tempphoneNum = rdr.GetString("PhoneNum");
                    if (!IsNull_Column("user", "CompanyNum", ID))
                        tempcompanyNum = rdr.GetString("CompanyNum");
                    if (!IsNull_Column("user", "HomeNum", ID))
                        temphomeNum = rdr.GetString("HomeNum");
                    if (!IsNull_Column("user", "Email", ID))
                        tempEmail = rdr.GetString("Email");

                    userinfo[0] = tempnickname;
                    userinfo[1] = tempstatemessage;
                    userinfo[2] = tempphoneNum;
                    userinfo[3] = tempcompanyNum;
                    userinfo[4] = temphomeNum;
                    userinfo[5] = tempEmail;
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

        public void LoadUserImg(string ID, Image img)
        {
            try
            {
                conn.Open();
                String sql = "select ProfileImage from user where ID = '" + ID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    byte[] tempImg = (byte[])rdr[0];
                    MemoryStream mem = new MemoryStream(tempImg);
                    var imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = mem;
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
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
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void UpdateUserImg(string ID, string FileName)
        {
            FileStream fs;
            BinaryReader br;
            byte[] ImageData;
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);

            try
            {
                conn.Open();
                String sql = "update user set ProfileImage =@profileImage where ID = '" + ID + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@profileImage", MySqlDbType.MediumBlob);
                cmd.Parameters["@profileImage"].Value = ImageData;
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
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void UpdateUserInfo(string ID, String sql, ref string[] userinfo)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

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

        public bool IsNull_UserImg(string ID)
        {
            String sql = "select isnull(ProfileImage) from user where ID = '" + ID + "'";
            try
            {
                con.Open();
                MySqlCommand _cmd = new MySqlCommand(sql, con);
                MySqlDataReader _rdr = _cmd.ExecuteReader();
                while (_rdr.Read())
                {
                    int temp = _rdr.GetInt16(0);
                    if (temp.Equals(0))
                    {
                        _rdr.Close();
                        con.Close();
                        return true;   //DB에 값이 있으면
                    }
                }
                _rdr.Close();
                con.Close();
                return false;    //DB에 값이 없으면
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                return false;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void LoadCategory(TreeView trv_category)
        {
            String sql = "select * from category order by Name asc";
            try
            {
                trv_category.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                var sqlData = new List<Category>
                  {
                      new Category {ParentId = null, Name = "F1"},
                      new Category {ParentId = null, Name = "F2"},
                      new Category {ParentId = 1, Name = "S1"},
                      new Category {ParentId = 2, Name = "S21"},
                      new Category {ParentId = 2, Name = "S22"},
                  };
                trv_category.ItemsSource = library.GetHerachy(sqlData);
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

        public void fillCategoryList(string ID, ComboBox cmb_selectCategory)
        {
            String sql = "select * from category where Madeby = '" + ID + "'";

            try
            {
                conn.Open();
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

        public void SaveDocument(ref string[] docInfo, String content)
        {
            String sql = "insert into document (Title, Sort, Tag, Writer, RecentModifyDate, Content) values('" + docInfo[1] +
                "', '" + docInfo[2] + "', '" + docInfo[3] + "', '" + docInfo[0] + "', now(), '" + content + "')";

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

        public void UpdateDocument(ref string[] docInfo, String content, string preTitle)
        {

            String sql = "update Document set Title = '" + docInfo[1] + "'," +
                "Sort = '" + docInfo[2] +
                "', Tag = '" + docInfo[3] +
                "', RecentModifyDate = now()," +
                " Content = '" + content + "'" +
                " where Title = '" + preTitle + "'";

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

        private bool IsNull_Column(string table, string col, string ID)
        {
            String sql = "select isnull(" + col + ") from " + table + " where ID = '" + ID + "'";
            try
            {
                con.Open();
                MySqlCommand _cmd = new MySqlCommand(sql, con);
                MySqlDataReader _rdr = _cmd.ExecuteReader();
                while (_rdr.Read())
                {
                    int temp = _rdr.GetInt16(0);
                    if (temp.Equals(0)) //DB에 값이 있으면
                    {
                        _rdr.Close();
                        con.Close();
                        return false;
                    }
                }
                _rdr.Close();
                con.Close();
                return true;    //DB에 값이 없으면
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                return true;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

    }
}
