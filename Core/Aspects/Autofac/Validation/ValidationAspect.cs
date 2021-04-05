using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    //bu bir attribute
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        //bana validatorType ı ver
        //attribute te type ile geçmek zorundayız
        public ValidationAspect(Type validatorType)
        {
            //gönderilen validatorType bir validator değilse
            //abstarctValidator bir IValidator dı ya
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
            //sorun yoksa gönderilen validatorType benim _validatorType ımdır
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
                //ValidationTool u CarManager dan sildik ama merkezi bir noktaya aldık
            }
        }
    }
}
