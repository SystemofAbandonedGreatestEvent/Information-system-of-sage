using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMIS.Entities
{
    class DocumentEntity
    {
        public string Id { get; private set; }
        public string Title { get; set; }
        public string Sort { get; set; }
        public string Content { get; set; }
        public string Tag { get; set; }
        public string PreparationDate { get; set; }
        public string RecentModifyDate { get; set; }
        public string Writer { get; set; }

        DocumentEntity(string strTitle, string strSort, string strContent, string strTag,
            string strPreparationDate, string strRecentModifyDate, string strWriter)
        {
            this.Title = strTitle;
            this.Sort = strSort;
            this.Content = strContent;
            this.Tag = strTag;
            this.PreparationDate = strPreparationDate;
            this.RecentModifyDate = strRecentModifyDate;
            this.Writer = strWriter;
        }

        DocumentEntity(string strTitle, string strSort, string strContent, string strTag,
            string strRecentModifyDate, string strWriter)
        {
            this.Title = strTitle;
            this.Sort = strSort;
            this.Content = strContent;
            this.Tag = strTag;
            
            this.RecentModifyDate = strRecentModifyDate;
            this.Writer = strWriter;
        }
    }
}
