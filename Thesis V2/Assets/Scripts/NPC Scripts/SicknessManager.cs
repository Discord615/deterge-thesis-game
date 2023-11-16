using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SicknessManager : MonoBehaviour
{
    public static SicknessManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(string.Format("There are more than one instance of {0} in current scene", this.name));
        }
        instance = this;
    }

    public bool displayNumberOfSickStudents = false;

    public int numberOfSickStudents = 0;

    [SerializeField] private GameObject studentsObject;

    private void Update()
    {
        if (!displayNumberOfSickStudents) return;

        GameObject.Find("Objective").GetComponent<TextMeshProUGUI>().text = string.Format("Find and talk to sick students\nNumber of sick students roaming: {0}", numberOfSickStudents);
    }

    public void spreadSickness()
    {
        foreach (Transform student in studentsObject.transform)
        {
            if (Random.Range(0, 30) < 9 && !student.gameObject.GetComponent<NPCAnimScript>().isSick)
            {
                student.gameObject.GetComponent<NPCAnimScript>().isSick = true;
                numberOfSickStudents++; // TODO: incrementing for some weird reason..
            }
        }

        if (numberOfSickStudents < 3)
        {
            spreadSickness();
        }
    }
}
