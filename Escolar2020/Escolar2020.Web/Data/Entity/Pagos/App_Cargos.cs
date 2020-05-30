namespace Escolar2020.Web.Data.Entity.Pagos
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class App_Cargos
    {
        [Required]
        public int LaveRef_Id { get; set; }
        [Required]
        public int Ciclo_Id { get; set; }
        [Required]
        public int Persona_Id { get; set; }
        [Required]
        public int Plantel_Id { get; set; }
        [Required]
        public int Concepto_Id { get; set; }
        [Required]
        public int Mes_Id { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        public string Concepto { get; set; }
        //__________________________________
        [Required]
        [DisplayName("Precio")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [Required]
        [DisplayName("Pagado")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Abono { get; set; }

        [Required]
        [DisplayName("Saldo")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }
        //__________________________________
        [Display(Name = "Fecha Vencimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? Fecha_Vencimiento { get; set; }

    }
}
