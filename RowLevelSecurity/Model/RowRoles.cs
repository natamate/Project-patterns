using System;
using System.ComponentModel.DataAnnotations;

namespace ACLDatabase.Model
{
    //Database of RowRoles
    public class RowRoles
    {
        [Required]
        [Key]
        public Guid RowId { get; set; }

        [Required]
        public string RoleId { get; set; }

    }
}