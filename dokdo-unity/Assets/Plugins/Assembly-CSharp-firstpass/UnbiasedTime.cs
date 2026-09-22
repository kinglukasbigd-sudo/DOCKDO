using System;
using UnityEngine;
public class UnbiasedTime : MonoBehaviour
{
	private static UnbiasedTime _instance;
	public long timeOffset;
	public static UnbiasedTime Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject gameObject = new GameObject("UnbiasedTime");
				_instance = gameObject.AddComponent<UnbiasedTime>();
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
			return _instance;
		}
	}
	public DateTime Now() { return DateTime.Now; }
	public void UpdateTimeOffset() { }
	public bool IsUsingSystemTime() { return true; }
}
