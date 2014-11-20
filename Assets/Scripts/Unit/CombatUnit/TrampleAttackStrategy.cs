using System;

public class TrampleAttackStrategy : IAttackStrategy
{
	protected IUnitCombat UnitCombat;

	public TrampleAttackStrategy ()
	{
	}

	public void Attack(IUnitCombat attacker, IUnitCombat defender)
	{
		int damageStopped = defender.getStrength ();

		defender.Damage (attacker.getStrength ());
		if (defender.getXCoord() == 0 && attacker.getStrength() - damageStopped > 0)
		{
			Unit trampled = defender.getCombatSituation().findUnit(1, defender.getYCoord(), defender.getPlayer());
			if (trampled != null)
				trampled.Damage(attacker.getStrength() - damageStopped);
		}
	}
	public void setParent(IUnitCombat com)
	{
		UnitCombat = com;
	}
}