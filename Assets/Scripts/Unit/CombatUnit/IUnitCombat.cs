using UnityEngine;
using System.Collections;

public interface IUnitCombat{

	bool getIsAttackable();

	void setFragile(bool b);
	bool getFragile();

	int getPlayer();
	void setPlayer(int i);

	int getXCoord();
	void setXCoord(int i);

	int	getYCoord();
	void setYCoord(int i);

	int getStrength();
	void setStrength(int i);

	void Damage(int i);

	int getRange();
	void setRange(int i);

	int getGlory();
	void setGlory(int i);

	bool canAttack(IUnitCombat combat);

	void attack(IUnitCombat combat);

	void Select();
	bool Die();

	IAttackStrategy getCombatStrategy();
	void setCombatStrategy(IAttackStrategy a);

	IAttackRangeStrategy getRangeStrategy();
	void setRangeStrategy(IAttackRangeStrategy a);

	ICombatSituation getCombatSituation();
	void setCombatSituation(ICombatSituation situation);

}
