using Assets.Scripts.Shared.Constant;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanelManager : MonoBehaviour
{
	[SerializeField] private string nameScene;

	public void Replay()
	{
		Time.timeScale = 1f;
		SceneManager.LoadSceneAsync(nameScene);
	}

	public void Next()
	{
		// Set lai data để sang map mới
		//if (GameData.CurrentLevel < GameData.TotalLevel)
		//{
		//	GameData.CurrentLevel++;
		//}
		//else
		//{
		//	GameData.CurrentMap++;
		//	GameData.CurrentLevel = 1;
		//	GameData.TotalLevel += 5;
		//	GameData.NumberDiamond = GameData.CurrentMap + 2;
		//}

		GameData.CurrentMap++;
		GameData.CurrentLevel = 1;
		GameData.TotalLevel += 5;
		GameData.NumberDiamond = GameData.CurrentMap + 2;

		Time.timeScale = 1f;
		SceneManager.LoadSceneAsync(nameScene);
	}
}
