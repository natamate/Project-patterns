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
            //TODO dodaj nowe dziłąnie filtru
            throw new NotImplementedException();
            modelBuilder.Filter("SecuredByRole",
                (Row securedEntity, IEnumerable<Guid> userRows) => userRows.Contains(securedEntity.RowId),
                (ModelContext context) => context.GetUserRowIds(_userNameInProcess));

            base.OnModelCreating(modelBuilder);
        }

        public void Authorize(string username)
        {
            _userNameInProcess = username;
        }

        private IEnumerable<Guid> GetUserRowIds(string username) {
            var roles = GetUserRoles(username);
            //TODO zmien implementacje z Usera dla roli wzraz z wszystkimi uzyciami
            throw new NotImplementedException();
            //return RowRoles
            //    .Where(r => roles.Contains(r.RoleId))
            //    .Select(r => r.RowId);
        }

        private IEnumerable<string> GetUserRoles(string userName)
        {
            //TODO zamień User na Role 
            throw new NotImplementedException();
            //var user = Users.First(u => u.Login == userName);
            //var roles = user.Roles.Select(r => r.RoleId);
            //return roles.Concat(GetChildRoleIds(roles)).Distinct();
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
        //Uzytkownika indentyfikuejmy z rolą 
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
            RowRoleDependencies.Add(new RowRoleDependency(addedRow,role: addedRole));
        }

        public void RemoveRowRoleDependency(Row removedRow,Role removedRole)
        {
            var toBeRemoved = RowRoleDependencies.Where(n => n.RoleId == removedRole && n.RowId == removedRow.RowId);
            RowRoleDependencies.RemoveRange(toBeRemoved);
        }


    }
}