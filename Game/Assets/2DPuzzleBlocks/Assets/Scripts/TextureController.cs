using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
public struct Textures
{
	public string key;
	public TextureName name;
	public Texture2D texture;
	public Sprite sprite;
}

public class TextureController : MonoBehaviour
{
	public TextureSize defaultSize;

	public GameObject textureDictionaryObject;

	public Texture2D blank;

	private int realSize;
	private int borderSize;

	private TextureDictionary textureDictionary;

	private List<Textures> textures;
	private Dictionary<int, Sprite[,]> baked;

	public TextureController()
	{
		textures = new List<Textures>();
		baked = new Dictionary<int, Sprite[,]>();
	}

	private void Awake()
	{
		realSize = (int)defaultSize * 9 / 8;
		borderSize = (int)defaultSize / 16;

		textureDictionary = textureDictionaryObject.GetComponent<TextureDictionary>();
	}

	public void Bake(int id, string name)
	{
		int i, j;

		Sprite[,] temp = new Sprite[4, 16];
		Texture2D[] texture = new Texture2D[16];

		for (i = 0; i < 16; i++)
		{
			BitArray b = new BitArray(new int[] { i });

			bool[] bits = new bool[4] { b.Get(0), b.Get(1), b.Get(2), b.Get(3) };

			texture[i] = new Texture2D(realSize, realSize, TextureFormat.ARGB32, false);

			for (int x = 0; x < texture[i].width; x++)
			{
				for (int y = 0; y < texture[i].height; y++)
				{
					texture[i].SetPixel(x, y, new Color(0f, 0f, 0f, 0f));
				}
			}

			texture[i].Apply();

			texture[i] = TextureMerge(texture[i], GetTexture(name, TextureName.main), borderSize, borderSize);

			//Left.
			if (bits[0] == false)
			{
				texture[i] = TextureMerge(texture[i], GetTexture(name, TextureName.left), 0, borderSize);
			}

			//Right.
			if (bits[1] == false)
			{
				texture[i] = TextureMerge(texture[i], GetTexture(name, TextureName.right), (int)defaultSize - borderSize, borderSize);
			}

			//Top.
			if (bits[2] == false)
			{
				texture[i] = TextureMerge(texture[i], GetTexture(name, TextureName.top), borderSize, (int)defaultSize - borderSize);
			}
			else
			{
				texture[i] = TextureMerge(texture[i], GetTexture(name, TextureName.grass), borderSize, (int)defaultSize - borderSize);
			}

			//Bottom.
			if (bits[3] == false)
			{
				texture[i] = TextureMerge(texture[i], GetTexture(name, TextureName.bottom), borderSize, 0);
			}
		}

		for (i = 0; i < 4; i++)
		{
			for (j = 0; j < 16; j++)
			{
				Texture2D mixed = TextureCopy(texture[j]);

				mixed = TextureMerge(mixed, GetTexture(name, textureDictionary.GetTextureFrameName(i)), borderSize * 2, borderSize * 2);

				temp[i, j] = Sprite.Create(mixed, new Rect(0.0f, 0.0f, mixed.width, mixed.height), new Vector2(0.5f, 0.5f), 144);
			}
		}

		baked[id] = temp;
	}

	public void Load(string key, TextureName name)
	{
		Textures texture = new Textures();

		texture.key = key;
		texture.name = name;
		texture.texture = textureDictionary.GetPartial(key, name, defaultSize);

		texture.sprite = Sprite.Create(texture.texture, new Rect(0.0f, 0.0f, texture.texture.width, texture.texture.height), new Vector2(0.5f, 0.5f), 128);

		textures.Add(texture);
	}

	public Sprite GetSprite(string key, TextureName name)
	{
		Load(key, name);

		foreach (Textures texture in textures)
		{
			if (texture.key == key && texture.name == name)
			{
				return texture.sprite;
			}
		}

		return null;
	}

	public Texture2D GetTexture(string key, TextureName name)
	{
		foreach (Textures texture in textures)
		{
			if (texture.key == key && texture.name == name)
			{
				return texture.texture;
			}
		}

		Load(key, name);
		return GetTexture(key, name);
	}

	public Sprite GetBaked(int id, int frame, bool[] edges)
	{
		BitArray b = new BitArray(edges);

		int[] array = new int[1];
		b.CopyTo(array, 0);

		return baked[id][frame, array[0]];
	}

	private Texture2D TextureMerge(Texture2D textureA, Texture2D textureB, int offX = 0, int offY = 0)
	{
		for (int x = 0; x < textureB.width; x++)
		{
			for (int y = 0; y < textureB.height; y++)
			{
				Color colorA = textureA.GetPixel(x + offX, y + offY);
				Color colorB = textureB.GetPixel(x, y);

				Color color = Color.Lerp(colorA, colorB, colorB.a / 1.0f);

				textureA.SetPixel(x + offX, y + offY, color);
			}
		}

		textureA.Apply();

		return textureA;
	}

	private Texture2D TextureCopy(Texture2D textureA)
	{
		Texture2D textureB = new Texture2D(textureA.width, textureA.height, TextureFormat.ARGB32, false);

		for (int x = 0; x < textureA.width; x++)
		{
			for (int y = 0; y < textureA.height; y++)
			{
				textureB.SetPixel(x, y, textureA.GetPixel(x, y));
			}
		}

		textureB.Apply();

		return textureB;
	}
}