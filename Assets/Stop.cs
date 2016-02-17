using UnityEngine;
using System.Collections;

public class Stop : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (other.tag.Equals ("Player")) {
			float vecx = transform.position.x;
			float vecz = transform.position.z;
			float vecy = other.transform.position.y;
			other.transform.position = transform.position;
			other.rigidbody.velocity = Vector3.zero;
			
			MakeTest.nextMap = true;
			MakeTest.gameStarted = false;
			
		}
	}
	
	
	
}
