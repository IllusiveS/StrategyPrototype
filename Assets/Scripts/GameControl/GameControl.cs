using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour, ITurnSubject {

	private bool started = false;

	public static int winner;

	public void Attach(ITurnObserver obs)
	{
		players.Add (obs);
	}
	public void Detach(ITurnObserver obs)
	{
		players.Remove (obs);
	}
	
	public void Notify(int turn)
	{
		foreach(ITurnObserver obs in players)
		{
			obs.Update(turn);
		}
	}

	void Awake()
	{
		for(int i = 0; i < MAX_PLAYERS; i++)
		{
			Instance = this;
			Attach(new Player(i));
		}
	}

	private static GameControl Instance = null;

	public static int MAX_PLAYERS = 2;

	public static GameControl getInstance()
	{
		return Instance;
	}

	public int iTurn = 0;
	private int gameTurn = 1;
	public int iPlayers;

	public List<ITurnObserver> players = new List<ITurnObserver> ();
	
	//Przycisk tury
	void OnGUI() {
		if(!started)
		{
			Notify (iTurn);
			started = true;
		}

		if(UCombat.getSingleton() == null)
		{
			if (GUI.Button(new Rect(10, 10, 150, 30), "Next Turn"))
			{
				iTurn++;
				if(iTurn % MAX_PLAYERS == 0)
					gameTurn++;
				if(gameTurn > 5)
				{
					endGame();
				}
				Notify(iTurn);
				try
				{
					Army.selected.selectArmy(null);
				}
				catch (System.NullReferenceException)
				{
				}
			}
			GUI.Label(new Rect(160, 10, 150, 30), "Turn: " + (gameTurn).ToString());
		}

		for(int i = 0; i < GameControl.MAX_PLAYERS; i++)
		{
			GUI.Label(new Rect(Screen.width*9/12, 5 + (15 * i), Screen.width, 20 + (15 * i)), new GUIContent( "Player " + (i+1).ToString() + ": " + Player.getPlayer(i).getPoints().ToString(), GetComponent<PlayerTextureSelection>().GetPlayerSprite(i)));
		}

	}

	public void endGame()
	{
		if(Player.getPlayer(0).getPoints() > Player.getPlayer(1).getPoints())
		{
			winner = 0;
		}
		else
			winner = 1;

		Application.LoadLevel ("EndGame");
	}
}
