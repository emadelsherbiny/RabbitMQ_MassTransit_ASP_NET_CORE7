using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitmqDotNetMass.Common.DTO
{
    public class BalanceUpdateDTO
    {
        public string Instruction { get; set; }
        public decimal Amount { get; set; }
    }
}
