using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using FluentValidation;
using Framework.CrossCuttingConcerns.Validation.FluentValidation;
using Framework.Utilities.Interceptors.Autofac;
using Framework.Utilities.Messages;

namespace Framework.Aspects.Autofac.Validation
{
   public class ValidationAspect:MethodInterception
   {
       private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // doğru class göndermiş mi
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;// doğruysa buna ata
        }

        //Validationda bunu dolduruyoruz onbeforeda çalıır çünkü
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator) Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];// productı bulur.
            //invocation metod demek.
            // Aşağıdaki kod metoda git parametrelerini yakala.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);

            }
        }
    }
}
