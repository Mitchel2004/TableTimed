using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrompt : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] public List<TextMeshProUGUI> days = new List<TextMeshProUGUI>();

    [SerializeField] private float disappearDelay;

    public int randomDay;
    public string randomClassroom;
    public int startTime;

    private void OnEnable()
    {
        GameObject newPrompt = Instantiate(prompt, transform);

        randomDay = Random.Range(0, days.Count);
        randomClassroom = Random.Range(201, 206).ToString("000");
        startTime = Random.Range(9, 16);

        newPrompt.GetComponentInChildren<TextMeshProUGUI>().text = $"{days[randomDay].text}\n{randomClassroom}\n{startTime}:00-{startTime + 1}:00";

        StartCoroutine(DisappearDelay());
    }

    IEnumerator DisappearDelay()
    {
        yield return new WaitForSeconds(disappearDelay);

        GameObject.Find("Timetable Panel").GetComponent<LoadTimetable>().enabled = true;
        GameObject.Find("Reject").GetComponent<Button>().interactable = true;
        GameObject.Find("Approve").GetComponent<Button>().interactable = true;
        GameObject.Find("Timer").GetComponent<Timer>().enabled = true;

        foreach(Transform prompt in transform)
        {
            Destroy(prompt.gameObject);
        }

        gameObject.SetActive(false);
    }
}