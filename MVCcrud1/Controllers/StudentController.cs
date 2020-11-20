using MVCcrud1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCcrud1.Controllers
{
    
    public class StudentController : Controller
    {
        DetailsEntities dbobj = new DetailsEntities();
        public ActionResult Student(registrationdetail obj)

        {
         if(obj!=null)
            return View(obj);
         else
                return View();
        }
        [HttpPost]
        public ActionResult AddStudent(registrationdetail m)
        {
            if (ModelState.IsValid)
            {
                registrationdetail obj = new registrationdetail();
                obj.firstname = m.firstname;
                obj.lastname = m.lastname;
                obj.email = m.email;
                obj.rollno = m.rollno;
                obj.student_address = m.student_address;
                obj.student_state = m.student_state;
                obj.mobile = m.mobile;
                dbobj.registrationdetails.Add(obj);
                dbobj.SaveChanges();
            }
            ModelState.Clear();
                return View("Student");
            
        }
        public ActionResult Studentlist()
        {
            var res = dbobj.registrationdetails.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbobj.registrationdetails.Where(x => x.rollno == id).First();
            dbobj.registrationdetails.Remove(res);
            dbobj.SaveChanges();
            var list = dbobj.registrationdetails.ToList();
            return View("Studentlist",list);
        }


    }
}