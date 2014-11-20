using UnityEngine;
using System.Collections;

public class Combat : ICombat, ICombatSituation{

	static public Combat instance = null;

	public static Combat getSingletonInstance()
	{
		if (instance != null)
		{
			return instance;
		}
		else 
			return null;
	}

	public ICombat getInstance()
	{
		return Combat.getSingletonInstance ();
	}

	UCombat unityModule;

	IArmy atk;
	IArmy def;

	public Combat ()
	{
		instance = this;
	}
	public void setUp(UCombat unity, IArmy atk, IArmy def)
	{
		unityModule = unity;
		this.atk = atk;
		this.def = def;
	}

	public IArmy CalculateWinner()
	{
		return null;
	}
	public void BeginCombat(IArmy atk, IArmy def)
	{

	}
	public void EndCombat()
	{

	}
	/// <summary>
	/// checks if the row of an army participating in combat is empty
	/// </summary>
	/// <returns><c>true</c>, if first row is empty, <c>false</c> otherwise.</returns>
	/// <param name="i">The player</param>
	public bool isFirstRowEmpty(int i)
	{
		bool empty = true;

		IArmy army;

		if(i == atk.getPlayer())
		{
			army = atk;
		}else
		{
			army = def;
		}

		foreach(Unit un in army.getUArmy().army.getUnits())
		{
			if(un.getXCoord() == 0)
			{
				empty = false;
			}
		}

		return empty;
	}
	
	public void FindAttackable(IUnitCombat attacker)
	{
	}

	public Unit findUnit(int x, int y, int player)
	{
		Unit unit = null;

		IArmy army;

		if (player == this.atk.getPlayer ()) 
		{
			army = atk;
		}else
		{
			army = def;
		}

		foreach(Unit un in army.getUArmy().army.getUnits())
		{
			if(un.getXCoord() == x && un.getYCoord() == y)
			{
				unit = un;
			}
		}

		return unit;
	}

}
