using Assets.Scripts.Shared.Constant;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatPanelManager : MonoBehaviour
{
	[SerializeField] private string nameScene;

	public void Replay()
	{
		Time.timeScale = 1f;
		GameData.CurrentLevel = 1;
		GameData.Indexes.Clear();
		SceneManager.LoadSceneAsync(nameScene);
	}
}
