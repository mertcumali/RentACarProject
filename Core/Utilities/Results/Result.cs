using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success,string message):this(success)//with message success info
        {
            Message = message;
        }
        public Result(bool success)//just success info
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
