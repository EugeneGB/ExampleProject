using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform cameraObject;
    [SerializeField] Transform rotationBody;

    [Header("Look settings")]
    [SerializeField] int mouseSense = 100;
    Vector3 lookDir = new Vector3();


    private void Start()
    {
        BlockCursor();   
    }
    private void Update()
    {
        OnLook();
    }


    private void BlockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnLook()
    {
        lookDir.x -= Input.GetAxis("Mouse Y") * mouseSense * Time.fixedDeltaTime;
        lookDir.y += Input.GetAxis("Mouse X") * mouseSense * Time.fixedDeltaTime;
        cameraObject.rotation = Quaternion.Euler(transform.eulerAngles + lookDir);
        rotationBody.rotation = Quaternion.Euler(0, lookDir.y, 0);
    }
}
