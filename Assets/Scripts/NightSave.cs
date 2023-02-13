using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSave : MonoBehaviour
{
    public int level;
    public GameObject[] nights;

    void Start()
    {
        level = PlayerPrefs.GetInt("level", 0);
    }

    void Update()
    {
        PlayerPrefs.SetInt("level", level);

        for(int i = 0; i < nights.Length; i++)
        {
            if (level >= i)
            {
                nights[i].SetActive(true);
            }
        }
    }
}
