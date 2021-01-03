using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private int key = 0;
    


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
            vill.y = -6; // тяжесть
        }

        if (Input.GetButtonDown("Jump") && _is_grounded)
        {
            vill.y = Mathf.Sqrt(jump * -2 * gravity);
        }

        vill.y += gravity * Time.deltaTime;
    }

    public int GetKey()
    {
        return key;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }

        if (other.tag == "Key")
        {
            key++;
            Destroy(other.gameObject);
        }
    }


    private void Update()
    {
        Transform();
        Rotate();
        Animation();
    }

    private void Animation()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Animator>().SetBool("is_jumping", true);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            gameObject.GetComponent<Animator>().SetBool("is_jumping", false);
            gameObject.GetComponent<Animator>().SetBool("is_idle", true);
        }


        if(Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Animator>().SetBool("is_walking", true);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            gameObject.GetComponent<Animator>().SetBool("is_walking", false);
            gameObject.GetComponent<Animator>().SetBool("is_idle", true);
        }


        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            gameObject.GetComponent<Animator>().SetBool("is_running", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            gameObject.GetComponent<Animator>().SetBool("is_running", false);
            gameObject.GetComponent<Animator>().SetBool("is_idle", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Animator>().SetBool("is_right", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            gameObject.GetComponent<Animator>().SetBool("is_right", false);
            gameObject.GetComponent<Animator>().SetBool("is_idle", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Animator>().SetBool("is_left", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            gameObject.GetComponent<Animator>().SetBool("is_left", false);
            gameObject.GetComponent<Animator>().SetBool("is_idle", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Animator>().SetBool("is_back", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            gameObject.GetComponent<Animator>().SetBool("is_back", false);
            gameObject.GetComponent<Animator>().SetBool("is_idle", true);
        }
    }



    

}
