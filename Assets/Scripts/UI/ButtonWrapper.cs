using UnityEngine;
using UnityEngine.UI;

public class ButtonWrapper : MonoBehaviour
{
	private AudioManager audioManager;
	private Button btn;

	void Start()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
		btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick()
	{
		audioManager.PlaySound("select");
	}
}
