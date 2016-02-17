using UnityEngine;
using System.Collections;

public class PickMeSlope : MonoBehaviour {
	
	public Texture2D SlopeOn;
	public Texture2D SlopeOff;
	public static bool isOnSlope = false;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		
		
		if (!isOnSlope) {
			guiTexture.texture = SlopeOff;	
		}
		else {
			guiTexture.texture = SlopeOn;	
		}
		
		
		
		
		if(Input.touchCount > 0)
		{
			
			Touch touch  = Input.touches[0];
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				
			{
				isOnSlope = true;
				PickMeBox.isOnBox = false;
				PickMeSpeeder.isOnSpeeder = false;
				PickMeDelete.isOnDelete = false;
			}
		}
	}
	
}
