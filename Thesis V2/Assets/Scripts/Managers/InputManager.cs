using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;
    private bool interactPressed = false;
    private bool contextActionPressed = false;
    private bool runPressed = false;
    private bool escapePressed = false;
    private bool spacePressed = false;
    private bool alcoholPressed = false;
    private bool glovePressed = false;
    private bool maskPressed = false;
    private static InputManager instance;

    private void Awake() {
        if(instance != null){
            Debug.LogError("Found more than one instance of Input Manager in the scene");
        }
        instance = this;
    }

    public static InputManager getInstance(){
        return instance;
    }

    public void AlcoholPressed(InputAction.CallbackContext context){
        if (context.performed){
            alcoholPressed = true;
        } else if (context.canceled){
            alcoholPressed = false;
        }
    }

    public void GlovePressed(InputAction.CallbackContext context){
        if (context.performed){
            glovePressed = true;
        } else if (context.canceled){
            glovePressed = false;
        }
    }

    public void MaskPressed(InputAction.CallbackContext context){
        if (context.performed){
            maskPressed = true;
        } else if (context.canceled){
            maskPressed = false;
        }
    }

    public void SpacePressed(InputAction.CallbackContext context){
        if (context.performed){
            spacePressed = true;
        } else if (context.canceled){
            spacePressed = false;
        }
    }

    public void InteractPressed(InputAction.CallbackContext context){
        if (context.performed){
            interactPressed = true;
        } else if(context.canceled){
            interactPressed = false;
        }
    }

    public void RunPressed(InputAction.CallbackContext context){
        if(context.performed){
            runPressed = true;
        } else if(context.canceled){
            runPressed = false;
        }
    }

    public void EscapePressed(InputAction.CallbackContext context){
        if (context.performed){
            escapePressed = true;
        } else if (context.canceled){
            escapePressed = false;
        }
    }

    public void MovePressed(InputAction.CallbackContext context){
        if(context.performed){
            moveDirection = context.ReadValue<Vector2>();
        } else if(context.canceled){
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    public void ContextActionPressed(InputAction.CallbackContext context){
        if (context.performed){
            contextActionPressed = true;
        } else if (context.canceled){
            contextActionPressed = false;
        }
    }

    public bool getAlcoholPressed(){
        bool result = alcoholPressed;
        alcoholPressed = false;
        return result;
    }

    public bool getGlovePressed(){
        bool result = glovePressed;
        glovePressed = false;
        return result;
    }

    public bool getMaskPressed(){
        bool result = maskPressed;
        maskPressed = false;
        return result;
    }

    public Vector2 GetMovePressed(){
        return moveDirection;
    }

    public Vector2 GetMovePressImpulse(){
        Vector2 result = moveDirection;
        moveDirection = Vector2.zero;
        return result;
    }

    public bool GetInteractPressed(){
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetContextActionPressed(){
        bool result = contextActionPressed;
        contextActionPressed = false;
        return result;
    }

    public bool GetRunPressed(){
        return runPressed;
    }

    public bool GetEscapedPressed(){
        bool result = escapePressed;
        escapePressed = false;
        return result;
    }

    public bool getSpacePressedHold(){
        return spacePressed;
    }

    public bool getSpacePressedImpulse(){
        bool result = spacePressed;
        spacePressed = false;
        return result;
    }
}
