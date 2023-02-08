using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    public int currentLevel;

    public void NextLevel()
    {
        currentLevel++;

        GetComponent<TextMeshProUGUI>().text = $"Level: {currentLevel}";
    }
}