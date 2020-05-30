namespace Escolar2020.Web.Data.Entity.Catalogos
{
    using System.ComponentModel.DataAnnotations;
    public class App_c_Conceptos : IEntity
    {
        public int Id { get; set; }
        public int Concepto_Id { get; set; }
        public string Clave { get; set; }
        public string Concepto { get; set; }
    }
}
