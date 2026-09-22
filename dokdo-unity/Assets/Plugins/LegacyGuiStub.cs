using UnityEngine;
// UnityEngine.GUIText / GUITexture were removed from Unity; these inert stand-ins keep legacy iTween code compiling.
public class GUITexture : Component
{
	public Color color;
	public Texture texture;
}
public class GUIText : Component
{
	public Color color;
	public Material material;
	public string text;
}
