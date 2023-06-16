using DL;
using DL.Model;
using DL.Repo;
using DL.Strategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyWorker;

namespace BL.Services
{
    public class TeamResultService
    {
        private IDataRetrievalStrategy<TeamResult> getDataMale;
        private IDataRetrievalStrategy<TeamResult> getDataFemale;

        private readonly DataRepo<TeamResult> repoMale;
        private readonly DataRepo<TeamResult> repoFemale;

        public TeamResultService() 
        {
            if (!MyWorker.NetworkConnectivityCheck.ServerStatusBy(Constants.API_PING))
            {
                getDataMale = new LocalDataRetrievalStrategy<TeamResult>(Constants.pathToMenResults);
                getDataFemale = new LocalDataRetrievalStrategy<TeamResult>(Constants.pathToMenResults);

                repoMale = new DataRepo<TeamResult>(getDataMale);
                repoFemale = new DataRepo<TeamResult>(getDataFemale);
            }
            else
            {
                getDataMale = new ApiDataRetrievalStrategy<TeamResult>(new HttpClient(), Constants.TEAMS_RESULTS_M);
                getDataFemale = new ApiDataRetrievalStrategy<TeamResult>(new HttpClient(), Constants.TEAMS_RESULTS_W);

                repoMale = new DataRepo<TeamResult>(getDataMale);
                repoFemale = new DataRepo<TeamResult>(getDataFemale);
            }
        }

        public async Task<List<TeamResult>> GetMaleResults()
        {
            IEnumerable<TeamResult> results = await repoMale.GetAllAsync();
            List<TeamResult> sortedResults = results.OrderBy(r => r.Country).ToList();
            return sortedResults;
        }

        public async Task<List<TeamResult>> GetFemaleResults()
        {
            IEnumerable<TeamResult> results = await repoFemale.GetAllAsync();
            List<TeamResult> sortedResults = results.OrderBy(r => r.Country).ToList();
            return sortedResults;
        }

    }
}
