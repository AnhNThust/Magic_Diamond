using Assets.Scripts.Shared.Constant;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlaySpaceManager : MonoBehaviour
{
	[SerializeField] private int brickSize;
	[SerializeField] private GridLayoutGroup grid;
	[SerializeField] private Text mapTitle;
	[SerializeField] private Text levelTitle;

	private int numberRowCol = 0;
	private bool canDetach = false;

	private void OnEnable()
	{
		EventDispatcher.AddEvent(EventID.CanDetachGridLayout, OnCanDetachGridLayout);

		numberRowCol = GameData.CurrentMap + 2;
		mapTitle.text = $"Map: {GameData.CurrentMap}";
		levelTitle.text =$"Level: {GameData.CurrentLevel}";

		StartCoroutine(CalCulatePlaySpace());
		StartCoroutine(DetachGridLayout());
	}

	private void OnDisable()
	{
		EventDispatcher.RemoveEvent(EventID.CanDetachGridLayout, OnCanDetachGridLayout);
	}

	private void OnCanDetachGridLayout(object obj)
	{
		canDetach = (bool)obj;
	}

	private IEnumerator CalCulatePlaySpace()
	{
		// Calculate size of Brick
		int size = SpacePlayInfo.PlaySpaceSize;
		int padding = SpacePlayInfo.Padding;
		int spacing = SpacePlayInfo.Spacing;
		brickSize = (size - 2 * padding - (numberRowCol - 1) * spacing) / numberRowCol;

		grid.cellSize = new Vector2(brickSize, brickSize);

		yield return new WaitForSeconds(0.5f);

		EventDispatcher.PostEvent(EventID.CanSpawnBrick, true);
	}

	private IEnumerator DetachGridLayout()
	{
		yield return new WaitUntil(() => canDetach);

		grid.GetComponent<GridLayoutGroup>().enabled = false;
	}
}
