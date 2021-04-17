using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IDataResult<List<OperationClaim>> GetAll();
        IDataResult<OperationClaim> GetByName(string name);
    }
}
