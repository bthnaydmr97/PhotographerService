using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{

    //Class Method lara eklenebilir. Inherit edilebilir. Birden fazla kullanılabilir anlamına gelir. Eklediğimiz Attribute.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}
