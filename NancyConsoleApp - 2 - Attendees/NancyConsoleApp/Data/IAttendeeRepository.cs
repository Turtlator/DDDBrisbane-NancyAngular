using System.Collections.Generic;
using NancyConsoleApp.Model;

namespace NancyConsoleApp.Data
{
    public interface IAttendeeRepository
    {
        Attendee GetById(int id);
        ICollection<Attendee> GetAll();

        void Insert(string name);
    }
}