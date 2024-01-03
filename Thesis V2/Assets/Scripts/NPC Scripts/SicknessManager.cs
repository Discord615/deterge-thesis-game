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

    public int numberOfSickStudents = 0;
    [SerializeField] private int targetSickStudents = 5;

    [SerializeField] private GameObject studentsObject;
    [SerializeField] private GameObject[] beds;

    public void spreadSickness()
    {
        foreach (Transform student in studentsObject.transform)
        {
            if (Random.Range(0, 30) < 13 && student.GetComponent<Unit>().floor == 1 && student.gameObject.activeInHierarchy)
            {
                student.GetComponent<NPCAnimScript>().isSick = true;
                student.GetComponent<Unit>().target = UnitTargetManager.GetInstance().getAnyGameObjectTarget(student.GetComponent<Unit>().floor, student.gameObject);
                numberOfSickStudents++;
            }

            if (numberOfSickStudents > targetSickStudents) break;
        }
    }

    public void showPatientZero(){
        Transform student = studentsObject.transform.GetChild(Random.Range(0, studentsObject.transform.childCount));

        while (true){
                student = studentsObject.transform.GetChild(Random.Range(0, studentsObject.transform.childCount));
            if (student.GetComponent<Unit>().floor == 1 && student.gameObject.activeInHierarchy) {
                break;
            }
        }

        student.GetComponent<MiscScript>().isPatientZero = true;
        student.GetComponent<NPCAnimScript>().isSick = true;
        student.GetComponent<Unit>().target = UnitTargetManager.GetInstance().getAnyGameObjectTarget(student.GetComponent<Unit>().floor, student.gameObject);
    }

    public Transform getPatientZero(){
        Transform student = null;

        foreach (Transform item in studentsObject.transform)
        {
            if (!item.GetComponent<MiscScript>().isPatientZero) continue;
            student = item;
            break;
        }

        return student;
    }

    public void resetAllBeds(){
        foreach (GameObject bed in beds)
        {
            bed.GetComponent<LayDown>().playerHasMeds = false;

            bed.GetComponent<LayDown>().sampleTaken = false;
        }
    }
}
