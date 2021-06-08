using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angsoz.GerenciamentoAmigosAniversario.Web.Models
{
    public class PessoasViewModel
    {
        public List<Pessoa> Pessoas { get; set; }
        public string SearchString { get; set; }

    }
}
