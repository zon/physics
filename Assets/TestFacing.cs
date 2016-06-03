using UnityEngine;

public class TestFacing : MonoBehaviour {
	public float maxSpeed = 90;
	public Vector3 point;
	public Vector3 target;
	public bool assert;

	new Rigidbody rigidbody;

	void Awake() {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.angularDrag = 0;
	}

	void FixedUpdate() {
		var look = transform.rotation;
		var forward = point - transform.position;
		if (forward != Vector3.zero)
			look = Quaternion.LookRotation(forward, transform.up);
        var rotDelta = look * Quaternion.Inverse(transform.rotation);

		if (assert && transform.rotation * rotDelta != look)
			throw new System.Exception("Incorrect look delta");

		target = rotDelta.eulerAngles.ToNegativeDegrees();

		var avDelta = target - rigidbody.angularVelocity * Mathf.Rad2Deg;

		var torque = new Vector3(
			Mathf.Min(avDelta.x, maxSpeed),
			Mathf.Min(avDelta.y, maxSpeed),
			Mathf.Min(avDelta.z, maxSpeed)
		);
		rigidbody.AddTorque(torque, ForceMode.Acceleration);

		Debug.DrawLine(transform.position, point, Color.green, 0, false);
		Debug.DrawLine(transform.position, transform.position + transform.forward, Color.blue, 0, false);
	}

}
