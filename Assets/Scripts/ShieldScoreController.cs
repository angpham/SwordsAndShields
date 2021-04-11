using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldScoreController : MonoBehaviour
{
    public int shieldScore = 0;

    public void UpdateShieldScore()
    {
        GetComponent<Text>().text = "Shield: " + shieldScore;
    }
}
