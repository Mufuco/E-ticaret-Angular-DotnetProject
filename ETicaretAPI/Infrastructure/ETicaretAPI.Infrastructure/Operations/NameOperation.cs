using System;
namespace ETicaretAPI.Infrastructure.Operations
{
	public static class NameOperation
	{
		public static string CharacterRequlatory(string name)
            =>
        
			name.Replace(" ", "-").Replace("ğ", "g").Replace("ı", "i").Replace("ö", "o")
            .Replace("ü", "u").Replace("ş", "s").Replace("ç", "c").Replace("Ç", "c")
            .Replace("Ş", "s").Replace("Ğ", "g").Replace("Ü", "u").Replace("İ", "i")
            .Replace("Ö", "o").Trim().Replace("!","").Replace("/", "").Replace("/", "").Replace("'", "")
            .Replace("!", "").Replace("?", "").Replace("-", "").Replace("=", "").Replace("@", "").Replace(",", "")
            .Replace(";", "").Replace(":", "").Replace("(", "").Replace(")", "").Replace("%", "")
            .Replace("&", "").Replace("-", "").Replace("_", "").Replace("<", "").Replace(">", "");
        
	}
}

