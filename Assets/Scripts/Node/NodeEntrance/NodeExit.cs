using System;

public class NodeExit
{
	public virtual void Leave(INode node, IArmy army)
	{
		node.setArmy (null);
		army.setNode (null);
	}
}

