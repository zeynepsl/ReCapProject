using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //Bu iş kurallarımı nasıl gönderebilirim
        //params verdiğimde istediğim kadar (virgülle ayırarak) IResult verebilirim
        //gönderdiğim bütün parametreler c# tarafından array haline getirilir logics e atanır
        
        //parametre ile gönderilen iş kurallarından başarısız olanı Business katmanına haber liyoruz
        public static IResult Run(params IResult[] logics)
        {
            foreach(var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
