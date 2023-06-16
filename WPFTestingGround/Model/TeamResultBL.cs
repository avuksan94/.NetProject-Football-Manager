using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestingGround.Model
{
    public class TeamResultBL : INotifyPropertyChanged
    {
        private object? alternateName;
        private string? country;
        private long? draws;
        private string? fifaCode;
        private long gamesPlayed;
        private long goalDifferential;
        private long goalsAgainst;
        private long goalsFor;
        private long groupId;
        private string? groupLetter;
        private long id;
        private long losses;
        private long points;
        private long wins;

        public object? AlternateName
        {
            get { return alternateName; }
            set
            {
                if (alternateName != value)
                {
                    alternateName = value;
                    OnPropertyChanged("AlternateName");
                }
            }
        }

        public string? Country
        {
            get { return country; }
            set
            {
                if (country != value)
                {
                    country = value;
                    OnPropertyChanged("Country");
                }
            }
        }

        public long? Draws
        {
            get { return draws; }
            set
            {
                if (draws != value)
                {
                    draws = value;
                    OnPropertyChanged("Draws");
                }
            }
        }

        public string? FifaCode
        {
            get { return fifaCode; }
            set
            {
                if (fifaCode != value)
                {
                    fifaCode = value;
                    OnPropertyChanged("FifaCode");
                }
            }
        }

        public long GamesPlayed
        {
            get { return gamesPlayed; }
            set
            {
                if (gamesPlayed != value)
                {
                    gamesPlayed = value;
                    OnPropertyChanged("GamesPlayed");
                }
            }
        }

        public long GoalDifferential
        {
            get { return goalDifferential; }
            set
            {
                if (goalDifferential != value)
                {
                    goalDifferential = value;
                    OnPropertyChanged("GoalDifferential");
                }
            }
        }

        public long GoalsAgainst
        {
            get { return goalsAgainst; }
            set
            {
                if (goalsAgainst != value)
                {
                    goalsAgainst = value;
                    OnPropertyChanged("GoalsAgainst");
                }
            }
        }

        public long GoalsFor
        {
            get { return goalsFor; }
            set
            {
                if (goalsFor != value)
                {
                    goalsFor = value;
                    OnPropertyChanged("GoalsFor");
                }
            }
        }

        public long GroupId
        {
            get { return groupId; }
            set
            {
                if (groupId != value)
                {
                    groupId = value;
                    OnPropertyChanged("GroupId");
                }
            }
        }

        public string? GroupLetter
        {
            get { return groupLetter; }
            set
            {
                if (groupLetter != value)
                {
                    groupLetter = value;
                    OnPropertyChanged("GroupLetter");
                }
            }
        }

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

        public long Losses
        {
            get { return losses; }
            set
            {
                if (losses != value)
                {
                    losses = value;
                    OnPropertyChanged("Losses");
                }
            }
        }

        public long Points
        {
            get { return points; }
            set
            {
                if (points != value)
                {
                    points = value;
                    OnPropertyChanged("Points");
                }
            }
        }

        public long Wins
        {
            get { return wins; }
            set
            {
                if (wins != value)
                {
                    wins = value;
                    OnPropertyChanged("Wins");
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
