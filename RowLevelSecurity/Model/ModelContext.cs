using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EntityFramework.DynamicFilters;

namespace ACLDatabase.Model
{
    public abstract class ModelContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public  DbSet<Row> Rows { get; set; }
        public DbSet<RowRoleDependency> RowRoleDependencies { get; set; }

        private string _userNameInProcess;

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
                (Row securedEntity, IEnumerable<int> userRows) => userRows.Contains(securedEntity.RowId),
                (ModelContext context) => context.GetUserRowIds(_userNameInProcess));
                

            base.OnModelCreating(modelBuilder);
        }

        private IEnumerable<int> GetUserRowIds(string username)
        {
            var roles = GetUserRoles(username);
            return RowRoleDependencies
                .Where(r => roles.Contains(r.RoleId))
                .Select(r => r.RowId);
        }

        private IEnumerable<string> GetUserRoles(string userName)
        {
            var role = Roles.First(u => u.RoleId == userName).RoleId;
            var roles = new List<string>() { role };
            return roles.Concat(GetChildRoleIds(roles)).Distinct();
        }

        private IEnumerable<string> GetChildRoleIds(IEnumerable<string> roleParentIds)
        {
            var childRoleIds =
                Roles
                    .Where(r => roleParentIds.Contains(r.ParentId))
                    .Select(r => r.RoleId)
                    .AsEnumerable();
            return childRoleIds.Any() ? childRoleIds.Concat(GetChildRoleIds(childRoleIds)) : childRoleIds;
        }

        //private List<string> GetRowRoles(Row row)
        //{
        //    return (from dependency in RowRoleDependencies where dependency.RowId == row.RowId select dependency.Role.RoleId).ToList();
        //}

        public void Authorize(string username)
        {
            _userNameInProcess = username;
        }


        //private IEnumerable<string> GetChildRoleIds(IEnumerable<string> roleParentIds)
        //{
        //    var childRoleIds =
        //        Roles
        //            .Where(r => roleParentIds.Contains(r.ParentId))
        //            .Select(r => r.RoleId)
        //            .AsEnumerable();
        //    return childRoleIds.Any() ? childRoleIds.Concat(GetChildRoleIds(childRoleIds)) : childRoleIds;
        //}

        /**************************************************************************************************/
        //private void AddRole(Role addedRole)
        //{
        //    Roles.Add(addedRole);
        //}

        //private void RemoveRole(Role removedRole)
        //{
        //    Roles.Remove(removedRole);
        //}

        //private void AddRow(Row addedRow)
        //{
        //    Rows.Add(addedRow);
        //}

        //private void RemoveRow(Row removedRow)
        //{
        //    Rows.Remove(removedRow);
        //}

        //private void AddRowRoleDependency(Row addedRow, Role addedRole)
        //{
        //    RowRoleDependencies.Add(new RowRoleDependency(addedRow,addedRole));
        //}

        //private void RemoveRowRoleDependency(Row removedRow,Role removedRole)
        //{
        //    var toBeRemoved = RowRoleDependencies.Where(n => n.Role == removedRole && n.RowId == removedRow.RowId);
        //    RowRoleDependencies.RemoveRange(toBeRemoved);
        //}
    }
}