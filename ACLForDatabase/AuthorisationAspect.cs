using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using PostSharp.Aspects;

namespace ACLForDatabase
{
    [Serializable]
    public class AuthorisationAspect : MethodInterceptionAspect
    {
        private readonly string regexToIdentifyInsert =
            ".*insert +into +([a-z_]+) +.*";
        // TO CHANGE
        private readonly string regexToIdentifyEditionPerms = 
            "(update)|(delete)";

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var statement = (string)args.Arguments[0];
            var user = (IDBUser)args.Arguments[1];
            if (!user.IsAdmin)
            {
                var newStatement = GenerateNewStatement(statement, user);
                args.Arguments[0] = newStatement;
            }
            args.Proceed();
        }

        // TO DO
        private string GenerateNewStatement(string statement, IDBUser user)
        {
            var userRole = user.UserRole;


            return "";
        }
    }
}
