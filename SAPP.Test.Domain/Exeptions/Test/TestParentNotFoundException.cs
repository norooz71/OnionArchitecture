using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Test.Domain.Exeptions.Test
{
    public sealed class TestParentNotFoundException : NotFoundException
    {
        public TestParentNotFoundException(int testId) 
            : base($"The Test with Id {testId} not found")
        {

        }
    }
}
