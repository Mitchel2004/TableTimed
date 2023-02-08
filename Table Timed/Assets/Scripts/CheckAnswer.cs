using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckAnswer : MonoBehaviour
{
    [SerializeField] private GameObject teacherPanel;
    [SerializeField] private LoadTeacher teacher;

    public void Check()
    {
        //foreach (List<string> hour in GameObject.Find("Timetable Panel").GetComponent<LoadTimetable>().schedule)
        //{
        //    print(hour[0] + " " + hour[1]);
        //}

        foreach(Transform day in GameObject.Find("Timetable Panel").GetComponentInChildren<Transform>())
        {
            foreach(TextMeshProUGUI text in day.GetComponentsInChildren<TextMeshProUGUI>())
            {
                for(int i = 0; i < teacher.teachers.Count; i++)
                {
                    if(teacher.teachers[i].name == text.text && teacher.teachers[i].days.Contains(day.name))
                    {
                        print(day.name);
                    }
                    else
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
                }
            }
        }
    }

    private void Wrong()
    {
        GameObject.Find("Reject").GetComponent<Button>().interactable = false;
        GameObject.Find("Approve").GetComponent<Button>().interactable = false;
        teacherPanel.SetActive(true);
    }

    private void Right()
    {
        GameObject.Find("Level").GetComponent<Level>().NextLevel();
        GameObject.Find("Reject").GetComponent<Button>().interactable = false;
        GameObject.Find("Approve").GetComponent<Button>().interactable = false;
        teacherPanel.SetActive(true);
    }
}