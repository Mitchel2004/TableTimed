using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadTeacher : MonoBehaviour
{
    [SerializeField] private float disappearDelay;

    [SerializeField] public List<string> names = new List<string>();
    [SerializeField] private List<TextMeshProUGUI> days = new List<TextMeshProUGUI>();

    [SerializeField] private TextMeshProUGUI teacherName;
    [SerializeField] private TextMeshProUGUI availableDays;
    [SerializeField] private TextMeshProUGUI availableTimes;

    private void OnEnable()
    {
        teacherName.text = names[Random.Range(0, names.Count)];
        availableDays.text = days[Random.Range(0, days.Count)].text;
        //availableDays.text += ", " + days[Random.Range(0, days.Count)].text;

        int startTime = Random.Range(9, 16);
        int endTime = Random.Range(startTime + 1, 17);

        availableTimes.text = $"{startTime}:00 – {endTime}:00";

        StartCoroutine(DisappearDelay());
    }

    IEnumerator DisappearDelay()
    {
        yield return new WaitForSeconds(disappearDelay);

        GameObject.Find("Timetable Panel").GetComponent<LoadTimetable>().enabled = true;
        GameObject.Find("Reject").GetComponent<Button>().interactable = true;
        GameObject.Find("Approve").GetComponent<Button>().interactable = true;
        GameObject.Find("Timer").GetComponent<Timer>().enabled = true;

        gameObject.SetActive(false);
    }
}