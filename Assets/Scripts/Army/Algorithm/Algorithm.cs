using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Algorithm : IAlgorithm{

	public IArmy armyOwner;

	public IAlgorithmCost roads;
	public IAlgorithmCost plains;
	public IAlgorithmCost forests;
	public IAlgorithmCost cities;

	public int getRoadCost()
	{
		try
		{
			return roads.getCost();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
	public int getPlainsCost()
	{
		try
		{
			return plains.getCost();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
	public int getForestCost()
	{
		try
		{
			return forests.getCost();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
	public int getCityCost()
	{
		try
		{
			return cities.getCost();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}

	public void setRoadCost(IAlgorithmCost cost)
	{
		roads = cost;
	}
	public void setPlainsCost(IAlgorithmCost cost)
	{
		plains = cost;
	}
	public void setForestCost(IAlgorithmCost cost)
	{
		forests = cost;
	}
	public void setCityCost(IAlgorithmCost cost)
	{
		cities = cost;
	}

	public Algorithm()
	{
		roads = null;
		plains = null;
		forests = null;
		cities = null;
	}

	public void setArmyOwner(IArmy army)
	{
		armyOwner = army;
	}

	public void GenerateGrid(INode selected, int i)
	{
		ResetAllNodes ();
		SetStarting (selected, i);
		List<INode> nodes = new List<INode> ();
		nodes.Add (selected);
		IterateNodes (nodes);
	}

	public INode TryNode(INode start, INode end, int i)
	{
		if(end.getArmy() == null)
		{
			if (testViability(start, end ,i)) 
			{
				end.setPrev(start);
				end.setActive(true);
				end.setMoveLeft(i - end.getCost(this));
			}
			if(end.getVisited() == false)
			{
				end.setVisited(true);
				return end;
			}else
			{
				return null;
			}
		}
		else
		{
			if (end.getArmy().getPlayer() == armyOwner.getPlayer())
			{
				if (testViability(start, end ,i)) 
				{
					end.setPrev(start);
					end.setActive(false);
					end.setMoveLeft(i - end.getCost(this));
					if(!end.getVisited())
					{
						end.setVisited(true);
						return end;
					}
				}
			}
			else
			{
				if (testViability(start, end ,i)) 
				{
					end.setPrev(start);
					if(armyOwner.getCanAttack())
						end.setActive(true);
					else
						end.setActive(false);
					end.setMoveLeft(i - end.getCost(this));
					end.setVisited(true);
				}
			}

			return null;
		}
	}

	public bool testViability(INode start, INode end, int i)
	{
		return end.getCost (this) <= i && end.getMoveLeft() < i - end.getCost(this);
	}

	public List<UNode> GenerateRoute(INode start, INode end)
	{
		List<UNode> trasa = new List<UNode> ();
		trasa.Clear ();

		INode testedNode = end;

		do
		{
			trasa.Add(testedNode.getUnityNode());
			testedNode = testedNode.getPrev();
		}while (testedNode != null);
		trasa.Reverse ();
		return trasa;

	}

	public void ResetAllNodes()
	{
		foreach (INode node in AllTheNodes.AccessAllNodeList()) 
		{
			node.setActive(false);
			node.setVisited(false);
			node.setPrev(null);
			node.setMoveLeft(-1);
		}
	}
	public void SetStarting(INode selected, int i)
	{
		selected.setVisited (true);
		selected.setActive (true);
		selected.setPrev (null);
		selected.setMoveLeft (i);
	}
	public void IterateNodes(List<INode> nodes)
	{
		do {
			foreach (INode NodeNeigh in nodes[0].getNeighbours()) 
			{
				INode next = TryNode (nodes[0], NodeNeigh, nodes[0].getMoveLeft ());
				if (next != null) 
				{
					nodes.Add (next);
				}
			}
			nodes.RemoveAt(0);
		} while(nodes.Count > 0);
	}
}
