using NUnit.Framework;
using NSubstitute;
using System;

[TestFixture]
public class AttackStrategyTests
{
	[Test]
	public void DyingTest ()
	{
		
		IAttackStrategy atkStr = new RegularAttackStrategy ();
		
		IUnitCombat attacker = Substitute.For<IUnitCombat> ();
		UnitCombat defender = Substitute.For<UnitCombat> ();
		
		attacker.getStrength ().Returns (5);
		defender.setStrength (1);
		
		atkStr.Attack (attacker, defender);
		
		defender.Received ().Die ();
	}
	[Test]
	public void RegularAttackStrategyTest ()
	{
		IUnitCombat attacker = Substitute.For<UnitCombat> ();
		IUnitCombat defender = Substitute.ForPartsOf<UnitCombat> ();
		
		IAttackStrategy atkStr = Substitute.For<RegularAttackStrategy> ();
		
		attacker.setStrength (5);
		
		atkStr.Attack (attacker, defender);
		
		defender.Received ().Damage (5);
	}
}

