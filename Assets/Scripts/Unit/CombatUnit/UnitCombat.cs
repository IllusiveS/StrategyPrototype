using System;

public class UnitCombat : IUnitCombat
{
	protected ICombatSituation situation;

	protected int XCoord;
	protected int YCoord;

	protected int Strength;
	protected int Range;
	protected int Glory;

	protected int Player;

	protected IAttackStrategy attackStrategy;
	protected IAttackRangeStrategy rangeStrategy;

	protected bool isAttackable;
	protected bool isDead;
	protected bool isFragile;

	public bool getIsAttackable()
	{
		return isAttackable;
	}

	public void setFragile(bool b)
	{
		isFragile = b;
	}
	public bool getFragile()
	{
		return isFragile;
	}

	public int getPlayer()
	{
		return Player;
	}
	public void setPlayer(int i)
	{
		Player = i;
	}

	public int getXCoord()
	{
		return XCoord;
	}
	public void setXCoord(int i)
	{
		XCoord = i;
	}
	
	public int getYCoord()
	{
		return YCoord;
	}
	public void setYCoord(int i)
	{
		YCoord = i;
	}
	
	public int getStrength()
	{
		return Strength;
	}
	public void setStrength(int i)
	{
		Strength = i;
		if (Strength <= 0)
			isDead = true;
	}
	public void Damage(int i)
	{
		if(isFragile)
		{
			setStrength(-1);
			return;
		}
		setStrength(getStrength() - i);
	}

	public int getRange()
	{
		return Range;
	}
	public void setRange(int i)
	{
		Range = i;
	}

	public int getGlory()
	{
		return Glory;
	}
	public void setGlory(int i)
	{
		Glory = i;
	}
	
	public bool canAttack(IUnitCombat combat)
	{
		bool stuff = rangeStrategy.CanAttack (this, combat);
		isAttackable = stuff;
		return stuff;
	}
	
	public void attack(IUnitCombat combat)
	{
		attackStrategy.Attack (this, combat);
	}
	
	public void Select()
	{

	}
	public bool Die()
	{
		return isDead;
	}
	
	public IAttackStrategy getCombatStrategy()
	{
		return attackStrategy;
	}
	public void setCombatStrategy(IAttackStrategy a)
	{
		attackStrategy = a;
	}
	
	public IAttackRangeStrategy getRangeStrategy()
	{
		return rangeStrategy;
	}
	public void setRangeStrategy(IAttackRangeStrategy a)
	{
		rangeStrategy = a;
	}

	public ICombatSituation getCombatSituation()
	{
		return situation;
	}
	public void setCombatSituation(ICombatSituation situation)
	{
		this.situation = situation;
	}

}

