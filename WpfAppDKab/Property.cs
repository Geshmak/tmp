using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfAppDKab
{
    class Property : IDataErrorInfo, INotifyPropertyChanged
    {
        private string path;
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value.Trim();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Path"));

            }
        }
        public string Error => throw new NotImplementedException();
        public Property()
        {
           
            //list = V4MC.list;
            
        }
        public string this[string property]
        {
            get
            {
                string msg = null;
                switch (property)
                {
                    case "Path":
                        if (Path == null)
                            msg = "Path  null";
                        else if (Path.Length == 0)
                            msg = "Path length";
                        break;
                    
                    default:
                        break;

                }
                return msg;
            }
        }
    }
}
