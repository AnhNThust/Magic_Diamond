using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatPanelManager : MonoBehaviour
{
	[SerializeField] private string nameScene;

	public void Replay()
	{
		Time.timeScale = 1f;
		SceneManager.LoadSceneAsync(nameScene);
	}
}
