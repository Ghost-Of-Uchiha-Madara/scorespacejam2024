using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonCondition : MonoBehaviour
{
    public GameObject optionPannel;

    public void ChangeScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OptionPannelEnable()
    {
        optionPannel.SetActive(true);
    }

    public void OptionPannelDisable()
    {
        optionPannel.SetActive(false);
    }
}
