using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonCondition : MonoBehaviour
{
    public GameObject optionPannel;

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
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
