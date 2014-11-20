using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject tutorial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Strategy game prototype \nmade by Patryk Wysocki");
		GUI.Label(new Rect(Screen.width*4/10, Screen.height*9/10, Screen.width*2/10, Screen.height*1/10), "Feel free to contact me at \nwysockipawelpatryk@gmail.com\nUsed unit portraits are from Dota 2.");

		if(GUI.Button(new Rect(Screen.width*4/10, Screen.height*5/10, Screen.width*2/10, Screen.height*1/10), "start game"))
		{
			Application.LoadLevel("scena");
		}
		if(GUI.Button(new Rect(Screen.width*4/10, Screen.height*7/10, Screen.width*2/10, Screen.height*1/10), "instructions"))
		{
			Instantiate(tutorial);
			Destroy (this.gameObject);
		}
	}
}
