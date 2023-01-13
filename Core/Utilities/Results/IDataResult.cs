using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        // IDATAREsult yapı yaparsak hem datayı döndüğrüpü hem de sonuç mesajını döndüren generic yapı oluşturabiliriz. Böylelikle GetAll sınıfı List<DailyRecord> sorununu hallederiz.
        T Data { get; }
    }
}
