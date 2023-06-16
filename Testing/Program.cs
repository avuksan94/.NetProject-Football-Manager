using BL.Services;
using DL;
using DL.Enums;
using DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Testing
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //TeamLocalService localResults = new TeamLocalService();
            //var localMaleRes = await localResults.GetMaleResults();
            //
            //TeamResultService results = new TeamResultService();
            //var maleResults = await results.GetMaleResults();
            
            MatchesServices matches = new MatchesServices();
            var maleMatch = await matches.GetMaleMatches();
            //Console.WriteLine(maleMatch.Count());

            //GroupResultService groupm = new GroupResultService();
            //var maleGroup = await groupm.GetMaleGroupResults();
            //
            //if (!MyWorker.NetworkConnectivityCheck.ServerStatusBy(Constants.API_PING))
            //{
            //
            //    foreach (var item in localMaleRes)
            //    {
            //     Console.WriteLine(item.FifaCode + " " + item.Country + " " + item.GroupLetter + " " + item.Id + " " + item.AlternateName);
            //    }
            //}
            //else
            //{
            //    
            //    foreach (var item in maleResults)
            //    {
            //        Console.WriteLine(item.FifaCode + " " + item.Country + " " + item.GroupLetter + " " + item.Id + " " + item.AlternateName);
            //    }
            //}

            //foreach (var item in maleMatch)
            //{
            //    Console.WriteLine(item.Winner);
            //}
            //
            //foreach (var item in maleGroup)
            //{
            //    Console.WriteLine(item.Letter);
            //}

            //SortedDictionary<string, SortedSet<Player>> players = match.LoadPlayers(maleMatch.ToList());

            //Kreirati i napuniti klasu za Attendence
            //foreach (var m in maleMatch.Where(m => m.HomeTeamCountry == "Croatia" || m.AwayTeamCountry == "Croatia"))
            //{
            //    Console.WriteLine(m.Venue + " , " + m.Location + " , " +  m.Attendance + " , Home: " + m.HomeTeam.Country + " , Away: " + m.AwayTeam.Country);
            //}

            //Vadenje info o golovima itd
            int counterGoals = 0;
            int counterYellowCards = 0;
            int counterAppereances = 0;

            string playerName = "Ivan PERISIC";
            foreach (var m in maleMatch)
            {
                List<TeamEvent> eventsHome = m.HomeTeamEvents.ToList();
                List<TeamEvent> eventsAway = m.AwayTeamEvents.ToList();

                List<StartingEleven> sElevenAway = m.AwayTeamStatistics.StartingEleven;
                List<StartingEleven> substiututesAway = m.AwayTeamStatistics.Substitutes;

                List<StartingEleven> sElevenHome = m.HomeTeamStatistics.StartingEleven;
                List<StartingEleven> substiututesHome = m.HomeTeamStatistics.Substitutes;

                foreach (var e in sElevenAway.Where(es => es.Name == playerName)) 
                {
                    Console.WriteLine(e.Name + "Starting eleven");
                    counterAppereances++;
                }
                foreach (var e in substiututesAway.Where(es => es.Name == playerName))
                {
                    foreach (var ev in eventsAway)
                    {
                        if (ev.TypeOfEvent == TypeOfEvent.SubstitutionIn)
                        {
                            counterAppereances++;
                            Console.WriteLine(e.Name + ev.TypeOfEvent);
                        }
                    }
                    
                }

                foreach (var e in sElevenHome.Where(es => es.Name == playerName))
                {
                    Console.WriteLine(e.Name + "Starting Eleven");
                    counterAppereances++;
                }
                foreach (var e in substiututesHome.Where(es => es.Name == playerName))
                {
                    foreach (var ev in eventsHome)
                    {
                        if (ev.TypeOfEvent == TypeOfEvent.SubstitutionIn)
                        {
                            counterAppereances++;
                            Console.WriteLine(e.Name + ev.TypeOfEvent);
                        }
                    }
                }

                //Golovi
                //foreach (var ev in eventsHome.Where(ev => (ev.TypeOfEvent == TypeOfEvent.Goal || ev.TypeOfEvent == TypeOfEvent.GoalPenalty) && ev.Player == playerName))
                //{
                //    Console.WriteLine(ev.Player.ToString() + " " + ev.TypeOfEvent.ToString());
                //    counterGoals++;
                //}
                //
                //foreach (var ev in eventsAway.Where(ev => (ev.TypeOfEvent == TypeOfEvent.Goal || ev.TypeOfEvent == TypeOfEvent.GoalPenalty) && ev.Player == playerName))
                //{
                //    Console.WriteLine(ev.Player.ToString() + " " + ev.TypeOfEvent.ToString());
                //    counterGoals++;
                //}

                //Zute karte
                //foreach (var ev in eventsHome.Where(ev => (ev.TypeOfEvent == TypeOfEvent.YellowCard || ev.TypeOfEvent == TypeOfEvent.YellowCardSecond) && ev.Player == playerName))
                //{
                //    Console.WriteLine(ev.Player.ToString() + " " + ev.TypeOfEvent.ToString());
                //    counterYellowCards++;
                //}
                //
                //foreach (var ev in eventsAway.Where(ev => (ev.TypeOfEvent == TypeOfEvent.YellowCard || ev.TypeOfEvent == TypeOfEvent.YellowCardSecond) && ev.Player == playerName))
                //{
                //    Console.WriteLine(ev.Player.ToString() + " " + ev.TypeOfEvent.ToString());
                //    counterYellowCards++;
                //}



            }
            //Console.WriteLine(counterGoals);
            //Console.WriteLine(counterYellowCards);
            Console.WriteLine(counterAppereances);



        }
    }
}
