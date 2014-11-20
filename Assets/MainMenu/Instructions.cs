using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	public TextAsset tekst;
	public GameObject menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), tekst.text);
		if(GUI.Button(new Rect(Screen.width*4/10, Screen.height*9/10, Screen.width*2/10, Screen.height*1/10), "return"))
        {
			Instantiate(menu);
			Destroy (this.gameObject);
		}
	}
}
