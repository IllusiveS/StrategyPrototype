using System;

public interface IArmy
{
	void selectArmy(IArmy army);
	void attackArmy(IArmy army);

	void setCanAttack(bool b);
	bool getCanAttack();

	Node getNode();
	void setNode(Node node);

	void setSpeed(int i);
	int getSpeed();

	bool getIsActive();
	void setIsActive(bool boolean);

	bool getIsItsTurn();
	void setIsItsTurn(bool boolean);

	int getPlayer();
	void setPlayer(int i);

	IAlgorithm getAlgorithm();

	int getGlory();

	UArmy getUArmy();
}

