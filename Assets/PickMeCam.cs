using UnityEngine;
using System.Collections;

public class PickMeCam : MonoBehaviour {

	public static int rot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0)
		{
			
			Touch touch  = Input.touches[0];
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				
			{
				Camera.main.transform.RotateAround(Vector3.zero,Vector3.up,-90.0f);
				rot+=90;

			}
		}
	
	}
}
