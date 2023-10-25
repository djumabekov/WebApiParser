using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.ReferenceParser
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        Task<object> Handle(object request);
    }

    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;

            return handler;
        }

        public virtual Task<object> Handle(object request)
        {
            return this._nextHandler.Handle(request);
        }
    }
}
