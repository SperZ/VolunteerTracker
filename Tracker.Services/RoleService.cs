using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;
using Tracker.Models;
using Tracker.Models.RoleModels;

namespace Tracker.Services
{
    public class RoleService
    {
        public bool CreateRole(RoleCreate model)
        {
            var entity =
                new Role() 
                { 
                    RoleName = model.RoleName,
                    Description= model.Description 
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Roles.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public RoleDetail GetRolebyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var role =
                    ctx
                    .Roles
                    .Single(e => e.RoleId == id);
                return new RoleDetail
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    Description = role.Description,
                };
            }
        }

        public IEnumerable<RoleListItem> GetAllRoles()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Roles
                    .Select
                    (e =>
                        new RoleListItem 
                        { 
                            RoleId = e.RoleId,
                            RoleName = e.RoleName
                        }

                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RoleListItem> GetAllRolesbyProgramId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allRoles =
                    ctx
                    .OrganizationPrograms
                    .Single(e => e.ProgramId == id)
                    .Roles
                    .Select(
                        e =>
                        new RoleListItem 
                        { 
                            RoleId = e.RoleId,
                            RoleName = e.RoleName
                        }
                        );
                return allRoles.ToArray();
            }
        }

        public IEnumerable<RoleListItem> GetAllRolesbyVolunteerId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var allRoles =
                    ctx
                    .Volunteers
                    .Single(e => e.VolunteerId == id)
                    .Roles
                    .Select(
                        e =>
                        new RoleListItem
                        {
                            RoleId = e.RoleId,
                            RoleName = e.RoleName,
                        }

                        );
                return allRoles.ToArray();
            }
        }

        public bool UpdateRole(RoleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Roles
                    .Single(e => e.RoleId == model.RoleId);
                entity.RoleName = model.RoleName;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRole(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Roles
                    .Single(e => e.RoleId == id);
                ctx.Roles.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
