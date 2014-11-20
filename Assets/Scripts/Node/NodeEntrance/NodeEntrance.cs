using System;

public class NodeEntrance
{
	public virtual int Enter(INode node, IArmy army)
	{
		army.setSpeed (army.getSpeed () - node.getCost(army.getAlgorithm()));
		
		if (node.getArmy() == null)
		{
			node.setArmy(army);
			army.setNode(node.getUnityNode().node);
		}
		else
		{
			return -1;
		}
		return 0;
	}
}

