using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightConfig : MonoBehaviour
{
	public bool entranceDoorOpen = true;
	public bool officeDoorOpen = true;
	public float nightStartDelay;
	public bool jumpScareInProgress;

	public GameObject[] cameraBlocks;

	public void GameOver()
	{
		
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
