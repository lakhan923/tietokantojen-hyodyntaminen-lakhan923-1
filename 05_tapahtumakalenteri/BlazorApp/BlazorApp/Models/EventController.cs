using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class EventController
    {
        public readonly EventCalendarContext _context;

        public EventController(EventCalendarContext context)
        {
            _context = context;
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            return await _context.Events.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == eventId);
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.Include(e => e.Category).ToListAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddEventAsync(Event newEvent)
        {
            if (newEvent != null)
            {
                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEventAsync(Event eventToUpdate)
        {
            try
            {
                // Update logic (e.g., update in a database)
                var existingEvent = await _context.Events.FindAsync(eventToUpdate.Id);
                if (existingEvent != null)
                {
                    existingEvent.Title = eventToUpdate.Title;
                    existingEvent.StartDate = eventToUpdate.StartDate;
                    existingEvent.EndDate = eventToUpdate.EndDate;
                    existingEvent.Location = eventToUpdate.Location;
                    existingEvent.CategoryId = eventToUpdate.CategoryId;
                    existingEvent.Description = eventToUpdate.Description;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                throw new Exception("Error updating event", ex);
            }
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var eventToDelete = await _context.Events.FindAsync(eventId);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
