using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLForDatabase
{
    public class MySqlCommand : ICommand
    {
        public MySqlCommand(string commandText, IDBUser user)
        {
            this.CommandText = commandText;
            this.CommandUser = user;
        }

        public string CommandText { get; set; }

        public IDBUser CommandUser { get; }
    }
}
