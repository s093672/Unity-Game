using UnityEngine;
using System.Collections;

public class PickMeSpeeder : MonoBehaviour {
	
	public Texture2D SpeederOn;
	public Texture2D SpeederOff;
	public static bool isOnSpeeder = false;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		
		
		if (!isOnSpeeder) {
			guiTexture.texture = SpeederOff;	
		}
		else {
			guiTexture.texture = SpeederOn;	
		}
		
		
		
		
		if(Input.touchCount > 0)
		{
			
			Touch touch  = Input.touches[0];
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				
			{
				isOnSpeeder = true;
				PickMeBox.isOnBox = false;
				PickMeSlope.isOnSlope = false;
				PickMeDelete.isOnDelete = false;
			}
		}
	}
	
}
