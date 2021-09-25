using Makaya.Resolver.IExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makaya.Resolver.Handlers
{
    public class ApiBusinessExceptionHandler : BaseExceptionHandler
    {
        static ApiBusinessExceptionHandler _instance;
        private ApiBusinessExceptionHandler() { }
        public static ApiBusinessExceptionHandler GetInstance()
        {
            if (_instance == null)
                _instance = new ApiBusinessExceptionHandler();
            return _instance;
        }

        public override IApiExceptions HandleExceptions(Exception ex)
        {
            if (ex is ApiBusinessException)
                return (ApiBusinessException)ex;
            return Mychainhandler.HandleExceptions(ex);
        }
    }
}
