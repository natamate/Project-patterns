﻿using System;
using System.Linq;
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
            string userName = null;
            var parameters = args.Method.GetParameters();
            for (var i = 0; i < parameters.Length; i++)
                if (parameters[i].Name.ToLower().Equals("username"))
                    userName = (string) args.Arguments.GetArgument(i);

            var context = args.Arguments.OfType<ModelContext>().FirstOrDefault();
            if (userName == null || context == null)
                throw new ArgumentException("Argument usrename and context are required");

            context.Authorize(userName);
        }
    }
}