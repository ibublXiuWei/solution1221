using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebApplication1221.Models.DTOs;
using WebApplication1221.Models.EFModels;
using WebApplication1221.Models.Services;
using WebApplication1221.Models.VM;

namespace WebApplication1221.Models.Repositories
{

    public class MemberRepository : IMemberRepository
    {
        private AppDbContext db = new AppDbContext();
        public void Create(MemberCreateDTO dto)
        {
            Member member = new Member
            {

                Id = dto.Id,
                Name = dto.Name,
                Account = dto.Account,
                Password = dto.Password,
                CellPhone = dto.CellPhone,

            };

            db.Members.Add(member);
            db.SaveChanges();
        }
        public Member FindByAccount(string account)
        {
            return db.Members.FirstOrDefault(x => x.Account == account);
        }
        public Member FindById(int id)
        {
            return db.Members.Find(id);
        }

        public List<Member> GetAll()
        {
            return db.Members.ToList();
        }
    }
}