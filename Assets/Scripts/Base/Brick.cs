using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour
{
	[SerializeField] private int id;

	[SerializeField] private Transform leftBox;
	[SerializeField] private Transform aboveBox;
	[SerializeField] private Transform rightBox;
	[SerializeField] private Transform underBox;
	[SerializeField] private bool canHide;
	[SerializeField] private List<Transform> boxes = new List<Transform>();
	[SerializeField] private Transform boxChooseMove;

	protected bool canCheck = false;
	private List<Transform> boxesHide = new List<Transform>();

	protected virtual void OnEnable()
	{
		EventDispatcher.AddEvent(EventID.CanCheckChanged, OnCanCheckChanged);

		StartCoroutine(MoveBox());
	}

	private IEnumerator MoveBox()
	{
		yield return new WaitUntil(() => canHide);

		GetRandomBoxMove();

		gameObject.SetActive(false);
	}

	protected virtual void OnDisable()
	{
		EventDispatcher.RemoveEvent(EventID.CanCheckChanged, OnCanCheckChanged);
	}

	private void OnCanCheckChanged(object obj)
	{
		canCheck = (bool)obj;
	}

	protected virtual void OnClickHaveDiamond()
	{
		if (!canCheck) return;
	}

	protected virtual void OnClickNoneDiamond()
	{
		if (!canCheck) return;
	}

	public void SetInfo(int id, Transform left, Transform right, Transform above, Transform under)
	{
		this.id = id;
		leftBox = left;
		rightBox = right;
		aboveBox = above;
		underBox = under;

		if (left != null)
			boxes.Add(left);
		if (right != null)
			boxes.Add(right);
		if (above != null)
			boxes.Add(above);
		if (under != null)
			boxes.Add(under);
	}

	public void SetInfoHide(bool canHide, List<Transform> boxesHide)
	{
		this.canHide = canHide;
		this.boxesHide = boxesHide;
	}

	private void GetRandomBoxMove()
	{
		while (true)
		{
			int id = Random.Range(0, boxes.Count);
			if (boxes[id].GetComponent<BoxMove>() != null || boxesHide.Contains(boxes[id])) continue;

			boxChooseMove = boxes[id];
			BoxMove move = boxChooseMove.gameObject.AddComponent(typeof(BoxMove)) as BoxMove;
			move.Target = transform.position;
			break;
		}
	}
}
