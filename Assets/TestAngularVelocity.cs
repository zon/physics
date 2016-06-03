using UnityEngine;

public class TestAngularVelocity : MonoBehaviour {
	public float power = 1;

	new Rigidbody rigidbody;
	Vector3 expected = new Vector3();

	void Awake() {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.angularDrag = 0;
	}

	void FixedUpdate() {
		if (!rigidbody.angularVelocity.Approximate(expected))
			throw new System.Exception(rigidbody.angularVelocity + " != " + expected);

		var torque = Vector3.one * power;
		rigidbody.AddTorque(torque, ForceMode.Acceleration);

		expected = rigidbody.angularVelocity + torque * Time.fixedDeltaTime;
	}

}
