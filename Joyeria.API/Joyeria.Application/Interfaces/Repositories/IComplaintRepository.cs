using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joyeria.Core.Repositories
{
    public interface IComplaintRepository
    {
        Task<IEnumerable<Complaint>> GetComplaintsAsync();
        Task<Complaint> GetComplaintstByIdAsync(int id);
        Task<Complaint> CreateAsync(Complaint createToComplaints);
        Task<Complaint> UpdateAsync(Complaint complaintToUpdate);
        Task DeleteAsync(int id);
    }
}
