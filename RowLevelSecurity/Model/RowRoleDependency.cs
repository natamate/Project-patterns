using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACLDatabase.Model
{
    //Database of SecureEntity
    public class RowRoleDependency
    {
        protected RowRoleDependency() { }

        public RowRoleDependency(Row row, Role role)
        {
            RoleId = role.RoleId;
            RowId = row.RowId;
        }
        public RowRoleDependency(int rowId, Role role)
        {
            RoleId = role.RoleId;
            RowId = rowId;
        }

        [Key]
        public int RowRoleDependencyId { get; set; }
        [Required]
        public int RowId { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}