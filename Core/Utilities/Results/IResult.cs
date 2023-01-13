using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //Temel voidler için başlangıç.
        // Get ile getir işlemi  yapıyıruz. birşeyleri set etmeyeceğiz. Constructor içinde get ile çağıracağız.
        bool Suscces { get; }
        string Message { get; }
    }
}
