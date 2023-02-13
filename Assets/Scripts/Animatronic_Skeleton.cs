using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatronic_Skeleton : MonoBehaviour
{
	[Header("Dependencies")]
	public NightConfig config;

	[Header("Config")]
	public float difficulty = 0; //0 - 100
	public GameObject jumpScare;
	public GameObject jumpscareSound;
    public float jumpscareSoundDelay;

    public float musicBoxPosition = 1000;
    public float musicCuttoff = 100;
    public GameObject musicOb;
    public GameObject handelSound;
    public GameObject model;
    public Transform handel;

    private bool isHover = false;
    private bool isHolding = false;
    private bool waitStart = true;

    void OnMouseOver()
    {
        isHover = true;
    }

    void OnMouseExit()
    {
        isHover = false;
    }

    void Update()
    {
        if(waitStart == false)
        {
            if (isHover == true)
            {
                if(Input.GetMouseButton(0))
                {
                    isHolding = true;
                    if(musicBoxPosition < 1000){handel.Rotate(-50*Time.deltaTime,0,0); handelSound.SetActive(true);}else{handelSound.SetActive(false); musicOb.SetActive(false);}
                }else{
                    handel.Rotate(50*Time.deltaTime,0,0);
                    musicOb.SetActive(true);
                    handelSound.SetActive(false);
                    isHolding = false;
                }
            }else{
                handel.Rotate(50*Time.deltaTime,0,0);
                musicOb.SetActive(true);
                handelSound.SetActive(false);
                isHolding = false;
            }
        }

        if (difficulty < 1)
        {
            musicOb.SetActive(false);
            handelSound.SetActive(false);           
        }
    }

	void Start()
	{
		StartCoroutine(nightWait());
	}
		
	IEnumerator nightWait()
	{
		yield return new WaitForSeconds(config.nightStartDelay);
        waitStart = false;
		StartCoroutine(musicBoxCycle());
	}

    IEnumerator musicBoxCycle()
    {
        yield return new WaitForSeconds(1f);
        if (isHolding == false){musicBoxPosition -= difficulty;}else{musicBoxPosition += difficulty * 4;}
        DoChecks();
        StartCoroutine(musicBoxCycle());
    }    

    void DoChecks()
    {
        if (musicBoxPosition <= musicCuttoff)
        {
            musicOb.SetActive(false);
        }
        if (musicBoxPosition > musicCuttoff)
        {
            musicOb.SetActive(true);
        }

        if (musicBoxPosition <= 0)
        {
            DoJumpScare();
        }
    }

    void DoJumpScare()
    {
        if (config.jumpScareInProgress == false)
        {
            config.jumpScareInProgress = true;
            model.SetActive(false);
            jumpScare.SetActive(true);

            StartCoroutine(soundWait());
            config.GameOver();
        }
    }

    IEnumerator soundWait()
    {
        yield return new WaitForSeconds(jumpscareSoundDelay);
        config.PlaySound(jumpscareSound, 4.41f);
    }
}
