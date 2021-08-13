using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEPAPI5.Models
{
    public class Cep
    {
        public static bool validar (string cep)
        {
            if (cep.Length < 8 || cep.Length > 9)
                return false;
            return true;
        }
    }
}
