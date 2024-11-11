using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.ManageShowTime
{
	public class ShowtimesModel : PageModel
	{
		private readonly PRN221_FinalProjectContext _context;

		public ShowtimesModel(PRN221_FinalProjectContext context)
		{
			_context = context;
		}
		public List<Models.Showtime> Showtimes { get; set; }
		public List<Models.Movie> Movies { get; set; }

		[BindProperty(SupportsGet = true)]
		public bool isAutoRendered { get; set; }

		[BindProperty]
		public Models.Showtime Showtime { get; set; } = new Models.Showtime();
		[BindProperty]
		public Models.Room? room { get; set; }
		public DateTime StartOfWeek { get; set; }
		public async Task<IActionResult> OnPostSaveShowtimeAsync(int id, int? weekOffset)
		{

			int? isEdittingValue = HttpContext.Session.GetInt32("isEditting");
			bool isEditting = isEdittingValue.HasValue && isEdittingValue.Value == 1;

			var roomID = HttpContext.Session.GetInt32("RoomID");
			room = await _context.Rooms.FindAsync(roomID);

			var movie = _context.Movies.Find(Showtime.MovieId);
			var sameDayShowtime = await _context.Showtimes
								 .Where(s => s.RoomId == roomID && s.Date == Showtime.Date && s.Id != id)
								 .ToListAsync();
            if (Showtime.StartTime + movie?.Duration > new TimeSpan(23, 59, 59))
            {
                TempData["error"] = "The selected time is out of range!";
                return RedirectToPage();
            }
            if (isEditting)
			{
				var showtime = await _context.Showtimes.FindAsync(id);

				if (showtime == null)
				{
					return NotFound();
				}

				showtime.MovieId = Showtime.MovieId;
				showtime.StartTime = Showtime.StartTime;
				showtime.EndTime = Showtime.StartTime + movie?.Duration;
				showtime.RoomId = roomID;
				var overlap = sameDayShowtime.Any(s =>
					(showtime.StartTime <= s.EndTime && showtime.StartTime >= s.StartTime) ||
					(showtime.EndTime >= s.StartTime && showtime.EndTime <= s.EndTime) ||
					(showtime.StartTime <= s.StartTime && showtime.EndTime >= s.EndTime)
				);

				if (overlap)
				{
					TempData["error"] = "The selected time conflicts with another showtime!";
					return RedirectToPage();
				}
				_context.Showtimes.Update(showtime);
				_context.SaveChanges();
				TempData["success"] = "Showtime updated successfully";
			}
			else
			{
				var showtime = new Models.Showtime
				{
					RoomId = roomID,
					MovieId = Showtime.MovieId,
					Date = Showtime.Date,
					StartTime = Showtime.StartTime,
					EndTime = Showtime.StartTime + movie?.Duration
				};
				if (isAutoRendered)
				{
					var currentStartTime = Showtime.StartTime;

					while (true)
					{
						var endTime = currentStartTime + movie.Duration;

						if (endTime > new TimeSpan(23, 59, 59))
						{
							break;
						}

						var newShowtime = new Models.Showtime
						{
							RoomId = roomID,
							MovieId = Showtime.MovieId,
							Date = Showtime.Date,
							StartTime = currentStartTime,
							EndTime = endTime
						};

						var overlap = sameDayShowtime.Any(s =>
							(newShowtime.StartTime <= s.EndTime && newShowtime.StartTime >= s.StartTime) ||
							(newShowtime.EndTime >= s.StartTime && newShowtime.EndTime <= s.EndTime) ||
							(newShowtime.StartTime <= s.StartTime && newShowtime.EndTime >= s.EndTime)
						);

						if (!overlap)
						{
							_context.Showtimes.Add(newShowtime);
							await _context.SaveChangesAsync();
						}

						currentStartTime += movie.Duration + TimeSpan.FromMinutes(15);
					}
				}
				else
				{
					_context.Showtimes.Add(showtime);
					await _context.SaveChangesAsync();
				}
				TempData["success"] = "Showtimes created successfully";

			}

			await LoadWeeklyShowtimes(weekOffset);

			return RedirectToPage();
		}
		public async Task<ActionResult> OnGetAsync(int? weekOffset)
		{
            if (!User.Identity.IsAuthenticated)
            {
                var returnURl = Url.Page("/HomeOwner");
                return RedirectToPage("/Login", new { returnURl = returnURl });
            }
            HttpContext.Session.SetInt32("isEditting", 0);
			await LoadWeeklyShowtimes(weekOffset);
			return Page();
		}
		public async Task<IActionResult> OnGetSelectShowtime(int id, int? weekOffset)
		{
			HttpContext.Session.SetInt32("isEditting", 1);
			// Tải suất chiếu từ cơ sở dữ liệu
			Showtime = await _context.Showtimes
				.Include(s => s.Movie)
				.Include(s => s.Room)
				.FirstOrDefaultAsync(s => s.Id == id);

			if (Showtime == null)
			{
				return NotFound();
			}
			// Tải lại danh sách suất chiếu trong tuần hiện tại
			await LoadWeeklyShowtimes(weekOffset);

			return Page();
		}
		public async Task<IActionResult> OnPostDeleteShowtimeAsync(int id)
		{
			var showtime = await _context.Showtimes.FindAsync(id);

			if (showtime == null)
			{
				return NotFound();
			}

			_context.Showtimes.Remove(showtime);
			await _context.SaveChangesAsync();

			TempData["success"] = "Showtime deleted successfully";

			return RedirectToPage();
		}

		private async Task LoadWeeklyShowtimes(int? weekOffset)
		{

			var roomId = HttpContext.Session.GetInt32("RoomID");
			room = await _context.Rooms.FindAsync(roomId);


			StartOfWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
			if (weekOffset.HasValue)
			{
				StartOfWeek = StartOfWeek.AddDays(weekOffset.Value * 7);
			}

			// Lấy các suất chiếu của tuần
			Showtimes = await _context.Showtimes
				.Include(s => s.Movie)
				.Include(s => s.Room)
				.Where(s => s.Date >= StartOfWeek && s.Date < StartOfWeek.AddDays(7) && s.RoomId == room.Id)
				.ToListAsync();

			Movies = await _context.Movies.ToListAsync();
		}
	}
}
