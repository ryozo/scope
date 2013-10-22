using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scope.Exception
{
    /// <summary>
    /// 業務再起可能なエラーが発生した場合にthrowする例外。
    /// </summary>
    public class ApplicationRuntimeException : System.Exception
    {
        public ApplicationRuntimeException() { }
        public ApplicationRuntimeException(String message) : base(message) {}
        public ApplicationRuntimeException(String message, System.Exception cause) : base(message, cause) { }
    }
}