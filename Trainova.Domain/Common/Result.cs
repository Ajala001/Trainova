using System;
using System.Collections.Generic;
using System.Text;

namespace Trainova.Domain.Common
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string Error { get; private set; }

        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, string.Empty);
        public static Result Failure(string error) => new Result(false, error);
    }
}
