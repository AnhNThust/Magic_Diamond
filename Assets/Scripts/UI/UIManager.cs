using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] private Transform uiVictory;
	[SerializeField] private Transform uiDefeat;

    static UIManager instance;

	private void OnEnable()
	{
		if (instance != null) Debug.LogError("Only 1 UIManager allow exists");

		instance = this;
	}

	// =================================================

	private void EnableVictory()
	{
		Time.timeScale = 0f;
		uiVictory.gameObject.SetActive(true);
	}

	private void EnableDefeat()
	{
		Time.timeScale = 0f;
		uiDefeat.gameObject.SetActive(true);
	}

	// =================================================

	public static void ShowVictory()
	{
		instance.EnableVictory();
	}

	public static void ShowDefeat()
	{
		instance.EnableDefeat();
	}
}
