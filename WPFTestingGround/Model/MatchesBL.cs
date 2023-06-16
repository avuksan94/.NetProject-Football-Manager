using DL.Enums;
using DL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestingGround.Model
{
    public class MatchesBL : INotifyPropertyChanged
    {
        private long attendance;
        private Team? awayTeam;
        private string? awayTeamCountry;
        private List<TeamEvent>? awayTeamEvents;
        private TeamStatistics? awayTeamStatistics;
        private DateTimeOffset datetime;
        private long fifaId;
        private Team? homeTeam;
        private string? homeTeamCountry;
        private List<TeamEvent>? homeTeamEvents;
        private TeamStatistics? homeTeamStatistics;
        private DateTimeOffset lastEventUpdateAt;
        private DateTimeOffset? lastScoreUpdateAt;
        private string? location;
        private List<string>? officials;
        private StageName? stageName;
        private Status status;
        private Time time;
        private string? venue;
        private Weather? weather;
        private string? winner;
        private string? winnerCode;

        public long Attendance
        {
            get { return attendance; }
            set
            {
                if (attendance != value)
                {
                    attendance = value;
                    OnPropertyChanged(nameof(Attendance));
                }
            }
        }

        public Team? AwayTeam
        {
            get { return awayTeam; }
            set
            {
                if (awayTeam != value)
                {
                    awayTeam = value;
                    OnPropertyChanged(nameof(AwayTeam));
                }
            }
        }

        public string? AwayTeamCountry
        {
            get { return awayTeamCountry; }
            set
            {
                if (awayTeamCountry != value)
                {
                    awayTeamCountry = value;
                    OnPropertyChanged(nameof(AwayTeamCountry));
                }
            }
        }

        public List<TeamEvent>? AwayTeamEvents
        {
            get { return awayTeamEvents; }
            set
            {
                if (awayTeamEvents != value)
                {
                    awayTeamEvents = value;
                    OnPropertyChanged(nameof(AwayTeamEvents));
                }
            }
        }

        public TeamStatistics? AwayTeamStatistics
        {
            get { return awayTeamStatistics; }
            set
            {
                if (awayTeamStatistics != value)
                {
                    awayTeamStatistics = value;
                    OnPropertyChanged(nameof(AwayTeamStatistics));
                }
            }
        }

        public DateTimeOffset Datetime
        {
            get { return datetime; }
            set
            {
                if (datetime != value)
                {
                    datetime = value;
                    OnPropertyChanged(nameof(Datetime));
                }
            }
        }

        public long FifaId
        {
            get { return fifaId; }
            set
            {
                if (fifaId != value)
                {
                    fifaId = value;
                    OnPropertyChanged(nameof(FifaId));
                }
            }
        }

        public Team? HomeTeam
        {
            get { return homeTeam; }
            set
            {
                if (homeTeam != value)
                {
                    homeTeam = value;
                    OnPropertyChanged(nameof(HomeTeam));
                }
            }
        }

        public string? HomeTeamCountry
        {
            get { return homeTeamCountry; }
            set
            {
                if (homeTeamCountry != value)
                {
                    homeTeamCountry = value;
                    OnPropertyChanged(nameof(HomeTeamCountry));
                }
            }
        }

        public List<TeamEvent>? HomeTeamEvents
        {
            get { return homeTeamEvents; }
            set
            {
                if (homeTeamEvents != value)
                {
                    homeTeamEvents = value;
                    OnPropertyChanged(nameof(HomeTeamEvents));
                }
            }
        }

        public TeamStatistics? HomeTeamStatistics
        {
            get { return homeTeamStatistics; }
            set
            {
                if (homeTeamStatistics != value)
                {
                    homeTeamStatistics = value;
                    OnPropertyChanged(nameof(HomeTeamStatistics));
                }
            }
        }

        public DateTimeOffset LastEventUpdateAt
        {
            get { return lastEventUpdateAt; }
            set
            {
                if (lastEventUpdateAt != value)
                {
                    lastEventUpdateAt = value;
                    OnPropertyChanged(nameof(LastEventUpdateAt));
                }
            }
        }

        public DateTimeOffset? LastScoreUpdateAt
        {
            get { return lastScoreUpdateAt; }
            set
            {
                if (lastScoreUpdateAt != value)
                {
                    lastScoreUpdateAt = value;
                    OnPropertyChanged(nameof(LastScoreUpdateAt));
                }
            }
        }

        public string? Location
        {
            get { return location; }
            set
            {
                if (location != value)
                {
                    location = value;
                    OnPropertyChanged(nameof(Location));
                }
            }
        }

        public List<string>? Officials
        {
            get { return officials; }
            set
            {
                if (officials != value)
                {
                    officials = value;
                    OnPropertyChanged(nameof(Officials));
                }
            }
        }

        public StageName? StageName
        {
            get { return stageName; }
            set
            {
                if (stageName != value)
                {
                    stageName = value;
                    OnPropertyChanged(nameof(StageName));
                }
            }
        }

        public Status Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public Time Time
        {
            get { return time; }
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }

        public string? Venue
        {
            get { return venue; }
            set
            {
                if (venue != value)
                {
                    venue = value;
                    OnPropertyChanged(nameof(Venue));
                }
            }
        }

        public Weather? Weather
        {
            get { return weather; }
            set
            {
                if (weather != value)
                {
                    weather = value;
                    OnPropertyChanged(nameof(Weather));
                }
            }
        }

        public string? Winner
        {
            get { return winner; }
            set
            {
                if (winner != value)
                {
                    winner = value;
                    OnPropertyChanged(nameof(Winner));
                }
            }
        }

        public string? WinnerCode
        {
            get { return winnerCode; }
            set
            {
                if (winnerCode != value)
                {
                    winnerCode = value;
                    OnPropertyChanged(nameof(WinnerCode));
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
