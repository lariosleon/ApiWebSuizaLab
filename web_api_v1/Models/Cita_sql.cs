namespace web_api_v1.Models
{
    public class Cita_sql
    {
        public int Idcita { get; set; }

        public string? Paciente { get; set; }
        public string? Especialidad { get; set; }

        public DateTime? FechaCita { get; set; }
    }
}
