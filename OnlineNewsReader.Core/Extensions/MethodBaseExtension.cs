using System.Reflection;

namespace OnlineNewsReader.Core.Extensions
{
	public static class MethodBaseExtension
    {
		public static string FullName(this MethodBase currentMethod)
		{
			string fullName = null;

			if (currentMethod != null && !string.IsNullOrWhiteSpace(currentMethod.Name) && currentMethod.DeclaringType != null && !string.IsNullOrWhiteSpace(currentMethod.DeclaringType.Name) && !string.IsNullOrWhiteSpace(currentMethod.DeclaringType.Namespace))
			{
				fullName = string.Format("{0}.{1}.{2}", currentMethod.Name, currentMethod.DeclaringType.Name, currentMethod.DeclaringType.Namespace);
			}

			return fullName;
		}
	}
}
