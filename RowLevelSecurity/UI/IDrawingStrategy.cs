using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACLDatabase.Company.DB;


namespace ACLDatabase.UI
{
    public interface IDrawingStrategy
    {
        void DrawSpecificTable(CompanyContext context);
    }
}
