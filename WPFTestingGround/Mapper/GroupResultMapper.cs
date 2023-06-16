using DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingGround.Model;

namespace WPFTestingGround.Mapper
{
    public class GroupResultMapper
    {
        public GroupResultBL MapToViewModel(GroupResult groupResult)
        {
            return new GroupResultBL
            {
                Id = groupResult.Id,
                Letter = groupResult.Letter,
                OrderedTeams = groupResult.OrderedTeams
            };
        }
    }
}
