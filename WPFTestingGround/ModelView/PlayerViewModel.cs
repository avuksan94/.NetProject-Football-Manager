using BL.Services;
using DL.Enums;
using DL.Model;
using FootballManagerWPFApp.Mapper;
using FootballManagerWPFApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WPFTestingGround.Mapper;
using WPFTestingGround.Model;

namespace FootballManagerWPFApp.ModelView
{
    public class PlayerViewModel
    {
        private ObservableCollection<KeyValuePair<string, SortedSet<PlayerBL>>>? _teamBLMale;
        private ObservableCollection<KeyValuePair<string, SortedSet<PlayerBL>>>? _teamBLFemale;

        private readonly MatchesServices _matchesServices;

        private PlayerMapper _mapper;

        public PlayerViewModel() 
        {
            _matchesServices = new MatchesServices();
            initComps();
            LoadTeamPlayers('m');
            LoadTeamPlayers('f');
        }

        private void initComps() 
        {
            _mapper = new PlayerMapper();
        }

        public ObservableCollection<KeyValuePair<string, SortedSet<PlayerBL>>>? TeamMale
        {
            get { return _teamBLMale; }
            set { _teamBLMale = value; }
        }


        public ObservableCollection<KeyValuePair<string, SortedSet<PlayerBL>>>? TeamFemale
        {
            get { return _teamBLFemale; }
            set { _teamBLFemale = value; }
        }

        private async Task LoadTeamPlayers(char gender)
        {
            IList<Match> matches = new List<Match>();

            SortedDictionary<string, SortedSet<Player>> players = new SortedDictionary<string, SortedSet<Player>>();
            ObservableCollection<KeyValuePair<string, SortedSet<PlayerBL>>> convertedCollection = new ObservableCollection<KeyValuePair<string, SortedSet<PlayerBL>>>();

            if (gender == 'm')
            {
                matches = await _matchesServices.GetMaleMatches();
                players = LoadPlayers(matches);

                foreach (var pair in players)
                {
                    string key = pair.Key;
                    SortedSet<Player> playerSet = pair.Value;

                    SortedSet<PlayerBL> mappedSet = new SortedSet<PlayerBL>(playerSet.Select(player => _mapper.MapToViewModel(player)));

                    KeyValuePair<string, SortedSet<PlayerBL>> convertedPair = new KeyValuePair<string, SortedSet<PlayerBL>>(key, mappedSet);

                    convertedCollection.Add(convertedPair);
                }

                _teamBLMale= convertedCollection;

            }
            else if (gender == 'f')
            {
                matches = await _matchesServices.GetFemaleMatches();
                players = LoadPlayers(matches);

                foreach (var pair in players)
                {
                    string key = pair.Key;
                    SortedSet<Player> playerSet = pair.Value;

                    SortedSet<PlayerBL> mappedSet = new SortedSet<PlayerBL>(playerSet.Select(player => _mapper.MapToViewModel(player)));

                    KeyValuePair<string, SortedSet<PlayerBL>> convertedPair = new KeyValuePair<string, SortedSet<PlayerBL>>(key, mappedSet);

                    convertedCollection.Add(convertedPair);
                }

                _teamBLFemale = convertedCollection;
            }
        }

        private SortedDictionary<string, SortedSet<Player>> LoadPlayers(IList<Match> matches)
        {
            SortedDictionary<string, SortedSet<Player>> countryPlayers = new SortedDictionary<string, SortedSet<Player>>();

            foreach (var item in matches.ToList())
            {
                int counterGoals = 0;
                int counterYellowCards = 0;
                int counterAppereance = 0;

                string countryName = item.HomeTeamStatistics.Country;
                SortedSet<Player> players;

                if (!countryPlayers.TryGetValue(countryName, out players))
                {
                    players = new SortedSet<Player>();
                    countryPlayers.Add(countryName, players);
                }

                foreach (var player in item.HomeTeamStatistics.StartingEleven)
                {
                    List<TeamEvent> eventsHome = item.HomeTeamEvents.ToList();
                    List<TeamEvent> eventsAway = item.AwayTeamEvents.ToList();

                    List<StartingEleven> startingHome = item.HomeTeamStatistics.StartingEleven;
                    List<StartingEleven> substitutesHome = item.HomeTeamStatistics.Substitutes;

                    List<StartingEleven> startingAway = item.AwayTeamStatistics.StartingEleven;
                    List<StartingEleven> substitutesAway = item.AwayTeamStatistics.Substitutes;

                    counterGoals += CountGoals(eventsHome, player.Name);
                    counterGoals += CountGoals(eventsAway, player.Name);

                    counterYellowCards += CountYellowCards(eventsHome, player.Name);
                    counterYellowCards += CountYellowCards(eventsAway, player.Name);

                    counterAppereance += CountApperencesStarting11(startingHome, player.Name);
                    counterAppereance += CountApperencesSubs(substitutesHome, eventsHome, player.Name);

                    counterAppereance += CountApperencesStarting11(startingAway, player.Name);
                    counterAppereance += CountApperencesSubs(substitutesAway, eventsAway, player.Name);

                    players.Add(new Player
                    {
                        Name = player.Name,
                        Position = player.Position,
                        ShirtNumber = player.ShirtNumber,
                        Captain = player.Captain,
                        YellowCards = counterYellowCards,
                        Goals= counterGoals,
                        Appereances = counterAppereance
                    });
                }

                foreach (var player in item.HomeTeamStatistics.Substitutes)
                {
                    List<TeamEvent> eventsHome = item.HomeTeamEvents.ToList();
                    List<TeamEvent> eventsAway = item.AwayTeamEvents.ToList();

                    List<StartingEleven> startingHome = item.HomeTeamStatistics.StartingEleven;
                    List<StartingEleven> substitutesHome = item.HomeTeamStatistics.Substitutes;

                    List<StartingEleven> startingAway = item.AwayTeamStatistics.StartingEleven;
                    List<StartingEleven> substitutesAway = item.AwayTeamStatistics.Substitutes;

                    counterGoals += CountGoals(eventsHome, player.Name);
                    counterGoals += CountGoals(eventsAway, player.Name);

                    counterYellowCards += CountYellowCards(eventsHome, player.Name);
                    counterYellowCards += CountYellowCards(eventsAway, player.Name);

                    counterAppereance += CountApperencesStarting11(startingHome, player.Name);
                    counterAppereance += CountApperencesSubs(substitutesHome, eventsHome, player.Name);

                    counterAppereance += CountApperencesStarting11(startingAway, player.Name);
                    counterAppereance += CountApperencesSubs(substitutesAway, eventsAway, player.Name);

                    players.Add(new Player
                    {
                        Name = player.Name,
                        Position = player.Position,
                        ShirtNumber = player.ShirtNumber,
                        Captain = player.Captain,
                        YellowCards = counterYellowCards,
                        Goals = counterGoals,
                        Appereances = counterAppereance
                    });
                }

            }
            return countryPlayers;
        }

