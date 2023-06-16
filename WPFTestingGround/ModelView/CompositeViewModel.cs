using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingGround.ModelView;

namespace FootballManagerWPFApp.ModelView
{
    //ovo sam napravio jer mi je za data context bilo potrebno vise VM
    public class CompositeViewModel
    {
        public MatchViewModel VMMatch { get; set; }
        public TeamResultViewModel VMTeamRes { get; set; }

        public CompositeViewModel()
        {
            VMMatch = new MatchViewModel();
            VMTeamRes = new TeamResultViewModel();
        }
    }
}
