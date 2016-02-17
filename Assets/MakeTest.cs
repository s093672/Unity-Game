using UnityEngine;
using System.Collections;

public class MakeTest : MonoBehaviour {

	private static int layers = 5;
	private static int rows = 7;
	private static int cols = 7;
	private static int level = 0;
	public static Vector3 startBallCoor = new Vector3(0,5,-3);
	private static Vector3 startCoor = new Vector3(1,3,0);
	private static Vector3 currentCoor;
	private static int currentDir = 0;
	public static bool nextMap = true;
	private static bool fail;
	public static GameObject ball;
	public static bool gameStarted = false;


	private static string[,,] map = new string[layers,rows,cols];
	private static string[,,] tempMap = new string[layers,rows,cols];

	private GameObject[] mapExist;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag("Player");
		for (int i = 0; i<layers; i++) {
						for (int j = 0; j<rows; j++) {
								for (int k = 0; k<cols; k++) {
					map[i,j,k] = "0";
								}
						}
				}

		map [1, 1, 3] = "occupied";
		map [2, 1, 3] = "occupied";
		map [3, 1, 3] = "occupied";
		map [4, 1, 3] = "occupied";

		currentCoor = startCoor;


	}
	
	// Update is called once per frame
	void Update () {


		if (!gameStarted) {
			ball.transform.position = startBallCoor;
			ball.rigidbody.velocity = Vector3.zero;
			ball.rigidbody.angularVelocity = Vector3.zero;
		}



		if(nextMap){
			nextMap = false;

			currentCoor = startCoor;
			for (int i = 0; i<layers; i++) {
				for (int j = 0; j<rows; j++) {
					for (int k = 0; k<cols; k++) {
						map[i,j,k] = "0";
						tempMap[i,j,k] = "0";
					}
				}
			}

			map [1, 1, 3] = "occupied";
			map [2, 1, 3] = "occupied";
			map [3, 1, 3] = "occupied";
			map [4, 1, 3] = "occupied";
			tempMap [1, 1, 3] = "occupied";
			tempMap [2, 1, 3] = "occupied";
			tempMap [3, 1, 3] = "occupied";
			tempMap [4, 1, 3] = "occupied";
			
			mapExist = GameObject.FindGameObjectsWithTag("mapObject");
					
					foreach (GameObject mapObject in mapExist) {
						Destroy(mapObject);
					}
					
					mapExist = GameObject.FindGameObjectsWithTag("tempObject");
					
					foreach (GameObject mapObject in mapExist) {
						Destroy(mapObject);
					}


				MakeTestMap();




			MakeMap();


			ball.transform.position = startBallCoor;
			ball.rigidbody.velocity = Vector3.zero;
			ball.rigidbody.angularVelocity = Vector3.zero;
		}
	
	}


	void MakeMap(){

		//Dimension of the map/world
		int layer = map.GetLength (0)-1;
		int dir = 0;

		for (int i = 0; i<layers; i++) {
			for (int j = 0; j<rows; j++) {
				for (int k = 0; k<cols; k++) {

					if(map [i, j, k]==null){
						map [i, j, k] = "0";
					}

					int r = Random.Range(1,2);

					if(i==0){
						GameObject platform = (GameObject)Instantiate (Resources.Load<GameObject> ("PlatformPrefab"));
						platform.transform.position = new Vector3 (j-rows/2, i*0.5f, k-cols/2);

					}
					else{


						
						char temp = map[i,j,k][0];
						if(map[i,j,k].Length>1){
							dir = (int) map[i,j,k][1];
						}

					switch (temp){
						
					case '0':
						//Empty element
						break;
					case '1':
						//Platform
						GameObject platform = (GameObject)Instantiate (Resources.Load<GameObject> ("PlatformPrefab"));
						platform.transform.position = new Vector3 (j-rows/2, i*0.5f, k-cols/2);
						break;
					case '2':
						//Slope


							
							
							if(r == 1 ){
								
							}
							
							else{

						GameObject slope = (GameObject)Instantiate (Resources.Load<GameObject> ("SlopePrefab"));
						slope.transform.position = new Vector3 (j-rows/2, i*0.5f, k-cols/2);
						slope.transform.RotateAround(slope.transform.position,Vector3.up,dir*90);
							}
						break;
					case '3':
						//Speeder

							
							
							if(r == 1 ){
								
							}
							
							else{
						GameObject speeder = (GameObject)Instantiate (Resources.Load<GameObject> ("SpeederPrefab"));
						speeder.transform.position = new Vector3 (j-rows/2, i*0.501f, k-cols/2);
						speeder.transform.RotateAround(speeder.transform.position,Vector3.up,dir*90);
							}
						break;
					case '5':
						//Stop
						GameObject stop = (GameObject)Instantiate (Resources.Load<GameObject> ("StopPrefab"));
						stop.transform.position = new Vector3 (j-rows/2, i*0.501f, k-cols/2);
						break;
					}
					}

				}
			}
		}
	}


	void MakeJump(Vector3 coor,int dir){

		//x = layer
		int x = (int) coor.x;
		int y = (int) coor.y;
		int z = (int) coor.z;

		map [x+1,y,z] = "3"+dir.ToString();
		currentDir = dir;
		switch (dir%4) {
		case 0:

			for(int i = 0;i<5;i++){

				if(!map [x,y,z+i].Equals("0")){
					fail = true;
					break;
				}else{
					if(i == 2 || i == 3) {map [x+1,y,z+i] = "occupied"; map [x+2,y,z+i] = "occupied";map [x,y,z+i] = "occupied";continue;}
				map [x,y,z+i] = "1";
				
				map [x+1,y,z+i] = "occupied";
			}
			}
			if(map[x,y,z+5].Equals("0")){
				currentCoor = new Vector3(x,y,z+5);
			}

			
			break;
		case 1:
			for(int i = 0;i<5;i++){
				if(!map [x,y+i,z].Equals("0")){
					fail = true;
					break;
				}else{
					if(i == 2 || i == 3) {map [x+1,y+i,z] = "occupied";map [x+2,y+i,z] = "occupied";map [x,y+i,z] = "occupied"; continue;}
				map [x,y+i,z] = "1";
				map [x+1,y+i,z] = "occupied";
			}
			}
			if(map[x,y+5,z].Equals("0")){
				currentCoor = new Vector3(x,y+5,z);
			}

			break;
		case 2:
			for(int i = 0;i<5;i++){
					if(!map [x,y,z-i].Equals("0")){
						fail = true;
						break;
					}else{
					if(i == 2 || i == 3) {map [x+1,y,z-i] = "occupied";map [x+2,y,z-i] = "occupied";map [x,y,z-i] = "occupied";continue;}
				map [x,y,z-i] = "1";
				
				map [x+1,y,z-i] = "occupied";
			}
				}
			if(map[x,y,z-5].Equals("0")){
				currentCoor = new Vector3(x,y,z-5);
			}

				
			break;
		case 3:
			for(int i = 0;i<5;i++){
						if(!map [x,y-i,z].Equals("0")){
							fail = true;
							break;
						}else{
					if(i == 2 || i == 3) {map [x+1,y-i,z] = "occupied";map [x+2,y-i,z] = "occupied";map [x,y-i,z] = "occupied";continue;}
				map [x,y-i,z] = "1";
				
				map [x+1,y-i,z] = "occupied";
			}
				}
			if(map[x,y-5,z].Equals("0")){
				currentCoor = new Vector3(x,y-5,z);
			}


			break;

		}
	}

	void MakeStairs(Vector3 coor,int dir){
		
		//x = layer
		int x = (int) coor.x;
		int y = (int) coor.y;
		int z = (int) coor.z;

		if(!map [x,y,z].Equals("0")){
			fail = true;
		}else{
		map [x,y,z] = "1";
		map [x+1,y,z] = "3"+dir.ToString();
		map [x+2,y,z] = "ocuppied";
		currentDir = dir;
		switch (dir%4) {
		case 1:
				if(!map [x,y,z+1].Equals("0")){
					fail = true;
					break;
				}else{
			map [x,y,z+1] = "1";
			map [x+1,y,z+1] = "2"+dir.ToString();
			map [x+2,y,z+1] = "ocuppied";
					if(map[x+1,y,z+2].Equals("0")){
						currentCoor = new Vector3(x+1,y,z+2);
					}
			break;
				}
		case 0:
				if(!map [x,y+1,z].Equals("0")){
					fail = true;
					break;
				}else{
			map [x,y+1,z] = "1";
			map [x+1,y+1,z] = "2"+dir.ToString();
			map [x+2,y+1,z] = "ocuppied";
					if(map[x+1,y+2,z].Equals("0")){
						currentCoor = new Vector3(x+1,y+2,z);
					}

			break;
				}
		case 3:
				if(!map [x,y,z-1].Equals("0")){
					fail = true;
					break;
				}else{
			map [x,y,z-1] = "1";
			map [x+1,y,z-1] = "2"+dir.ToString();
			map [x+2,y,z-1] = "ocuppied";
					if(map[x+1,y,z-2].Equals("0")){
						currentCoor = new Vector3(x+1,y,z-2);
					}
			
			break;
				}
		case 2:
				if(!map [x,y-1,z].Equals("0")){
					fail = true;
					break;
				}else{
			map [x,y-1,z] = "1";
			map [x+1,y-1,z] = "2"+dir.ToString();
			map [x+2,y-1,z] = "ocuppied";
					if(map[x+1,y-2,z].Equals("0")){
						currentCoor = new Vector3(x+1,y-2,z);
					}
			break;
				}
			}
		}
	}

	void MakeRoad(Vector3 coor,int dir,int length){
		
		//x = layer
		int x = (int) coor.x;
		int y = (int) coor.y;
		int z = (int) coor.z;

		//map [x+1,y,z] = "3"+dir.ToString();
		currentDir = dir;
		switch (dir%4) {
		case 0:
			for(int i = 0;i<length;i++){
				if(!map [x,y,z+i].Equals("0")){
					fail = true;
					break;
				}else{
				map [x,y,z+i] = "1";
				map [x+1,y,z+i] = "ocuppied";


					if(map[x,y,z+i+1].Equals("0")){
						currentCoor = new Vector3(x,y,z+i+1);
					}
					fail = false;

				}
			}
			break;
		case 1:
			for(int i = 0;i<length;i++){
				if(!map [x,y+i,z].Equals("0")){
					fail = true;
					break;
				}else{
				map [x,y+i,z] = "1";
				map [x+1,y+i,z] = "ocuppied";
					if(map[x,y+i+1,z].Equals("0")){
						currentCoor = new Vector3(x,y+i+1,z);
					}
					fail = false;
				}
			}
			break;
		case 2:
			for(int i = 0;i<length;i++){
				if(!map [x,y,z-i].Equals("0")){
					fail = true;
					break;
				}else{
				map [x,y,z-i] = "1";
				map [x+1,y,z-i] = "ocuppied";
					if(map[x,y,z-i-1].Equals("0")){
						currentCoor = new Vector3(x,y,z-i-1);
					}
					fail = false;
				}
			}
			break;
		case 3:
			for(int i = 0;i<length;i++){
				if(!map [x,y-i,z].Equals("0")){
					fail = true;
					break;
				}else{
				map [x,y-i,z] = "1";
				map [x+1,y-i,z] = "ocuppied";
					if(map[x,y-i-1,z].Equals("0")){
						currentCoor = new Vector3(x,y-i-1,z);
					}
					fail = false;
				}
			}
			break;
		}

	}

	void MakeFinish(Vector3 coor){
		//x = layer
		int x = (int) coor.x;
		int y = (int) coor.y;
		int z = (int) coor.z;
		map [x,y,z] = "1";
		map [x+1, y, z] = "5";


			

	}

	void MakeTestMap(){
		int times = 0;

		System.Array.Copy(map, tempMap, map.Length);
		Vector3 tempCoor = currentCoor;
		int tempDir = currentDir;

		

		

		for (int i = 0; i<25; i++) {
			times++;
			if(times>50){
				break;
			}
				System.Array.Copy(map, tempMap, map.Length);
				tempCoor = currentCoor;
				tempDir = currentDir;

						try {
								int r = Random.Range (0, 3);
								int t = Random.Range (0, 4);

								while (((t+2)%4)==currentDir) {
										t = Random.Range (0, 4);
								}
								int l = Random.Range (2, 4);

								switch (r) {
								case 0:
										MakeRoad (currentCoor, t, l);
				
										break;
								case 1:
										MakeStairs (currentCoor, t);
										break;
								case 2:
										MakeJump (currentCoor, t);
										break;
		
		
								}
								if (fail) {
					System.Array.Copy(tempMap, map, tempMap.Length);
					currentCoor = tempCoor;
										currentDir = tempDir;
										i--;

								}

						} catch {
					System.Array.Copy(tempMap, map, tempMap.Length);
					currentCoor = tempCoor;
								currentDir = tempDir;
								i--;
				
						}

				}
				MakeFinish (currentCoor);

		}














}
