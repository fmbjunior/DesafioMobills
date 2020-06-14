using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMobills.WebApi.Entidades
{
    public class Conta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Despesa> Despesas { get; set; }
        public List<Receita> Receitas { get; set; }
        public decimal Saldo { get; set; }
        public decimal SomaDespesas { get; set; }
        public decimal SomaReceitas { get; set; }
    }
}
