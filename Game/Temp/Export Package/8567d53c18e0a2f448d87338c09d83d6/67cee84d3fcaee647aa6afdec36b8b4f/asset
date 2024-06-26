using UnityEngine;

public abstract class AbstractBlock : MonoBehaviour
{
	public int index;

	public bool liquid;
	public bool animated;

	public SpriteRenderer sr;

	private TextureController textureController;

	private int frame;
	private float frameTime;

	private bool[] edges;

	public AbstractBlock()
	{
		edges = new bool[4] { true, true, true, true };
	}

	void Awake()
	{
		sr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		sr.receiveShadows = true;
	}

	void Update()
	{
		if (animated)
		{
			if (frameTime > 0.5f)
			{
				frame = UnityEngine.Random.Range(0, 4);
				sr.sprite = textureController.GetBaked(index, frame, edges);

				frameTime = 0f;
			}

			frameTime += Time.deltaTime;
		}
	}

	public void SetTextureController(TextureController textureController)
	{
		this.textureController = textureController;
	}

	public void Set(int id)
	{
		Set(id, Color.white);
	}

	public void Set(int id, Color color)
	{
		index = id;

		frame = UnityEngine.Random.Range(0, 4);
		frameTime = 0f;

		RefreshTexture();
		sr.material.color = color;

		RescaleSprite();
	}

	private void RescaleSprite()
	{
		Bounds bounds = sr.sprite.bounds;
		float size = (1f / bounds.size.x) * 1.128f;

		sr.gameObject.transform.localScale = new Vector3(size, size, 1f);
	}

	public void RefreshTexture()
	{
		sr.sprite = textureController.GetBaked(index, frame, edges);
	}

	public void SetLiquid(bool liquid = true)
	{
		this.liquid = liquid;
	}

	public void SetAnimated(bool animated = true)
	{
		this.animated = animated;
	}

	public void SetNeighbor(int indexX, int indexY, bool state = true)
	{
		indexX++;
		indexY++;

		//Left.
		if (indexX == 0 && indexY == 1)
		{
			edges[0] = !state;
		}

		//Right.
		if (indexX == 2 && indexY == 1)
		{
			edges[1] = !state;
		}

		//Top.
		if (indexX == 1 && indexY == 2)
		{
			edges[2] = !state;
		}

		//Bottom.
		if (indexX == 1 && indexY == 0)
		{
			edges[3] = !state;
		}
	}
}