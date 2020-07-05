namespace Escolar2020.Web.Data.Entity.Catalogos
{
    using System.ComponentModel.DataAnnotations;
    public class App_c_Seccion : IEntity
    {
        public int Id { get; set; }
        public int Seccion_Id { get; set; }

        [Display(Name = "Nivel Escolar")]
        public string Seccion { get; set; }
        public int Orden { get; set; }
    }
}
