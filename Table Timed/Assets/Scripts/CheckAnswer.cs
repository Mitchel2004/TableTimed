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

        //    foreach(Transform day in GameObject.Find("Timetable Panel").GetComponentInChildren<Transform>())
        //    {
        //        foreach(TextMeshProUGUI text in day.GetComponentsInChildren<TextMeshProUGUI>())
        //        {
        //            for(int i = 0; i < teacher.teachers.Count; i++)
        //            {
        //                if(teacher.teachers[i].name == text.text && teacher.teachers[i].days.Contains(day.name))
        //                {
        //                    print(day.name);
        //                }
        //                else
        //                {
        //                    if(name == "Reject")
        //                    {
        //                        Right();
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        Wrong();
        //                        break;
        //                    }
        //                }
        //            }

        //            break;
        //        }

        //        break;
        //    }

        foreach(Transform day in GameObject.Find("Timetable Panel").GetComponentInChildren<Transform>())
        {
            if(day.name == teacher.defaultWeekDays[teacher.randomDay].text)
            {
                int[] times = { 9, 10, 11, 12, 13, 14, 15 };

                Transform timeBlock = day.GetChild(System.Array.IndexOf(times, teacher.startTime) + 1);

                if(timeBlock.Find("Classroom").GetComponent<TextMeshProUGUI>().text == teacher.classroom)
                {
                    print("yes");
                }
                else
                {
                    print("no");
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
        teacherPanel.SetActive(true);
    }

    private void Right()
    {
        GameObject.Find("Timer").GetComponent<Timer>().IncreaseTimer(10f);
        GameObject.Find("Level").GetComponent<Level>().NextLevel();
        GameObject.Find("Reject").GetComponent<Button>().interactable = false;
        GameObject.Find("Approve").GetComponent<Button>().interactable = false;
        GameObject.Find("Timetable Panel").GetComponent<LoadTimetable>().enabled = false;
        teacherPanel.SetActive(true);
    }
}