using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makaya.Resolver.Handlers
{
    public class HandlerExceptions
    {
        private static HandlerExceptions _handler;
        private HandlerExceptions() { }

        private BaseExceptionHandler ExceptionHandler;

        static List<BaseExceptionHandler> Handlers;
        public static HandlerExceptions GetInstance()
        {
            if (_handler == null)
                _handler = new HandlerExceptions();
            return _handler;
        }

        public Exception RunCustomExceptions(Exception ex)
        {
            if (Handlers == null)
                FillExceptions();
            return RunExceptions(ex);


        }

        private Exception RunExceptions(Exception ex)
        {
            return (Exception)Handlers.First().HandleExceptions(ex);
        }

        private void FillExceptions()
        {
            Handlers = new List<BaseExceptionHandler>();
            Handlers.Add(ApiBusinessExceptionHandler.GetInstance());
            Handlers.Add(ApiExceptionHandler.GetInstance());
            BaseExceptionHandler _handler;
            for (int i = 0; i <= Handlers.Count(); i++)
            {

                _handler = Handlers.ElementAt(i);
                if (i + 1 == Handlers.Count())
                    break;
                _handler.Mychainhandler = Handlers.ElementAt(i + 1);

            }
        }
    }
}
