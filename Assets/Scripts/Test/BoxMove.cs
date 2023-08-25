using UnityEngine;

public class BoxMove : MonoBehaviour
{
	[SerializeField] private Vector3 target;

	public Vector3 Target { get => target; set => target = value; }

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, 2f * Time.deltaTime);

		if (transform.position == target)
		{
			EventDispatcher.PostEvent(EventID.BoxStop, true);
			Destroy(transform.GetComponent<BoxMove>());
		}
	}

	private void OnDisable()
	{
		Destroy(transform.GetComponent<BoxMove>());
	}
}
