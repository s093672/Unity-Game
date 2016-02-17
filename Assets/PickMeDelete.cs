using UnityEngine;
using System.Collections;

public class PickMeDelete : MonoBehaviour {
	
	public Texture2D DeleteOn;
	public Texture2D DeleteOff;
	public static bool isOnDelete = false;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		
		
		if (!isOnDelete) {
			guiTexture.texture = DeleteOff;	
		}
		else {
			guiTexture.texture = DeleteOn;	
		}
		
		
		
		
		if(Input.touchCount > 0)
		{
			
			Touch touch  = Input.touches[0];
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				
			{
				isOnDelete = true;
				PickMeBox.isOnBox = false;
				PickMeSlope.isOnSlope = false;
				PickMeSpeeder.isOnSpeeder = false;
			}
		}
	}
	
}
