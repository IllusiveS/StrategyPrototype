using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	int winner;

	string PesantsWon = "After a few days the rebellion grew in strength across the empire and it soon fell \ninto chaos and disarray";
	string EmpireWon = "Despite the efforts of the rebellion the empire crushed everyone who stood in their way";

	string str;
	// Use this for initialization
	void Start () {
		this.winner = GameControl.winner;
		if(winner == 0)
			str = PesantsWon;
		else
			str = EmpireWon;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), str);

		if(GUI.Button(new Rect(Screen.width*4/10, Screen.height*5/10, Screen.width*1/10, Screen.height*1/10), "quit"))
		{
			Application.Quit();
		}
		if(GUI.Button(new Rect(Screen.width*4/10, Screen.height*7/10, Screen.width*1/10, Screen.height*1/10), "play again"))
		{
			Application.LoadLevel("scena");
		}

		GUI.Label(new Rect(Screen.width*4/10, Screen.height*9/10, Screen.width*2/10, Screen.height*1/10), "Feel free to contact me at \nwysockipawelpatryk@gmail.com");
	}
}
