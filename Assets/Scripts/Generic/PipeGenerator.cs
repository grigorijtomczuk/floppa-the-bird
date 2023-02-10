using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
	[SerializeField]
	private GameObject pipes;

	[SerializeField]
	private float spawnRate;

	[SerializeField]
	private float heightOffset;

	private float timer = 0f;

	void Start()
	{
		SpawnPipes(); // Initial spawn
	}

	void Update()
	{
		if (timer > spawnRate)
		{
			SpawnPipes();
			timer = 0f;
		}
		else
		{
			timer += Time.deltaTime;
		}
	}

	void SpawnPipes()
	{
		float lowestY = transform.position.y - heightOffset;
		float highestY = transform.position.y + heightOffset;
		Instantiate(pipes, new Vector3(transform.position.x, Random.Range(lowestY, highestY), transform.position.z), transform.rotation);
	}
}
