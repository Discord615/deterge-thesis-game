using System;

public class MiscEvents
{
    public event Action onPatientSaved;

    public void patientSaved()
    {
        onPatientSaved?.Invoke();
    }

    // TODO: use event to check if patient was saved from seizure
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
