using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerSeconds;

    private void Update()
    {
        if(timerSeconds <= 0)
        {
            Debug.Log("Game Over");
        }
        else
        {
            string minutes = Mathf.FloorToInt(timerSeconds / 60).ToString("00");
            string seconds = (timerSeconds % 60).ToString("00");

            GetComponent<TextMeshProUGUI>().text = $"{minutes}:{seconds}";

            timerSeconds -= 1 * Time.deltaTime;
        }
    }
}