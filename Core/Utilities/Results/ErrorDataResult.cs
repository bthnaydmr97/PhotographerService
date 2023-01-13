using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataresult<T> : DataResult<T>
    {
        public ErrorDataresult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataresult(T data) : base(data, false)
        {


        }

        public ErrorDataresult(string message) : base(default, false, message)
        {

        }

        public ErrorDataresult() : base(default, false)
        {

        }
    }
}
