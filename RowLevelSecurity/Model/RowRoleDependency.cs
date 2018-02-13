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
            Role = role;
            RowId = row.RowId;
        }
        public RowRoleDependency(int rowId, Role role)
        {
            RowRoleDependencyId = Guid.NewGuid();
            Role = role;
            RowId = rowId;
        }

        [Required]
        public Guid RowRoleDependencyId { get; set; }

        [Required]
        public int RowId { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}