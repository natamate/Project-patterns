using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EntityFramework.DynamicFilters;

namespace ACLDatabase.Model
{
    //Context of model
    //Using entity framework to deal with database. It inheritances from DbContext
    public abstract class ModelContext : DbContext
    {
        //Model contains User, Role, RowRole
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RowRoles> RowRoles { get; set; }
        private string UserNameInProcess;

        protected ModelContext()
        {
            this.InitializeDynamicFilters();
        }

        protected ModelContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            this.InitializeDynamicFilters();
        }

        protected sealed override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter("SecuredByRole",
                (Row securedEntity, IEnumerable<Guid> userRows) => userRows.Contains(securedEntity.RowId),
                (ModelContext context) => context.GetUserRowIds(UserNameInProcess));

            base.OnModelCreating(modelBuilder);
        }


        public void Authorize(string username)
        {
            UserNameInProcess = username;
        }

        private IEnumerable<Guid> GetUserRowIds(string username) {
            var roles = GetUserRoles(username);
            return RowRoles
                .Where(r => roles.Contains(r.RoleId))
                .Select(r => r.RowId);
        }

        private IEnumerable<string> GetUserRoles(string userName)
        {
            var user = Users.First(u => u.Login == userName);
            var roles = user.Roles.Select(r => r.RoleId);
            return roles.Concat(GetChildRoleIds(roles)).Distinct();
        }

        private IEnumerable<string> GetChildRoleIds(IEnumerable<string> roleParentIds)
        {
            var childRoleIds =
                Roles
                    .Where(r => roleParentIds.Contains(r.ParentId))
                    .Select(r => r.RoleId)
                    .AsEnumerable();
            if (childRoleIds.Any())
                return childRoleIds.Concat(GetChildRoleIds(childRoleIds));
            return childRoleIds;
        }
    }
}