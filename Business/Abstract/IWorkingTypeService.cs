using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWorkingTypeService
    {
        IResult Add(WorkingType workingType);
        IResult Update(WorkingType workingType);
        IResult Delete(WorkingType workingType);
        IDataResult<List<WorkingType>> GetAll();
    }
}
