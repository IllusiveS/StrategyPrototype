using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnConrol : ITurnSubject{

	private static TurnConrol Instance = null;

	public static TurnConrol getInstance()
	{
		if (TurnConrol.Instance == null)
		{
			Instance = new TurnConrol();
		}
		return Instance;
	}

	TurnConrol()
	{
		observers = new List<ITurnObserver> ();
		observers.Clear ();
	}

	private List<ITurnObserver> observers;

	public void Attach(ITurnObserver obs)
	{
		observers.Add (obs);
	}
	public void Detach(ITurnObserver obs)
	{
		observers.Remove (obs);
	}
	
	public void Notify(int turn)
	{
		foreach(ITurnObserver obs in observers)
		{
			obs.Update(turn);
		}
	}

}
