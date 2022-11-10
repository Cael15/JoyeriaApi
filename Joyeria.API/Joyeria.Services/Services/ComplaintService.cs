using Joyeria.Core;
using Joyeria.Core.Services;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joyeria.Services.Services
{
   public class ComplaintService : IComplaintService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComplaintService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Complaint> CreateAsync(Complaint createToComplaints)
         
        {
          await _unitOfWork.Complaint.CreateAsync(createToComplaints);
            await _unitOfWork.SaveChangesAsync();
            return createToComplaints;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Complaint.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Complaint>> GetComplaintsAsync()
        {
            return await _unitOfWork.Complaint.GetComplaintsAsync();
        }

        public async Task<Complaint> GetComplaintstByIdAsync(int id)
        {
            return await _unitOfWork.Complaint.GetComplaintstByIdAsync(id);
        }

        public async Task<Complaint> UpdateAsync(Complaint complaintToUpdate)
        {
            await _unitOfWork.Complaint.UpdateAsync(complaintToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return complaintToUpdate;
        }
    }
}
