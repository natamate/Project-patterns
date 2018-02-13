using System;
using System.Linq;
using ACLDatabase.Company;
using PostSharp.Aspects;
using ACLDatabase.Model;

namespace ACLDatabase.Aspect
{
    [Serializable]
    public class Authorize : OnMethodBoundaryAspect
    {
        public string Username { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            //TODO Podmień user na Role
            var user = args.Arguments.OfType<IUser>().FirstOrDefault();
            var context = args.Arguments.OfType<ModelContext>().FirstOrDefault();

            if (user == null || context == null)
                throw new ArgumentNullException();

            context.Authorize(user.Username);
        }
    }
}