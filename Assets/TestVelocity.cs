using UnityEngine;

public class TestVelocity : MonoBehaviour {
	public float power = 1;

	new Rigidbody rigidbody;
	Vector3 expected = new Vector3();

	void Awake() {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.drag = 0;
	}

	void FixedUpdate() {
		if (rigidbody.velocity != expected)
			throw new System.Exception(rigidbody.velocity + " != " + expected);

		var force = Vector3.up * power;
		rigidbody.AddForce(force);

		expected = rigidbody.velocity + force * Time.fixedDeltaTime;
	}

}
