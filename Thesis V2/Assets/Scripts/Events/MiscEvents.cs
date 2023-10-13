using System;

public class MiscEvents
{
    public event Action onPatientSaved;

    public void patientSaved(){
        if (onPatientSaved == null) return;
        onPatientSaved();
    }
}
