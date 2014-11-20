using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Army : IArmy, ITurnObserver, IUnitContainer, IOwnable
{
	public static IArmy selected = null;

	UArmy uArmy;

	List<Unit> units = new List<Unit>();

	bool isActive;
	bool isItsTurn;
	bool canAttack;

	int iMove;
	int iMoveMax;
	int iPlayerOwner;

	Node currentNode;

	public IAlgorithm movingAlgorithm;

	public Army (int i, int speed, UArmy arm)
	{
		movingAlgorithm = new Algorithm ();
		movingAlgorithm.setArmyOwner (this);
		uArmy = arm;
		iPlayerOwner = i;
		iMoveMax = speed;
	}

	public void attachToPlayer()
	{
		if (iPlayerOwner >= 0)
		{
			Player player = Player.getPlayer (iPlayerOwner);
			player.Attach (this);
		}
	}
	public void detachFromPlayer()
	{
		if (iPlayerOwner >= 0)
		{
			Player player = Player.getPlayer (iPlayerOwner);
			player.Detach(this);
		}
	}

	public void Update(int turn)
	{
		int player = turn % GameControl.MAX_PLAYERS;
		if(player == iPlayerOwner)
		{
			setIsItsTurn(true);
			iMove = iMoveMax;
			setCanAttack(true);
		}
		else
		{
			setCanAttack(false);
			setIsItsTurn(false);
			iMove = 0;
		}
	}

	public void selectArmy(IArmy army)
	{
		try
		{
			selected.setIsActive (false);
		}
		catch (System.NullReferenceException)
		{

		}
		if(army != null && isItsTurn)
		{
			selected = army;
			movingAlgorithm.GenerateGrid (currentNode, iMove);
			setIsActive(true);
			ListUnits.getInstance().displayArmy(this.getUArmy());
		}
		else
		{
			selected = null;
			ListUnits.getInstance().displayArmy(null);
			setIsActive(false);
			movingAlgorithm.ResetAllNodes();
		}

	}

	public void attackArmy(IArmy def)
	{
		List<UNode> trasa = Army.selected.getAlgorithm ().GenerateRoute (getNode (), def.getNode ());
		Army.selected.getUArmy().GetComponent<ArmyMovement>().setRoute(trasa);
	}

	public Node getNode()
	{
		return currentNode;
	}
	public void setNode(Node node)
	{
		currentNode = node;

	}

	public bool getIsActive()
	{
		return isActive;
	}
	public void setIsActive(bool boolean)
	{
		isActive = boolean;
	}

	public void setSpeed(int i)
	{
		iMove = i;
		uArmy.UpdateMovementDisplay ();
	}
	public int getSpeed()
	{
		return iMove;
	}

	public void setPlayer(int i)
	{
		iPlayerOwner = i;
	}
	public int getPlayer()
	{
		return iPlayerOwner;
	}

	public bool getIsItsTurn()
	{
		return isItsTurn;
	}
	public void setIsItsTurn(bool boolean)
	{
		isItsTurn = boolean;
	}

	public IAlgorithm getAlgorithm()
	{
		return movingAlgorithm;
	}

	public UArmy getUArmy()
	{
		return uArmy;
	}

	public List<Unit> getUnits()
	{
		return units;
	}

	public void addUnit(Unit u)
	{
		units.Add (u);
		u.setPlayer (getPlayer ());
		u.owner = this.uArmy;
	}
	public void removeUnit(Unit u)
	{
		units.Remove(u);
	}

	public int getOwner()
	{
		return iPlayerOwner;
	}
	public void setOwner(int i)
	{
		iPlayerOwner = i;
	}

	public int getGlory()
	{
		int glory = 0;
		foreach(Unit un in units)
		{
			glory += un.getGlory();
		}
		return glory;
	}

	public void setCanAttack(bool b)
	{
		canAttack = b;
	}
	public bool getCanAttack()
	{
		return canAttack;
	}
}
