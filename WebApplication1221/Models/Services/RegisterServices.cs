using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using WebApplication1221.Models.DTOs;
using WebApplication1221.Models.EFModels;
using WebApplication1221.Models.Repositories;

namespace WebApplication1221.Models.Services
{
    public class RegisterServices
    {
        //private AppDbContext db = new AppDbContext();
        private IRegisterRepository repository;
        
        public RegisterServices(IRegisterRepository repo)
        {
            repository = repo;
        }
        public void Create(RegisterDTO registerDto)
        {
            //驗證Email 是否已經存在
            //FirstOrDefault代表找到重複的第一筆或是沒有找到
            //var dataDb = db.Registers.FirstOrDefault(x => x.Email == register.Email);
            var dataDb = repository.FindByEmail(registerDto.Email);
            if (dataDb != null)
            {
                //用AddModelError增加ModelState中的錯誤訊息， 新增錯誤的屬性/欄位是"Email" 後面是原因
                throw new Exception("Email 已經報名過了,無法再度報名");
                //ModelState.AddModelError("Email", "這個 Email 已經報名過了,無法再度報名");            
            }

            //用程式指定建檔時間,而不是由使用者輸入
            registerDto.CreatedTime = DateTime.Now;

            repository.Create(registerDto);
            //db.Registers.Add(register);
            //db.SaveChanges();
        }

        public Register Find(int id)
        {
            //Register register = db.Registers.Find(id);
            Register register = repository.FindById(id);
            if (register == null)
            {
                throw new Exception("找不到指定的紀錄");
            }
            return register;
        }
    }
}