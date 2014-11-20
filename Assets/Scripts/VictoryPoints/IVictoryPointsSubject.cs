using System;

public interface IVictoryPointsSubject
{
	void Attach(IVictoryPointsObserver obs);
	void Detach(IVictoryPointsObserver obs);
	
}

