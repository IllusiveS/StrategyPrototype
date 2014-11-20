using System;
using UnityEngine;

[System.Serializable]
public class UnitFactory
{
	public string name;

	public int Strength;
	public int Range;
	public int Glory;
	public bool Fragile;

	public Sprite sprajt;
	public Sprite desaturated;

	public String description;

	public AttackType attackType;

	public Unit getUnit()
	{
		Unit unit;
		unit = new Unit ();

		unit.combatModule = new UnitCombat ();

		unit.setCombatStrategy(addStrategy());
		unit.setRangeStrategy (new RegularAttackRange ());

		unit.setGlory (Glory);
		unit.setRange (Range);
		unit.setStrength (Strength);

		unit.sprite = sprajt;
		unit.desaturated = desaturated;

		unit.name = this.name;
		this.description = this.description.Replace ("\\n","\n");
		unit.description = this.description;

		unit.setFragile (Fragile);
		if(Fragile)
		{
			unit.description += "\nFragile";
		}
	
		return unit;
	}

	IAttackStrategy addStrategy()
	{
		IAttackStrategy strategia = null;

		switch(this.attackType)
		{
		case AttackType.Regular:
			strategia = new RegularAttackStrategy();
			break;
		case AttackType.Trample:
			strategia = new TrampleAttackStrategy();
			break;
		}

		return strategia;
	}

	public enum AttackType
	{
		Regular,
		Trample
	}
}
