using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using NancyConsoleApp.Data;
using NancyConsoleApp.Model;

namespace NancyConsoleApp.NancyModules
{
    public class AttendeeModule : NancyModule
    {
        private readonly IAttendeeRepository _attendeeRepo;

        public AttendeeModule(IAttendeeRepository attendeeRepo)
        {
            _attendeeRepo = attendeeRepo;

            Get["/attendees"] = _ => GetAttendees();
            Get["/attendees/{id:int}"] = _ => GetDetails((int)_.Id);
            Get["/attendee/new"] = _ => View["New.html", new Attendee()];

            Post["/attendees"] = _ => UpdateAttendee();
            Post["/attendee/new"] = _ => AddAttendee();
        }

        private Negotiator UpdateAttendee()
        {
            var model = this.Bind<Attendee>();

            var attendee = _attendeeRepo.GetById(model.Id);

            attendee.Name = model.Name;

            return Negotiate
                .WithMediaRangeResponse("text/html", Response.AsRedirect("/Attendees"))
                .WithModel(attendee);
        }

        private Negotiator GetAttendees()
        {
            var model = _attendeeRepo.GetAll();

            return Negotiate
                .WithView("Attendees.html")
                .WithModel(new { Attendees = model });
        }

        private Negotiator GetDetails(int id)
        {
            var model = _attendeeRepo.GetById(id);

            return Negotiate
                .WithView("Details.html")
                .WithModel(model);
        }

        private Negotiator AddAttendee()
        {
            var model = this.Bind<Attendee>();

            var responseModel = _attendeeRepo.Insert(model.Name);

            return Negotiate
                .WithModel(responseModel)
                .WithMediaRangeResponse("text/html", Response.AsRedirect("/attendees"));
        }
    }
}