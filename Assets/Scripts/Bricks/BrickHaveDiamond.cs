using UnityEngine.UI;

public class BrickHaveDiamond : Brick
{
	protected override void OnEnable()
	{
		base.OnEnable();

		Button button = gameObject.GetComponent<Button>();
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(OnClickHaveDiamond);
	}

	protected override void OnClickHaveDiamond()
	{
		base.OnClickHaveDiamond();

		if (!canCheck) return;

		transform.Find("Diamond").gameObject.SetActive(true);
		EventDispatcher.PostEvent(EventID.CountDiamond, 1);
	}
}
