using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angsoz.GerenciamentoAmigosAniversario.Web.Models;

namespace Angsoz.GerenciamentoAmigosAniversario.Web.Models
{
    public class Pessoa : Entidade
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} tem que ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} tem que ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "É amigo ou familiar?")]
        public AmigoOuFamiliar AmigoOuFamiliar { get; set; }

        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }

        [Display( Name = "Te deu presente?")]
        public bool TeDeuPresente { get; set; }

        //Relação EF (1 p/ ...n presentes)
        public IEnumerable<Presente> Presentes { get; set; }

        


    }





}
