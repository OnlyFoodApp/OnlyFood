using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IResult<T>
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }

        T Data { get; set; }

        //List<ValidationResult> ValidationErrors { get; set; }

        Exception Exception { get; set; }

        int Code { get; set; }
    }
}
