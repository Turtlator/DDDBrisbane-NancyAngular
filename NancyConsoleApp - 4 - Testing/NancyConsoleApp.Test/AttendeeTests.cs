using System.Collections;
using System.Linq;
using Nancy.Testing;
using NancyConsoleApp.Data;
using NancyConsoleApp.Model;
using NancyConsoleApp.NancyModules;
using NSubstitute;
using NUnit.Framework;

namespace NancyConsoleApp.Test
{
    [TestFixture]
    public class AttendeeTests
    {
        private Browser _browser;

        [SetUp]
        public void Setup()
        {
            _browser = new Browser(with =>
            {
                with.Module<AttendeeModule>();
                with.Dependency<IAttendeeRepository>(new AttendeeRepository());
                with.Dependency(Substitute.For<ILog>());

            });
        }

        [Test]
        public void GetAttendeesShouldReturnThreePeople()
        {
            var response = _browser.Get("/attendees");

            response.Body["ul li"].ShouldExistExactly(3);
        }

        [Test]
        public void UpdateAttendeeShouldHaveUpdatedNameInList()
        {
            var response = _browser.Post("/attendees", ctx =>
            {
                ctx.Header("accept","application/json");
                ctx.FormValue("Id", "1");
                ctx.FormValue("Name", "Turtle Graham");
            });

            var model = response.Body.DeserializeJson<Attendee>();
            
            Assert.AreEqual(model.Name, "Turtle Graham");
        }

        [Test]
        public void AddAttendeeShouldIncreaseTheId()
        {
            var response = _browser.Post("/attendee/new",
                ctx =>
                {
                    ctx.Header("accept", "application/json");
                    ctx.FormValue("Name", "Peter Parker");
                });

            var model = response.Body.DeserializeJson<Attendee>();

            Assert.AreEqual(model.Id, 4);
        }
    }
}