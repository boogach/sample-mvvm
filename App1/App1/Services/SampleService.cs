using App1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public class SampleService : ISampleService
    {
        public Task<string> GetSomeDummyData()
        {
            throw new NotImplementedException();
        }

        public string SomeDummyString()
        {
            throw new NotImplementedException();
        }
    }
}
