using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckAnswer : MonoBehaviour
{
    [SerializeField] private LoadPrompt prompt;

    public void Check()
    {
        foreach(Transform day in GameObject.Find("Timetable Panel").GetComponentInChildren<Transform>())
        {
            if(day.name == prompt.days[prompt.randomDay].text)
            {
                int[] times = { 9, 10, 11, 12, 13, 14, 15 };

                Transform timeBlock = day.GetChild(Array.IndexOf(times, prompt.startTime) + 1);

                if(timeBlock.Find("Classroom").GetComponent<TextMeshProUGUI>().text == prompt.randomClassroom)
                {
                    if(name == "Reject")
                    {
                        Right();
                    }
                    else
                    {
                        Wrong();
                    }
                }
                else
                {
                    if(name == "Reject")
                    {
                        Wrong();
                    }
                    else
                    {
                        Right();
                    }
                }

                break;
            }
        }
    }

    private void Wrong()
    {
        GameObject.Find("Reject").GetComponent<Button>().interactable = false;
        GameObject.Find("Approve").GetComponent<Button>().interactable = false;
        GameObject.Find("Timetable Panel").GetComponent<LoadTimetable>().enabled = false;

        prompt.gameObject.SetActive(true);
    }

    private void Right()
    {
        GameObject.Find("Timer").GetComponent<Timer>().IncreaseTimer(5f);
        GameObject.Find("Level").GetComponent<Level>().NextLevel();

        GameObject.Find("Reject").GetComponent<Button>().interactable = false;
        GameObject.Find("Approve").GetComponent<Button>().interactable = false;
        GameObject.Find("Timetable Panel").GetComponent<LoadTimetable>().enabled = false;

        prompt.gameObject.SetActive(true);
    }
}