using System;

public class NodeForestCost : INodeCost
{
	public int getCost(IAlgorithmCostInterface alg)
	{
		try
		{
			return alg.getForestCost ();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
}

