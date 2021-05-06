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
        private Type _validatorType;//attribute te type ile geçmek zorundayız

        //defensive coding - savunma odaklı kodlama:
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))                   //gönderilen validatorType bir validator değilse
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;                                            //sorun yoksa gönderilen validatorType benim _validatorType ımdır
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);      //şu an elimde : CarValidator ın bir instance ı var mesela
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];         //CarValidator ın base type ını bul, onun generic argümanlarından ilkini bul
                                                                                       //şu an elimde : car tipi var

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//invocation ın (metodun) argümanlarını (parametrelerini) gez
                                                                                      //eğer oradaki bir tip (1 den fazla olabilir), entityType (car) türünde ise
                                                                                      
            foreach (var entity in entities)                                          //onları validate et
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
