using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimScript : MonoBehaviour
{
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
    public bool wantToSit = false; // TODO: Anim - Should base off of the target name/tag. If Chair then wantToSit = false
    public bool isSitting = false; 
    

    private void Start() {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update() {
        if (!stopped){
            if (slowDown){
                if (speed < 0.05f){
                    speed = 0;
                    stopped = true;
                    slowDown = false;
                }

                speed -= deccelarationSpeed * Time.deltaTime;
            } else {
                speed += accelarationSpeed * Time.deltaTime;
            }

            if (speed > 1f) speed = 1f;
        }

        animator.SetFloat("Speed", speed);
    }
}
