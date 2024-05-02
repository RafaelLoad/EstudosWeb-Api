using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
