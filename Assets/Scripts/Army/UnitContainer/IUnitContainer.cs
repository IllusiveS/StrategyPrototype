using System;
using System.Collections.Generic;

public interface IUnitContainer
{
	List<Unit> getUnits();

	void addUnit(Unit u);
	void removeUnit(Unit u);
}

