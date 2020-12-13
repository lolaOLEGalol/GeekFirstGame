using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveGorizontal;
    private float moveVertical;
    private float mouseGorizontal;
    private float mouseVertical;
    private float speed = 3f;
    private float speedRotation = 3f;

    public Vector3 vill;
    public CharacterController controller;
    public float gravity = -10f;
    private bool _is_grounded;
    public LayerMask _is_ground;
    public Transform feetPosition;
    public float jump = 3f;

    private void Rotate()
    {
        mouseGorizontal += speedRotation * Input.GetAxis("Mouse X");
        mouseVertical += speedRotation * Input.GetAxis("Mouse Y");

        transform.rotation = Quaternion.Euler(0, mouseGorizontal, 0);
    }

    private void Transform()
    {
        moveGorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(moveGorizontal, 0, moveVertical).normalized;
        Vector3 move = transform.forward * moveVertical * speed + transform.right * moveGorizontal * speed;

        controller.Move(move * speed * Time.deltaTime);
        controller.Move(vill * Time.deltaTime);

        //transform.Translate(moveGorizontal * Time.deltaTime * speed, 0, moveVertical * Time.deltaTime * speed);
        _is_grounded = Physics.CheckSphere(feetPosition.position, 0.178f, _is_ground);

        if (_is_grounded && vill.y < 0) 
        {
            vill.y = -20; // тяжесть
        }

        if (Input.GetButtonDown("Jump") && _is_grounded)
        {
            vill.y = Mathf.Sqrt(jump * -2 * gravity);
        }

        vill.y += gravity * Time.deltaTime;
    }

    private void Update()
    {
        Transform();
        Rotate();
    }
}
