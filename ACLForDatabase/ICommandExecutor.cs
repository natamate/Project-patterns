using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ACLForDatabase
{
    public interface ICommandExecutor<TCommand> where TCommand : class, ICommand
    {
        
        DataTable Execute(TCommand command);
    }
}
