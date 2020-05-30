namespace Escolar2020.Web.Data.Entity.Notification
{

    public class App_Notification_HomeWork
    {
        public int Id_HomeWork { get; set; }  
        //Id Encabezado Data
        public int Id_Data { get; set; }
        //Id Encabezado Respuesta
        public int Id_Respond { get; set; }
        //Archivo Return
        public string FileUrl { get; set; }
        public string FileFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.FileUrl))
                {
                    return null;
                }
                return $"http://www.gissa.com.mx{this.FileUrl.Substring(1)}";
            }
        }

    }
}
