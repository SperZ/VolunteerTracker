using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;
using Tracker.Models;
using Tracker.Models.OrganiztionModels;

namespace Tracker.Services
{
    public class OrganizationService
    {
        public bool CreateOrganization(OrganizationCreate model)
        {
            var entity =
                new Organization()
                {
                    OrganizationName = model.OrganizationName,
                    OrganizatinonDescription = model.OrganizatinonDescription,
                    Address = model.Address,
                    WebUrl = model.WebUrl
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Organizations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public OrganizationDetail GetOrganizationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Organizations
                    .Single(e => e.OrganizationId == id);

                return
                    new OrganizationDetail
                    {
                        OrganizationId = entity.OrganizationId,
                        OrganizationName = entity.OrganizationName,
                        OrganizatinonDescription = entity.OrganizatinonDescription,
                        Address = entity.Address,
                        WebUrl =entity.WebUrl,
                        OrganizationPrograms = entity.OrganizationPrograms
                    };
            };
        }

        public IEnumerable<OrganizationListItem> GetOrganizations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Organizations
                    .Select
                    (
                        e =>
                        new OrganizationListItem
                        {
                            OrganizationId = e.OrganizationId,
                            OrganizationName = e.OrganizationName,
                            WebUrl = e.WebUrl
                        }

                        );
                return query.ToArray();
            }
        }

        public bool UpdateOrganization(OrganizationEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Organizations
                    .Single(e => e.OrganizationId == model.OrganizationId);
                entity.OrganizationName = model.OrganizationName;
                entity.OrganizatinonDescription = model.OrganizatinonDescription;
                entity.Address = model.Address;
                entity.WebUrl = model.WebUrl;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteOrganization(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Organizations
                    .Single(e => e.OrganizationId == id);

                ctx.Organizations.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
