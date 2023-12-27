using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimScript : MonoBehaviour
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    Animator animator;

    [SerializeField] float speed;
    [SerializeField] float deccelarationSpeed = 0.5f;
    [SerializeField] float accelarationSpeed = 1f;

    [Header("Bed Variables")]
    public bool isSick = false;
    public bool isLayingDown = false;
    public bool slowDown = false;
    public bool stopped = false;

    [Header("Chair Variables")]
    public bool wantToSit = false;
    public bool isSitting = false;

    [SerializeField] private Material skinColor;
    private Color originalSkinColor, sickSkinColor, patientZeroSkinColor;


    private void Start()
    {
        originalSkinColor = new Color(0.772549f, 0.6980392f, 0.5529411f);
        sickSkinColor = new Color(0.6552206f, 0.7169812f, 0.4430402f);
        patientZeroSkinColor = Color.red;
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Color color;
        color = originalSkinColor;
        if (isSick) color = GetComponent<MiscScript>().isPatientZero ? patientZeroSkinColor : sickSkinColor;

        skinColor.color = color;

        updateSpeed();

        animator.SetFloat("Speed", speed);
    }

    private void updateSpeed()
    {
        if (stopped)
        {
            speed = 0;
            return;
        }

        if (speed > 1f) speed = 1f;

        if (!slowDown)
        {
            speed += accelarationSpeed * Time.deltaTime;
            return;
        }

        speed -= deccelarationSpeed * Time.deltaTime;

        if (speed < 0.05f)
        {
            speed = 0;
            stopped = true;
            slowDown = false;
        }
    }
}
