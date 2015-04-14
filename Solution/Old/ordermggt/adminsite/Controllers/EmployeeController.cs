using adminsite.Models;
using adminsite.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace adminsite.Controllers
{
     [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        private OrderManagmentEntities db = new OrderManagmentEntities();

        public void setdata()
        {
            ViewBag.empType = db.TblEmployeeTypeMasters.ToList<TblEmployeeTypeMaster>();
        }
        //view Index of Employee

        public ActionResult EmpIndex()
        {
            List<employeedto> qry = (from emp in db.TblEmployeeMasters
                                     join etype in db.TblEmployeeTypeMasters on emp.EmployeeTypeID equals etype.EmployeeTypeID
                                     select new employeedto
                                   {
                                       empid = emp.EmployeeID,
                                       empname = emp.EmployeeName,
                                       emptype = etype.EmployeeType,
                                       fname = emp.FirstName,
                                       mname = emp.MiddleName,
                                       lname = emp.LastName,
                                       emailid = emp.EmailId

                                   }).ToList<employeedto>();
            return View(qry);

        }

        //create Employee
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            setdata();
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(TblEmployeeMaster Model)
        {
            setdata();

            var check = db.TblEmployeeMasters.Where(h => h.EmailId.Equals(Model.EmailId) && h.EmployeeName.Equals(Model.EmployeeName)).FirstOrDefault();

            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    Model.IsActive = true;
                    Model.CreatedBy = int.Parse(Session["AdminName"].ToString());
                    Model.CreatedDateTime = DateTime.Now;
                    db.TblEmployeeMasters.Add(Model);
                    db.SaveChanges();
                    ViewBag.actionmsg = "1";
                    return RedirectToAction("EmpIndex", "Employee");
                }
                return View(Model);
            }
            else
            {
                ViewBag.actionmsg = "0";
                ViewBag.empNAME = check.EmployeeName;
                ViewBag.email = check.EmailId;
                return View(Model);
            }


        }

        //Employee detail
        public ActionResult EmpDetail(int id)
        {
            employeedto qry = (from emp in db.TblEmployeeMasters
                               join etype in db.TblEmployeeTypeMasters on emp.EmployeeTypeID equals etype.EmployeeTypeID
                               where emp.EmployeeID == id && emp.IsActive == true
                               select new employeedto
                               {
                                   empid = emp.EmployeeID,
                                   empname = emp.EmployeeName,
                                   emptype = etype.EmployeeType,
                                   fname = emp.FirstName,
                                   mname = emp.MiddleName,
                                   lname = emp.LastName,
                                   emailid = emp.EmailId,
                                   address = emp.Address

                               }).FirstOrDefault<employeedto>();
            return View(qry);
        }

        //Delete Employee Record

        [HttpGet]
        public ActionResult EmpDelete(int id)
        {

            employeedto qry = (from emp in db.TblEmployeeMasters
                               join etype in db.TblEmployeeTypeMasters on emp.EmployeeTypeID equals etype.EmployeeTypeID
                               where emp.EmployeeID == id && emp.IsActive == true
                               select new employeedto
                               {
                                   empid = emp.EmployeeID,
                                   empname = emp.EmployeeName,
                                   emptype = etype.EmployeeType,
                                   fname = emp.FirstName,
                                   mname = emp.MiddleName,
                                   lname = emp.LastName,
                                   emailid = emp.EmailId,
                                   address = emp.Address

                               }).FirstOrDefault<employeedto>();
            return View(qry);
        }


        [HttpPost, ActionName("EmpDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            orderdto orderdto = new orderdto();
            orderdto.employeeData = db.TblEmployeeMasters.Where(h => h.EmployeeID == id).FirstOrDefault();
            orderdto.employeeTypeData = db.TblEmployeeTypeMasters.Find(orderdto.employeeData.EmployeeID);
            db.TblEmployeeMasters.Remove(orderdto.employeeData);
            db.SaveChanges();
            return RedirectToAction("EmpIndex");
        }

        //Edit Employee Detail

        [HttpGet]
        public ActionResult EmpEdit(int id = 0)
        {
            setdata();
            TblEmployeeMaster employee = db.TblEmployeeMasters.Where(h => h.EmployeeID == id).FirstOrDefault();
            return View(employee);
        }


        [HttpPost]
        public ActionResult EmpEdit(TblEmployeeMaster emp)
        {
            setdata();

            var check = db.TblEmployeeMasters.Where(h => h.EmployeeID != emp.EmployeeID && (h.EmailId.Equals(emp.EmailId) || h.EmployeeName.Equals(emp.EmployeeName))).ToList();
            if (check.Count == 0)
            {
                if (ModelState.IsValid)
                {
                    TblEmployeeMaster temp = db.TblEmployeeMasters.Where(h => h.EmployeeID == emp.EmployeeID).FirstOrDefault();
                    temp.EmployeeName = emp.EmployeeName;
                    temp.EmployeeTypeID = emp.EmployeeTypeID;
                    temp.Address = emp.Address;
                    temp.EmailId = emp.EmailId;
                    temp.FirstName = emp.FirstName;
                    temp.MiddleName = emp.MiddleName;
                    temp.LastName = emp.LastName;
                    temp.IsActive = true;
                    temp.UpdatedBy = int.Parse(Session["AdminName"].ToString());
                    temp.UpdatedDateTime = DateTime.Now;

                    if (db.SaveChanges() > 0)
                        return RedirectToAction("EmpIndex");
                    else
                        return View(emp);
                }
                return View(emp);
            }
            else
            {
                ViewBag.actionmsg = "0";
              //  ModelState.AddModelError("", "Your empoyee name or mobile no is alreay exist");
                //ViewBag.empNAME = check.EmployeeName;
                //  ViewBag.email = check.EmailId;
                return View(emp);
            }
        }


    }
}
