using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpGet("[action]")]
        public int Add3(int num1, int num2, int num3) => num1 + num2 + num3;

        [HttpGet("[action]")]
        public MathResult Add4(int num1, int num2, int num3)
        {
            return new MathResult
            {
                Sum = num1 + num2 + num3,
                Average = (num1 + num2 + num3) / 3
            };
        }
    }

    public class MathResult
    {
        public int Sum { get; set; }
        public int Average { get; set; }
    }
}
