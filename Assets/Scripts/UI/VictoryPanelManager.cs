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
		GameData.CurrentMap++;
		GameData.CurrentLevel = 1;
		GameData.TotalLevel += 5;
		GameData.NumberDiamond = GameData.CurrentMap + 2;
		GameData.Indexes.Clear();

		Time.timeScale = 1f;
		SceneManager.LoadSceneAsync(nameScene);
	}
}
