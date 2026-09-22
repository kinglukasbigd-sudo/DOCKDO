using System;
using UnityEngine;
// The ad networks are gone, so the "watch ad -> full repair" reward is granted directly.
// This cooldown keeps it from being an unlimited heal. Tune CooldownSeconds to taste.
public static class FreeRepair
{
	public const int CooldownSeconds = 150;
	private const string Key = "FreeRepairLastUtcTicks";
	public static bool TryUse()
	{
		long now = DateTime.UtcNow.Ticks;
		long last;
		if (!long.TryParse(PlayerPrefs.GetString(Key, "0"), out last))
		{
			last = 0L;
		}
		double left = CooldownSeconds - new TimeSpan(now - last).TotalSeconds;
		if (last > 0 && left > 0 && left <= CooldownSeconds)
		{
			Toast.Show(string.Format("Free repair ready again in {0}:{1:00}", (int)left / 60, (int)left % 60));
			return false;
		}
		PlayerPrefs.SetString(Key, now.ToString());
		PlayerPrefs.Save();
		return true;
	}
}