        //************************************************************************************************************************************
        public List<PlayerBL> GetHomePlayers(MatchesBL match) 
        {
            IList<PlayerBL> homePlayers = new List<PlayerBL>(); 

            foreach (var player in match.HomeTeamStatistics.StartingEleven)
            {
                homePlayers.Add(_mapper.MapToViewModel(
                    new Player() 
                    {
                        Name = player.Name,
                        Position = player.Position,
                        ShirtNumber = player.ShirtNumber
                    }
                ));
            }

            return homePlayers.ToList();
        }

        public List<PlayerBL> GetAwayPlayers(MatchesBL match)
        {
            IList<PlayerBL> awayPlayers = new List<PlayerBL>();

            foreach (var player in match.AwayTeamStatistics.StartingEleven)
            {
                awayPlayers.Add(_mapper.MapToViewModel(
                    new Player()
                    {
                        Name = player.Name,
                        Position = player.Position,
                        ShirtNumber = player.ShirtNumber
                    }
                ));
            }

            return awayPlayers.ToList();
        }

        public List<PlayerBL> GetPlayerStats(MatchesBL match)
        {
            List<PlayerBL> players = new List<PlayerBL> ();
            foreach (var player in match.HomeTeamStatistics.StartingEleven)
            {
                int counterGoals = 0;
                int counterYellowCards = 0;

                List<TeamEvent> eventsHome = match.HomeTeamEvents.ToList();

                counterGoals += CountGoals(eventsHome, player.Name);
                counterYellowCards += CountYellowCards(eventsHome, player.Name);

                players.Add(new PlayerBL
                {
                    Name = player.Name,
                    Position = player.Position,
                    ShirtNumber = player.ShirtNumber,
                    Captain = player.Captain,
                    YellowCards = counterYellowCards,
                    Goals = counterGoals
                });
            }

            foreach (var player in match.AwayTeamStatistics.StartingEleven)
            {
                int counterGoals = 0;
                int counterYellowCards = 0;

                List<TeamEvent> eventsAway = match.AwayTeamEvents.ToList();

                counterGoals += CountGoals(eventsAway, player.Name);
                counterYellowCards += CountYellowCards(eventsAway, player.Name);

                players.Add(new PlayerBL
                {
                    Name = player.Name,
                    Position = player.Position,
                    ShirtNumber = player.ShirtNumber,
                    Captain = player.Captain,
                    YellowCards = counterYellowCards,
                    Goals = counterGoals
                });
            }

            return players;
            
        }


        //**************************************************************************************************

        //COUNTANJE -- prebaciti u class library
        private int CountGoals(List<TeamEvent> events, string playerName)
        {
            int counter = 0;

            foreach (var ev in events)
            {
                switch (ev.TypeOfEvent)
                {
                    case TypeOfEvent.Goal:
                    case TypeOfEvent.GoalOwn:
                    case TypeOfEvent.GoalPenalty:
                        if (ev.Player == playerName)
                        {
                            counter++;
                        }
                        break;
                    default:
                        break;
                }
            }

            return counter;
        }

        private int CountYellowCards(List<TeamEvent> events, string playerName)
        {
            int counter = 0;

            foreach (var ev in events)
            {
                switch (ev.TypeOfEvent)
                {
                    case TypeOfEvent.YellowCard:
                    case TypeOfEvent.YellowCardSecond:
                        if (ev.Player == playerName)
                        {
                            counter++;
                        }
                        break;
                    default:
                        break;
                }
            }

            return counter;
        }

        private int CountApperencesStarting11(List<StartingEleven> gamePlayers, string playerName)
        {
            int counter = 0;

            foreach (var player in gamePlayers.Where(pn => pn.Name == playerName))
            {
                counter++;
            }

            return counter;
        }

        private int CountApperencesSubs(List<StartingEleven> gamePlayers, List<TeamEvent> events, string playerName)
        {
            int counter = 0;

            foreach (var player in gamePlayers.Where(pn => pn.Name == playerName))
            {
                foreach (var ev in events)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
