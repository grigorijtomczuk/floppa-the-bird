using UnityEngine;

public class BirdController : MonoBehaviour
{
	[SerializeField]
	private float flapForce;

	private LogicManager logicManager;
	private AudioManager audioManager;
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private Animator anim;

	private bool isAlive = true;
	private float deadZoneY = 3.55f;

	void Start()
	{
		logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && isAlive)
		{
			Flap();
		}

		if (transform.position.y >= deadZoneY || transform.position.y <= -deadZoneY)
		{
			Die();
		}
	}

	void Flap()
	{
		audioManager.PlaySound("flap");
		anim.Play("BirdFlap");
		rb.velocity = Vector2.up * flapForce;
	}

	void Die()
	{
		isAlive = false;
		sprite.flipY = true;
		logicManager.GameOver();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		audioManager.PlaySound("hit");
		Die();
	}
}
