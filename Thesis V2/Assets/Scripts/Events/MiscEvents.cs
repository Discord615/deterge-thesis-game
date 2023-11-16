using System;
using UnityEngine;

public class MiscEvents
{
    public event Action onPatientSaved;

    public void patientSaved()
    {
        onPatientSaved?.Invoke();
    }

    public event Action onSampleCollected;

    public void sampleCollected(){
        onSampleCollected?.Invoke();
    }

    public event Action onTalkToSickStudent;

    public void talkToStudent(){
        onTalkToSickStudent?.Invoke();
    }

    public event Action onPlayerGetMeds;

    public void playerGetsMeds(){
        onPlayerGetMeds?.Invoke();
    }

    public static event Action onSequenceCompleted;

    public void sequenceCompleted()
    {
        onSequenceCompleted?.Invoke();
    }

    public static event Action onSequenceFailed;

    public void sequenceFailed()
    {
        onSequenceFailed?.Invoke();
    }
}
