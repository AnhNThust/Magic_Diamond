using Assets.Scripts.Shared.Constant;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private int totalDiamond = 0;
	[SerializeField] private int counter = 0;

	[SerializeField] private int totalBoxMove;
	[SerializeField] private int count;

	private void OnEnable()
	{
		EventDispatcher.AddEvent(EventID.TotalDiamond, OnGetTotalDiamond);
		EventDispatcher.AddEvent(EventID.CountDiamond, OnCountDiamondChanged);

		EventDispatcher.AddEvent(EventID.TotalBoxMove, OnTotalBoxMoveChanged);
		EventDispatcher.AddEvent(EventID.CountBoxMove, OnCountBoxMoveChanged);
	}

	private void OnDisable()
	{
		EventDispatcher.RemoveEvent(EventID.TotalDiamond, OnGetTotalDiamond);
		EventDispatcher.RemoveEvent(EventID.CountDiamond, OnCountDiamondChanged);

		EventDispatcher.RemoveEvent(EventID.TotalBoxMove, OnTotalBoxMoveChanged);
		EventDispatcher.RemoveEvent(EventID.CountBoxMove, OnCountBoxMoveChanged);
	}

	private IEnumerator Victory()
	{
		yield return new WaitUntil(() => counter >= totalDiamond);

		yield return new WaitForSeconds(2f);

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
	}

	private void OnGetTotalDiamond(object obj)
	{
		totalDiamond = (int)obj;

		StartCoroutine(Victory());
	}

	private void OnCountBoxMoveChanged(object obj)
	{
		count += (int)obj;

		if (count >= totalBoxMove)
		{
			EventDispatcher.PostEvent(EventID.CanCheckChanged, true);
		}
	}

	private void OnTotalBoxMoveChanged(object obj)
	{
		totalBoxMove = (int)obj;
	}
}
