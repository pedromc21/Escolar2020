namespace Escolar2020.UIForms.Interfaces
{
	using System.Globalization;
	public interface ILocalize
	{
		CultureInfo GetCurrentCultureInfo();

		void SetLocale(CultureInfo ci);
	}

}
