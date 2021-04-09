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

        //defensive coding - savunma odaklı
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
            //şu an elimde : CarValidator ın bir instance ı var 

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //CarValidator ın base type ını bul, onun generic argümanlarından ilkini bul
            //şu an elimde : car tipi var

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}











//invocation ın (metodun) argümanlarını (parametrelerini) gez
//eğer oradaki bir tip (1 den fazla olabilir), entityType (product) türünde ise
//onları validate et


//ValidationTool u CarManager dan sildik ama merkezi bir noktaya aldık
