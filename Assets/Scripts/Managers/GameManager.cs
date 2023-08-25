using Assets.Scripts.Shared.Constant;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private int totalDiamond = 0;
	[SerializeField] private int counter = 0;

	private bool isBoxStop = false;

	private void OnEnable()
	{
		EventDispatcher.AddEvent(EventID.TotalDiamond, OnGetTotalDiamond);
		EventDispatcher.AddEvent(EventID.CountDiamond, OnCountDiamondChanged);

		EventDispatcher.AddEvent(EventID.BoxStop, OnBoxStop);
	}

	private void OnDisable()
	{
		EventDispatcher.RemoveEvent(EventID.TotalDiamond, OnGetTotalDiamond);
		EventDispatcher.RemoveEvent(EventID.CountDiamond, OnCountDiamondChanged);

		EventDispatcher.RemoveEvent(EventID.BoxStop, OnBoxStop);
	}

	private IEnumerator Victory()
	{
		//yield return new WaitUntil(() => counter >= totalDiamond);

		yield return new WaitForSeconds(1f);

		if (GameData.CurrentLevel < GameData.TotalLevel)
		{
			GameData.CurrentLevel++;
			SceneManager.LoadSceneAsync("GamePlay");
		}
		else
		{
			UIManager.ShowVictory();
		}
	}

	private void OnCountDiamondChanged(object obj)
	{
		counter += (int)obj;

		if (counter >= totalDiamond)
		{
			EventDispatcher.PostEvent(EventID.CanCheckChanged, false);
			StartCoroutine(Victory());
		}
	}

	private void OnGetTotalDiamond(object obj)
	{
		totalDiamond = (int)obj;

		//StartCoroutine(Victory());
	}

	private void OnBoxStop(object obj)
	{
		isBoxStop = (bool)obj;

		if (!isBoxStop) return;

		EventDispatcher.PostEvent(EventID.CanCheckChanged, true);
	}
}
