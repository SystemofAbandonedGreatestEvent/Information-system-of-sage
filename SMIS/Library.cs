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
using System.ComponentModel;
using System.Collections.ObjectModel;
using SMIS.Entities;

namespace SMIS
{
    public partial class Library
    {
        private static Library libarary;
        DatabaseControl dbcon = new DatabaseControl();
        private UserEntity userEtt;
        private DocumentEntity documentEtt;
        private CategoryEntity categoryEtt;
        private FriendsEntity friendsEtt;
        private MessageEntity messageEtt;

        public static Library GetInstance()
        {
            if (libarary == null) libarary = new Library();
            return libarary;
        }

        public void Initialization(string strUserId)
        {
            userEtt = new UserEntity(strUserId);
            friendsEtt = new FriendsEntity(strUserId);
            set_userInfo(strUserId);
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
    }

    /// <summary>
    /// Login, Account와의 상호작용
    /// </summary>
    public partial class Library
    {
        public void set_userInfo(string strUserId)
        {
            string[] tempUserInfo = new string[9];
            dbcon.LoadUserInfo(userEtt.UserId, ref tempUserInfo);

            userEtt.Id = tempUserInfo[0];
            userEtt.NickName = tempUserInfo[1];
            userEtt.State = tempUserInfo[2];
            userEtt.Comment = tempUserInfo[3];
            userEtt.Address = tempUserInfo[4];
            userEtt.Email = tempUserInfo[5];
            userEtt.PhoneNum = tempUserInfo[6];
            userEtt.HomeNum = tempUserInfo[7];
            userEtt.CompanyNum = tempUserInfo[8];
        }

        public void set_state(string strState)
        {
            userEtt.State = strState;
        }

        public string get_Id()
        {
            return userEtt.Id;
        }

        public string get_userId()
        {
            return userEtt.UserId;
        }

        public string get_Nickname()
        {
            return userEtt.NickName;
        }

        public int get_State()
        {
            int tempState;
            tempState = Convert.ToInt32(userEtt.State);
            return tempState;
        }

        public string get_Comment()
        {
            return userEtt.Comment;
        }

        public string get_Address()
        {
            return userEtt.Address;
        }

        public string get_Email()
        {
            return userEtt.Email;
        }

        public string get_PhoneNum()
        {
            return userEtt.PhoneNum;
        }

        public string get_HomeNum()
        {
            return userEtt.HomeNum;
        }

        public string get_CompanyNum()
        {
            return userEtt.CompanyNum;
        }

        public List<string> State = new List<string>
        {
            "오프라인",
            "온라인",
            "자리 비움",
            "다른 용무중"
        };
    }

    /// <summary>
    /// Document와의 상호작용
    /// </summary>
    public partial class Library
    {
        public void set_documentInfo(ref string[] strDocumentInfo)
        {
            documentEtt = new DocumentEntity(
                strDocumentInfo[0], strDocumentInfo[1], strDocumentInfo[3], strDocumentInfo[2]);
           
        }

        public void set_PreparationDate(string strPreparationDate)
        {
            documentEtt.PreparationDate = strPreparationDate;
        }

        public string get_title()
        {
            return documentEtt.Title;
        }
    }

    /// <summary>
    /// Contact와의 상호작용
    /// </summary>
    public partial class Library
    {
        public void set_friendInfo(string strFriendId)
        {
            string[] tempInfo = new string[5]; 
            dbcon.SelectContect(strFriendId, ref tempInfo);
            friendsEtt.FriendId = tempInfo[0];
            friendsEtt.FriendNickname = tempInfo[1];
            friendsEtt.FriendComment = tempInfo[2];
            friendsEtt.Id = tempInfo[3];
        }

        public string get_fId()
        {
            return friendsEtt.Id;
        }

        public string get_friendId()
        {
            return friendsEtt.FriendId;
        }

        public string get_friendNickname()
        {
            return friendsEtt.FriendNickname;
        }

        public string get_friendComment()
        {
            return friendsEtt.FriendComment;
        }
    }
}