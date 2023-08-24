using UnityEngine;

namespace Assets.Scripts.Shared.Constant
{
	public class GameData
	{
		public static int TotalLevel
		{
			get
			{
				return PlayerPrefs.GetInt(KEY.TOTAL_LEVEL, 10);
			}

			set
			{
				PlayerPrefs.SetInt(KEY.TOTAL_LEVEL, value);
				EventDispatcher.PostEvent(EventID.TotalLevelChanged, value);
			}
		}

		public static int CurrentMap
		{
			get
			{
				return PlayerPrefs.GetInt(KEY.CURRENT_MAP, 1);
			}

			set
			{
				PlayerPrefs.SetInt(KEY.CURRENT_MAP, value);
				EventDispatcher.PostEvent(EventID.CurrentMapChanged, value);
			}
		}

		public static int CurrentLevel
		{
			get
			{
				return PlayerPrefs.GetInt(KEY.CURRENT_LEVEL, 1);
			}

			set
			{
				PlayerPrefs.SetInt(KEY.CURRENT_LEVEL, value);
				EventDispatcher.PostEvent(EventID.CurrentLevelChanged, value);
			}
		}

		public static int NumberDiamond
		{
			get
			{
				return PlayerPrefs.GetInt(KEY.NUMBER_DIAMOND, 3);
			}

			set
			{
				PlayerPrefs.SetInt(KEY.NUMBER_DIAMOND, value);
			}
		}
	}

	public class KEY
	{
		public const string TOTAL_LEVEL = "TOTAL_LEVEL";
		public const string CURRENT_MAP = "CURRENT_MAP";
		public const string CURRENT_LEVEL = "CURRENT_LEVEL";
		public const string NUMBER_DIAMOND = "NUMBER_DIAMOND";
	}
}
