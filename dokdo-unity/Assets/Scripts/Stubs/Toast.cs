using UnityEngine;
using UnityEngine.UI;
public class Toast : MonoBehaviour
{
	private float life;
	public static void Show(string message, float seconds = 2.5f)
	{
		GameObject root = new GameObject("Toast");
		Canvas canvas = root.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.sortingOrder = 32000;
		CanvasScaler scaler = root.AddComponent<CanvasScaler>();
		scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		scaler.referenceResolution = new Vector2(1080f, 1920f);
		GameObject bg = new GameObject("bg");
		bg.transform.SetParent(root.transform, false);
		Image image = bg.AddComponent<Image>();
		image.color = new Color(0f, 0f, 0f, 0.78f);
		image.raycastTarget = false;
		RectTransform rt = image.rectTransform;
		rt.anchorMin = rt.anchorMax = new Vector2(0.5f, 0.3f);
		rt.sizeDelta = new Vector2(920f, 150f);
		GameObject label = new GameObject("label");
		label.transform.SetParent(bg.transform, false);
		Text text = label.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
		text.fontSize = 46;
		text.alignment = TextAnchor.MiddleCenter;
		text.color = Color.white;
		text.raycastTarget = false;
		text.text = message;
		RectTransform trt = text.rectTransform;
		trt.anchorMin = Vector2.zero;
		trt.anchorMax = Vector2.one;
		trt.offsetMin = trt.offsetMax = Vector2.zero;
		root.AddComponent<Toast>().life = seconds;
	}
	private void Update()
	{
		life -= Time.unscaledDeltaTime;
		if (life <= 0f)
		{
			Destroy(gameObject);
		}
	}
}
