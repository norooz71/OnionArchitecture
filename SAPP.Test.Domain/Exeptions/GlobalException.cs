using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SAPP.Test.Domain.Exeptions
{
    public class GlobalException : Exception
    {
        private readonly ExceptionLevel Level;

        private readonly ExceptionType Type;

        public GlobalException(ExceptionLevel level, ExceptionType type, string message) : base(message)
        {
            Level = level;
            Type = type;
        }

    }
}
