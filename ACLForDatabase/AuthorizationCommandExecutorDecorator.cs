using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLForDatabase
{
    public sealed class AuthorizationCommandExecutorDecorator<TCommand> : ICommandExecutor<TCommand> where TCommand : class, ICommand
    {
        private readonly ICommandExecutor<TCommand> decorated;

        public AuthorizationCommandExecutorDecorator(ICommandExecutor<TCommand> decorated)
        {
            this.decorated = decorated;
        }

        public DataTable Execute(TCommand command)
        {
           var onBefore = new OnBeforeExecute<TCommand>(command);
           return this.decorated.Execute(onBefore.Command);
        }
    }
}
