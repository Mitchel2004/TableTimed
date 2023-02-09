using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTimetable : MonoBehaviour
{
    [SerializeField] private List<string> teachers = new List<string>();

    private void OnEnable()
    {
        foreach(GameObject name in GameObject.FindGameObjectsWithTag("Name"))
        {
            name.GetComponent<TextMeshProUGUI>().text = teachers[Random.Range(0, teachers.Count)];
        }

        foreach(GameObject classroom in GameObject.FindGameObjectsWithTag("Classroom"))
        {
            classroom.GetComponent<TextMeshProUGUI>().text = Random.Range(201, 206).ToString("000");
        }
    }
}