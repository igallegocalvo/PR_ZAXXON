// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputSystem/ZaxxonControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ZaxxonControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ZaxxonControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ZaxxonControl"",
    ""maps"": [
        {
            ""name"": ""Nave"",
            ""id"": ""4f926ee1-ee65-4221-afeb-c4960fbaf056"",
            ""actions"": [
                {
                    ""name"": ""Movimiento"",
                    ""type"": ""Value"",
                    ""id"": ""99c23a4e-e2c1-439b-8987-5611ac49751f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotacion"",
                    ""type"": ""Value"",
                    ""id"": ""23938aa2-88ef-4fbf-b4f6-0bcac89a1a0a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Disparo1"",
                    ""type"": ""Button"",
                    ""id"": ""6f7f67c5-46ef-46ec-bea6-574930eee22e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Disparo2"",
                    ""type"": ""Button"",
                    ""id"": ""d2cb6070-d5f0-45b2-86b8-02275af5cff8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dbf27cc6-bea3-4049-8853-70e0b01f5d11"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1788f7c9-4b61-4ac0-898c-92757134bd56"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotacion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb08d88d-c7f5-4ad1-b753-57d280d120f0"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disparo1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b9c9dcb-25db-4d35-81b7-c2c8c27d7bdc"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disparo2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camara"",
            ""id"": ""eb89bc64-7f0a-43b9-8912-945891f8238d"",
            ""actions"": [
                {
                    ""name"": ""CambiaCamara"",
                    ""type"": ""Button"",
                    ""id"": ""50bdc9aa-31e3-47d7-9bf7-eaa9f71157ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""69dc2b73-14a6-40b4-814f-14ea1905f8fa"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CambiaCamara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Nave
        m_Nave = asset.FindActionMap("Nave", throwIfNotFound: true);
        m_Nave_Movimiento = m_Nave.FindAction("Movimiento", throwIfNotFound: true);
        m_Nave_Rotacion = m_Nave.FindAction("Rotacion", throwIfNotFound: true);
        m_Nave_Disparo1 = m_Nave.FindAction("Disparo1", throwIfNotFound: true);
        m_Nave_Disparo2 = m_Nave.FindAction("Disparo2", throwIfNotFound: true);
        // Camara
        m_Camara = asset.FindActionMap("Camara", throwIfNotFound: true);
        m_Camara_CambiaCamara = m_Camara.FindAction("CambiaCamara", throwIfNotFound: true);
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

    // Nave
    private readonly InputActionMap m_Nave;
    private INaveActions m_NaveActionsCallbackInterface;
    private readonly InputAction m_Nave_Movimiento;
    private readonly InputAction m_Nave_Rotacion;
    private readonly InputAction m_Nave_Disparo1;
    private readonly InputAction m_Nave_Disparo2;
    public struct NaveActions
    {
        private @ZaxxonControl m_Wrapper;
        public NaveActions(@ZaxxonControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movimiento => m_Wrapper.m_Nave_Movimiento;
        public InputAction @Rotacion => m_Wrapper.m_Nave_Rotacion;
        public InputAction @Disparo1 => m_Wrapper.m_Nave_Disparo1;
        public InputAction @Disparo2 => m_Wrapper.m_Nave_Disparo2;
        public InputActionMap Get() { return m_Wrapper.m_Nave; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NaveActions set) { return set.Get(); }
        public void SetCallbacks(INaveActions instance)
        {
            if (m_Wrapper.m_NaveActionsCallbackInterface != null)
            {
                @Movimiento.started -= m_Wrapper.m_NaveActionsCallbackInterface.OnMovimiento;
                @Movimiento.performed -= m_Wrapper.m_NaveActionsCallbackInterface.OnMovimiento;
                @Movimiento.canceled -= m_Wrapper.m_NaveActionsCallbackInterface.OnMovimiento;
                @Rotacion.started -= m_Wrapper.m_NaveActionsCallbackInterface.OnRotacion;
                @Rotacion.performed -= m_Wrapper.m_NaveActionsCallbackInterface.OnRotacion;
                @Rotacion.canceled -= m_Wrapper.m_NaveActionsCallbackInterface.OnRotacion;
                @Disparo1.started -= m_Wrapper.m_NaveActionsCallbackInterface.OnDisparo1;
                @Disparo1.performed -= m_Wrapper.m_NaveActionsCallbackInterface.OnDisparo1;
                @Disparo1.canceled -= m_Wrapper.m_NaveActionsCallbackInterface.OnDisparo1;
                @Disparo2.started -= m_Wrapper.m_NaveActionsCallbackInterface.OnDisparo2;
                @Disparo2.performed -= m_Wrapper.m_NaveActionsCallbackInterface.OnDisparo2;
                @Disparo2.canceled -= m_Wrapper.m_NaveActionsCallbackInterface.OnDisparo2;
            }
            m_Wrapper.m_NaveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movimiento.started += instance.OnMovimiento;
                @Movimiento.performed += instance.OnMovimiento;
                @Movimiento.canceled += instance.OnMovimiento;
                @Rotacion.started += instance.OnRotacion;
                @Rotacion.performed += instance.OnRotacion;
                @Rotacion.canceled += instance.OnRotacion;
                @Disparo1.started += instance.OnDisparo1;
                @Disparo1.performed += instance.OnDisparo1;
                @Disparo1.canceled += instance.OnDisparo1;
                @Disparo2.started += instance.OnDisparo2;
                @Disparo2.performed += instance.OnDisparo2;
                @Disparo2.canceled += instance.OnDisparo2;
            }
        }
    }
    public NaveActions @Nave => new NaveActions(this);

    // Camara
    private readonly InputActionMap m_Camara;
    private ICamaraActions m_CamaraActionsCallbackInterface;
    private readonly InputAction m_Camara_CambiaCamara;
    public struct CamaraActions
    {
        private @ZaxxonControl m_Wrapper;
        public CamaraActions(@ZaxxonControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @CambiaCamara => m_Wrapper.m_Camara_CambiaCamara;
        public InputActionMap Get() { return m_Wrapper.m_Camara; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CamaraActions set) { return set.Get(); }
        public void SetCallbacks(ICamaraActions instance)
        {
            if (m_Wrapper.m_CamaraActionsCallbackInterface != null)
            {
                @CambiaCamara.started -= m_Wrapper.m_CamaraActionsCallbackInterface.OnCambiaCamara;
                @CambiaCamara.performed -= m_Wrapper.m_CamaraActionsCallbackInterface.OnCambiaCamara;
                @CambiaCamara.canceled -= m_Wrapper.m_CamaraActionsCallbackInterface.OnCambiaCamara;
            }
            m_Wrapper.m_CamaraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CambiaCamara.started += instance.OnCambiaCamara;
                @CambiaCamara.performed += instance.OnCambiaCamara;
                @CambiaCamara.canceled += instance.OnCambiaCamara;
            }
        }
    }
    public CamaraActions @Camara => new CamaraActions(this);
    public interface INaveActions
    {
        void OnMovimiento(InputAction.CallbackContext context);
        void OnRotacion(InputAction.CallbackContext context);
        void OnDisparo1(InputAction.CallbackContext context);
        void OnDisparo2(InputAction.CallbackContext context);
    }
    public interface ICamaraActions
    {
        void OnCambiaCamara(InputAction.CallbackContext context);
    }
}
