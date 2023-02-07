using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    public void Check()
    {
        //foreach(List<string> hour in GameObject.Find("Timetable Panel").GetComponent<LoadTimetable>().schedule)
        //{
        //    print(hour[0] + " " + hour[1]);
        //}

        foreach(Transform day in GameObject.Find("Timetable Panel").GetComponentInChildren<Transform>())
        {
            print(day.name);
        }
    }
}