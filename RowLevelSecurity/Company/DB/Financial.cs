using ACLDatabase.Model;

namespace ACLDatabase.Company.DB
{
    public class Financial : Row
    {

        public double Value { get; set; }
        public virtual Employee Employee { get; set; }
    }
}