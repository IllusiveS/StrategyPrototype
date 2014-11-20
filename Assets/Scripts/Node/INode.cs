using System.Collections;
using System.Collections.Generic;

public interface INode{

	void SelectNode(INode selected, IAlgorithm algorytm);
	void DestinateNode(INode selected, IAlgorithm algorytm);

	void Enter(IArmy army);
	void Leave(IArmy army);

	IArmy getArmy();
	int getCost(IAlgorithmCostInterface alg);
	INode getPrev();
	List<INode> getNeighbours();
	bool getVisited();
	bool getActive();
	int getMoveLeft();
	UNode getUnityNode();

	void setCost(int i);
	void setPrev(INode node);
	void setNeighbours(List<INode> list);
	void setVisited(bool b);
	void setActive(bool b);
	void setMoveLeft(int i);
	void setArmy(IArmy army);

	bool isReachable();
}
