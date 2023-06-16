using BL.Services;
using DL.Model;
using FootballManagerWPFApp.Relay;
using FootballManagerWPFApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTestingGround.Mapper;
using WPFTestingGround.Model;

namespace WPFTestingGround.ModelView
{
    public class MatchViewModel
    {
        //Commands: 
        public ICommand OpenRepInfoCommand { get; private set; }

        private void OpenRepWindow(object parameter)
        {
            List<TeamResultBL>? selectedMatch = parameter as List<TeamResultBL>;
            if (selectedMatch != null)
            {
                var repInfo = new RepInfo(selectedMatch);

                repInfo.Show();
            }
            
        }

        //*********************************************************
        ObservableCollection<MatchesBL> _matchesBLMale;
        ObservableCollection<MatchesBL> _matchesBLFemale;

        MatchesMapper _mapper;
        private readonly MatchesServices _matchesService;

        public MatchViewModel()
        {
            _matchesService = new MatchesServices();
            InitComps();
            LoadMatches('m');
            LoadMatches('f');
        }

        private void InitComps() 
        {
            OpenRepInfoCommand = new RelayCommand(OpenRepWindow);
            _matchesBLMale = new ObservableCollection<MatchesBL>();
            _matchesBLFemale = new ObservableCollection<MatchesBL>();
            _mapper = new MatchesMapper();
        }

        public ObservableCollection<MatchesBL> MatchesMale
        {
            get { return _matchesBLMale; }
            set { _matchesBLMale = value; }
        }

        public ObservableCollection<MatchesBL> MatchesFemale
        {
            get { return _matchesBLFemale; }
            set { _matchesBLFemale = value; }
        }

        private async Task LoadMatches(char gender)
        {
            IList<Match> data = new List<Match>();
            if (gender == 'm')
            {
                data = await _matchesService.GetMaleMatches();
                foreach (var item in data)
                {
                    _matchesBLMale.Add(_mapper.MapToViewModel(item));
                }
            }
            else if (gender == 'f')
            {
                data = await _matchesService.GetFemaleMatches();
                foreach (var item in data)
                {
                    _matchesBLFemale.Add(_mapper.MapToViewModel(item));
                }
            }

           
        }
    }
}
