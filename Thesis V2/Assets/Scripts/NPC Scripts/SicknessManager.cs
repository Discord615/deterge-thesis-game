using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
        int numberOfSickStudents = 0;
        foreach (Transform student in studentsObject.transform)
        {
            if (student.gameObject.GetComponent<NPCAnimScript>().isSick) numberOfSickStudents++;
        }
        if (numberOfSickStudents < 2)
            spreadSickness();
    }

    [SerializeField] private GameObject studentsObject;

    public void spreadSickness()
    {
        foreach (Transform student in studentsObject.transform)
        {
            if (Random.Range(0, 30) < 9)
            {
                student.gameObject.GetComponent<NPCAnimScript>().isSick = true;
            }
        }
    }
}
