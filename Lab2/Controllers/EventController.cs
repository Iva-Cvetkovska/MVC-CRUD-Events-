using Lab2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class EventController : Controller
    {
        private static List<EventModel> _events = new List<EventModel> { 
            new EventModel { Id = 1, Name = "Brucoshka", Location = "Kampus" },
            new EventModel { Id = 2, Name = "Zemjotres", Location = "MKC" },
            new EventModel { Id = 3, Name = "Kalabalak", Location = "Radovish" }
        };

        // GET: Event
        public ActionResult Index()
        {
            return View(_events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            EventModel current_event = _events.FirstOrDefault(e => e.Id == id);
            return View(current_event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(string name, string location)
        {
            try
            {
                var highestId = _events.Any() ? _events.Max(x => x.Id) + 1 : 1;
                EventModel new_event = new EventModel { Id = highestId, Name = name, Location = location };
                _events.Add(new_event);

                return RedirectToAction("Details", new { id = new_event.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            EventModel current_event = _events.FirstOrDefault(e => e.Id == id);
            return View(current_event);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string name, string location)
        {
            try
            {
                EventModel current_event = _events.FirstOrDefault(e => e.Id == id);
                current_event.Name = name;
                current_event.Location = location;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            int index = _events.FindIndex(e => e.Id == id);
            _events.RemoveAt(index);

            return RedirectToAction("Index");
        }
    }
}
