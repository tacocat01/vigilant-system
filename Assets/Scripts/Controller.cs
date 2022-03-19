using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{   
    // speed of the master object
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // USE WASD TO MOVE THE MASTER OBJECT
        // IF USER  presses w key, move the master object forward
        if (Input.GetKey(KeyCode.W))
        {
            // move the master object forward
            transform.position = transform.position + transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            // move the master object backward
            transform.position = transform.position - transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // move the master rotation by one degree
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 1, transform.rotation.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // move the master rotation by one degree
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 1, transform.rotation.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            // move the master rotation by one degree
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - 1, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.E))
        {
            // move the master rotation by one degree
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 1, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }


        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        // }

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.rotation = Quaternion.Euler(-1 * Time.deltaTime, 0, 0);
        //     //transform.rotate(1 * Time.deltaTime, 0, 0);
        // }

        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.rotation = Quaternion.Euler(1 * Time.deltaTime, 0, 0);
        // }
    }
}
