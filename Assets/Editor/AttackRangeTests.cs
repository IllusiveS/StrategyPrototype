using NUnit.Framework;
using NSubstitute;
using System;

[TestFixture]
public class AttackRangeTests
{
	[Test]
	public void TestBasicRange ()
	{
		RegularAttackRange rangeStrat = Substitute.ForPartsOf<RegularAttackRange> ();
		
		IUnitCombat attacker = Substitute.For<IUnitCombat> ();
		attacker.getXCoord ().Returns (0);
		attacker.getRange ().Returns (1);
		
		IUnitCombat attackable = Substitute.For<IUnitCombat> ();
		attackable.getXCoord ().Returns (0);
		
		IUnitCombat notAttackable= Substitute.For<IUnitCombat> ();
		notAttackable.getXCoord ().Returns (5);

		bool result = rangeStrat.CanAttack (attacker, attackable);

		Assert.AreEqual (true, result);

		result = rangeStrat.CanAttack (attacker, notAttackable);
		
		Assert.AreEqual (false, result);
	}
	[Test]
	public void TestFirstRowEmptyRange ()
	{
		RegularAttackRange rangeStrat = Substitute.ForPartsOf<RegularAttackRange> ();

		ICombatSituation situation = Substitute.For<ICombatSituation> ();
		situation.isFirstRowEmpty (Arg.Any<int> ()).Returns (true);
		
		IUnitCombat attacker = Substitute.For<IUnitCombat> ();
		attacker.getXCoord ().Returns (0);
		attacker.getRange ().Returns (1);
		
		IUnitCombat attackable = Substitute.For<IUnitCombat> ();
		attackable.getCombatSituation ().Returns (situation);
		attackable.getXCoord ().Returns (1);
		attackable.getPlayer ().Returns (1);
		
		IUnitCombat notAttackable= Substitute.For<IUnitCombat> ();
		notAttackable.getCombatSituation ().Returns (situation);
		notAttackable.getXCoord ().Returns (2);
		notAttackable.getPlayer ().Returns (1);
		
		bool result = rangeStrat.CanAttack (attacker, attackable);
		
		Assert.AreEqual (true, result);
		
		result = rangeStrat.CanAttack (attacker, notAttackable);
		
		Assert.AreEqual (false, result);
	}
}