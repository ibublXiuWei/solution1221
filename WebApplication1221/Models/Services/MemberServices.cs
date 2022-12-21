using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1221.Models.DTOs;
using WebApplication1221.Models.EFModels;
using WebApplication1221.Models.Repositories;

namespace WebApplication1221.Models.Services
{
    public class MemberServices
    {
        private IMemberRepository repository;
        public MemberServices(IMemberRepository repo)
        {
            this.repository = repo;
        }

        public void Create(MemberCreateDTO dto)
        {
            var dataDb = repository.FindByAccount(dto.Account);
            //todo 驗證account 是否唯一
            if (dataDb != null)
            {
                throw new Exception("Account 已經註冊過了,無法再度註冊");      
            }


            //repository.Create(dto);
        }
        public Member Find(int id)
        {
           
            Member member = repository.FindById(id);
            if (member == null)
            {
                throw new Exception("找不到指定的紀錄");
            }
            return member;
        }
    }
}