using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float speedRotation = 3;
    [SerializeField] private float jump;
    private float verticalMove;
    private float horizontalMove;
    private float mouseGorizontal;
    public int key;

    private void Awake()
    {
        key = 0;
        UnityEngine.Cursor.visible = false;
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
        Animation();
    }

    
    void Animation()
    {

        //Вперед
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Animator>().SetBool("is_walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("is_walk", false);
        }
        //Назад
        if(Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("is_walkBack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("is_walkBack", false);
        }
        // Бег
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Animator>().SetBool("is_run", true);
            speed = 7;
        }
        else
        {
            GetComponent<Animator>().SetBool("is_run", false);
            speed = 2.5f;
        }
        // Стороны
        if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0)
        {
            GetComponent<Animator>().SetBool("is_walk", true);
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            GetComponent<Animator>().SetBool("is_walk", false);
        }



    }
}
