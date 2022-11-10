using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joyeria.Core.Services
{
    public interface IComplaintService
    {
        Task<IEnumerable<Complaint>> GetComplaintsAsync();
        Task<Complaint> GetComplaintstByIdAsync(int id);
        Task<Complaint> CreateAsync(Complaint createToComplaints);
        Task<Complaint> UpdateAsync(Complaint complaintToUpdate);
        Task DeleteAsync(int id);
    }
}
