using UnityEngine;

public class Controller : MonoBehaviour
{
    public CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
        characterController.Move(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
