using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACLDatabase.Model;

namespace ACLDatabase.UI
{
    public interface IView
    {
        void DrawGreetings();
        void ClearView();
        void DrawTable();
        string GetTypeOfConnection();
        Company.IUser GetUser();
        void SetDrawingStrategy(IDrawingStrategy stratefy);
    }
}
