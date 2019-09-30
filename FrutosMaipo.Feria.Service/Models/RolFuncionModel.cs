using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Infrastructure.Interfaces
{
    public class RolFuncionModel
    {
        public long IdRole { get; set; }
        public string DescriptionRole { get; set; }
        public List<FuncionModel> Funciones { get; set; }
    }
}
