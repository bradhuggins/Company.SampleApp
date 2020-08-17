#region Using Statements
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Company.SampleApp.WebApis.api
{
    public abstract class BaseController<T> : Controller where T : class
    {
        internal readonly T _service;

        public BaseController(T service)
        {
            _service = service;
        }
    }
}