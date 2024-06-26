using System;
using UnityEngine;

public enum TextureSize
{
	x32 = 32,
	x64 = 64,
	x128 = 128,
	x256 = 256,
	x512 = 512
}

public enum TextureName
{
	main,
	grass,
	top,
	bottom,
	left,
	right,

	frame0,
	frame1,
	frame2,
	frame3
}

[Serializable]
public struct PartialsGroup
{
	public string blockName;

	public BlockPartials size32;
	public BlockPartials size64;
	public BlockPartials size128;
	public BlockPartials size256;
	public BlockPartials size512;

	public BlockPartials Get(TextureSize size = TextureSize.x128)
	{
		switch (size)
		{
			case TextureSize.x32:
				return size32;
			case TextureSize.x64:
				return size64;
			case TextureSize.x256:
				return size256;
			case TextureSize.x512:
				return size512;
			default:
				return size128;
		}
	}
}

[Serializable]
public struct BlockPartials
{
	public Texture2D main;
	public Texture2D grass;
	public Texture2D top;
	public Texture2D bottom;
	public Texture2D left;
	public Texture2D right;

	public Texture2D frame0;
	public Texture2D frame1;
	public Texture2D frame2;
	public Texture2D frame3;
}

public class TextureDictionary : MonoBehaviour
{
	public PartialsGroup[] partials;

	public Texture2D GetPartial(string key, TextureName name, TextureSize size = TextureSize.x128)
	{
		BlockPartials partials = GetPartials(key, size);

		switch (name)
		{
			case TextureName.main:
				return partials.main;
			case TextureName.grass:
				return partials.grass;
			case TextureName.top:
				return partials.top;
			case TextureName.bottom:
				return partials.bottom;
			case TextureName.left:
				return partials.left;
			case TextureName.right:
				return partials.right;
			case TextureName.frame0:
				return partials.frame0;
			case TextureName.frame1:
				return partials.frame1;
			case TextureName.frame2:
				return partials.frame2;
			case TextureName.frame3:
				return partials.frame3;
			default:
				return partials.main;
		}
	}

	public BlockPartials GetPartials(string key, TextureSize size = TextureSize.x128)
	{
		foreach (PartialsGroup partial in partials)
		{
			if (key == partial.blockName)
			{
				return partial.Get(size);
			}
		}

		return new BlockPartials();
	}

	public TextureName GetTextureFrameName(int i)
	{
		switch (i)
		{
			case 0:
				return TextureName.frame0;
			case 1:
				return TextureName.frame1;
			case 2:
				return TextureName.frame2;
			case 3:
				return TextureName.frame3;
			default:
				return TextureName.frame0;
		}
	}
}