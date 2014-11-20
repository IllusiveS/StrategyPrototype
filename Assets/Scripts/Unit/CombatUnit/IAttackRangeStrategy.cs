using System;
public interface IAttackRangeStrategy
{
	bool CanAttack(IUnitCombat attacker, IUnitCombat defender);
}