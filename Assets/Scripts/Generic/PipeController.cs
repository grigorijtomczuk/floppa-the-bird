using UnityEngine;

public class PipeController : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed;

	private float deadZoneX = -8;

	void Update()
	{
		transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		if (transform.position.x <= deadZoneX)
		{
			Destroy(gameObject);
		}
	}
}
