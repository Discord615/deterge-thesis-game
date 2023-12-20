using System;
using UnityEngine;

public class MiscEvents
{
    public event Action onPatientSaved;

    public void patientSaved()
    {
        onPatientSaved?.Invoke();
    }

    public event Action onPatientKilled;

    public void patientKilled()
    {
        onPatientKilled?.Invoke();
    }

    public event Action onSampleCollected;

    public void sampleCollected()
    {
        onSampleCollected?.Invoke();
    }

    public event Action onTalkToSickStudent;

    public void talkToStudent()
    {
        onTalkToSickStudent?.Invoke();
    }

    public event Action onPlayerGetMeds;

    public void playerGetsMeds()
    {
        onPlayerGetMeds?.Invoke();
    }

    public event Action onPlayerLosesMeds;

    public void playerLostMeds(){
        onPlayerLosesMeds?.Invoke();
    }

    public event Action onPlayerZeroMeds;

    public void playerZeroMeds(){
        onPlayerZeroMeds?.Invoke();
    }

    public event Action onSequenceCompleted;

    public void sequenceCompleted()
    {
        onSequenceCompleted?.Invoke();
    }

    public event Action onSequenceFailed;

    public void sequenceFailed()
    {
        onSequenceFailed?.Invoke();
    }

    public event Action onWordSearchComplete;

    public void wordSearchCompleted()
    {
        onWordSearchComplete?.Invoke();
    }

    public event Action onWordFound;

    public void wordFound()
    {
        onWordFound?.Invoke();
    }

    public event Action onPatientZeroFound;

    public void patientZeroFound(){
        onPatientZeroFound?.Invoke();
    }

    public event Action LetterFound;

    public void onLetterFound(){
        onWordFound?.Invoke();
    }
}
