using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IAlgorithm : IAlgorithmCostInterface{

	void GenerateGrid(INode selected, int i);

	INode TryNode(INode start, INode end, int i);

	List<UNode> GenerateRoute(INode start, INode end);

	void ResetAllNodes();

	void setArmyOwner(IArmy army);
}
