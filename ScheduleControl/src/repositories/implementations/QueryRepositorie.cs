using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories.implementations
{
    public class QueryRepositorie : IQuery
    {
        public Task DeleteQueryAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<QueryModel>> GetAllQueriesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task NewQueryAsync(NewQueryDTO query)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<QueryModel>> SearchQueryAsync(string reason, string nameDoctor)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateQueryAsync(UpdateQueryDTO query)
        {
            throw new System.NotImplementedException();
        }
    }
}
