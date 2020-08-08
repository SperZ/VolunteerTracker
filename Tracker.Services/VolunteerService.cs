using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;
using Tracker.Models;

namespace Tracker.Services
{
    public class VolunteerService
    {
        public bool CreateVolunteer(VolunteerCreate model)
        {
            var entity =
                new Volunteer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    DaysAbleToVolunteer = model.DaysAbleToVolunteer
                };
            using(var ctx = new ApplicationDbContext)
            {
                ctx.Volunteers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VolunteerListItem> GetAllVolunteers()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Volunteers
                    .Select
                    (e =>
                    new VolunteerListItem
                    {
                        VolunteerId = e.VolunteerId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,

                    }

                    );
                return query.ToArray();
            }
        }

        public VolunteerDetail GetVolunteerById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Volunteers
                    .Single(e => e.VolunteerId == id);
                return new VolunteerDetail 
                { 
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    EmailAddress= entity.EmailAddress,
                    DaysAbleToVolunteer = entity.DaysAbleToVolunteer,
                };

            }
        }
        public IEnumerable<VolunteerListItem> GetVolunteersByProgramId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var allVolunteers =
                    ctx
                    .OrganizationPrograms
                    .Single(e => e.ProgramId == id)
                    .Volunteers
                    .Select(
                        e =>
                        new VolunteerListItem
                        {
                            VolunteerId = e.VolunteerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                        }
                        );
                return allVolunteers.ToArray();
            }
        }

        public IEnumerable<VolunteerListItem> GetVolunteersByRoleId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var allVolunteers =
                    ctx
                    .Roles
                    .Single(e => e.RoleId == id)
                    .Volunteers
                    .Select(
                        e =>
                        new VolunteerListItem 
                        { 
                            VolunteerId = e.VolunteerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                        }

                      );
                return allVolunteers.ToArray();
            }
        }
    }
}
