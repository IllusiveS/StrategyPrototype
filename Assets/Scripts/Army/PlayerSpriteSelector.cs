using UnityEngine;
using System.Collections;

public class PlayerSpriteSelector : MonoBehaviour {

	public static PlayerSpriteSelector getSingleton()
	{
		return singleton;
	}

	static PlayerSpriteSelector singleton;

	static Sprite staticPlayer1;
	static Sprite staticPlayer2;
	static Sprite staticPlayer3;

	void Start()
	{
		singleton = this;

		staticPlayer1 = player1;
		staticPlayer2 = player2;
		staticPlayer3 = player3;
	}

	public Sprite player1;
	public Sprite player2;
	public Sprite player3;

	public static Sprite GetPlayerSprite(int i)
	{
		switch(i)
		{
		case 0:
			return staticPlayer1;
		case 1:
			return staticPlayer2;
		case 2:
			return staticPlayer3;
		}
		return null;
	}
}
