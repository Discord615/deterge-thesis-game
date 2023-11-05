using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public class BottleBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bottleLabel;
    public string medLabel;

    private void Update()
    {
        bottleLabel.text = medLabel;
    }

    /* 
        TODO: Add trigger enter that checks if syringe is on top of the bottle and checks for space input.

        TODO: If space was pressed then pass the medicine label and syringe script will check if it is the right medicine for the given virus.
    */
}