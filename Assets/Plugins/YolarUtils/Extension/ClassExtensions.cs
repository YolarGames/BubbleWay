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

		public static Vector3 OffsetX(this Vector3 vector, float x) =>
			new(vector.x + x, vector.y, vector.z);

		public static Vector3 OffsetY(this Vector3 vector, float y) =>
			new(vector.x, vector.y + y, vector.z);

		public static Vector3 OffsetZ(this Vector3 vector, float z) =>
			new(vector.x, vector.y, vector.z + z);

		public static Vector3 SetX(this Vector3 vector, float x) =>
			new(x, vector.y, vector.z);

		public static Vector3 SetY(this Vector3 vector, float y) =>
			new(vector.x, y, vector.z);

		public static Vector3 SetZ(this Vector3 vector, float z) =>
			new(vector.x, vector.y, z);

		public static Vector2 OffsetX(this Vector2 vector, float x) =>
			new(vector.x + x, vector.y);

		public static Vector2 OffsetY(this Vector2 vector, float y) =>
			new(vector.x, vector.y + y);

		public static Vector2 SetX(this Vector2 vector, float x) =>
			new(x, vector.y);

		public static Vector2 SetY(this Vector2 vector, float y) =>
			new(vector.x, y);
	}
}