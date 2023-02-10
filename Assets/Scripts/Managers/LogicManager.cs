using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR

using UnityEditor;

#endif

public class LogicManager : MonoBehaviour
{
	[SerializeField]
	private Preset preset;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private GameObject gameOverScreen;

	private enum Preset { None, MainScene };

	private AudioManager audioManager;

	private int playerScore = 0;
	private static string currentSceneName;
	private string previousSceneName;

#if UNITY_EDITOR

	[CustomEditor(typeof(LogicManager))]
	public class LogicManagerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			LogicManager logicManager = (LogicManager)target;

			serializedObject.Update();

			SerializePropertyField("preset");

			if (logicManager.preset == Preset.MainScene)
			{
				EditorGUILayout.Space();
				SerializePropertyField("scoreText");
				SerializePropertyField("gameOverScreen");
			}

			serializedObject.ApplyModifiedProperties();

			void SerializePropertyField(string propertyPath)
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty(propertyPath));
			}
		}
	}

#endif

	void Start()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

		// Store current scene name in a static variable to have an access to it in the subsequent manager instances
		previousSceneName = currentSceneName;
		currentSceneName = SceneManager.GetActiveScene().name;

		if (currentSceneName == "TitleScreen")
		{
			audioManager.PlayMusic("titleScreen");
		}

		// Check additionally if the scene switched from another; if so - replay music; do nothing otherwise (keep music playing)
		if (currentSceneName == "Main" && previousSceneName != currentSceneName)
		{
			audioManager.PlayMusic("chiptune");
		}
	}

	public void SwitchToTitleScreen()
	{
		SceneManager.LoadScene("TitleScreen");
	}

	public void SwitchToMainScene()
	{
		SceneManager.LoadScene("Main");
	}

	[ContextMenu("Restart Scene")]
	public void RestartScene()
	{
		SceneManager.LoadScene(currentSceneName);
	}

	public void GameOver()
	{
		gameOverScreen.SetActive(true);
	}

	public void AddScore(int scoreToAdd)
	{
		audioManager.PlaySound("score");
		playerScore += scoreToAdd;
		scoreText.text = playerScore.ToString();
	}
}
