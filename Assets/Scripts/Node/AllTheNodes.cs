using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllTheNodes
{
	private static AllTheNodes Singleton = null;

	AllTheNodes()
	{
		allTheNodes = new List<INode>();
		allTheNodes.Clear ();
	}

	List<INode> allTheNodes;

	public static List<INode> AccessAllNodeList()
	{
		if (Singleton == null) 
		{
			Singleton = new AllTheNodes();
		}
		return Singleton.allTheNodes;
	}
}

