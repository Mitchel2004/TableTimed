using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTimetable : MonoBehaviour
{
    [SerializeField] private LoadTeacher teacher;

    private void Start()
    {
        foreach(GameObject name in GameObject.FindGameObjectsWithTag("Name"))
        {
            if(Random.value >= 0.5f)
            {
                name.GetComponent<TextMeshProUGUI>().text = teacher.names[Random.Range(0, teacher.names.Count)];
            }
        }
    }
}