using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1221.Models.DTOs;
using WebApplication1221.Models.EFModels;
using WebApplication1221.Models.Services;

namespace WebApplication1221.Models.Repositories
{

    public class RegisterRepository : IRegisterRepository
    {
        private AppDbContext db = new AppDbContext();
        public void Create(RegisterDTO registerDto)
        {
            Register register = new Register
            {
                
                    Id=registerDto.Id,
                    Name=registerDto.Name,
                    Email=registerDto.Email,
                    CreatedTime=DateTime.Now,

            };

            db.Registers.Add(register);
            db.SaveChanges();
        }
        public Register FindByEmail(string email)
        {
            return db.Registers.FirstOrDefault(x => x.Email == email);
        }
        public Register FindById(int id)
        {
            return db.Registers.Find(id);
        }
        public List<Register> GetAll()
        {
            return db.Registers.ToList();
        }

    }
}