using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestRecordProject.Domain.Abstract;
using TestRecordProject.Domain.Concrete;
using TestRecordProject.Domain.Entities;

namespace TestRecordProject.Controllers
{
    public class TestController : Controller
    {
        private IRepository<Test> test;
        public TestController(IRepository<Test> test)
        {
            this.test = test;
        }
        // GET: Test
        public ActionResult Index()
        {            
            return View(test.QueryEntities);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View(new Test());
        }
        [HttpPost]
        public ActionResult Create(Test t)
        {
            test.SaveEntities(t);
            return RedirectToActionPermanent("Index");
        }
        [HttpPost]
        public ActionResult Edit(Test t)
        {
            test.SaveEntities(t);
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Test t = test.QueryEntities.FirstOrDefault(x => x.id == id);
            return View(t);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Test t = test.QueryEntities.FirstOrDefault(x => x.id == id);
            test.DeleteEntities(t);
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public ViewResult Delete(int id)
        {
            Test t = test.QueryEntities.FirstOrDefault(x => x.id == id);
            return View(t);
        }
    }
}