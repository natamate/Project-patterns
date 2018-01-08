using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace ACLForDatabase
{
    class AuthorisationAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            

            throw new NotImplementedException();
        }
    }
}
