using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //Bu iş kuralları mı nasıl gönderebilirim
        //params verdiğinde istediğin kadar (virgülle ayırarak) IResult verebilirsin
        //gönderdiğin bütün parametreler c# by array haline getirilir logics e atar
        //parametre ile gönderilen iş kurallarından
        //başarısız olanı business a haber liyoruz

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
