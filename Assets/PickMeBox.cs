using UnityEngine;
using System.Collections;

public class PickMeBox : MonoBehaviour {

	public Texture2D BoxOn;
	public Texture2D BoxOff;
	public static bool isOnBox = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {


		if (!isOnBox) {
			guiTexture.texture = BoxOff;	
		}
		else {
			guiTexture.texture = BoxOn;	
		}


		
		
		if(Input.touchCount > 0)
		{

			Touch touch  = Input.touches[0];
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				
			{
				isOnBox = true;
				PickMeSlope.isOnSlope = false;
				PickMeSpeeder.isOnSpeeder = false;
				PickMeDelete.isOnDelete = false;
			}
		}
	}

}
