using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class OperationClaimValidator:AbstractValidator<OperationClaim>
    {
        public OperationClaimValidator()
        {
            RuleFor(operationC => operationC.Name).NotEmpty();
            RuleFor(operationC => operationC.Name).MinimumLength(3);
        }
    }
}
