// Credits: richardkettlewell
// https://forum.unity.com/threads/lwrp-using-2d-lights-in-a-particle-system-emitter.718847/#post-5554201

using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAttachment : MonoBehaviour
{
	[SerializeField]
	private GameObject prefab;

	private ParticleSystem _particleSystem;
	private List<GameObject> instances = new List<GameObject>();
	private ParticleSystem.Particle[] particles;

	void Start()
	{
		_particleSystem = GetComponent<ParticleSystem>();
		particles = new ParticleSystem.Particle[_particleSystem.main.maxParticles];
	}

	void LateUpdate()
	{
		int count = _particleSystem.GetParticles(particles);

		while (instances.Count < count)
			instances.Add(Instantiate(prefab, _particleSystem.transform));

		bool worldSpace = (_particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World);
		for (int i = 0; i < instances.Count; i++)
		{
			if (i >= count)
			{
				instances[i].SetActive(false);
			}
			else
			{
				if (worldSpace)
				{
					instances[i].transform.position = particles[i].position;
				}
				else
				{
					instances[i].transform.localPosition = particles[i].position;
					instances[i].SetActive(true);
				}
			}
		}
	}
}
