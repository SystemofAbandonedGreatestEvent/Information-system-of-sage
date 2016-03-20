using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information_system_of_sage.login
{
    class opAccount
    {
        static private string opId = "sylvester127";
        static private string opPassword = "liberty114";

        static public int opUser(string Id, string Password)
        {
            if (opId == Id && opPassword == Password)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    class Accounts
    {        
        private string Id;
        private string Password;
        private enum authoritySystem { SSS, SS, S, A, B, C, D, E, F };
        private int authority;
        
        private int firstXorCode;
        private int secondXorCode;

        private int secureId(string ID, int srcCode)
        {
            int tmp = int.Parse(ID);
            return tmp ^ srcCode;
        }

        private int securdPassword(string Password, int srcCode)
        {
            int tmp = int.Parse(Password);
            return tmp ^ srcCode;
        }

        public void setAccounts(string Id, string Password)
        {
            Random randomCode = new Random();           
            firstXorCode = randomCode.Next() + randomCode.Next() + randomCode.Next();   //Id키값 할당
            secondXorCode = randomCode.Next() + randomCode.Next() + randomCode.Next();  //Password키값 할당

            int EncrytedId = secureId(Id, firstXorCode.GetHashCode()); //Id 암호화
            int EncrytedPassword = securdPassword(Password, secondXorCode.GetHashCode());  //Password 암호화
            this.Id = Convert.ToString(EncrytedId); //암호화된 아이디 저장
            this.Password = Convert.ToString(EncrytedPassword); //암호화된 비밀번호 저장
            this.authority = (int)authoritySystem.F;    //보안등급 F등급으로 초기화
        }

        public int getAccounts(string Id, string Password)
        {
            string DecryptedId = Convert.ToString(secureId(this.Id, firstXorCode)); //Id 복호화
            string DecryptedPassword = Convert.ToString(
                securdPassword(this.Password,secondXorCode));   //Password 복호화
                           
            if(Id == DecryptedId)
            {
                if (Password == DecryptedPassword)
                {
                    return 0;
                }
                else
                {
                    return -2;
                }
                
            }
            else
            {
                return -1;
            }
        }

        public void EncrytedIdAndPassword()
        {

        }
    }
}
