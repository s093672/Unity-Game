using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Time used: "+Mathf.RoundToInt (time).ToString();

		if (!MakeTest.gameStarted) {
						time = 0.0f;		
				} else {
			time += Time.deltaTime;

					
				}
	}
}
