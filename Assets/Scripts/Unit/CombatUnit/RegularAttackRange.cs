using System;

public class RegularAttackRange : IAttackRangeStrategy
{
	public RegularAttackRange ()
	{
	}
	
	public bool CanAttack(IUnitCombat attacker, IUnitCombat defender)
	{
		int range = attacker.getRange ();
		int distance = 0;

		distance += defender.getXCoord ();
		distance += attacker.getXCoord ();

		if(defender.getCombatSituation().isFirstRowEmpty(defender.getPlayer()) == true)
			distance -= 1;
		if(attacker.getCombatSituation().isFirstRowEmpty(attacker.getPlayer()) == true)
			distance -= 1;

		if(range > distance)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}


