using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerSeconds;

    [SerializeField] private GameObject gameOverScreen;

    private void Update()
    {
        if(timerSeconds <= 0)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            string minutes = Mathf.FloorToInt(timerSeconds / 60).ToString("00");
            string seconds = (timerSeconds % 60).ToString("00");

            GetComponent<TextMeshProUGUI>().text = $"{minutes}:{seconds}";

            if(GameObject.Find("Teacher Panel") == null)
            {
                timerSeconds -= 1 * Time.deltaTime;
            }
        }
    }

    public void IncreaseTimer(float seconds)
    {
        timerSeconds += seconds;
    }
}