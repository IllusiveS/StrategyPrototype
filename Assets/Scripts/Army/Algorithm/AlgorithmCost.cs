using System;

public class AlgorithmCost : IAlgorithmCost
{
	int cost;

	public AlgorithmCost (int cost)
	{
		this.cost = cost;
	}

	public int getCost()
	{
		return cost;
	}
}

