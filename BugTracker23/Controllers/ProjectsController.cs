﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTracker23.Models;

namespace BugTracker23.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        [Authorize(Roles = "Administrator, Project Manager")]
        public ActionResult Create()
        {
            var model = new Project();
            return View(model);
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Created,IsArchived")] Project project)
        {
            if (ModelState.IsValid)
            {

                project.Created = DateTime.Now;
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }
        ////Project Wizard View Model
        //public ActionResult ProjectWizard()
        //{
        //    ViewBag.ProjectManagerId = new SelectList(roleHelper.UsersinRole("Project Manager"), "Id", "FullName");
        //    ViewBag.DeveloperIds = new MultiSelectList(roleHelper.UsersinRole("Developer", "Id", "FullName"));
        //    ViewBag.SubmitterIds = new MultiSelectList(roleHelper.UsersinRole("Submitter", "Id", "FullName"));
        //    ViewBag.Errors = "";
        //    var model = new ProjectWizardVM();
        //    return View(model);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ProjectWizard(ProjectWizardVM model)
        //{
        //    ViewBag.Errors = "";

        //    if (model.ProjectManagerId == null)
        //    {
        //        ViewBag.Errors += "<p>You must select a Project Manager</p>";
        //    }
        //    if (model.DeveloperId == null)
        //    {
        //        ViewBag.Errors += "<p>You must select a Developer</p>";
        //    }
        //    if (model.SubmitterId == null)
        //    {
        //        ViewBag.Errors += "<p>You must select a Submitter</p>";
        //    }
        //    if ViewBag.Errors.Length > 0
        //}

        // GET: Projects/Edit/5
        [Authorize(Roles = "Administrator, Project Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Created,IsArchived")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;

                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
