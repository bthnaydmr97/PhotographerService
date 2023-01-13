using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //params ile istediğimiz kadar parametre geçilebilir. ve arr haline getirir logics içine atar.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Suscces)
                    return logic;
            }
            return null;
        }
    }
}
