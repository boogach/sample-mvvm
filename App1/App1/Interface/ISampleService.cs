using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Interface
{
    public interface ISampleService
    {
        Task<SampleModel> GetSomeDummyData(Dictionary<string, string> parameters);
        string SomeDummyString(string btnText);
    }
}
