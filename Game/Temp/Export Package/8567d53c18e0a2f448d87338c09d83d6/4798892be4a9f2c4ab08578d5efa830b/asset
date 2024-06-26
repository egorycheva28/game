using UnityEngine;

public class SceneController : MonoBehaviour
{
	public GameObject blocksControllerObject;

	private BlocksController blocksController;

	private int groundBlock;
	private int stoneBlock;
	private int waterBlock;
	private int gravelBlock;
	private int toxinBlock;
	private int icestoneBlock;
	private int darkstoneBlock;
	private int sandBlock;
	private int lavaBlock;
	private int marshBlock;

	private void Awake()
	{
		blocksController = blocksControllerObject.GetComponent<BlocksController>();
	}

	private void Start()
	{
		//Set block size.
		blocksController.SetSize(100f);

		//Define some blocks id.
		groundBlock = blocksController.CreateBlock("Ground");
		stoneBlock = blocksController.CreateBlock("Stone");

		//Example 1.
		//Example1();

		//Example 2.
		//Example2();

		//Example 3.
		//Example3();

		//Example 4.
		Example4();
	}

	private void AdditionalBlocks()
	{
		gravelBlock = blocksController.CreateBlock("Gravel");
		stoneBlock = blocksController.CreateBlock("Stone");
		icestoneBlock = blocksController.CreateBlock("IceStone");
		darkstoneBlock = blocksController.CreateBlock("DarkStone");
		sandBlock = blocksController.CreateBlock("Sand");
		waterBlock = blocksController.CreateBlock("Water", true, true);
		lavaBlock = blocksController.CreateBlock("Lava", true, true);
		marshBlock = blocksController.CreateBlock("Marsh", true, true);
		toxinBlock = blocksController.CreateBlock("Toxin", true, true);
	}

	public void Example1()
	{
		blocksController.AddBlock(groundBlock, Vector2.zero);
	}

	public void Example2()
	{
		int[,] blocks = new int[3, 3];

		blocks[0, 0] = groundBlock;
		blocks[0, 1] = groundBlock;
		blocks[0, 2] = groundBlock;
		blocks[1, 0] = groundBlock;
		blocks[1, 1] = 0;
		blocks[1, 2] = groundBlock;
		blocks[2, 0] = groundBlock;
		blocks[2, 1] = groundBlock;
		blocks[2, 2] = groundBlock;

		blocksController.AddBlocks(blocks, Vector2.zero);
	}

	public void Example3()
	{
		int[,] blocks = new int[3, 3];

		blocks[0, 0] = stoneBlock;
		blocks[0, 1] = stoneBlock;
		blocks[0, 2] = stoneBlock;
		blocks[1, 0] = stoneBlock;
		blocks[1, 1] = stoneBlock;
		blocks[1, 2] = stoneBlock;
		blocks[2, 0] = stoneBlock;
		blocks[2, 1] = stoneBlock;
		blocks[2, 2] = stoneBlock;

		blocksController.AddBlocks(blocks, Vector2.zero);
	}

	public void Example4()
	{
		AdditionalBlocks();

		int[,] blocks = new int[5, 2];

		blocks[0, 0] = stoneBlock;
		blocks[0, 1] = sandBlock;
		blocks[1, 0] = darkstoneBlock;
		blocks[1, 1] = marshBlock;
		blocks[2, 0] = lavaBlock;
		blocks[2, 1] = toxinBlock;
		blocks[3, 0] = gravelBlock;
		blocks[3, 1] = icestoneBlock;
		blocks[4, 0] = groundBlock;
		blocks[4, 1] = waterBlock;

		blocksController.AddBlocks(blocks, Vector2.zero);
	}
}