using UnityEngine;

public class BackgroundController : MonoBehaviour
{
	[SerializeField]
	private GameObject backgroundLeft;

	[SerializeField]
	private GameObject backgroundRight;

	[SerializeField, Range(-1f, 1f)]
	private float scrollSpeed;

	private float maxOffsetX = 12.65f;

	void Update()
	{
		backgroundLeft.transform.position += new Vector3(-scrollSpeed * Time.deltaTime * 10f, 0f, 0f);
		backgroundRight.transform.position += new Vector3(-scrollSpeed * Time.deltaTime * 10f, 0f, 0f);

		if (backgroundLeft.transform.position.x <= -maxOffsetX)
		{
			backgroundLeft.transform.position = new Vector3(maxOffsetX, 0, 0);
		}

		if (backgroundRight.transform.position.x <= -maxOffsetX)
		{
			backgroundRight.transform.position = new Vector3(maxOffsetX, 0, 0);
		}
	}
}
