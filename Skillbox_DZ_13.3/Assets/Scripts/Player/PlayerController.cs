using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Animator anim;

    [SerializeField] private float _speed = 7.5f;
    [SerializeField] private float _jumpSpeed = 8f;
    [SerializeField] private float _gravity = 20f;
    [SerializeField] private Transform _playerCameraParent;
    [SerializeField] private float _lookSpeed = 2f;
    [SerializeField] private float _lookXLimit = 60f;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }

    private void Update()
    {
        
        anim.SetFloat("Speed", _moveDirection.magnitude);

        if (_characterController.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? _speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? _speed * Input.GetAxis("Horizontal") : 0;
            _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if(Input.GetButton("Jump") && canMove)
            {
                _moveDirection.y = _jumpSpeed;
            }
        }

        // as an acceleration (ms^-2)
        _moveDirection.y -= _gravity * Time.deltaTime;

        //движение controller
        _characterController.Move(_moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * _lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * _lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -_lookXLimit, _lookXLimit);
            _playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }
    }
}
