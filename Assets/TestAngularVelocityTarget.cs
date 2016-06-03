using UnityEngine;

public class TestAngularVelocityTarget : MonoBehaviour {
	public float power = 1;
	public Vector3 angularVelocity;
	public Vector3 target;

	new Rigidbody rigidbody;

	void Awake() {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.angularDrag = 0;
	}

	void FixedUpdate() {
		angularVelocity = rigidbody.angularVelocity * Mathf.Rad2Deg;
		var delta = target - angularVelocity;

		var torque = Vector3.ClampMagnitude(delta, power);
		rigidbody.AddTorque(torque, ForceMode.Acceleration);
	}

}
