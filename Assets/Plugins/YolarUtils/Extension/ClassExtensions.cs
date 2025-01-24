using UnityEngine;

namespace YolarUtils.Extension
{
	public static class ClassExtensions
	{
		public static bool IsNull(this Object obj)
		{
			return !obj;
		}

		public static bool NotNull(this Object obj)
		{
			return obj;
		}

		public static bool IsNull(this object obj)
		{
			return obj == null;
		}

		public static bool NotNull(this object obj)
		{
			return obj != null;
		}
	}
}