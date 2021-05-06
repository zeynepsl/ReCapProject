using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    //Token üretimi gerçekleştirecek
    //interface ile belirttik çünkü yarın bir gün jwt kullanılmayabilir,başka bir tekniğe geçilebilir
    public interface ITokenHelper
    {
        //Token Üretme:
        //ihityacım olan şey user, o da bu user bilgisine göre token üretecek
        //kullanıcının rollerinin de token a eklenmesini istiyorum

        //kullanıcı bilgisi ve roller
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
