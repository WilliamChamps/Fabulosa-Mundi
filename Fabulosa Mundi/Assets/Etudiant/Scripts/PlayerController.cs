using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Movement")]
    public float MovementSpeed = 10.0f;

    private Rigidbody _rigidbody;
    private Vector2 _inputVector;
    private float _moveSpeed;

    [Header("Camera Control")]
    public Camera playerCamera;
    public float LookSpeed = 2.0f;
    private float _cameraPitch = 0.0f;

    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;

    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (!playerCamera)
        {
            Debug.LogError("No player camera is set!");
        }
    }

    private void Update()
    {
        HandleMovementInput();
        CameraRotation();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        _inputVector = new Vector2(horizontalInput, verticalInput);
        _inputVector.Normalize();
        _moveSpeed = MovementSpeed;
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(_inputVector.x, 0, _inputVector.y);
        Vector3 moveOffset = moveDirection * _moveSpeed * Time.fixedDeltaTime;

        _rigidbody.MovePosition(_rigidbody.position + moveOffset);
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * LookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * LookSpeed;

        _cameraPitch -= mouseY;
        _cameraPitch = Mathf.Clamp(_cameraPitch, BottomClamp, TopClamp);

        playerCamera.transform.localEulerAngles = new Vector3(_cameraPitch, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }
}

