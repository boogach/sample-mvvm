using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Interface
{
    public interface ISampleService
    {
        Task<string> GetSomeDummyData();
        string SomeDummyString();
    }
}
