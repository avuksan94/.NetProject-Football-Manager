using DL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerWPFApp.Model
{
    public class PlayerBL : INotifyPropertyChanged
    {
        private string? name;
        private bool captain;
        private long shirtNumber;
        private Position position;
        private int yellowCards;
        private int goals;
        private int appearances;

        public string? Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public bool Captain
        {
            get { return captain; }
            set
            {
                if (captain != value)
                {
                    captain = value;
                    OnPropertyChanged("Captain");
                }
            }
        }

        public long ShirtNumber
        {
            get { return shirtNumber; }
            set
            {
                if (shirtNumber != value)
                {
                    shirtNumber = value;
                    OnPropertyChanged("ShirtNumber");
                }
            }
        }

        public Position Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    OnPropertyChanged("Position");
                }
            }
        }

        public int YellowCards
        {
            get { return yellowCards; }
            set
            {
                if (yellowCards != value)
                {
                    yellowCards = value;
                    OnPropertyChanged("YellowCards");
                }
            }
        }

        public int Goals
        {
            get { return goals; }
            set
            {
                if (goals != value)
                {
                    goals = value;
                    OnPropertyChanged("Goals");
                }
            }
        }

        public int Appearances
        {
            get { return appearances; }
            set
            {
                if (appearances != value)
                {
                    appearances = value;
                    OnPropertyChanged("Appearances");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
