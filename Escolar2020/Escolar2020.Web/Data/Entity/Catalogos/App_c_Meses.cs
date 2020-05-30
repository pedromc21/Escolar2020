namespace Escolar2020.Web.Data.Entity.Catalogos
{
    using System.ComponentModel.DataAnnotations;
    public class App_c_Meses : IEntity
    {
        public int Id { get; set; }
        public int Mes_Id { get; set; }
        public string Mes { get; set; }
        [Display(Name = "Orden Escolar")]
        public int Orden_Esc { get; set; }
        public int Orden { get; set; }
    }
}
