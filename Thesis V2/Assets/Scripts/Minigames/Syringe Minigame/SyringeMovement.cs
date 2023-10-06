using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SyringeMovement : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject syringe;
    [SerializeField] private float moveSpeed = 2f;

    private RectTransform canvas;
    private float syringeStartPos;

    private Vector2 moveDirection;

    private void Start(){
        canvas = gameObject.GetComponent<RectTransform>();
        syringeStartPos = -canvas.rect.x;
    }

    private void Update(){
        moveDirection = InputManager.getInstance().GetMovePressed();
        syringeStartPos = -canvas.rect.x;
    }

    private void FixedUpdate(){
        if ((moveDirection.x > 0.1f || moveDirection.x < -0.1f) && !InputManager.getInstance().getSpacePressedHold()){
            syringe.transform.position += new Vector3(moveDirection.x * moveSpeed, 0);
        }

        if (syringe.transform.position.x >= syringeStartPos + (syringeStartPos * .4585f) - 0.05f) syringe.transform.position = new Vector3(syringeStartPos + (syringeStartPos * .4585f), syringe.transform.position.y);
        if (syringe.transform.position.x <= syringeStartPos - (syringeStartPos * .4585f) + 0.05f) syringe.transform.position = new Vector3(syringeStartPos - (syringeStartPos * .4585f), syringe.transform.position.y);
    }
}
