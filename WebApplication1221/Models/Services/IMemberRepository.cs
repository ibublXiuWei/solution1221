using System.Collections.Generic;
using WebApplication1221.Models.DTOs;
using WebApplication1221.Models.EFModels;
using WebApplication1221.Models.VM;

namespace WebApplication1221.Models.Services
{
    public interface IMemberRepository
    {
        void Create(MemberCreateDTO dto);
        Member FindByAccount(string account);
        Member FindById(int id);
        List<Member> GetAll();
    }
}