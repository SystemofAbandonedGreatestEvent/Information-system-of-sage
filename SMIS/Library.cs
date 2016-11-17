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
    public class Library
    {
        private static Library libarary;
        private string userID;

        public static Library GetInstance()
        {
            if (libarary == null) libarary = new Library();
            return libarary;
        }

        public void set_userID(string userID)
        {
            this.userID = userID;
        }

        public string get_userID()
        {
            return userID;
        }

        public struct WindowPoint
        {
            public int x;
            public int y;

            public WindowPoint(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }

        public List<string> state = new List<string>
        {
            "온라인",
            "자리 비움",
            "다른 용무중"
        };

    }

    public class DBControl
    {
        private static String strConn = "Server=localhost;Database=smis;Uid=root;Pwd=1111;";
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
        }

        /// <summary>
        /// Database에 대한 CRUE
        /// </summary>
        public void CreactUpdateDelete(String sql)
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
                String sql = "select ProfileImage from user where ID = '"+ID+"'";
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

        private bool IsNull_Column(string table, string col, string ID)
        {           
            String sql =  "select isnull(" + col + ") from " + table + " where ID = '" + ID + "'";
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
    }
}