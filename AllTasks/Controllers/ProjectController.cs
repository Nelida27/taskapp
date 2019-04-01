using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AllTasks.Models;
namespace AllTasks.Controllers

{
    public class ProjectController : Controller
    {
        private TasksDBContext db = new TasksDBContext();

        // GET: Project
        public async System.Threading.Tasks.Task<ActionResult> Index(string Project_Name,string searchString)
        {
            string pn = Project_Name;
            var movies = from m in db.Tasks
                         select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            else
            {
                movies = movies.Where(s => s.Project_Name.Contains(pn));

            }
            return View(await movies.ToListAsync());


        }



        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nr,Title,Description,Worked,T_L,Test_Date,My_Time,Project_Name")] tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(tasks);
                db.SaveChanges();
                return RedirectToAction("Index", new { tasks.Project_Name });
            }

            return View(tasks);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            tasks.Test_Date = DateTime.Now;
            return View(tasks);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nr,Title,Description,Worked,T_L,Test_Date,My_Time,Project_Name")] tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new { tasks.Project_Name});
            }
            return View(tasks);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            else {
                db.Tasks.Remove(tasks);
                db.SaveChanges();

            }
            return RedirectToAction("Index/" + tasks.Project_Name );
        }
        //public ActionResult Delete(int id)
        //{
        //    User user = db.Users.Find(id);
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    TempData["Msg"] = "Data has been deleted succeessfully";
        //    return RedirectToAction();
        //}
        // POST: Project/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tasks tasks = db.Tasks.Find(id);
        //    db.Tasks.Remove(tasks);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
