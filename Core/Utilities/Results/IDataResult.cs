using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //includes success info,message and in addition data
    public interface IDataResult<T>:IResult//implement IResult interface
    {
        T Data { get; }
    }
}
