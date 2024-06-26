using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
	public GameObject prefab;

	public GameObject textureControllerObject;

	private int[,] neighborsMap = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

	private TextureController textureController;

	private int index = 1;
	private float size;
	private List<bool> liquid;
	private List<bool> animated;

	private void Awake()
	{
		size = 100;

		liquid = new List<bool>();
		animated = new List<bool>();

		textureController = textureControllerObject.GetComponent<TextureController>();
	}

	private void SetNeighbors(int[,] blocks, GameObject[,] clones)
	{
		int countI = blocks.GetLength(0);
		int countJ = blocks.GetLength(1);

		for (int i = 0; i < countI; i++)
		{
			for (int j = 0; j < countJ; j++)
			{
				if (clones[i, j] != null)
				{
					AbstractBlock abstractBlock = clones[i, j].GetComponent<AbstractBlock>();

					IterateNeighborsMap(blocks, i, j, abstractBlock);
				}
			}
		}
	}

	private void IterateNeighborsMap(int[,] blocks, int positionX, int positionY, AbstractBlock abstractBlock)
	{
		int countI = blocks.GetLength(0);
		int countJ = blocks.GetLength(1);
		int countMap = neighborsMap.GetLength(0);

		for (int i = 0; i < countMap; i++)
		{
			int x = positionX + neighborsMap[i, 0];
			int y = positionY + neighborsMap[i, 1];

			if (x < 0 || y < 0 || x >= countI || y >= countJ)
			{
				continue;
			}

			if (blocks[x, y] > 0)
			{
				abstractBlock.SetNeighbor(neighborsMap[i, 0], neighborsMap[i, 1]);
			}
		}

		abstractBlock.RefreshTexture();
	}

	public void SetSize(float size)
	{
		this.size = size;
	}

	public int CreateBlock(string name, bool liquid = false, bool animated = false)
	{
		textureController.Bake(index, name);
		this.liquid.Add(liquid);
		this.animated.Add(animated);

		return index++;
	}

	public GameObject[,] AddBlocks(int[,] blocks, Vector2 position)
	{
		int countI = blocks.GetLength(0);
		int countJ = blocks.GetLength(1);
		GameObject[,] clones = new GameObject[countI, countJ];

		for (int i = 0; i < countI; i++)
		{
			for (int j = 0; j < countJ; j++)
			{
				clones[i, j] = AddBlock(blocks[i, j], GetPosition(position, i, j));
			}
		}

		SetNeighbors(blocks, clones);

		return clones;
	}

	public Vector2 GetPosition(Vector2 position, int i, int j)
	{
		return position + new Vector2(i, j);
	}

	public GameObject AddBlock(int block, Vector2 position)
	{
		if (block == 0)
		{
			return null;
		}

		GameObject clone = Instantiate(prefab, position, Quaternion.identity);

		AbstractBlock abstractBlock = clone.GetComponent<AbstractBlock>();

		if (abstractBlock != null)
		{
			abstractBlock.SetTextureController(textureController);
			abstractBlock.Set(block);
			abstractBlock.SetLiquid(liquid[block - 1]);
			abstractBlock.SetAnimated(animated[block - 1]);
		}

		return clone;
	}
}