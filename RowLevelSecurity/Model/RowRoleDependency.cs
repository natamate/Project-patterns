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
            Role = role;
            RowId = row.RowId;
        }
        public RowRoleDependency(int rowId, Role role)
        {
            Role = role;
            RowId = rowId;
        }

        [Key]
        public int RowRoleDependencyId { get; set; }
        [Required]
        public int RowId { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}