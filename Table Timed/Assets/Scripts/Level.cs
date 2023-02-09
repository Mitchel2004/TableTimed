using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    private int currentLevel = 1;

    public void NextLevel()
    {
        currentLevel++;

        GetComponent<TextMeshProUGUI>().text = $"Level: {currentLevel}";
    }
}