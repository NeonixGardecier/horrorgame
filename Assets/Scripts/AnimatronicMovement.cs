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
	public GameObject[] positions; //Works based off their numbered positions in the array for the next variable
	public Vector2[] moves; //Value 1 is where the animatronic is moving from, Value 2 is where it can move, multiple entries for multiple choice paths
	public int finalPositionValue; //Array position of the final movement (typically the door)
	public GameObject jumpScare;
	public float jumpScareDuration;

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
		yield return new WaitForSeconds(5f);
		int rnd = Random.Range(0, 100);
		if (rnd <= difficulty)
		{
			if (currentPosition != finalPositionValue)
			{	
				DoMove();
			}else{
				DoJumpScare();
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

	public int[] possibleMoves;
	void DoMove()
	{
		possibleMoves = new int[0];
		for (int i = 0; i < moves.Length; i++)
		{
			if (moves[i].x == currentPosition)
			{
				int[] temp = possibleMoves;
				possibleMoves = new int[possibleMoves.Length + 1];
				for (int o = 0; 0 < temp.Length; o++)
				{
					possibleMoves[o] = temp[0];
				}
				possibleMoves[possibleMoves.Length - 1] = (int)moves[i].y;
			}
		}

		int rnd = Random.Range(0, possibleMoves.Length);
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
		jumpScare.SetActive(true);
		yield return new WaitForSeconds(jumpScareDuration);
		config.GameOver();
	}
}
