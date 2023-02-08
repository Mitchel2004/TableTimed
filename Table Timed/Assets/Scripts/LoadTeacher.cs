using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadTeacher : MonoBehaviour
{
    [SerializeField] private GameObject teacher;

    private int playableTeachers;
    [SerializeField] public List<string> defaultNames = new List<string>();
    private List<string> names = new List<string>();

    private int availableDays;
    [SerializeField] private List<TextMeshProUGUI> defaultWeekDays = new List<TextMeshProUGUI>();
    private List<TextMeshProUGUI> weekDays = new List<TextMeshProUGUI>();

    private float disappearDelay;

    [System.Serializable]
    public struct TeacherInformation
    {
        public string name;
        public List<string> days;
    }

    public TeacherInformation teacherInformation = new TeacherInformation();
    public List<TeacherInformation> teachers = new List<TeacherInformation>();

    private void OnEnable()
    {
        if (GameObject.Find("Level").GetComponent<Level>().currentLevel % 10 == 0 && playableTeachers < 3)
        {
            playableTeachers++;
            disappearDelay += 5;
        }

        if (GameObject.Find("Level").GetComponent<Level>().currentLevel % 5 == 0 && availableDays < 3)
        {
            availableDays++;
        }

        teachers.Clear();

        names.Clear();
        names.AddRange(defaultNames);

        teacherInformation.days.Clear();

        for (int playingTeachers = 0; playingTeachers < playableTeachers; playingTeachers++)
        {
            weekDays.Clear();
            weekDays.AddRange(defaultWeekDays);

            GameObject instantiatedTeacher = Instantiate(teacher, transform);

            int randomName = Random.Range(0, names.Count);

            teacherInformation.name = names[randomName];
            names.RemoveAt(randomName);

            for(int day = 0; day < availableDays; day++)
            {
                int randomDay = Random.Range(0, weekDays.Count);

                teacherInformation.days.Add(weekDays[randomDay].text);
                weekDays.RemoveAt(randomDay);
            }

            instantiatedTeacher.GetComponentInChildren<TextMeshProUGUI>().text = teacherInformation.name + "\n";

            foreach(string day in teacherInformation.days)
            {
                int startTime = Random.Range(9, 16);
                int endTime = Random.Range(startTime + 1, 17);

                instantiatedTeacher.GetComponentInChildren<TextMeshProUGUI>().text += $"\n{day}, {startTime}:00-{endTime}:00";
            }
            
            teachers.Add(teacherInformation);
        }

        StartCoroutine(DisappearDelay());
    }

    IEnumerator DisappearDelay()
    {
        yield return new WaitForSeconds(disappearDelay);

        GameObject.Find("Timetable Panel").GetComponent<LoadTimetable>().enabled = true;
        GameObject.Find("Reject").GetComponent<Button>().interactable = true;
        GameObject.Find("Approve").GetComponent<Button>().interactable = true;
        GameObject.Find("Timer").GetComponent<Timer>().enabled = true;

        foreach (Transform teacher in transform)
        {
            Destroy(teacher.gameObject);
        }

        gameObject.SetActive(false);
    }
}