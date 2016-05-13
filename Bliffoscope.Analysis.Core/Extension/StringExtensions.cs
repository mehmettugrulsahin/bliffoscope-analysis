namespace Bliffoscope.Analysis.Core.Extension
{
	public static class StringExtensions
	{
		public static string WithEndingSlash(this string path)
		{
			string lastOneCharacter = path.Substring(path.Length - 1, 1);
			if(lastOneCharacter != "\\")
			{
				return $"{path}\\";
			}
			return path;
		}
	}
}
