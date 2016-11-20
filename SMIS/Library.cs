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

namespace SMIS
{
    public class Library
    {
        private static Library libarary;
        private string userID;
        private string documentTitle;

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

        public void set_documentName(string documentTitle)
        {
            this.documentTitle = documentTitle;
        }

        public string get_documentName()
        {
            return documentTitle;
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

        public List<LocalData> GetHerachy(List<Category> sqlData)
        {
            var sqlParents = sqlData.Where(q => q.ParentId == null).ToList();
            var parents = sqlParents.Select(q => new LocalData { Id = q.Id, Name = q.Name }).ToList();
            foreach (var parent in parents)
            {
                var childs = sqlData.Where(q => q.ParentId == parent.Id).Select(q => new LocalData { Id = q.Id, Name = q.Name, Parent = parent });
                parent.Children = new ObservableCollection<LocalData>(childs);
            }
            return parents;
        }
    }

    public class Category
    {
        public int? Id { get; set; }

        public int? ParentId { get; set; }

        public String Name { get; set; }

        public String OtherDataRelatedToTheNode { get; set; }
    }

    public class LocalData : INotifyPropertyChanged
    {
        private int? _id;
        public int? Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        private int? _parentId;

        public int? ParentId
        {
            get { return _parentId; }
            set { _parentId = value; OnPropertyChanged("ParentId"); }
        }

        private string _name;
        public String Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private string _otherDataRelatedToTheNode;
        public String OtherDataRelatedToTheNode
        {
            get { return _otherDataRelatedToTheNode; }
            set { _otherDataRelatedToTheNode = value; OnPropertyChanged("OtherDataRelatedToTheNode"); }
        }

        private LocalData _parent;
        public LocalData Parent
        {
            get { return _parent; }
            set { _parent = value; OnPropertyChanged("Parent"); }
        }

        private ObservableCollection<LocalData> _children;
        public ObservableCollection<LocalData> Children
        {
            get { return _children; }
            set { _children = value; OnPropertyChanged("Children"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}