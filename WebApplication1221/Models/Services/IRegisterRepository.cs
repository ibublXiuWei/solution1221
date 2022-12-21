using System.Collections.Generic;
using WebApplication1221.Models.DTOs;
using WebApplication1221.Models.EFModels;

namespace WebApplication1221.Models.Services
{
    public interface IRegisterRepository
    {
        void Create(RegisterDTO register);
        Register FindByEmail(string email);
        Register FindById(int id);
        List<Register> GetAll();
    }
}