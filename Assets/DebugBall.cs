using UnityEngine;
using System.Collections;

public class DebugBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce (Vector3.up/100);

	
	}
}
