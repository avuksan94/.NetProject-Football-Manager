using DL;
using DL.Model;
using DL.Repo;
using DL.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    //Nisam ga na kraju koristio ali sam ga ostavio
    public class GroupResultService
    {
        private IDataRetrievalStrategy<GroupResult> getDataMale;
        private IDataRetrievalStrategy<GroupResult> getDataFemale;

        private readonly DataRepo<GroupResult> repoMale;
        private readonly DataRepo<GroupResult> repoFemale;

        public GroupResultService()
        {
            getDataMale = new LocalDataRetrievalStrategy<GroupResult>(Constants.pathToMenGroupResults);
            getDataFemale = new LocalDataRetrievalStrategy<GroupResult>(Constants.pathToWomenGroupResults);
            repoMale = new DataRepo<GroupResult>(getDataMale);
            repoFemale = new DataRepo<GroupResult>(getDataFemale);
        }

        public async Task<List<GroupResult>> GetMaleGroupResults()
        {
            IEnumerable<GroupResult> results = await repoMale.GetAllAsync();
            return results.ToList();
        }

        public async Task<List<GroupResult>> GetFemaleGroupResults()
        {
            IEnumerable<GroupResult> results = await repoFemale.GetAllAsync();
            return results.ToList();
        }
    }
}
