using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{

    

    private const float LERP_SPEED = 9;

    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;

    [SerializeField] private Transform _mainCamera;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private bool _isAiming;

    private Vector3 _movementVector;
  


    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();

        ResetAngularVelocity();
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

   
    void Update()
    {
        _movementVector = CalculateMovementVector();
        UpdateAnimatorVariables();

            TurnCharacterInMovementDirection();
        

        ResetAngularVelocity();
    }

    private void UpdateAnimatorVariables()
    {
        _playerAnimator.SetFloat("MovementSpeed", _movementVector.magnitude);

        //_playerAnimator.SetBool(IsAttacking, Input.GetKey(KeyCode.Mouse1));
    }

    private void FixedUpdate()
    {
        _playerRigidbody.velocity = new Vector3(_movementVector.x * _movementSpeed, _playerRigidbody.velocity.y,
            _movementVector.z * _movementSpeed);
    }

    private Vector3 CalculateMovementVector()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 cameraR = _mainCamera.right;
        Vector3 cameraF = _mainCamera.forward;

        cameraR.y = 0;
        cameraF.y = 0;

        Vector3 movementVector = cameraF.normalized * v + cameraR.normalized * h;
        movementVector = Vector3.ClampMagnitude(movementVector, 1);

        Vector3 relativeVector = transform.InverseTransformDirection(movementVector);
        _playerAnimator.SetFloat("Turn", relativeVector.x);
        _playerAnimator.SetFloat("Forward", relativeVector.z);
        
       
        return movementVector;
    }

    private void ResetAngularVelocity()
    {
        _playerRigidbody.angularVelocity = Vector3.zero;
    }

    private void TurnCharacterInMovementDirection()
    {
        if (_playerRigidbody.velocity.magnitude / _movementSpeed > 0.1f)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(_playerRigidbody.velocity.x, 0, _playerRigidbody.velocity.z)),
                LERP_SPEED * Time.deltaTime);
    }
    
}
