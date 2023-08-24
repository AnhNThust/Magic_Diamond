using UnityEngine;

public class BoxMove : MonoBehaviour
{
	[SerializeField] private Vector3 target;

	public Vector3 Target { get => target; set => target = value; }

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, 0.02f);

		if (transform.position == target)
		{
			EventDispatcher.PostEvent(EventID.CountBoxMove, 1);
			Destroy(transform.GetComponent<BoxMove>());
		}
	}

	private void OnDisable()
	{
		Destroy(transform.GetComponent<BoxMove>());
	}
}
