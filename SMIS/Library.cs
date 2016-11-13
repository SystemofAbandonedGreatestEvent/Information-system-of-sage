using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SMIS
{
    public class Library
    {
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
    }

    public class DBControl
    {
        private static String strConn = "Server=localhost;Database=smis;Uid=root;Pwd=1111;";
        private MySqlConnection conn = new MySqlConnection(strConn);

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
        }

        public int LoginCheck(string ID,string PW, String sql)
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
                return flag = -2; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return flag - 2;
            }
        }
    }
}