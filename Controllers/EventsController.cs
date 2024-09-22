using App.EventTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EventTracker.Controllers
{
	public class EventsController : Controller
	{
		private static List<EventModel> eventList = new List<EventModel>()
		{
			new EventModel{Title = "Tarkan Konseri", Description = "Şıkıdım şıkıdım", Date = DateTime.Now.AddMonths(1)},
			new EventModel{Title = "Ders", Description = "10 adımda 11 adım", Date = DateTime.Now.AddDays(7)}
		};

		public IActionResult Index()
		{
			return View(eventList);
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(EventModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			eventList.Add(model);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet("/Edit/{id}")]
		public IActionResult Edit([FromRoute] int id)
		{
			var model = eventList.FirstOrDefault(e => e.Id == id);

			if (model is null)
			{
				return NotFound();
			}

			return View(model);
		}

		[HttpPost("/Edit/{id}")]
		public IActionResult Edit([FromRoute] int id, [FromForm] EventModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var oldModel = eventList.FirstOrDefault(e => e.Id == model.Id);
            if (oldModel is not null)
            {
                oldModel.Title = model.Title;
                oldModel.Description = model.Description;
                oldModel.Date = model.Date;
            }

            return RedirectToAction(nameof(Index));
		}

		[HttpGet("/Details/{id}")]
		public IActionResult Details([FromRoute] int id, [FromForm] EventModel model)
		{
            model = eventList.First(e => e.Id == id);
			return View(model);
		}

		[HttpGet("/Delete/{id}")]
		public IActionResult Delete([FromRoute] int id)
		{
			var model = eventList.First(e => e.Id == id);
			if (model is null)
			{
				return NoContent();
			}

			eventList.Remove(model);

			return RedirectToAction(nameof(Index));
		}


	}
}
