using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightruntime : MonoBehaviour
{
    [Range(-1, 100)]
    public int bartenderDifficulty;
    [Range(-1, 100)]
    public int securitybotDifficulty;
    [Range(-1, 100)]
    public int singerDifficulty;
    [Range(-1, 100)]
    public int waitressDifficulty;
    [Range(-1, 100)]
    public int skeletonDifficulty;
    [Range(-1, 100)]
    public int chefDifficulty;

    public GameObject player;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        player = GameObject.Find("PLAYER");

        UpdateDifficulties();
    }

    void UpdateDifficulties()
    {
        if (player != null)
        {
            player.GetComponent<NightConfig>().bartender.difficulty = bartenderDifficulty;
            player.GetComponent<NightConfig>().singer.difficulty = singerDifficulty;
            player.GetComponent<NightConfig>().securitybot.difficulty = securitybotDifficulty;
            player.GetComponent<NightConfig>().waitress.difficulty = waitressDifficulty;
            player.GetComponent<NightConfig>().chef.difficulty = chefDifficulty;
            player.GetComponent<NightConfig>().skeleton.difficulty = skeletonDifficulty;
        }
    }

}
