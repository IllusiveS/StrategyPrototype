using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Node : INode{

	public UNode node;

	public NodeEntrance entrance;
	public NodeExit exit;

	public IArmy army;

	public int NeighboursNumber;

	public static INode Selected;

	public bool bWasVisited;
	public bool bIsActivated;

	public int iCost;
	public int iMoveLeft;

	public List<INode> Neighbours;

	public INode prevNode;

	public INodeCost costCalculator;
	
	public Node(UNode node)
	{
		AllTheNodes.AccessAllNodeList ().Add (this);
		this.node = node;

		entrance = new NodeEntrance ();
		exit = new NodeExit ();
	}

	public void SelectNode(INode selected, IAlgorithm algorytm)
	{
		if(selected.getActive())
		{
			DestinateNode(selected, algorytm);
			return;
		}
		Node.Selected = selected;
		algorytm.GenerateGrid (this, 3);
	}

	public void DestinateNode(INode selected, IAlgorithm algorytm)
	{
		List<UNode> trasa = algorytm.GenerateRoute (Selected, selected);

		foreach(INode nod in AllTheNodes.AccessAllNodeList())
		{
			nod.setActive(false);
		}
		foreach(UNode nod in trasa)
		{
			nod.setActive(true);
		}
	}

	public void Enter(IArmy army)
	{
		entrance.Enter (this, army);
	}
	public void Leave(IArmy army)
	{
		exit.Leave (this, army);
	}

	public IArmy getArmy()
	{
		return army;
	}
	public int getCost(IAlgorithmCostInterface alg){
		int i = costCalculator.getCost(alg);
		if (i == -1)
			return iCost;
		else
			return i;
	}
	public INode getPrev(){
		return prevNode;
	}
	public List<INode> getNeighbours(){
		return Neighbours;
	}
	public bool getVisited(){
		return bWasVisited;
	}
	public bool getActive(){
		return bIsActivated;
	}
	public int getMoveLeft()
	{
		return iMoveLeft;
	}
	public UNode getUnityNode()
	{
		return node;
	}

	public void setUnityNode(UNode n)
	{
		node = n;
	}

	public void setCost(int i)
	{
		iCost = i;
	}
	public void setPrev(INode node)
	{
		prevNode = node;
	}
	public void setNeighbours(List<INode> list)
	{
		Neighbours = list;
		NeighboursNumber = list.Count;
	}
	public void setVisited(bool b)
	{
		bWasVisited = b;
	}
	public void setActive(bool b)
	{
		node.setActive (b);
		bIsActivated = b;
	}
	public void setMoveLeft(int i)
	{
		iMoveLeft = i;
	}
	public void setArmy(IArmy army)
	{
		this.army = army;
	}

	public bool isReachable()
	{
		return bIsActivated;
	}
}
