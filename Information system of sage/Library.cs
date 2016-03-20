using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Information_system_of_sage
{
    class Library
    {
        public static string findDrawableDiretory()
        {
            string strDirectory = Application.StartupPath;
            strDirectory = strDirectory.Substring(0, strDirectory.LastIndexOf("\\"));
            strDirectory = strDirectory.Substring(0, strDirectory.LastIndexOf("\\"));
            strDirectory += "\\drawable";
            return strDirectory;
        }
    }
}
