// GENERATED AUTOMATICALLY FROM 'Assets/Input/actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Actions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""actions"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""9bb2249e-0f98-442c-bbcc-0e2a0877d9fc"",
            ""actions"": [
                {
                    ""name"": ""DAction"",
                    ""type"": ""Button"",
                    ""id"": ""3499da98-f339-44c1-8c98-9c067701ec74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FAction"",
                    ""type"": ""Button"",
                    ""id"": ""c2c44268-7a0a-498b-be1c-d8c81cff17a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JAction"",
                    ""type"": ""Button"",
                    ""id"": ""5fbbb855-2a15-4ef0-9155-4b0e0510feef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""KAction"",
                    ""type"": ""Button"",
                    ""id"": ""787d43e7-cf40-4e41-b82e-70d12dc9d7fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""095bc27b-d941-4016-946a-8a3bc974f8d0"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fae6022-c3ac-4273-b1b8-92c60529eb53"",
                    ""path"": ""<Keyboard>/#(F)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1a756b1-5311-47e4-9e9c-b4765ceab643"",
                    ""path"": ""<Keyboard>/#(J)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0797c625-0769-465a-a7c3-35b759d630c2"",
                    ""path"": ""<Keyboard>/#(K)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_DAction = m_Controls.FindAction("DAction", throwIfNotFound: true);
        m_Controls_FAction = m_Controls.FindAction("FAction", throwIfNotFound: true);
        m_Controls_JAction = m_Controls.FindAction("JAction", throwIfNotFound: true);
        m_Controls_KAction = m_Controls.FindAction("KAction", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_DAction;
    private readonly InputAction m_Controls_FAction;
    private readonly InputAction m_Controls_JAction;
    private readonly InputAction m_Controls_KAction;
    public struct ControlsActions
    {
        private @Actions m_Wrapper;
        public ControlsActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @DAction => m_Wrapper.m_Controls_DAction;
        public InputAction @FAction => m_Wrapper.m_Controls_FAction;
        public InputAction @JAction => m_Wrapper.m_Controls_JAction;
        public InputAction @KAction => m_Wrapper.m_Controls_KAction;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @DAction.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDAction;
                @DAction.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDAction;
                @DAction.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDAction;
                @FAction.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnFAction;
                @FAction.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnFAction;
                @FAction.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnFAction;
                @JAction.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJAction;
                @JAction.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJAction;
                @JAction.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJAction;
                @KAction.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnKAction;
                @KAction.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnKAction;
                @KAction.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnKAction;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DAction.started += instance.OnDAction;
                @DAction.performed += instance.OnDAction;
                @DAction.canceled += instance.OnDAction;
                @FAction.started += instance.OnFAction;
                @FAction.performed += instance.OnFAction;
                @FAction.canceled += instance.OnFAction;
                @JAction.started += instance.OnJAction;
                @JAction.performed += instance.OnJAction;
                @JAction.canceled += instance.OnJAction;
                @KAction.started += instance.OnKAction;
                @KAction.performed += instance.OnKAction;
                @KAction.canceled += instance.OnKAction;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    public interface IControlsActions
    {
        void OnDAction(InputAction.CallbackContext context);
        void OnFAction(InputAction.CallbackContext context);
        void OnJAction(InputAction.CallbackContext context);
        void OnKAction(InputAction.CallbackContext context);
    }
}
