//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.9.0
//     from Assets/Scripts/GameWideSystems/InputManager/MainInputs.inputactions
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
using UnityEngine;

public partial class @MainInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInputs"",
    ""maps"": [
        {
            ""name"": ""Pointer"",
            ""id"": ""8b513f95-5087-4c71-b77e-9cd13f246788"",
            ""actions"": [
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""d5431818-a0ed-422b-bcdb-1a5f4247638f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PointerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""fdc24da4-6bfb-4cd8-8c85-1e577963566c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""676b3d3c-29e3-4254-95ea-9f6e267a3d11"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f0d621f-14c0-4306-9151-4df6c1dbbcb8"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Pointer
        m_Pointer = asset.FindActionMap("Pointer", throwIfNotFound: true);
        m_Pointer_Press = m_Pointer.FindAction("Press", throwIfNotFound: true);
        m_Pointer_PointerPosition = m_Pointer.FindAction("PointerPosition", throwIfNotFound: true);
    }

    ~@MainInputs()
    {
        Debug.Assert(!m_Pointer.enabled, "This will cause a leak and performance issues, MainInputs.Pointer.Disable() has not been called.");
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

    // Pointer
    private readonly InputActionMap m_Pointer;
    private List<IPointerActions> m_PointerActionsCallbackInterfaces = new List<IPointerActions>();
    private readonly InputAction m_Pointer_Press;
    private readonly InputAction m_Pointer_PointerPosition;
    public struct PointerActions
    {
        private @MainInputs m_Wrapper;
        public PointerActions(@MainInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Press => m_Wrapper.m_Pointer_Press;
        public InputAction @PointerPosition => m_Wrapper.m_Pointer_PointerPosition;
        public InputActionMap Get() { return m_Wrapper.m_Pointer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PointerActions set) { return set.Get(); }
        public void AddCallbacks(IPointerActions instance)
        {
            if (instance == null || m_Wrapper.m_PointerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PointerActionsCallbackInterfaces.Add(instance);
            @Press.started += instance.OnPress;
            @Press.performed += instance.OnPress;
            @Press.canceled += instance.OnPress;
            @PointerPosition.started += instance.OnPointerPosition;
            @PointerPosition.performed += instance.OnPointerPosition;
            @PointerPosition.canceled += instance.OnPointerPosition;
        }

        private void UnregisterCallbacks(IPointerActions instance)
        {
            @Press.started -= instance.OnPress;
            @Press.performed -= instance.OnPress;
            @Press.canceled -= instance.OnPress;
            @PointerPosition.started -= instance.OnPointerPosition;
            @PointerPosition.performed -= instance.OnPointerPosition;
            @PointerPosition.canceled -= instance.OnPointerPosition;
        }

        public void RemoveCallbacks(IPointerActions instance)
        {
            if (m_Wrapper.m_PointerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPointerActions instance)
        {
            foreach (var item in m_Wrapper.m_PointerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PointerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PointerActions @Pointer => new PointerActions(this);
    public interface IPointerActions
    {
        void OnPress(InputAction.CallbackContext context);
        void OnPointerPosition(InputAction.CallbackContext context);
    }
}
