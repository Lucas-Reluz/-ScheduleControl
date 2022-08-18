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
            return await _context.Queries.ToListAsync();
        }

        public async Task<QueryModel> GetQueryByHours(string hours)
        {
            return await _context.Queries.FirstOrDefaultAsync(q => q.Hours == hours);
        }

        public async Task<QueryModel> GetQueryById(int id)
        {
            return await _context.Queries.FirstOrDefaultAsync(q => q.Id == id); 
        }

        public async Task NewQueryAsync(NewQueryDTO query)
        {
            if (!ExistingQueryOfPatient(query.Patient.Name, query.Hours)) throw new Exception("This patient is already registered in this hour");
            if (!ExistingQueryOfDoctor(query.Doctor.Name, query.Hours)) throw new Exception("This doctor is already registered");

            await _context.Queries.AddAsync(new QueryModel
            {
                  Reason = query.Reason,
                  Hours = query.Hours,
                  Data = query.Data,
                  Doctor = _context.Doctors.FirstOrDefault(d => d.Name == query.Doctor.Name),
                  Patient = _context.Patients.FirstOrDefault(p => p.Name == query.Patient.Name),
            });
            _context.SaveChanges();

            bool ExistingQueryOfPatient(string name, string hours)
            {
                var response = _context.Queries
                     .Include(q => q.Patient.Name == name)
                     .Include(q => q.Hours == hours);
                return response != null;
            }
            bool ExistingQueryOfDoctor(string name, string hours)
            {
                var response = _context.Queries
                    .Include(q => q.Doctor.Name == name)
                    .Include(q => q.Hours == hours);
                return response != null;
            }
        }

        public async Task UpdateQueryAsync(UpdateQueryDTO query)
        {
            var _query = await GetQueryById(query.Id);
            _query.Hours = query.Hours;
            _query.Data = query.Data;
        }
    }
}
