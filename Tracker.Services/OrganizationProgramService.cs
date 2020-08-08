using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;
using Tracker.Models;
using Tracker.Models.OrganiztionModels;

namespace Tracker.Services
{
    public class OrganizationProgramService
    {
        public bool CreateProgram(ProgramCreate model)
        {
            var entity =
                new OrganizationProgram()
                {
                    ProgramName = model.ProgramName,
                    ProgramDescription = model.ProgramDescription,
                    Address = model.Address,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.OrganizationPrograms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Organization_ProgramListItem> GetAllProgramsByOrganizationId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allPrograms =
                    ctx
                    .Organizations
                    .Single(e => e.OrganizationId == id)
                    .OrganizationPrograms
                    .Select
                    (e =>
                       new Organization_ProgramListItem
                       {
                           OrganizationProgramId = e.ProgramId,
                           OrganizationProgramName = e.ProgramName,
                           OrganizationId = e.OrganizationId,
                           OrganizationName = e.Organization.OrganizationName
                       }

                        );

                return allPrograms.ToArray();
            }
        }

        public IEnumerable<ProgramListItem> GetAllOrganizations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .OrganizationPrograms
                    .Select
                    (e =>
                    new ProgramListItem
                    {
                        ProgramId = e.ProgramId,
                        ProgramName = e.ProgramName,
                        Address = e.Address

                    }

                    );
                return query.ToArray();
            }
        }
        public ProgramDetail GetProgramById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .OrganizationPrograms
                    .Single(e => e.ProgramId == id);
                return new ProgramDetail
                {
                    ProgramId = entity.ProgramId,
                    ProgramName = entity.ProgramName,
                    ProgramDescription = entity.ProgramDescription,
                    Address = entity.Address
                };

            }
        }

        public bool UpdateProgram(ProgramEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .OrganizationPrograms
                    .Single(e => e.ProgramId == model.ProgramId);
                entity.ProgramName = model.ProgramName;
                entity.ProgramDescription = model.ProgramDescription;
                entity.Address = model.Address;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProgram(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .OrganizationPrograms
                    .Single(e => e.OrganizationId == id);

                ctx.OrganizationPrograms.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
