using UnityEngine;
using System.Collections;

public class Unit : IUnit, IUnitCombat{

	public UUnit unityUnit;

	public UArmy owner;

	public string name;
	public string description;

	public IUnitCombat combatModule;

	public Sprite sprite;
	public Sprite desaturated;

	public Unit()
	{

	}

	public bool getIsAttackable()
	{
		return combatModule.getIsAttackable ();
	}

	public void setFragile(bool b)
	{
		combatModule.setFragile (b);
	}
	public bool getFragile()
	{
		return combatModule.getFragile ();
	}
	
	public int getPlayer()
	{
		return combatModule.getPlayer ();
	}
	public void setPlayer(int i)
	{
		combatModule.setPlayer (i);
	}
	
	public int getXCoord()
	{
		return combatModule.getXCoord ();
	}
	public void setXCoord(int i)
	{
		combatModule.setXCoord (i);
	}
	
	public int	getYCoord()
	{
		return combatModule.getYCoord ();
	}
	public void setYCoord(int i)
	{
		combatModule.setYCoord (i);
	}
	
	public int getStrength()
	{
		return combatModule.getStrength ();
	}
	public void setStrength(int i)
	{
		combatModule.setStrength (i);
	}
	
	public void Damage(int i)
	{
		combatModule.Damage (i);
	}
	
	public int getRange()
	{
		return combatModule.getRange ();
	}
	public void setRange(int i)
	{
		combatModule.setRange (i);
	}
	public int getGlory()
	{
		return combatModule.getGlory ();
	}
	public void setGlory(int i)
	{
		combatModule.setGlory (i);
	}
	
	public bool canAttack(IUnitCombat combat)
	{
		return combatModule.canAttack (combat);
	}
	
	public void attack(IUnitCombat combat)
	{
		combatModule.attack (combat);
	}
	
	public void Select()
	{
		combatModule.Select ();
	}
	public bool Die()
	{
		return combatModule.Die ();
	}
	
	public IAttackStrategy getCombatStrategy()
	{
		return combatModule.getCombatStrategy ();
	}
	public void setCombatStrategy(IAttackStrategy a)
	{
		combatModule.setCombatStrategy (a);
	}
	
	public IAttackRangeStrategy getRangeStrategy()
	{
		return combatModule.getRangeStrategy ();
	}
	public void setRangeStrategy(IAttackRangeStrategy a)
	{
		combatModule.setRangeStrategy (a);
	}
	
	public ICombatSituation getCombatSituation()
	{
		return combatModule.getCombatSituation ();
	}
	public void setCombatSituation(ICombatSituation situation)
	{
		combatModule.setCombatSituation (situation);
	}

}
