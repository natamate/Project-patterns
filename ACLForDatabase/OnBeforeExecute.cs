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
            "(select.*from.*)(;)";
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
            var regex = new Regex(regexToIdentifySelect,
                RegexOptions.IgnoreCase);
            var match = regex.Match(commandText);



            // Here we check the Match instance.
            if (match.Success)
            {
                var beginningPart = match.Groups[1].Value;
                var endingPart = match.Groups[2].Value;
                var joinPart = " natural join permissions as p ";
                var wherePart = "where p.roleId in (SELECT node.roleId FROM roles AS parent, roles AS node " +
                    "WHERE node.lft BETWEEN parent.lft AND parent.rgt " +
                    "AND parent.name = '" + role.RoleName + "') and selectPermission = 1";
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
