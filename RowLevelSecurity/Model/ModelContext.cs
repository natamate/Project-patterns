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
            //var pom = new List<string> {_userNameInProcess};
            modelBuilder.Filter("SecuredByRole", 
                (Row securedRow) => GetRowRoles(securedRow));
            //TODO sprawdz nowe działnie filtru
            //jakby nie działalo to zostawiam starą wersję
            //modelBuilder.Filter("SecuredByRole",
            //    (Row securedEntity, IEnumerable<Guid> userRows) => userRows.Contains(securedEntity.RowId),
            //    (ModelContext context) => context.GetUserRowIds(_userNameInProcess));

            base.OnModelCreating(modelBuilder);
        }

        private List<string> GetRowRoles(Row row)
        {
            return (from dependency in RowRoleDependencies where dependency.RowId == row.RowId select dependency.Role.RoleId).ToList();
        }
            
        public void Authorize(string username)
        {
            _userNameInProcess = username;
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

        /**************************************************************************************************/
        public void AddRole(Role addedRole)
        {
            Roles.Add(addedRole);
        }

        public void RemoveRole(Role removedRole)
        {
            Roles.Remove(removedRole);
        }

        public void AddRow(Row addedRow)
        {
            Rows.Add(addedRow);
        }

        public void RemoveRow(Row removedRow)
        {
            Rows.Remove(removedRow);
        }

        public void AddRowRoleDependency(Row addedRow, Role addedRole)
        {
            RowRoleDependencies.Add(new RowRoleDependency(addedRow,addedRole));
        }

        public void RemoveRowRoleDependency(Row removedRow,Role removedRole)
        {
            var toBeRemoved = RowRoleDependencies.Where(n => n.Role == removedRole && n.RowId == removedRow.RowId);
            RowRoleDependencies.RemoveRange(toBeRemoved);
        }
    }
}