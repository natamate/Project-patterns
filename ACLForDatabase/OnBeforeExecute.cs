using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ACLForDatabase
{
    public class OnBeforeExecute<TCommand> where TCommand : class, ICommand
    {
        // there is only example part of code
        private readonly string regexToIdentifySelect =
            "(.*select +from.*?)(where)|(group|having|order.*)";
        // TO CHANGE
        private readonly string regexToIdentifyEditionPerms =
            "(update)|(delete)";

        public OnBeforeExecute(TCommand command)
        {
            this.Command = AddAuthorisationCode(command);
        }

        public TCommand Command { get; private set; }

        // method to change !
        private TCommand AddAuthorisationCode(TCommand command)
        {
            var user = command.CommandUser;
            if (user.IsAdmin())
                return command;
            else
            {
                // change commandText to add authorisation code
                var commandText = command.CommandText;

                commandText = ChangeIfSelect(commandText, user.UserRole);

                command.CommandText = commandText;
                return command;
            }
        }

        // example only, not done
        private string ChangeIfSelect(string commandText, IDBRole role)
        {
            var match = Regex.Match(commandText, regexToIdentifySelect,
                RegexOptions.IgnoreCase);



            // Here we check the Match instance.
            if (match.Success)
            {
                var beginningPart = match.Groups[1].Value;
                var endingPart = match.Groups[3].Value;
                var joinPart = " natural join permisions r ";
                var wherePart = "where roleId = (select roleId from roles where name='" + role.RoleName +
                                "') and selectPermision=1 ";
                var result = beginningPart + joinPart + wherePart;

                if (commandText.Contains("where"))
                    result += " and ";

                result += endingPart;
                commandText = result;
            }

            return commandText;
        }
    }
}
