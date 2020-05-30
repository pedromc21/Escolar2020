
namespace Escolar2020.Web.Data.Entity.Pagos
{
    using System.ComponentModel.DataAnnotations;
    public class App_DatosFacturacion
    {
        [Required]
        public int TipoFac_Id { get; set; }

        [Required]
        public int Persona_Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Facturar A")]
        public string FacturarA { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [MaxLength(200)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo de Facturación")]
        public string Email_fac { get; set; }
    }
}
