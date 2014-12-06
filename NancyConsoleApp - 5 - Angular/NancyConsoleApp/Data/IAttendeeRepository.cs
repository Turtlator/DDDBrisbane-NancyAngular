using System.Collections.Generic;
using NancyConsoleApp.Model;

namespace NancyConsoleApp.Data
{
    public interface IAttendeeRepository
    {
        Attendee GetById(int id);
        ICollection<Attendee> GetAll();

        Attendee Insert(string name);
    }
}