using System;
using System.Linq;
using ACLDatabase.Company;
using PostSharp.Aspects;
using ACLDatabase.Model;

namespace ACLDatabase.Aspect
{
    //When you create an object in a .Net framework application.
    //You don't need to think about how the data is stored in memory.
    //Serialization allows the developer to save the state of an object
    //Develop can recreate it as needed, providing storage of objects as well as data exchange.
    [Serializable]
    //Aspect that, when applied to a method defined in the current assembly,
    //inserts a piece of code before and after the body of these methods. 
    public class Authorize : OnMethodBoundaryAspect
    {
        public string Username { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            //TODO Podmień user na Role
            throw new NotImplementedException();
            var user = args.Arguments.OfType<IUser>().FirstOrDefault();
            var context = args.Arguments.OfType<ModelContext>().FirstOrDefault();

            if (user == null || context == null)
                throw new ArgumentNullException();

            context.Authorize(user.Username);
        }
    }
}