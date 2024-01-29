using System.ComponentModel.DataAnnotations;

namespace ApiIntelligenceEnergy.Models
{
    public class ClientModel
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        [Required]
        public string Telefone { get; set; }
        [MinLength(2), MaxLength(2)]
        public string Uf { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public int NEndereco { get; set; }
        [Required]
        public string Cep { get; set; }

        public ClientModel(string nome, string cnpj, DateTime dataCadastro, string telefone, string uf, string cidade, string bairro, string rua, int nEndereco, string cep)
        {

            Nome = nome;
            Cnpj = cnpj;
            DataCadastro = dataCadastro;
            Telefone = telefone;
            Uf = uf;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            NEndereco = nEndereco;
            Cep = cep;
        }


    }
}