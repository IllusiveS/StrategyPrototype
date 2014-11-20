using System;

public class NodePlainsCost : INodeCost
{
	public int getCost(IAlgorithmCostInterface alg)
	{
		try
		{
			return alg.getPlainsCost ();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
}
