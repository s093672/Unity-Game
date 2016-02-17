using UnityEngine;
using System.Collections;

public class Speeder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}





		void OnTriggerStay(Collider other) {
		if (other.tag.Equals ("Player")) {
			Debug.Log("Stay");

			other.rigidbody.velocity = Vector3.zero;
			other.rigidbody.angularVelocity = Vector3.zero;
			//other.rigidbody.velocity = transform.forward*10;
			other.rigidbody.AddForce(transform.forward*10,ForceMode.Impulse);
				}
		}
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("Player")) {
			Debug.Log("Enter");

			other.rigidbody.velocity = Vector3.zero;
			other.rigidbody.angularVelocity = Vector3.zero;
			other.transform.position = transform.position;
			other.rigidbody.AddForce(transform.forward*10,ForceMode.Impulse);
		}
	}
	


}
