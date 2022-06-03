using OnlineStudentManagementSystem.Configuration;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
    public class AddressCodeService : IAddressCodeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressCodeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AddressCode>> Get()
        {
            return await _unitOfWork.Repository<AddressCode>().All();
        }
        public async Task<AddressCode> GetById(int id)
        {
            return await _unitOfWork.Repository<AddressCode>().GetById(id);
        }
<<<<<<< HEAD
       
=======

>>>>>>> OnlineStudentManagement_UI
        public async Task CreateAddressCode(AddressCode addressCode)
        {
            await _unitOfWork.Repository<AddressCode>().Add(addressCode);
            await _unitOfWork.CompleteAsync();

        }
        public async Task UpdateAddressCode(int id, AddressCode addressCode)
        {
<<<<<<< HEAD
           // await _unitOfWork.RepoAddressCode.Upsert(addressCode);
            await _unitOfWork.CompleteAsync();

        }
=======
            var existingAddressCode = await GetById(addressCode.AddressCodeId);

            if (existingAddressCode == null)
                await _unitOfWork.Repository<AddressCode>().Add(addressCode);

            existingAddressCode.City = addressCode.City;
            existingAddressCode.State = addressCode.State;
            existingAddressCode.ZipCode = addressCode.ZipCode;

            await _unitOfWork.CompleteAsync();

        }


>>>>>>> OnlineStudentManagement_UI
        public async Task DeleteAddressCode(int id)
        {
            await _unitOfWork.Repository<AddressCode>().Delete(id);
            await _unitOfWork.CompleteAsync();
        }

    }
<<<<<<< HEAD
}
=======

}
>>>>>>> OnlineStudentManagement_UI
