using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("Movement Variables")]
    [SerializeField] private float transitionSpeedAcceleration;
    [SerializeField] private float transitionSpeedDecceleration;
    [SerializeField] private Movement movement;

    private float maxSpeed;
    public float blendValue { get; private set; } = 0f;
    

    private void Update(){
        if (MinigameManager.instance.syringeGame.activeInHierarchy || MinigameManager.instance.onBeatGame.activeInHierarchy) {
            StoppingBlend();
            animator.SetFloat("Blend", blendValue);
            return;
        }

        maxSpeed = InputManager.getInstance().GetRunPressed() ? 2 : 1;

        if (movement.moveDirection != Vector2.zero && !DialogueManagaer.GetInstance().dialogueIsPlaying) {
            MovingBlend();
        } else {
            StoppingBlend();
        }

        animator.SetFloat("Blend", blendValue);
    }

    private void MovingBlend(){
        if (blendValue < maxSpeed){
            blendValue += transitionSpeedAcceleration * Time.deltaTime;
        }

        if (maxSpeed == 1){
            if (blendValue > 1.05f){
                blendValue -= transitionSpeedDecceleration * Time.deltaTime * 1.5f;
            } else {
                if (blendValue >= maxSpeed - 0.05f){
                    blendValue = maxSpeed;
                }
            }
        }
    }

    private void StoppingBlend(){
        if (blendValue > 0){
            if (blendValue > 1){
                blendValue -= transitionSpeedDecceleration * Time.deltaTime * 3;
            } else {
                blendValue -= transitionSpeedDecceleration * Time.deltaTime * 2;
            }
        }

        if (blendValue <= 0.05f) {
            blendValue = 0;
        }
    }

}
