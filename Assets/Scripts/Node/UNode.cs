using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UNode : MonoBehaviour {

	public TileType tileType;

	public float halfSize;

	public List<UNode> neighbours = new List<UNode>();

	private int[,] neigh = {{1, 0}, {0, 1}, {-1, 0}, {0, -1}};

	public Node node;

	public int AllNodes;

	public UArmy army;

	public int cost;

	public int moveLeft;


	void Awake()
	{
		node = new Node (this);
		node.costCalculator = getTileType ();
	}

	void Start () {
		node.iCost = cost;

		for(int i = 0; i < neigh.GetLength(0); i++) 
		{
			Transform trans = GetComponent<Transform>();
			Vector3 start = new Vector3(trans.position.x + (halfSize * neigh[i, 0]), trans.position.y + (halfSize * neigh[i, 1]), trans.position.z);

			int asd = 1 << 8;

			try
			{
				UNode PotentialNeighbour = Physics.OverlapSphere(start, 0.2f, asd)[0].GetComponent<UNode>();
				neighbours.Add(PotentialNeighbour);
			}
			catch
			{

			}
		}
		List<INode> nods = new List<INode> ();
		foreach (UNode nod in neighbours) 
		{
			nods.Add(nod.node);
		}
		
		node.setNeighbours (nods);

		AllNodes = AllTheNodes.AccessAllNodeList ().Count;

		try
		{
			army = Physics.RaycastAll(transform.position, new Vector3(0, 0, -1.0f), 1.0f, 1 << 9)[0].collider.gameObject.GetComponent<UArmy>();
			node.army = army.army;
		}
		catch (System.IndexOutOfRangeException)
		{
			
		}
	}

	void Update()
	{
		try
		{
			army = node.army.getUArmy ();
		}
		catch(System.NullReferenceException)
		{
			army = null;
		}

		moveLeft = node.iMoveLeft;
	}

	public void setActive(bool b)
	{
		GetComponentInChildren<UIsActive>().setActive(b);
	}

	INodeCost getTileType()
	{
		INodeCost costCalc = null;

		switch(tileType)
		{
		case TileType.city:
			costCalc = new NodeCityCost();
			break;
		case TileType.plain:
			costCalc = new NodePlainsCost();
			break;
		case TileType.road:
			costCalc = new NodeRoadCost();
			break;
		case TileType.forest:
			costCalc = new NodeForestCost();
			break;
		}
		return costCalc;
	}

	public enum TileType
	{
		plain,
		road,
		city,
		forest
	}

}
