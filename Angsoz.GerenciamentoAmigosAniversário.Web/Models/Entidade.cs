using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angsoz.GerenciamentoAmigosAniversario.Web.Models
{
    public abstract class Entidade
    {
       
        [Key]
        public int Id { get; set; }
    }
}
