using System;

public interface IAlgorithmCostInterface
{
	int getRoadCost();
	int getPlainsCost();
	int getForestCost();
	int getCityCost();

	void setRoadCost(IAlgorithmCost cost);
	void setPlainsCost(IAlgorithmCost cost);
	void setForestCost(IAlgorithmCost cost);
	void setCityCost(IAlgorithmCost cost);
}


