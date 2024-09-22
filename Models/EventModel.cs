using System.ComponentModel.DataAnnotations;

namespace App.EventTracker.Models
{
	public class EventModel
	{
		private static int _count = 0;
		public int Id { get; set; }
		[Display(Name = "Başlık")]
		public string Title { get; set; } = null!;
		[Display(Name = "Açıklama")]
		public string Description { get; set; }
		[Display(Name = "Tarih")]
		public DateTime Date { get; set; }

        public EventModel()
        {
            Id = ++_count;
        }
    }
}
