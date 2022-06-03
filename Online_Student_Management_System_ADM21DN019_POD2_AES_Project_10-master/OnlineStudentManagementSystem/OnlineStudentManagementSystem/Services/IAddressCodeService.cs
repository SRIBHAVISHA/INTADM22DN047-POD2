using Microsoft.AspNetCore.Mvc;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
    public interface IAddressCodeService
    {
        Task<IEnumerable<AddressCode>> Get();
        Task<AddressCode> GetById(int id);
        Task CreateAddressCode(AddressCode addressCode);
        Task DeleteAddressCode (int id);
        Task UpdateAddressCode(int id, AddressCode addressCode);

    }
}
