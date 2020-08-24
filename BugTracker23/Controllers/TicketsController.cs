using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BugTracker23.Helpers;
using BugTracker23.Models;
using BugTracker23.ViewModels;
using Microsoft.AspNet.Identity;

namespace BugTracker23.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ProjectHelper projectHelper = new ProjectHelper();
        private RoleHelper roleHelper = new RoleHelper();
        private TicketHelper ticketHelper = new TicketHelper();
        private TicketManager ticketManager = new TicketManager();

        #region// GET: All Tickets and Get All My Tickets
        [Authorize]
        public ActionResult Index()
        {
            //I want to show all Tickets AND my Tickets - Jason 8-11-2020
            //Created and Using MyTicketVM
            var myTicketVM = new MyTicketVM();
            myTicketVM.AllTickets = db.Tickets.ToList();
            myTicketVM.MyTickets = ticketManager.GetMyTickets();
            return View(myTicketVM);
        }
        #endregion

        #region // GET: All Tickets by Project
        //Added on 8/13/2020 with Drew - Viewing Tickets by Project
        public ActionResult GetProjectTickets()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var ticketList = new List<Ticket>();
            ticketList = user.Projects.SelectMany(p => p.Tickets).ToList();
            return View("Index", ticketList);
        }
        #endregion

        #region//GET: All My Tickets by Project
        //Added on 8/13/2020 with Drew - Viewing MyTickets by Project
        public ActionResult GetMyTickets()
        {
            var userId = User.Identity.GetUserId();
            var ticketList = new List<Ticket>();
            if (User.IsInRole("Developer"))
            {
                ticketList = db.Tickets.Where(t => t.DeveloperId == userId).ToList();
                return View("Index", ticketList);
            }
            if (User.IsInRole("Submitter"))
            {
                ticketList = db.Tickets.Where(t => t.DeveloperId == userId).ToList();
                return View("Index", ticketList);
            }
            else
            {
                return RedirectToAction("GetProjectTickets");
            }
        }
        #endregion

        // GET: Tickets/Details/5
        [Authorize(Roles = "Administrator, Submitter")]
        public ActionResult Dashboard(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        [Authorize(Roles = "Administrator, Submitter")]
        public ActionResult Create()
        {

            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.ProjectId = new SelectList(projectHelper.ListUserProjects(userId), "Id", "Name");
            ViewBag.SubmitterId = new SelectList(db.Users, "Id", "Name");
            ViewBag.TicketPriorityId = new SelectList(db.TicketPriorities, "Id", "Name");
            ViewBag.TicketTypeId = new SelectList(db.TicketTypes, "Id", "Name");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Submitter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectId,TicketPriorityId,TicketTypeId,Title,Description")] Ticket ticket)
        {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                ticket.Created = DateTime.Now;
                ticket.TicketStatusId = db.TicketStatus.Where(ts => ts.Name == "Open").FirstOrDefault().Id;
                ticket.SubmitterId = userId;
                db.Tickets.Add(ticket);
                db.SaveChanges();
                
                return RedirectToAction("Index");//Best for allowing user to create a ticket outside of a project;
                //return RedirectToAction("Details", "Projects", new {id = ticket.ProjectId}); //Best for enforcing ticket creation from inside a project view;
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", ticket.ProjectId);
            ViewBag.TicketPriorityId = new SelectList(db.TicketPriorities, "Id", "Name", ticket.TicketPriorityId);
            ViewBag.TicketTypeId = new SelectList(db.TicketTypes, "Id", "Name", ticket.TicketTypeId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperId = new SelectList(db.Users, "Id", "FirstName", ticket.DeveloperId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", ticket.ProjectId);
            ViewBag.SubmitterId = new SelectList(db.Users, "Id", "FirstName", ticket.SubmitterId);
            ViewBag.TicketPriorityId = new SelectList(db.TicketPriorities, "Id", "Name", ticket.TicketPriorityId);
            ViewBag.TicketStatusId = new SelectList(db.TicketStatus, "Id", "Name", ticket.TicketStatusId);
            ViewBag.TicketTypeId = new SelectList(db.TicketTypes, "Id", "Name", ticket.TicketTypeId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectId,TicketPriorityId,TicketStatusId,TicketTypeId,SubmitterId,DeveloperId,Title,Description,Created,Updated,IsResolved,IsArchived")] Ticket ticket)
        {
            if (ModelState.IsValid)
            //{
            //    //Go out and get an unedited copy of the ticket from the DB
            //    var oldTicket = db.Tickets.AsNoTracking().FirstOrDefault(t => t.Id == ticket.Id);
            //    db.Entry(ticket).State = EntityState.Modified;
            //    db.SaveChanges();

            //    var newTicket = db.Tickets.AsNoTracking().FirstOrDefault(t => t.Id == ticket.Id);
            //    ticketHelper.EditedTicket(oldTicket, newTicket);
            //    return RedirectToAction("Index");

            //    //Somehow compare my old Ticket with the new Ticket to make any number of decisions that might be required;
            //    var newTicket = db.Tickets.AsNoTracking().FirstOrDefault(t => t.Id == ticket.Id);
            //    ticketHelper.ManageTicketNotifications(oldTicket, newTicket);
            //    return RedirectToAction("Index");
            //}
            ViewBag.ProjectId = new SelectList(db.Users, "Id", "FirstName", ticket.DeveloperId);
            ViewBag.TicketPriorityId = new SelectList(db.TicketPriorities, "Id", "Name", ticket.TicketPriorityId);
            ViewBag.TicketStatusId = new SelectList(db.TicketStatus, "Id", "Name", ticket.TicketStatusId);
            ViewBag.TicketTypeId = new SelectList(db.TicketTypes, "Id", "Name", ticket.TicketTypeId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5 Project specifies that tickets can not be deleted;

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