using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public static class Constants
    {

        public const string COMBO_BOXES = @"ComboBoxChoices.txt";

        public const string RESOLUTION_FILE = @"Resolution.txt";
        public const string SELECTED_REPRESENTATION = @"SelectedRep.txt";
        public const string SELECTED_MF = @"SelectedMF.txt";
        public const string SELECTED_LANGUAGE = @"SelectedLanguage.txt";

        public const string FAVORITES_FORM_M = @"FavoritesMen.json";
        public const string FAVORITES_FORM_F = @"FavoritesWomen.json";

        public const string SELECTED_REP_TRACKER = @"SelectedRep.txt";

        //************************************************************************************8

        public static string pathToMenFolder = Path.Combine(
            Path.GetDirectoryName(typeof(Constants).Assembly.Location),
            "..", "..", "..", "..", "DL", "LocalFiles", "men");
        
        public static string pathToWomenFolder = Path.Combine(
            Path.GetDirectoryName(typeof(Constants).Assembly.Location),
            "..", "..", "..", "..", "DL", "LocalFiles", "women");

        public static string pathToImagesFolder = Path.Combine(
                       Path.GetDirectoryName(typeof(Constants).Assembly.Location),
                       "..", "..", "..", "..", "DL", "LocalFiles", "images");

        public const string API_PING = "worldcup-vua.nullbit.hr";
        public const string TEAMS_RESULTS_M = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string TEAMS_RESULTS_W = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string TEAMS_MATCHES_M = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string TEAMS_MATCHES_W = "https://worldcup-vua.nullbit.hr/women/matches";

        public static string pathToMenResults = pathToMenFolder + "\\results.json";
        public static string pathToMenTeams = pathToMenFolder + "\\teams.json";
        public static string pathToMenMatches = pathToMenFolder + "\\matches.json";
        public static string pathToMenGroupResults = pathToMenFolder + "\\group_results.json";

        public static string pathToWomenResults = pathToWomenFolder + "\\results.json";
        public static string pathToWomenTeams = pathToWomenFolder + "\\teams.json";
        public static string pathToWomenMatches = pathToWomenFolder + "\\matches.json";
        public static string pathToWomenGroupResults = pathToWomenFolder + "\\group_results.json";
    }
}
