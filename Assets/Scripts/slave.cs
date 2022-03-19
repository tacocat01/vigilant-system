using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slave : MonoBehaviour
{
    // get the master object angle
    public GameObject master;
    public GameObject slave_object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update the slave object angle based on the master object angle, but the opposite direction
        slave_object.transform.rotation = Quaternion.Euler( master.transform.rotation.eulerAngles.x, master.transform.rotation.eulerAngles.y, -master.transform.rotation.eulerAngles.z);
    }
}
