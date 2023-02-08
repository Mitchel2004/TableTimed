using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTimetable : MonoBehaviour
{
    [SerializeField] private LoadTeacher teacher;

    public List<List<string>> schedule = new List<List<string>>();

    private void OnEnable()
    {
        foreach(GameObject name in GameObject.FindGameObjectsWithTag("Name"))
        {
            //if (Random.value >= 0.5f)
            //{
            //    name.GetComponent<TextMeshProUGUI>().text = teacher.defaultNames[Random.Range(0, teacher.defaultNames.Count)];

            //    name.transform.parent.Find("Classroom").GetComponent<TextMeshProUGUI>().text = Random.Range(1, 200).ToString("000");

            //    List<string> hour = new List<string>();
            //    hour.Add(name.GetComponent<TextMeshProUGUI>().text);
            //    hour.Add(name.transform.parent.Find("Classroom").GetComponent<TextMeshProUGUI>().text);

            //    schedule.Add(hour);
            //}

            name.GetComponent<TextMeshProUGUI>().text = teacher.defaultNames[Random.Range(0, teacher.defaultNames.Count)];
            name.transform.parent.Find("Classroom").GetComponent<TextMeshProUGUI>().text = Random.Range(201, 206).ToString("000");
        }
    }
}