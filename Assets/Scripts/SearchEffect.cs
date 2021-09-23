using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(RectTransform))]
public class SearchEffect : Graphic
{
	public override Texture mainTexture => _mainTexture;
	[SerializeField] private Texture _mainTexture;

	public Texture DepthTexture { get { return _depthTexture; } set { _depthTexture = value; } }
	[SerializeField] private Texture _depthTexture;

	public Color LineColor { get { return _lineColor; } set { _lineColor = value; } }
	[SerializeField] private Color _lineColor;

	public float Speed { get { return _speed; } set { _speed = value; } }
	[SerializeField] private float _speed;

	public float Frequency { get { return _frequency; } set { _frequency = value; } }
	[SerializeField] private float _frequency;

	public float Width { get { return _width; } set { _width = value; } }
	[SerializeField, Range(0,1)] private float _width;

	public float MinimalDepth { get { return _minimalDepth; } set { _minimalDepth = value; } }
	[SerializeField, Range(0, 1)] private float _minimalDepth;

	public Material Material
	{
		get
		{
			if (_material == null)
			{
				if (_shader == null)
				{
					_shader = Shader.Find("UI/SearchEffect");
				}
				_material = new Material(_shader);
			}
			return _material;
		}
	}
	private Material _material;

	private Shader _shader;

	protected override void Awake()
	{
		base.Awake();

	}

	private void SetMaterialProperties()
	{
		Material.SetTexture("_DepthTex", _depthTexture);
		Material.SetColor("_LineColor", _lineColor);
		Material.SetFloat("_Speed", _speed);
		Material.SetFloat("_Frequency", _frequency);
		Material.SetFloat("_Width", _width);
		Material.SetFloat("_MinimalDepth", _minimalDepth);
		base.material = Material;
	}

#if UNITY_EDITOR

	protected override void Reset()
	{
		base.Reset();
		SetMaterialProperties();
	}

	protected override void OnValidate()
	{
		base.OnValidate();
		SetMaterialProperties();
	}

#endif
}