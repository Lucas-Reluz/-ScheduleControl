using Microsoft.EntityFrameworkCore;
using ScheduleControl.src.data;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories.implementations
{
    /// <summary>
    /// <para>Resumo: Class responsible for implementing IQuery</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 18/08/2022</para>
    /// </summary>
    public class QueryRepositorie : IQuery
    {
        #region Attributes
        private readonly ScheduleControlContext _context;
        #endregion

        public QueryRepositorie(ScheduleControlContext context)
        {
            _context = context;
            
        }
        /// <summary>
        /// <para>Summary: Asynchronous method that deletes a query</para>
        /// </summary>
        public async Task DeleteQueryAsync(int id)
        {
            _context.Queries.Remove(await GetQueryById(id));
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to get all queries</para>
        /// </summary>
        /// <return>List Query</return>
        public async Task<List<QueryModel>> GetAllQueriesAsync()
        {
            return await _context.Queries
                .Include(q => q.Doctor)
                .Include(q => q.Patient)
                .ToListAsync();
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to get a query for hours</para>
        /// </summary>
        /// <param name="hours">Hours of Query</param>
        /// <return>QueryModel</return>
        public async Task<QueryModel> GetQueryByHours(string hours)
        {
            return await _context.Queries.FirstOrDefaultAsync(q => q.Hours == hours);
        }

        /// <summary>
        /// <para>Resumo: Asynchronous method to get a query by Id </para>
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <return>QueryModel</return>
        public async Task<QueryModel> GetQueryById(int id)
        {
            return await _context.Queries
                .Include(q => q.Doctor)
                .Include(q => q.Patient)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// <para>Resumo: Asynchronous method to create new Query</para>
        /// </summary>
        /// <param name="query">NewQueryDTO</param>
        public async Task NewQueryAsync(NewQueryDTO query)
        {
            await _context.Queries.AddAsync(new QueryModel
            {
                  Reason = query.Reason,
                  Hours = query.Hours,
                  Data = query.Data,
                  Doctor = _context.Doctors.FirstOrDefault(d => d.Name == query.Doctor.Name),
                  Patient = _context.Patients.FirstOrDefault(p => p.Name == query.Patient.Name),
            });
            _context.SaveChanges();
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to update a query</para>
        /// </summary>
        /// <param name="query">UpdateQueryDTO</param>
        public async Task UpdateQueryAsync(UpdateQueryDTO query)
        {
            var _query = await GetQueryById(query.Id);
            _query.Hours = query.Hours;
            _query.Data = query.Data;
        }
    }
}
