using System.ComponentModel.DataAnnotations;

namespace ACLDatabase.Model
{
    //Database of SecureEntity
    public abstract class Row
    {
        
        [Key]
        public int RowId { get; set; }
    }
}