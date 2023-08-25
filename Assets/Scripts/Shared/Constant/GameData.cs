using System.Collections.Generic;
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

		public static int CurrentLevel = 1;
		public static int HardLevel = Mathf.FloorToInt(0.65f * GameData.TotalLevel);
		public static List<int> Indexes = new(); // Lien quan den Ham GetBrickHaveDiamond trong class Spawner
	}

	public class KEY
	{
		public const string TOTAL_LEVEL = "TOTAL_LEVEL";
		public const string CURRENT_MAP = "CURRENT_MAP";
		public const string CURRENT_LEVEL = "CURRENT_LEVEL";
		public const string NUMBER_DIAMOND = "NUMBER_DIAMOND";
	}
}
