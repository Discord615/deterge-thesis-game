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

    private Vector2 moveDirection;

    private void Start(){
        canvas = gameObject.GetComponent<RectTransform>();
    }

    private void Update(){
        moveDirection = InputManager.getInstance().GetMovePressed();
    }

    private void FixedUpdate(){
        if ((moveDirection.x > 0.1f || moveDirection.x < -0.1f) && !InputManager.getInstance().getSpacePressedHold()){
            syringe.transform.position += new Vector3(moveDirection.x * moveSpeed, 0);
        }
        
        if (syringe.GetComponent<RectTransform>().localPosition.x >= 500) syringe.GetComponent<RectTransform>().localPosition = new Vector3(500, syringe.GetComponent<RectTransform>().localPosition.y, 0);
        if (syringe.GetComponent<RectTransform>().localPosition.x <= -500) syringe.GetComponent<RectTransform>().localPosition = new Vector3(-500, syringe.GetComponent<RectTransform>().localPosition.y, 0);
    }
}
