using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class master_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // User pressing left arrow key will rotate the master object left
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // move the master object angle by one degree
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // move the master object angle by one degree
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - 1);
        }
    }
}
