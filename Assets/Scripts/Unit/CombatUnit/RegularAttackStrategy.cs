using System;
public class RegularAttackStrategy : IAttackStrategy
{
	protected IUnitCombat UnitCombat;

	public RegularAttackStrategy ()
	{

	}

	public void setParent(IUnitCombat com)
	{
		UnitCombat = com;
	}

	public void Attack(IUnitCombat attacker, IUnitCombat defender)
	{
		defender.Damage (attacker.getStrength());
	}
}

