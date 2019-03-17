using modeloEnMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace modeloEnMVC.Controllers
{
    public class ClientesController : Controller
    {

        public static List<Clientes> empList = new List<Clientes>
            {
                new Clientes
                {
                    ID=1,
                    nombre = "Angel",
                    fechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                    edad = 30
                },
                new Clientes
                {
                    ID=2,
                    nombre = "Pablo",
                    fechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                    edad = 26
                },
            };

        // GET: Clientes
        public ActionResult Index()
        {
            var Clientes = from e in empList
                           orderby e.ID
                           select e;
            return View(Clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var Clientes = empList.Single(m => m.ID == id);
            return View(Clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Clientes emp)
        {
            try
            {
                var result = empList.OrderByDescending(x => x.ID).First();
                int id = result.ID+1;
                emp.ID = id;
                empList.Add(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            //List<Clientes> empList = TodosLosClintes();
            var Clientes = empList.Single(m => m.ID == id);
            return View(Clientes);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                
                var Clientes = empList.Single(m => m.ID == id);
                if (TryUpdateModel(Clientes))
                    return RedirectToAction("Index");
                return View(Clientes);
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var Clientes = empList.Single(m => m.ID == id);            
            return View(Clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //try
            //{
                var Clientes = empList.Single(m => m.ID == id);
                if (TryUpdateModel(Clientes))                
                    empList.Remove(Clientes);                   
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return RedirectToAction("Index");
            //}
        }

        [NonAction]
        public List<Clientes> TodosLosClintes()
        {
            return new List<Clientes>
            {
                new Clientes
                {
                    ID=1,
                    nombre = "Angel",
                    fechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                    edad = 30
                },
                new Clientes
                {
                    ID=2,
                    nombre = "Pablo",
                    fechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                    edad = 26
                },
            };
        }
    }
}
