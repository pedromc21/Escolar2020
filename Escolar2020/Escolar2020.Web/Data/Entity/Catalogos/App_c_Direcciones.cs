namespace Escolar2020.Web.Data.Entity.Catalogos
{
    using System.ComponentModel.DataAnnotations;
    public class App_c_Direccion : IEntity
    {
        public int Id { get; set; }
        public int Direccion_Id { get; set; }
        public string Codigo_Postal { get; set; }
        public int Asentamiento_Id { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public string EntreCalles { get; set; }
        public int IdMunicipio { get; set; }
        public string Municipio { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public string v_Lat { get; set; }
        public string v_Lng { get; set; }
    }
}
