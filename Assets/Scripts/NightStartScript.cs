using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NightStartScript : MonoBehaviour
{
    public string scene;

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

    public bool doText = true;
    public TextMeshProUGUI bartenderLevelText;
    public TextMeshProUGUI securityLevelText;
    public TextMeshProUGUI singerLevelText;
    public TextMeshProUGUI waitressLevelText;
    public TextMeshProUGUI skeletonLevelText;
    public TextMeshProUGUI chefLevelText;

    public Nightruntime nrun;

    public void LoadScene()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    void Update()
    {
        nrun.bartenderDifficulty = bartenderDifficulty;
        nrun.securitybotDifficulty = securitybotDifficulty;
        nrun.singerDifficulty = singerDifficulty;
        nrun.waitressDifficulty = waitressDifficulty;
        nrun.skeletonDifficulty = skeletonDifficulty;
        nrun.chefDifficulty = chefDifficulty;

        UpdateText();
    }

    void UpdateConstraints()
    {
        if(bartenderDifficulty < -1)
        {
            bartenderDifficulty = -1;
        }
        if(bartenderDifficulty > 100)
        {
            bartenderDifficulty = 100;
        }

        if(securitybotDifficulty < -1)
        {
            securitybotDifficulty = -1;
        }
        if(securitybotDifficulty > 100)
        {
            securitybotDifficulty = 100;
        }

        if(singerDifficulty < -1)
        {
            singerDifficulty = -1;
        }
        if(singerDifficulty > 100)
        {
            singerDifficulty = 100;
        }

        if(waitressDifficulty < -1)
        {
            waitressDifficulty = -1;
        }
        if(waitressDifficulty > 100)
        {
            waitressDifficulty = 100;
        }

        if(skeletonDifficulty < -1)
        {
            skeletonDifficulty = -1;
        }
        if(skeletonDifficulty > 100)
        {
            skeletonDifficulty = 100;
        }

        if(chefDifficulty < -1)
        {
            chefDifficulty = -1;
        }
        if(chefDifficulty > 100)
        {
            chefDifficulty = 100;
        }
    }

    void UpdateText()
    {
        if (doText)
        {
            if(bartenderDifficulty >= 0){bartenderLevelText.text = "" + bartenderDifficulty;}else{bartenderLevelText.text = "off";}
            if(securitybotDifficulty >= 0){securityLevelText.text = "" + securitybotDifficulty;}else{securityLevelText.text = "off";}
            if(singerDifficulty >= 0){singerLevelText.text = "" + singerDifficulty;}else{singerLevelText.text = "off";}
            if(waitressDifficulty >= 0){waitressLevelText.text = "" + waitressDifficulty;}else{waitressLevelText.text = "off";}
            if(skeletonDifficulty >= 0){skeletonLevelText.text = "" + skeletonDifficulty;}else{skeletonLevelText.text = "off";}
            if(chefDifficulty >= 0){chefLevelText.text = "" + chefDifficulty;}else{chefLevelText.text = "off";}
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            amount = 10;
        }else{amount = 1;}

        UpdateConstraints();
    }
    private int amount;
    public void addDifficulty(int character)
    {

        switch(character)
        {
            case 1: bartenderDifficulty += amount; break;
            case 2: securitybotDifficulty += amount; break;
            case 3: singerDifficulty += amount; break;
            case 4: waitressDifficulty += amount; break;
            case 5: skeletonDifficulty += amount; break;
            case 6: chefDifficulty += amount; break;
            default: Debug.Log("error"); break;
        }
    }

    public void lowerDifficulty(int character)
    {
        switch(character)
        {
            case 1: bartenderDifficulty -= amount; break;
            case 2: securitybotDifficulty -= amount; break;
            case 3: singerDifficulty -= amount; break;
            case 4: waitressDifficulty -= amount; break;
            case 5: skeletonDifficulty -= amount; break;
            case 6: chefDifficulty -= amount; break;
            default: Debug.Log("error"); break;
        }
    }

    public void SetBartenderDifficulty(int level)
    {
        bartenderDifficulty = level;
    }
    public void SetSecurityDifficulty(int level)
    {
        securitybotDifficulty = level;
    }
    public void SetSingerDifficulty(int level)
    {
        singerDifficulty = level;
    }
    public void SetWaitressDifficulty(int level)
    {
        waitressDifficulty = level;
    }
    public void SetSkeletonDifficulty(int level)
    {
        skeletonDifficulty = level;
    }
    public void SetChefDifficulty(int level)
    {
        chefDifficulty = level;
    }
}
