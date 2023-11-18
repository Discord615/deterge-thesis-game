using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SicknessManager : MonoBehaviour, IDataPersistence
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

    public void spreadSickness()
    {
        foreach (Transform student in studentsObject.transform)
        {
            if (Random.Range(0, 30) < 13)
            {
                student.GetComponent<NPCAnimScript>().isSick = true;
                numberOfSickStudents++;
            }
        }
    }

    public void LoadData(GameData data)
    {
        displayNumberOfSickStudents = data.displayNumberOfSickStudentsData;
        numberOfSickStudents = data.numberOfSickStudentsData;
    }

    public void SaveData(ref GameData data)
    {
        data.displayNumberOfSickStudentsData = displayNumberOfSickStudents;
        data.numberOfSickStudentsData = numberOfSickStudents;
    }
}
