using BL.Services;
using DL.Model;
using FootballManagerWPFApp.Relay;
using FootballManagerWPFApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFTestingGround.Mapper;
using WPFTestingGround.Model;

namespace WPFTestingGround.ModelView
{
    public class TeamResultViewModel
    {
        //Commands: 

        //*********************************************************

        private ObservableCollection<TeamResultBL> _teamResultsBLMale;
        private ObservableCollection<TeamResultBL> _teamResultsBLFemale;

        private TeamResultMapper _mapper;
        private readonly TeamResultService _teamResultService;

        public TeamResultViewModel()
        {
            _teamResultService = new TeamResultService();
            InitComps();
            LoadTeamRes('m');
            LoadTeamRes('f');

        }

        private void InitComps() 
        {
            _teamResultsBLMale = new ObservableCollection<TeamResultBL>();
            _teamResultsBLFemale = new ObservableCollection<TeamResultBL>();

            _mapper = new TeamResultMapper();
        }

        public ObservableCollection<TeamResultBL> TeamResultMale
        {
            get { return _teamResultsBLMale; }
            set { _teamResultsBLMale = value; }
        }


        public ObservableCollection<TeamResultBL> TeamResultFemale
        {
            get { return _teamResultsBLFemale; }
            set { _teamResultsBLFemale = value; }
        }

        private async Task LoadTeamRes(char gender)
        {
            IList<TeamResult> data = new List<TeamResult>();

            if (gender == 'm')
            {
                data = await _teamResultService.GetMaleResults();

                foreach (var item in data)
                {
                    _teamResultsBLMale.Add(_mapper.MapToViewModel(item));
                }
            }
            else if (gender == 'f')
            {
                data = await _teamResultService.GetFemaleResults();

                foreach (var item in data)
                {
                    _teamResultsBLFemale.Add(_mapper.MapToViewModel(item));
                }
            }
        }

    }
}

