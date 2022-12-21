﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1221.Models.EFModels;

namespace WebApplication1221.Controllers
{
    public class RegistersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Registers
        public ActionResult Index()
        {
            return View(db.Registers.ToList());
        }

        // GET: Registers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email")] Register register)
        {
            try 
            { 
            //驗證Email 是否已經存在
            //FirstOrDefault代表找到重複的第一筆或是沒有找到
                var dataDb =db.Registers.FirstOrDefault(x=>x.Email== register.Email);
                if (dataDb != null) 
                {
                    //用AddModelError增加ModelState中的錯誤訊息， 新增錯誤的屬性/欄位是"Email" 後面是原因
                    throw new Exception("Email 已經報名過了,無法再度報名");
                    //ModelState.AddModelError("Email", "這個 Email 已經報名過了,無法再度報名");            
                }

            //用程式指定建檔時間,而不是由使用者輸入
                register.CreatedTime= DateTime.Now;
                db.Registers.Add(register);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
            }

            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index");
            }

            return View(register);
        }

        
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
