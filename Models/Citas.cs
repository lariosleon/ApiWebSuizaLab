using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Citas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idcita { get; set; }

        public int? Idpaciente { get; set; }

        public int? Idespecialidad { get; set; }

        public DateTime? Fechacita { get; set; }

        [ForeignKey("Idpaciente")]
        public virtual Paciente? Paciente { get; set; }

        [ForeignKey("Idespecialidad")]
        public virtual Especialidad? Especialidad { get; set; }
        //public virtual ICollection<Paciente>? PacienteCollection { get; set; }
        //public virtual ICollection<Especialidad>? EspecialidadCollection { get; set; }
    }
}
