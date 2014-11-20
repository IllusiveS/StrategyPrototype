using UnityEngine;
using System.Collections;

public class UVictoryPoint : MonoBehaviour, IVictoryPointsObserver, IOwnable {

	public int victoryPointsOccupied;
	public int victoryPoints;
	public int playerOwner = -1;

	// Use this for initialization
	void Start () {
		GetComponentInChildren<DisplayPlayerSprite> ().owner = this;
		GetComponent<UNode> ().node.entrance = new VictoryNodeEntrance ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getPoints()
	{
		if (GetComponent<UNode>().node.getArmy() != null)
			return victoryPointsOccupied;
		return victoryPoints;
	}

	public int getOwner()
	{
		return playerOwner;
	}
	public void setOwner(int i)
	{
		if(playerOwner >= 0)
			Player.getPlayer(playerOwner).Detach(this);

		playerOwner = i;
		Player.getPlayer (i).Attach (this);
	}
}
