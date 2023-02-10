using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
	private LogicManager logic;

	void Start()
	{
		logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 6)
		{
			logic.AddScore(1);
		}
	}
}
