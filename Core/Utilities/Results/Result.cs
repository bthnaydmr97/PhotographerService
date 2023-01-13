using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Constroctor overloading yapildi.İki parametre gönderdiğin de : this(success) ile Alttaki tek parametreli success Const ta çalışır.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Suscces = success;
        }

        public bool Suscces { get; }
        public string Message { get; }
    }
}
