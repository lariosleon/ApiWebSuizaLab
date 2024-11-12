using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idpaciente { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? NombreCompleto { get; set; }

        public int? Idtipodocumento { get; set; }

        [ForeignKey("Idtipodocumento")]
        public virtual TipoDocumento? TipoDocumento { get; set; }
    }
}
