using System.Collections.Generic;
using System.Linq;
using NancyConsoleApp.Model;

namespace NancyConsoleApp.Data
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly List<Attendee> _attendees;

        public AttendeeRepository()
        {
            _attendees = new List<Attendee>(new[]
            {
                new Attendee(1, "Brendan Graham"),
                new Attendee(2, "Chris Gilbert"),
                new Attendee(3, "David Cook"),
            });
        }
        public Attendee GetById(int id)
        {
            return _attendees.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<Attendee> GetAll()
        {
            return _attendees;
        }

        public Attendee Insert(string name)
        {
            var id = _attendees.Max(a => a.Id) + 1;

            _attendees.Add(new Attendee(id, name));

            return GetById(id);
        }
    }
}