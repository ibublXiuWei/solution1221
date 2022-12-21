using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1221.Models.DTOs;
using WebApplication1221.Models.EFModels;
using WebApplication1221.Models.Repositories;
using WebApplication1221.Models.Services;
using WebApplication1221.Models.VM;

namespace WebApplication1221.Controllers
{
    public class MembersController : Controller
    {
        private IMemberRepository repository;
        // GET: Members

        public MembersController()
        {
            repository = new MemberRepository();
        }
        public ActionResult Index()
        {
            var data = repository.GetAll();
            return View(data);
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                Member member = new MemberServices(repository).Find(id.Value);
                return View(member);
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }
            
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        public ActionResult Create(Member model)
        {
            try
            {
                new MemberServices(repository).Create(model.ToDTO());
               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Members/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Members/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
