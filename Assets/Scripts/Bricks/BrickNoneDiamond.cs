using UnityEngine;
using UnityEngine.UI;

public class BrickNoneDiamond : Brick
{
	protected override void OnEnable()
	{
		base.OnEnable();

		Button button = gameObject.GetComponent<Button>();
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(OnClickNoneDiamond);
	}

	protected override void OnClickNoneDiamond()
	{
		base.OnClickNoneDiamond();

		if (!canCheck) return;

		UIManager.ShowDefeat();
	}
}
