// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b436032e-adf2-490b-8f65-ef24ac2583f9"",
            ""actions"": [
                {
                    ""name"": ""Deplacement"",
                    ""type"": ""Button"",
                    ""id"": ""41ad0c9f-fdd5-42f8-8220-6a1b1cf246d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""5ea4f4a4-6b07-470f-82aa-2e1cf6770083"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a4b0f359-b64a-422e-99b1-b3a95f35392d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa4bfdb0-3748-43f7-92c6-55452ce40776"",
                    ""path"": ""<Touchscreen>/touch0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f0e4fd8-b76e-40a8-b1e5-3dfe9b9e3945"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Deplacement = m_Gameplay.FindAction("Deplacement", throwIfNotFound: true);
        m_Gameplay_Action = m_Gameplay.FindAction("Action", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Deplacement;
    private readonly InputAction m_Gameplay_Action;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Deplacement => m_Wrapper.m_Gameplay_Deplacement;
        public InputAction @Action => m_Wrapper.m_Gameplay_Action;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Deplacement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeplacement;
                @Deplacement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeplacement;
                @Deplacement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeplacement;
                @Action.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Deplacement.started += instance.OnDeplacement;
                @Deplacement.performed += instance.OnDeplacement;
                @Deplacement.canceled += instance.OnDeplacement;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnDeplacement(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
    }
}
