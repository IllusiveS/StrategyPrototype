using UnityEngine;
using System.Collections;

public class ArmyMovementChange : MonoBehaviour {

	public UNode.TileType tileType;
	public int cost;

	// Use this for initialization
	void Start () {
		setAlgorithm (transform.parent.GetComponentInChildren<UArmy> ().army);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setAlgorithm(Army arm)
	{
		switch(tileType)
		{
		case UNode.TileType.city:
			arm.getAlgorithm().setCityCost(new AlgorithmCost(cost));
			break;
		case UNode.TileType.road:
			arm.getAlgorithm().setRoadCost(new AlgorithmCost(cost));
			break;
		case UNode.TileType.plain:
			arm.getAlgorithm().setPlainsCost(new AlgorithmCost(cost));
			break;
		case UNode.TileType.forest:
			arm.getAlgorithm().setForestCost(new AlgorithmCost(cost));
			break;
		}
	}
	void OnDestroy()
	{
		try
		{
		Army army = GetComponentInParent<UArmy> ().army;
		switch(tileType)
		{
		case UNode.TileType.city:
			army.getAlgorithm().setCityCost(new AlgorithmCost(cost));
			break;
		case UNode.TileType.road:
			army.getAlgorithm().setRoadCost(new AlgorithmCost(cost));
			break;
		case UNode.TileType.plain:
			army.getAlgorithm().setPlainsCost(new AlgorithmCost(cost));
			break;
		case UNode.TileType.forest:
			army.getAlgorithm().setForestCost(new AlgorithmCost(cost));
			break;
		}
		}
		catch(System.NullReferenceException)
		{

		}
	}
}
