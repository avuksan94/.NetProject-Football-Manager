using BL.Services;
using DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingGround.Mapper;
using WPFTestingGround.Model;

namespace WPFTestingGround.ModelView
{
    public class GroupResultViewModel
    {
        IList<GroupResultBL> _groupResultBL;
        GroupResultMapper _mapper;

        private readonly GroupResultService _groupResultService;

        public GroupResultViewModel()
        {
            _groupResultBL = new List<GroupResultBL>();
            _mapper = new GroupResultMapper();
            _groupResultService = new GroupResultService();
        }

        public IList<GroupResultBL> GroupResult
        {
            get { return _groupResultBL; }
            set { _groupResultBL = value; }
        }

        public async Task LoadGroupResult(char gender)
        {
            IList<GroupResult> data = new List<GroupResult>();
            if (gender == 'm')
            {
                data = await _groupResultService.GetMaleGroupResults();
            }
            else if (gender == 'f')
            {
                data = await _groupResultService.GetFemaleGroupResults();
            }

            foreach (var item in data)
            {
                _groupResultBL.Add(_mapper.MapToViewModel(item));
            }
        }
    }
}
