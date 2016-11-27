using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMIS.Entities
{
    class FriendsEntity
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public string FriendNickname { get; set; }
        public string FriendComment { get; set; }

        public FriendsEntity(string strUserSID)
        {
            this.UserId = strUserSID;
        } 
    }
}