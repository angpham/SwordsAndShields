using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour
{
    public GameObject resetButton;
    public GameObject quitButton;

    public void HideQuitButton()
    {
        quitButton.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowQuitButton()
    {
        quitButton.transform.localScale = new Vector3(1, 1, 1);
    }

    public void HideResetButton()
    {
        resetButton.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowResetButton()
    {
        resetButton.transform.localScale = new Vector3(1, 1, 1);
    }
}
