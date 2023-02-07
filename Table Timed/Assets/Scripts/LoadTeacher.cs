using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTeacher : MonoBehaviour
{
    [SerializeField] public List<string> names = new List<string>();
    [SerializeField] private List<TextMeshProUGUI> days = new List<TextMeshProUGUI>();

    [SerializeField] private TextMeshProUGUI teacherName;
    [SerializeField] private TextMeshProUGUI availableDays;
    [SerializeField] private TextMeshProUGUI availableTimes;

    private void OnEnable()
    {
        teacherName.text = names[Random.Range(0, names.Count)];
        availableDays.text = days[Random.Range(0, days.Count)].text;
        //availableDays.text += "\n" + days[Random.Range(0, days.Count)];

        int startTime = Random.Range(9, 16);
        int endTime = Random.Range(startTime + 1, 17);

        availableTimes.text = $"{startTime}:00 – {endTime}:00";
    }
}