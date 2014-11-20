using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmyMovement : MonoBehaviour {

	private class UNodeList : List<UNode>{};

	UNodeList trasa = new UNodeList ();

	IArmy movingArmy;

	public Vector3 start;
	public Vector3 end;

	public UNode startNode;
	public UNode endNode;

	public float progress = 1.1f;

	public float speed;

	bool moving = false;

	public void Start()
	{
		movingArmy = GetComponent<UArmy> ().army;
	}

	public void setRoute(List<UNode> route)
	{
		moving = true;
		trasa.AddRange (route);
		trasa.RemoveAt (0);
		progress = 2.0f;
	}
		
	void FixedUpdate () {
		if(moving)
		{
			Move ();
		}
	}

	void Move()
	{
		if(progress > 1.0f)
		{
			setNewTarget ();
		}

		transform.position = Vector3.Lerp (start, end, progress);
		progress += 0.02f;
	}

	void setNewTarget()
	{
		try
		{
			endNode.node.Enter(movingArmy);
			startNode.node.Leave(movingArmy);
			movingArmy.setNode(endNode.node);
		}
		catch (System.NullReferenceException)
		{
			
		}

		start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		startNode = movingArmy.getNode ().node;
		try
		{
			end = new Vector3 (trasa[0].transform.position.x, trasa[0].transform.position.y, -0.5f);
			endNode = trasa[0];
			trasa.RemoveAt (0);
			if(trasa.Count != 0)
			{

			}
		}catch (System.ArgumentOutOfRangeException)
		{
			moving = false;
			if(endNode.node.getArmy() != null && endNode.node.getArmy() != movingArmy)
				finishAttackMove();
			else
			{
				finishMove();
			}
		}

		progress = 0.0f;
	}

	void finishMove()
	{
		GetComponent<UArmy> ().army.setIsActive (false);
		GetComponent<UArmy> ().army.getAlgorithm ().ResetAllNodes ();
		endNode = null;
		startNode = null;

		Army.selected = null;

		ListUnits.getInstance().displayArmy(null);
	}
	void finishAttackMove()
	{
		UArmy unityArmy = movingArmy.getUArmy ();
		UNode closestNode;
		closestNode = endNode.node.prevNode.getUnityNode();
		Vector3 newPlace = new Vector3 (closestNode.transform.position.x, closestNode.transform.position.y, -0.5f);
		start = newPlace;
		unityArmy.transform.position = newPlace;

		unityArmy.army.setNode (endNode.node.prevNode.getUnityNode().node);
		closestNode.node.army = movingArmy;

		unityArmy.GetComponent<CombatInitiator> ().pressTheAttack (endNode.army.army);

		finishMove ();
	}
}
