namespace Escolar2020.UIForms.Infrastructure
{
    using ViewModels;
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }
        public InstanceLocator()
        {
            this.Main = new MainViewModel(); 
        }
    }
}
