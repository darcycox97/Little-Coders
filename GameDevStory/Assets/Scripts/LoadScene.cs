﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	public GameObject ConfirmationDisplay;

	public void LoadByIndex(int index) {
		SceneManager.LoadScene(index);
	}

	public void OpenConfirmationDisplay()
	{
		ConfirmationDisplay.SetActive(true);
		ProjectManager.Instance.PauseProject();
	}

	public void CloseConfirmationDisplay()
	{
		ConfirmationDisplay.SetActive(false);
		ProjectManager.Instance.ResumeProject();
	}

	public void LoadMainMenu()
	{
		if (ConfirmationDisplay != null)
		{
			ConfirmationDisplay.SetActive(false);
		}
		Destroy(GameObject.FindGameObjectWithTag("GameManager"));
		Debug.Log("Destroying gm and going to main menu");
		SceneManager.LoadScene("MainMenu");
	}

	public void LoadPrototypeScene()
	{
		SceneManager.LoadScene("PrototypeScene");
	}

	public void LoadHighScoreScene()
	{
		if (GameManager.IsInstantiated())
		{
			DontDestroyOnLoad(GameManager.Instance);
		}
		SceneManager.LoadScene("HighScoreTestScene");
	}

	public void LoadEndingCutscene()
	{
		NPCController.Instance.TeardownNpcs();
		DontDestroyOnLoad(GameManager.Instance);
		SceneManager.LoadScene("BoughtOut");
	}

}
