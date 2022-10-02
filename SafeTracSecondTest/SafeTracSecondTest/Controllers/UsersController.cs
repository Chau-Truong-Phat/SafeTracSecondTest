using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SafeTracSecondTest.Models;
using SafeTracSecondTest.Models.Dto;

namespace SafeTracSecondTest.Controllers
{
    public class UsersController : Controller
    {
        private SafeTracSecondTestDbContext db = new SafeTracSecondTestDbContext();

        // GET: Users
        public ActionResult Index(UserFilterDTO search)
        {
            UserFilterDTO userFilter = new UserFilterDTO();
            var query = db.Users.AsEnumerable();

            #region filter
            if (!String.IsNullOrEmpty(search.First_Name))
            {
                query = query.Where(x => x.First_Name.ToLowerInvariant().Contains(search.First_Name.ToLowerInvariant())); 
            }
            if (!String.IsNullOrEmpty(search.Last_Name))
            { 
                query = query.Where(x => x.Last_Name.ToLowerInvariant().Contains(search.Last_Name.ToLowerInvariant())); 
            }
            if (!String.IsNullOrEmpty(search.Email_Address))
            { 
                query = query.Where(x => x.Email_Address.ToLowerInvariant().Contains(search.Email_Address.ToLowerInvariant())); 
            }
            if (!search.Date_Created.Equals(DateTime.MinValue))
            { 
                query = query.Where(x => x.Date_Created.Equals(search.Date_Created)); 
            }
            #endregion

            #region sort
            if (search.Sort_By_First_Name)
            {
                query = query.OrderBy(x => x.First_Name);
            }
            if (search.Sort_By_Last_Name)
            {
                query = query.OrderBy(x => x.Last_Name);
            }
            if (search.Sort_By_Email)
            {
                query = query.OrderBy(x => x.Email_Address);
            }
            if (search.Sort_By_Date)
            {
                query = query.OrderBy(x => x.Date_Created);
            }
            #endregion

            userFilter.UserDTOs = query
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    First_Name = x.First_Name,
                    Last_Name = x.Last_Name,
                    Email_Address = "test@gmail.com",
                    User_Password = x.User_Password,
                    Date_Created_AU_Format = ConvertAustralianUserFriendlyDateFormat(x.Date_Created.GetValueOrDefault()),
                    Date_Modified_AU_Format = ConvertAustralianUserFriendlyDateFormat(x.Date_Modified.GetValueOrDefault()),
                })
                .ToList();
            userFilter.Sort_By_First_Name = search.Sort_By_First_Name;
            userFilter.Sort_By_Last_Name = search.Sort_By_Last_Name;
            userFilter.Sort_By_Email = search.Sort_By_Email;
            userFilter.Sort_By_Date = search.Sort_By_Date;

            return View(userFilter);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,User_Password,Email_Address,Date_Created,Date_Modified")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,User_Password,Email_Address,Date_Created,Date_Modified")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        private string ConvertAustralianUserFriendlyDateFormat(DateTime date)
        {
            DateTimeFormatInfo cfg = CultureInfo.GetCultureInfo("en-AU").DateTimeFormat;
            return date.Day + " " + cfg.GetMonthName(date.Month) + " " + date.Year;
        }
    }
}
