using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    //bu Class ta işlem sonucunu default true yapıyoruz
    {
        public SuccessDataResult(T data, string message):base(data, true, message)
        {

        }

        public SuccessDataResult(T data):base(data, true)
        {

        }

        public SuccessDataResult(string message):base(default, true, message)
        {

        }

        public SuccessDataResult():base(default, true)
        {

        }
    }
}
