using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMIS.Entities
{
    class FriendsEntity
    {
        public string Id { get; private set; }
        public string UserSID { get; set; }
        public IList<string> FriendSIDs { get; set; }

        public FriendsEntity(string strUserSID)
        {
            this.UserSID = strUserSID;
        }

        public FriendsEntity(string strUserSID, IList<string> arFriends)
            : this(strUserSID)
        {
            this.FriendSIDs = arFriends;
        }
    }
}
