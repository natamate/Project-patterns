using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACLDatabase.Model
{
    //Database of Role
    //Its parentID references to ID which is directly connect in the tree
    public class Role
    {
        [Key]
        [MinLength(3)]
        [MaxLength(20)]
        public string RoleId { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string ParentId { get; set; }
    }
}