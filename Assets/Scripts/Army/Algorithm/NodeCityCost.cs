using System;

public class NodeCityCost : INodeCost
{
	public int getCost(IAlgorithmCostInterface alg)
	{
		try
		{
			return alg.getCityCost ();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
}

