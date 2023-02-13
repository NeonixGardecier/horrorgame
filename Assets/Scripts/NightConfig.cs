using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class NightConfig : MonoBehaviour
{
	public bool entranceDoorOpen = true;
	public bool officeDoorOpen = true;
	public float nightStartDelay;
	public bool jumpScareInProgress;
	public int power;

	public GameObject Player;
	public Transform JumpscarePos;

	public GameObject[] cameras;
	public GameObject[] cameraBlocks;

	public AnimatronicMovement bartender;
	public AnimatronicMovement singer;
	public AnimatronicMovement securitybot;
	public AnimatronicMovement waitress;
	public AnimatronicMovement chef;
	public Animatronic_Skeleton skeleton;

	public TextMeshProUGUI TimeText;
	public int time = 0;

	public void Update()
	{
		if (jumpScareInProgress)
		{
			for (int i = 0; i < cameras.Length; i++)
			{
				cameras[i].SetActive(false);
			}

			Player.transform.position = JumpscarePos.position;
		}
	}

	void Start()
	{
		StartCoroutine(timeProgress());
	}

	public void GameOver()
	{
		SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
	}

	public void GameWin()
	{
		SceneManager.LoadScene("GameWin", LoadSceneMode.Single);
	}

	IEnumerator timeProgress()
	{
		yield return new WaitForSeconds(60f);
		time += 1;
		if (time >= 8)
		{
			GameWin();
		}
		TimeText.text = "" + time + " AM";
		StartCoroutine(timeProgress());
	}

	public void PlaySound(GameObject sound, float time)
	{
		StartCoroutine(playSound(sound, time));
	}

	IEnumerator playSound(GameObject sound, float time)
	{
		sound.SetActive(true);
		yield return new WaitForSeconds(time);
		sound.SetActive(false);
	}

	public void BlockCameras(float time)
	{
		StartCoroutine(blockCycle(time));
	}

	IEnumerator blockCycle(float time)
	{
		for (int i = 0; i < cameraBlocks.Length; i++)
		{
			cameraBlocks[i].SetActive(true);
		}
		yield return new WaitForSeconds(time);

		for (int o = 0; o < cameraBlocks.Length; o++)
		{
			cameraBlocks[o].SetActive(false);
		}
	}
}
