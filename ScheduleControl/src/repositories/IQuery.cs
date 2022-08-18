using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories
{
    /// <summary>
    /// <para>Summary: Responsible for representing query CRUD actions</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public interface IQuery
    {
        Task NewQueryAsync(NewQueryDTO query);
        Task UpdateQueryAsync(UpdateQueryDTO query);
        Task<QueryModel> GetQueryById(int id);

        Task<QueryModel> GetQueryByHours(string hours);
        Task DeleteQueryAsync(int id);
        Task<List<QueryModel>> GetAllQueriesAsync();

    }
}
