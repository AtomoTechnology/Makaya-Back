using Makaya.Resolver.IExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makaya.Resolver.Handlers
{
    public class ApiExceptionHandler : BaseExceptionHandler
    {
        static ApiExceptionHandler _instance;
        private ApiExceptionHandler() { }
        public static ApiExceptionHandler GetInstance()
        {
            if (_instance == null)
                _instance = new ApiExceptionHandler();
            return _instance;
        }

        public override IApiExceptions HandleExceptions(Exception ex)
        {
            if (ex is ApiException)
                return (ApiException)ex;
            return Mychainhandler.HandleExceptions(ex);
        }
    }
}
