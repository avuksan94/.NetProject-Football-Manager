using DL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestingGround.Model
{
    //nisam koristio ali sam ostavio
    public class GroupResultBL : INotifyPropertyChanged
    {
        private long id;
        private string? letter;
        private List<OrderedTeam>? orderedTeams;
        public long Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Letter
        {
            get { return letter; }
            set
            {
                if (letter != value)
                {
                    letter = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public List<OrderedTeam>? OrderedTeams
        {
            get { return orderedTeams; }
            set
            {
                if (orderedTeams != value)
                {
                    orderedTeams = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
