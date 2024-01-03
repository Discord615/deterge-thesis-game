//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0d523022-9431-46ce-81a4-f419c9281a24"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""ba7fe6f7-86f6-43f1-ab38-d99ead61a870"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ContextAction"",
                    ""type"": ""Button"",
                    ""id"": ""83a17e31-9705-4420-b105-86c4c73ed031"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c5858260-3a5e-4249-85ba-1f590831adbb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""adf50e7f-bf96-44ca-9dec-72029118d3f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""dc71e246-2be8-4c19-ac00-8a0773b7e9ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AlcoholBind"",
                    ""type"": ""Button"",
                    ""id"": ""a0249766-c24d-4c69-a666-5de51ff41539"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GloveBind"",
                    ""type"": ""Button"",
                    ""id"": ""dbf670eb-2a89-49ac-836c-4eb716795c25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MaskBind"",
                    ""type"": ""Button"",
                    ""id"": ""915c609d-0607-42ba-aabb-3240ef98b2b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""8e39dea7-719e-4e6f-90ab-549eccb979b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Encyclopedia"",
                    ""type"": ""Button"",
                    ""id"": ""c2fbe264-98e9-4a2a-9d83-866ae78d563c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""d3f3e136-29fc-4a52-9dd6-948a0ef7c1df"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Mouse Left Click"",
                    ""type"": ""Button"",
                    ""id"": ""f077d025-4630-49ea-a66e-a4dbad1bd147"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""611c7f8e-a2be-4c40-8cfa-0430dc13b7e3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc8abcc3-0fbe-4924-a57d-1511b22a8a83"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c1a83d4-fe99-49c1-9266-fee0de125065"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContextAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c9ce3682-5dde-437b-8d0d-a51099f4b2da"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c0dca72e-e7d1-4f97-8fe6-e30949a14312"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2d9ba764-4014-470f-84a5-2091d4a5c940"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f49f8c36-db7a-4a7e-9dbd-6a51ebf28832"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c14b4898-58ea-42cc-a5aa-ee5f2c84ed89"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""c1bd7e57-db02-4571-8a9e-0dbb8b240bcd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b20e0ec0-ee0c-4a5f-bf2f-e3335a3c7395"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""aeeedabf-50e7-4354-bab7-de1d7f7456bf"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6fbfc61b-bed2-4c32-ba8e-fa2138aa04bd"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""03f03f13-3acd-46e5-811c-c75fa2339bdb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""acb259e3-e9ef-4ca1-ac07-d9da9bf444df"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35a96ea7-2b3b-46b2-a77d-2ae62da6ca94"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0f0f8dd-b348-44b3-a686-608cd03e5808"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20fadfb0-538e-41ec-b83e-31a67dc785bc"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AlcoholBind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03e15806-ab36-4225-b7d6-c05042bcc450"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GloveBind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e3d1da8-7f05-4778-8aab-b21505b41884"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MaskBind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dfcd921-367c-4dee-9b49-bd80ada088fc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f29972f-5029-4b77-a38b-50ae924a4f0a"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Encyclopedia"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aaafa9e3-b3eb-4976-9602-0e8bb4d3b162"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""117bce1a-53b4-488d-8524-6dfe7d885060"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Left Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4712486-b433-4a47-a401-4000b77696c6"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_ContextAction = m_Player.FindAction("ContextAction", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_AlcoholBind = m_Player.FindAction("AlcoholBind", throwIfNotFound: true);
        m_Player_GloveBind = m_Player.FindAction("GloveBind", throwIfNotFound: true);
        m_Player_MaskBind = m_Player.FindAction("MaskBind", throwIfNotFound: true);
        m_Player_Space = m_Player.FindAction("Space", throwIfNotFound: true);
        m_Player_Encyclopedia = m_Player.FindAction("Encyclopedia", throwIfNotFound: true);
        m_Player_Mouse = m_Player.FindAction("Mouse", throwIfNotFound: true);
        m_Player_MouseLeftClick = m_Player.FindAction("Mouse Left Click", throwIfNotFound: true);
        m_Player_MouseScroll = m_Player.FindAction("Mouse Scroll", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_ContextAction;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_AlcoholBind;
    private readonly InputAction m_Player_GloveBind;
    private readonly InputAction m_Player_MaskBind;
    private readonly InputAction m_Player_Space;
    private readonly InputAction m_Player_Encyclopedia;
    private readonly InputAction m_Player_Mouse;
    private readonly InputAction m_Player_MouseLeftClick;
    private readonly InputAction m_Player_MouseScroll;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @ContextAction => m_Wrapper.m_Player_ContextAction;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @AlcoholBind => m_Wrapper.m_Player_AlcoholBind;
        public InputAction @GloveBind => m_Wrapper.m_Player_GloveBind;
        public InputAction @MaskBind => m_Wrapper.m_Player_MaskBind;
        public InputAction @Space => m_Wrapper.m_Player_Space;
        public InputAction @Encyclopedia => m_Wrapper.m_Player_Encyclopedia;
        public InputAction @Mouse => m_Wrapper.m_Player_Mouse;
        public InputAction @MouseLeftClick => m_Wrapper.m_Player_MouseLeftClick;
        public InputAction @MouseScroll => m_Wrapper.m_Player_MouseScroll;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @ContextAction.started += instance.OnContextAction;
            @ContextAction.performed += instance.OnContextAction;
            @ContextAction.canceled += instance.OnContextAction;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @AlcoholBind.started += instance.OnAlcoholBind;
            @AlcoholBind.performed += instance.OnAlcoholBind;
            @AlcoholBind.canceled += instance.OnAlcoholBind;
            @GloveBind.started += instance.OnGloveBind;
            @GloveBind.performed += instance.OnGloveBind;
            @GloveBind.canceled += instance.OnGloveBind;
            @MaskBind.started += instance.OnMaskBind;
            @MaskBind.performed += instance.OnMaskBind;
            @MaskBind.canceled += instance.OnMaskBind;
            @Space.started += instance.OnSpace;
            @Space.performed += instance.OnSpace;
            @Space.canceled += instance.OnSpace;
            @Encyclopedia.started += instance.OnEncyclopedia;
            @Encyclopedia.performed += instance.OnEncyclopedia;
            @Encyclopedia.canceled += instance.OnEncyclopedia;
            @Mouse.started += instance.OnMouse;
            @Mouse.performed += instance.OnMouse;
            @Mouse.canceled += instance.OnMouse;
            @MouseLeftClick.started += instance.OnMouseLeftClick;
            @MouseLeftClick.performed += instance.OnMouseLeftClick;
            @MouseLeftClick.canceled += instance.OnMouseLeftClick;
            @MouseScroll.started += instance.OnMouseScroll;
            @MouseScroll.performed += instance.OnMouseScroll;
            @MouseScroll.canceled += instance.OnMouseScroll;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @ContextAction.started -= instance.OnContextAction;
            @ContextAction.performed -= instance.OnContextAction;
            @ContextAction.canceled -= instance.OnContextAction;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @AlcoholBind.started -= instance.OnAlcoholBind;
            @AlcoholBind.performed -= instance.OnAlcoholBind;
            @AlcoholBind.canceled -= instance.OnAlcoholBind;
            @GloveBind.started -= instance.OnGloveBind;
            @GloveBind.performed -= instance.OnGloveBind;
            @GloveBind.canceled -= instance.OnGloveBind;
            @MaskBind.started -= instance.OnMaskBind;
            @MaskBind.performed -= instance.OnMaskBind;
            @MaskBind.canceled -= instance.OnMaskBind;
            @Space.started -= instance.OnSpace;
            @Space.performed -= instance.OnSpace;
            @Space.canceled -= instance.OnSpace;
            @Encyclopedia.started -= instance.OnEncyclopedia;
            @Encyclopedia.performed -= instance.OnEncyclopedia;
            @Encyclopedia.canceled -= instance.OnEncyclopedia;
            @Mouse.started -= instance.OnMouse;
            @Mouse.performed -= instance.OnMouse;
            @Mouse.canceled -= instance.OnMouse;
            @MouseLeftClick.started -= instance.OnMouseLeftClick;
            @MouseLeftClick.performed -= instance.OnMouseLeftClick;
            @MouseLeftClick.canceled -= instance.OnMouseLeftClick;
            @MouseScroll.started -= instance.OnMouseScroll;
            @MouseScroll.performed -= instance.OnMouseScroll;
            @MouseScroll.canceled -= instance.OnMouseScroll;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnContextAction(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnAlcoholBind(InputAction.CallbackContext context);
        void OnGloveBind(InputAction.CallbackContext context);
        void OnMaskBind(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
        void OnEncyclopedia(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnMouseLeftClick(InputAction.CallbackContext context);
        void OnMouseScroll(InputAction.CallbackContext context);
    }
}
