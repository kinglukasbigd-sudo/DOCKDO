using System.Globalization;
using UnityEngine;
public class PreciseLocale
{
	public static string GetRegion()
	{
		string n = CultureInfo.CurrentCulture.Name;
		if (n.Length >= 5 && n[2] == '-') return n.Substring(3, 2).ToUpper();
		switch (Application.systemLanguage)
		{
			case SystemLanguage.Korean: return "KR";
			case SystemLanguage.Japanese: return "JP";
			case SystemLanguage.Chinese: return "CN";
			case SystemLanguage.German: return "DE";
			case SystemLanguage.French: return "FR";
			case SystemLanguage.Spanish: return "ES";
			case SystemLanguage.Russian: return "RU";
			default: return "US";
		}
	}
	public static string GetLanguageID() { return CultureInfo.CurrentCulture.TwoLetterISOLanguageName; }
	public static string GetLanguage() { return Application.systemLanguage.ToString(); }
	public static string GetCurrencyCode() { return GetRegion() == "KR" ? "KRW" : "USD"; }
	public static string GetCurrencySymbol() { return GetRegion() == "KR" ? "\u20a9" : "$"; }
}
