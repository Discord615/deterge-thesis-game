using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed;

    [Header("Misc")]
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private PlayerAnim playerAnim;


    public Vector2 moveDirection { get; private set; } = Vector2.zero;

    void Update()
    {
        moveDirection = InputManager.getInstance().GetMovePressed();

        if (DialogueManager.instance.dialogueIsPlaying)
        {
            playerBody.isKinematic = true;
            playerBody.velocity = Vector3.zero;
        }
        else playerBody.isKinematic = false;

        if (TeleportManager.GetInstance().goingToTeleport) return;

        if (MinigameManager.instance.syringeGame.activeInHierarchy) return;
        if (MinigameManager.instance.onBeatGame.activeInHierarchy) return;
        if (MinigameManager.instance.sequenceGame.activeInHierarchy) return;

        if (DialogueManager.instance.dialogueIsPlaying) return;

        rotate();
        playerBody.velocity = MoveRelativeToCamera() * ((InputManager.getInstance().GetRunPressed() ? 2.5f : 1) * moveSpeed);
    }

    private void rotate()
    {
        if (moveDirection != Vector2.zero)
        {
            Vector3 moveDirectionV3 = new Vector3(MoveRelativeToCamera().x, 0, MoveRelativeToCamera().z);
            Quaternion rotation = Quaternion.LookRotation(moveDirectionV3, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    private Vector3 MoveRelativeToCamera()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelativeVertical = moveDirection.y * forward;
        Vector3 rightRelativeVertical = moveDirection.x * right;

        Vector3 cameraRelativeMovement = forwardRelativeVertical + rightRelativeVertical;

        return cameraRelativeMovement;
    }
}
