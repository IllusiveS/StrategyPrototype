using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CNode : MonoBehaviour {

	public INode node;

	void Start () {
		this.node = GetComponent<UNode> ().node;
	}
	
	void OnMouseDown()
	{
		if(Army.selected != null && node.isReachable())
		{
			List<UNode> trasa = Army.selected.getAlgorithm().GenerateRoute(null, node);
			Army.selected.getUArmy().GetComponent<ArmyMovement>().setRoute(trasa);
		}
	}
}
