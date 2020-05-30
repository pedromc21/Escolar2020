namespace Escolar2020.Web.Data.Entity.Pagos
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class App_Pagos
    {
        [Required]
        public int LaveRef_Id { get; set; }
        [Required]
        public string Folio { get; set; }
        [Required]
        public string Factura { get; set; }
        [Required]
        public int Renglon { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [DisplayName("Concepto Pagado")]
        public string ConceptoPagado { get; set; }
        //__________________________________
        [Required]
        [DisplayName("Abono")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Abono { get; set; }

        [Required]
        [DisplayName("Descuento")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Descuento { get; set; }

        [Required]
        [DisplayName("Importe")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Importe { get { return this.Abono - this.Descuento; } }

        [Required]
        [DisplayName("Recargo")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Recargo { get; set; }

        [Required]
        [DisplayName("Comision")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Comision { get; set; }

        [Required]
        [DisplayName("Pago")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Pago { get; set; }
        //__________________________________
        [Required]
        [Display(Name = "Fecha Pago")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Fecha_Pago { get; set; }

        [Required]
        [Display(Name = "Metodo de Pago")]
        [MaxLength(150, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        public string MetodoPago { get; set; }

        [Required]
        [Display(Name = "Referencia del Pago")]
        [MaxLength(150, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        public string ReferenciaPago { get; set; }

    }
}
