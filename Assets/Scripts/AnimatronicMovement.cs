using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicMovement : MonoBehaviour
{	
	[Header("Dependencies")]
	public NightConfig config;
	public int currentPosition = 0;

	[Header("Config")]
	public float difficulty = 0; //0 - 100
	public float moveDelay = 0;
	public int finalPositionValue; //Array position of the final movement (typically the door)
	public float jumpScareDuration;
	public GameObject jumpScare;
	public GameObject jumpscareSound;
	public GameObject[] positions; //Works based off their numbered positions in the array for the next variable
	public Vector2[] moves; //Value 1 is where the animatronic is moving from, Value 2 is where it can move, multiple entries for multiple choice paths

	public int[] jumpscareFailFallbackPositions; //the place the animatronic will go if the jumpscare fails

	void Start()
	{
		StartCoroutine(nightWait());
	}
		
	IEnumerator nightWait()
	{
		yield return new WaitForSeconds(config.nightStartDelay);
		StartCoroutine(moveCycle());
	}
	
	IEnumerator moveCycle()
	{
		yield return new WaitForSeconds(5f + Random.Range(0, moveDelay));

		Random.seed = System.Environment.TickCount;
		int rnd = Random.Range(0, 100);
		
		if(currentPosition != finalPositionValue)
		{	
			if (rnd <= difficulty)
			{
				if (currentPosition != finalPositionValue)
				{	
					DoMove();
				}else{
					DoJumpScare();
				}	
			}
		}
		else if(currentPosition == finalPositionValue)
		{	
			if (rnd <= difficulty * 2)
			{
				if (currentPosition != finalPositionValue)
				{	
					DoMove();
				}else{
					DoJumpScare();
				}	
			}
		}
		StartCoroutine(moveCycle());
	}
	
	void DisableAllPositions()
	{
		for(int i = 0; i < positions.Length; i++)
		{
			positions[i].SetActive(false);
		}
	}

	public List<int> possibleMoves = new List<int>();
	void DoMove()
	{
		config.BlockCameras(1.2f);
		possibleMoves = new List<int>();
		for (int i = 0; i < moves.Length; i++)
		{
			if (moves[i].x == currentPosition)
			{
				possibleMoves.Add((int)moves[i].y);
			}
		}

		Random.seed = System.Environment.TickCount;
		int rnd = Random.Range(0, possibleMoves.Count);
		currentPosition = possibleMoves[rnd];
		
		DisableAllPositions();
		positions[possibleMoves[rnd]].SetActive(true);
	}

	void DoJumpScare()
	{
		if(config.officeDoorOpen)
		{	
			if(config.jumpScareInProgress == false)
			{
				StartCoroutine(JumpScareCycle());
			}else{
				JumpscareFail();
			}
		}else{
			JumpscareFail();
		}
	}

	void JumpscareFail()
	{
		int rnd = Random.Range(0, jumpscareFailFallbackPositions.Length);
		DisableAllPositions();
		currentPosition = rnd;
		positions[jumpscareFailFallbackPositions[rnd]].SetActive(true);
	}

	IEnumerator JumpScareCycle()
	{
		config.jumpScareInProgress = true;
		DisableAllPositions();
		jumpScare.SetActive(true);
		if (jumpscareSound != null)
		{
			config.PlaySound(jumpscareSound, 4.41f);
		}
		yield return new WaitForSeconds(jumpScareDuration);
		config.GameOver();
		jumpScare.SetActive(false);
	}
}
