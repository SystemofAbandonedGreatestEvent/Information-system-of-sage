using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMIS.Entities
{
    class UserEntity
    {
        public string Id { get; private set; }
        public IList<string> InterestIds { get; set; }
        //public string ThumbnailPath { get; set; }
        public string UserId { get; set; }
        public string NickName { get; set; }
        public IList<string> State { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string CompanyNum { get; set; }
        public string Sid { get; set; }

        public UserEntity(string strUserId, string strSid, IList<string> InterestIds)
        {
            this.UserId = strUserId;
            this.Sid = strSid;
            this.InterestIds = InterestIds;
        }
    }
}
