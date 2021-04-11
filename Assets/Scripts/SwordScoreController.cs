using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordScoreController : MonoBehaviour
{
    public int swordScore = 0;

    public void UpdateSwordScore()
    {
        GetComponent<Text>().text = "Sword: " + swordScore;
    }
}
