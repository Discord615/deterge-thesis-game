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
}