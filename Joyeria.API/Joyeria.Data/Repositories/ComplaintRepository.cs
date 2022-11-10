using Joyeria.Core.Repositories;
using Joyeria.Data.Shared;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joyeria.Data.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly JoyeriaDbContext _dbContext;

        public ComplaintRepository(JoyeriaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Complaint> CreateAsync(Complaint createToComplaints)

        {
            await _dbContext.Complaint.AddAsync(createToComplaints);
       
            return createToComplaints;
        }

        public async Task DeleteAsync(int id)
        {
            var complaints = await _dbContext.Complaint.FindAsync(id);
            _dbContext.Complaint.Remove(complaints);
           
        }

        public async Task<IEnumerable<Complaint>> GetComplaintsAsync()
        {
            return await this._dbContext.Complaint.ToListAsync();
        }

        public async Task<Complaint> GetComplaintstByIdAsync(int id)
        {
             var complaints= await this._dbContext.Complaint.FindAsync(id);
            return complaints;
        }

        public async Task<Complaint> UpdateAsync(Complaint complaintToUpdate)
        {
            _dbContext.Complaint.Update(complaintToUpdate);
            return await Task.FromResult(complaintToUpdate);
        }
    }
}
