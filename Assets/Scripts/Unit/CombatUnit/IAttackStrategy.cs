using System;
public interface IAttackStrategy		
{
	void Attack(IUnitCombat attacker, IUnitCombat defender);
	void setParent(IUnitCombat com);
}