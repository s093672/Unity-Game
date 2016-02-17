using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	private static GameObject lastGameobject;
	private static Vector2 beganPos;
	private static Vector2 endPos;
	private bool objectMade;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0)
		{
			
			Touch touch  = Input.touches[0];



			
			if(touch.phase == TouchPhase.Began)
				
			{




				beganPos =  touch.position;




				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 100)){

					Debug.Log(hit.normal);

					if(PickMeBox.isOnBox && hit.transform.name.Equals("PlatformMesh") && hit.normal.y>0){
						objectMade = true;
						lastGameobject = (GameObject)Instantiate (Resources.Load<GameObject> ("PlatformPrefab"));
						lastGameobject.transform.Translate(hit.transform.position + new Vector3(0,0.5f,0));
						lastGameobject.tag = "tempObject";
						foreach(Transform t in lastGameobject.transform)
						{
							t.gameObject.tag = "tempObject";
						}
				}
					if(PickMeSlope.isOnSlope && hit.transform.name.Equals("PlatformMesh") && hit.normal.y>0){
						objectMade = true;
						lastGameobject = (GameObject)Instantiate (Resources.Load<GameObject> ("SlopePrefab"));
						lastGameobject.transform.Translate(hit.transform.position + new Vector3(0,0.5f,0));




						lastGameobject.tag = "tempObject";
						foreach(Transform t in lastGameobject.transform)
						{
							t.gameObject.tag = "tempObject";
						}
				}
					if(PickMeSpeeder.isOnSpeeder && hit.transform.name.Equals("PlatformMesh") && hit.normal.y>0){
						objectMade = true;
						lastGameobject = (GameObject)Instantiate (Resources.Load<GameObject> ("SpeederPrefab"));
						lastGameobject.transform.Translate(hit.transform.position + new Vector3(0,0.501f,0));
						lastGameobject.tag = "tempObject";
					
				}

					if(PickMeDelete.isOnDelete && hit.transform.tag.Equals("tempObject") && hit.normal.y>0){
						try{
							Destroy(hit.transform.parent.gameObject);}
						catch{
							Destroy(hit.transform.gameObject);
						}
						
					}
				}
			}


			if(objectMade && touch.phase == TouchPhase.Ended){
				objectMade = false;
				endPos = touch.position;

				Vector2 final = new Vector2(endPos.x - beganPos.x,endPos.y - beganPos.y).normalized;

				Debug.Log("This is me: "+Mathf.Round(final.x) +" "+Mathf.Round(final.y)+"  "+ final);

				float tempX = Mathf.Round(final.x);
				float tempY = Mathf.Round(final.y);

				float degree = 0;

				if(tempX>0 && tempY==0){

					degree = 90;

				}else if(tempX<0 && tempY==0){
					degree = 270;
					
				}else if(tempX==0 && tempY<0){
					degree = 180;
					
				}else if(tempX==0 && tempY>0){
					degree = 0;
				

				}

				lastGameobject.transform.RotateAround(lastGameobject.transform.position,Vector3.up,degree-PickMeCam.rot);






			}
		}
	
	}
}
