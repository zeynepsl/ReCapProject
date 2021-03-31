using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<List<Color>> GetColorsByColorId(int id);
        IResult Add(Color color);
        public void Delete(Color color);
        IResult Update(Color color);
    }
}
