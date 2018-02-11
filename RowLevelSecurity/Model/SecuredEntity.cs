using System;
using System.ComponentModel.DataAnnotations;

namespace ACLDatabase.Model
{
    //Database of SecureEntity
    public abstract class Row
    {
        protected Row()
        {
            this.RowId = Guid.NewGuid();
        }

        [Required]
        public Guid RowId { get; set; }
    }
}