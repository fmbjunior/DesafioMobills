using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMobills.WebApi.Entidades
{
    public class Receita
    {
        public int Id { get; set; }
        [Required]
        public int Id_Conta { get; set; }
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public bool Recebido { get; set; }
    }
}
