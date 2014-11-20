using UnityEngine;
using System.Collections;

public class PlayerTextureSelection : MonoBehaviour {

	public Texture player1;
	public Texture player2;
	public Texture player3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Texture GetPlayerSprite(int i)
	{
		if(i == 0)
		{
			return player1;
		}else if(i == 1)
		{
			return player2;
		}else if (i == 2)
		{
			return player3;
		}
		return null;
	}
}
