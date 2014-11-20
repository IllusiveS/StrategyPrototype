using System;

public interface ITurnSubject
{
	void Attach(ITurnObserver obs);
	void Detach(ITurnObserver obs);

	void Notify(int turn);
}


