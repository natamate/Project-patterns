using System;
using System.ComponentModel.DataAnnotations;

namespace ACLDatabase.Model
{
    //Database of SecureEntity
    public class RowRoleDependency
    {
        protected RowRoleDependency()
        {
            RowRoleDependencyId = Guid.NewGuid();
        }

        public RowRoleDependency(Row row, Role role)
        {
            RowRoleDependencyId = Guid.NewGuid();
            RoleId = role;
            RowId = row.RowId;
        }

        [Required]
        public Guid RowRoleDependencyId { get; set; }

        [Required]
        public Guid RowId { get; set; }

        [Required]
        public Role RoleId { get; set; }
    }
}