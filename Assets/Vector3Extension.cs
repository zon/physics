using UnityEngine;

public static class Vector3Extension {

	public static bool Approximate(this Vector3 self, Vector3 other) {
		return (
			Mathf.Approximately(self.x, other.x) &&
			Mathf.Approximately(self.y, other.y) &&
			Mathf.Approximately(self.z, other.z)
		);
	}

	public static Vector3 ToNegativeDegrees(this Vector3 v) {
		return new Vector3(
			ToNegativeDegrees(v.x),
			ToNegativeDegrees(v.y),
			ToNegativeDegrees(v.z)
		);
	}

	static float ToNegativeDegrees(float a) {
		a = a % 360;
		return a > 180 ? a - 360 : a; 
	}

}
