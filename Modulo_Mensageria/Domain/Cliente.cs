using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modulo_Mensageria.Domain
{
    [Table("cliente")]
    public class Cliente
    {
        public string cpf { get; set; }

        [Key]
        public int id_cliente { get; set; }
        public string nome_completo { get; set; }
        public DateTime data_nascimento { get; set; }
        public string telefone { get; set; }
        public int id_endereco { get; set; }
        public DateTime data_registro { get; set; }
        public char sexo { get; set; }
    }
}
