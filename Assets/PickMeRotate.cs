using UnityEngine;
using System.Collections;

public class PickMeRotate : MonoBehaviour {
	
	public Texture2D RotateOff;
	
	
	// Use this for initialization
	void Start () {
		guiTexture.texture = RotateOff;
	}
	
	// Update is called once per frame
	void Update() {

				

		
		
		
		
		if(Input.touchCount > 0)
		{
			
			Touch touch  = Input.touches[0];
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				
			{
				MakeTest.gameStarted = true;

				MakeTest.ball.transform.position = MakeTest.startBallCoor;
				MakeTest.ball.rigidbody.velocity = Vector3.zero;
				MakeTest.ball.rigidbody.angularVelocity = Vector3.zero;


			}
		}
	}
	
}
