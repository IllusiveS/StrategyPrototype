using System;

public class NodeRoadCost : INodeCost
{
	public int getCost(IAlgorithmCostInterface alg)
	{
		try
		{
			return alg.getRoadCost ();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
}

