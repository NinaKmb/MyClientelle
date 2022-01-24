using ClientelleAPI.Models;
using ClientelleAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientelleAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext _context;

        public PatientRepository(PatientContext context)
        {
            _context = context;
        }

        public async Task<patient> Create(patient patient)
        {
            _context.patient.Add(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task Delete(int id)
        {
            var patientToDelete = await _context.patient.FindAsync(id);
            _context.Patient.Remove(patientToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<patient>> Get()
        {
            return await _context.Patient.ToListAsync();
        }

        public async Task<patient> Get(int id)
        {
            return await _context.patient.FindAsync(id);
        }

        public async Task Update(patient Patient)
        {
            _context.Entry(Patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}