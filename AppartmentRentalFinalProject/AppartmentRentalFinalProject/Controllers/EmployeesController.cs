using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppartmentRentalFinalProject.Models;

namespace AppartmentRentalFinalProject.Controllers
{
   // [Authorize]
    public class EmployeesController : Controller
        
    {
        private PropertyRentalManagementDBEntities db = new PropertyRentalManagementDBEntities();

       
        // GET: Employees
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "FirstName")
            {
                return View(db.Employees.Where(x => x.FirstName.StartsWith(search) || search == null).ToList());
            }
            else if(searchBy == "LastName")
            {
                return View(db.Employees.Where(x => x.LastName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "EmpType")
            {
                return View(db.Employees.Where(x => x.EmpType.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.Employees.Where(x => x.Email.StartsWith(search) || search == null).ToList());
            }
            
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        

        // GET: Employees/Create
       // [Authorize(Roles = "Admin, Customer")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Admin, Customer")]
        public ActionResult Create([Bind(Include = "EmployeeId,FirstName,LastName,EmpType,BirthDate,Gender,Address,PhoneNumber,Email,Password")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName,EmpType,BirthDate,Gender,Address,PhoneNumber,Email,Password")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
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
