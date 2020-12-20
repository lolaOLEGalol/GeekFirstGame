using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float speedRotation = 3;
    [SerializeField] private float jump;
    private float verticalMove;
    private float horizontalMove;
    private float mouseGorizontal;
    public int key;

    private void Awake()
    {
        key = 0;
    }


    public int GetKey()
    {
        return key;
    }

    private void Rotate()
    {
        mouseGorizontal += speedRotation * Input.GetAxis("Mouse X");

        transform.rotation = Quaternion.Euler(0, mouseGorizontal, 0);
    }

    private void Transform()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        transform.Translate(horizontalMove * speed * Time.deltaTime, 0, verticalMove * speed * Time.deltaTime);
    }

    void Update()
    {
        Transform();
        Rotate();
    }
}
