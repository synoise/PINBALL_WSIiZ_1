using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _mainCamera;
    private Vector3 _input;

    private bool canMove = true;

    private void Update()
    {
        if (!canMove)
            return;

        GatherInput();
        Look();
    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;

        Move();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (_input != Vector3.zero)
            _animator.SetBool("isRunning", true);
        else
            _animator.SetBool("isRunning", false);
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        transform.rotation = rot;
    }

    IEnumerator setCameraDelay(float moveDelayX, float moveDelayZ)
    {
        yield return new WaitForSeconds(0.6f);
        _mainCamera.transform.position = new Vector3(moveDelayX, 0f, moveDelayZ); 
    }
    
    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
        //StartCoroutine(setCameraDelay(transform.position.x,transform.position.z));
        // move.Normalize();
    }

    public void SetMove(bool status)
    {
        canMove = status;
    }
}


public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}

