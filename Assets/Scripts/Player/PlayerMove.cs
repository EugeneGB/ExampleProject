using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController controller;
    [SerializeField] Transform rotationBody;
    [SerializeField] Animator anim;

    [Header("Movement settings")]
    [SerializeField] int basicMoveSpeed = 2;
    [SerializeField] int shiftSpeed = 3;
    [SerializeField] int sitSpeed = 1;
    [SerializeField] int jumpHeight = 2;
    [SerializeField] float gravityValue = 9.81f;
    int currentMoveSpeed;
    bool onSit = false;
    Vector3 moveDir = new Vector3();
    Vector3 gravityVelocity = new Vector3();


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        currentMoveSpeed = basicMoveSpeed;
    }
    private void Update()
    {
        OnShift();
        OnSit();
        OnMove();
    }


    private void OnJump()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            gravityVelocity.y += Mathf.Sqrt(jumpHeight * 3.0f * gravityValue);
        }
    }
    private void OnShift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && onSit == false)
            currentMoveSpeed = shiftSpeed;
        else if (Input.GetKeyUp(KeyCode.LeftShift) && onSit == false)
            currentMoveSpeed = basicMoveSpeed;
    }
    private void OnSit()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("sit", true);
            currentMoveSpeed = sitSpeed;
            onSit = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("sit", false);
            currentMoveSpeed = basicMoveSpeed;
            onSit = false;
        }
    }
    private void OnMove()
    {
        if (controller.isGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = 0f;
        }

        moveDir = rotationBody.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * currentMoveSpeed * Time.fixedDeltaTime;

        OnJump();

        gravityVelocity.y -= gravityValue * Time.fixedDeltaTime;
        controller.Move(moveDir + gravityVelocity * Time.fixedDeltaTime);
    }
}
