using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace ACLForDatabase
{
    [Serializable]
    public class AuthorisationAspect : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var statement = args.Arguments[0];
            var userName = args.Arguments[1];
            args.Proceed();
        }
    }
}
