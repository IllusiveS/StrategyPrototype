using System;
using System.Collections.Generic;

public class Player : ITurnObserver, ITurnSubject, IVictoryPointsSubject, IVictoryPointsObserver
{
	private int PlayerNumber;

	public int Glory = 0;

	private List<ITurnObserver> armies = new List<ITurnObserver>();
	private List<IVictoryPointsObserver> victoryPlaces = new List<IVictoryPointsObserver> ();

	public static List<Player> players = new List<Player> ();

	public static Player getPlayer(int i)
	{
		Player p = null;
		p = players.Find (a => a.getPlayerNumber() == i);
		return p;
	}

	public Player (int i)
	{
		PlayerNumber = i;
		players.Add (this);
	}

	public int getPlayerNumber()
	{
		return PlayerNumber;
	}

	public void Attach(ITurnObserver obs)
	{
		armies.Add (obs);
	}
	public void Detach(ITurnObserver obs)
	{
		armies.Remove (obs);
	}
	
	public void Notify(int turn)
	{
		foreach(ITurnObserver obs in armies)
		{
			obs.Update(turn);
		}
	}
	

	public void Update(int turn)
	{
		Notify (turn);
	}

	public void Attach(IVictoryPointsObserver obs)
	{
		victoryPlaces.Add (obs);
	}

	public void Detach(IVictoryPointsObserver obs)
	{
		victoryPlaces.Remove (obs);
	}

	public int getPoints()
	{
		int points = 0;

		foreach(IVictoryPointsObserver obs in victoryPlaces)
		{
			points += obs.getPoints();
		}

		points += Glory;

		return points;
	}
}
