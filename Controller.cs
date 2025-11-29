using System;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public CharacterController characterController;
    public float moveSpeed = 12f;
    public Gun gun;
    private Camera m_Cam;
    private InputSystem_Actions m_InputSystemActions;
    
    private float m_Yaw;
    private float m_Pitch;
    
    private float yaw;
    private float pitch;
    
    void OnEnable()
    {

        m_InputSystemActions.Enable();
    }

    void OnDisable()
    {
        m_InputSystemActions.Disable();
    }

    
    
    void Awake()
    {
        m_Cam = Camera.main;
        m_InputSystemActions = new InputSystem_Actions();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        m_InputSystemActions.Player.Attack.started += context => gun.Shoot();
    }

  

    // Update is called once per frame
    void Update()
    {
        Vector2 look = m_InputSystemActions.Player.Look.ReadValue<Vector2>();
        
        
        pitch -= look.y; 
        yaw += look.x;
        pitch = Mathf.Clamp(pitch, -90, 90);
        transform.rotation = Quaternion.Euler(0, yaw, 0);
        m_Cam.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        Vector3 move = transform.forward * m_InputSystemActions.Player.Move.ReadValue<Vector2>().y+
                       transform.right * m_InputSystemActions.Player.Move.ReadValue<Vector2>().x;
        
        move = move.normalized * moveSpeed * Time.deltaTime;
        characterController.Move(move);

    }

    
}
