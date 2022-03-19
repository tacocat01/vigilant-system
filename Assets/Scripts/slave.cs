using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slave : MonoBehaviour
{
    // get the master object angle
    public GameObject master;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.rotation.z = -master.transform.rotation.z;
        // update the self transform oposet angle
        // transform.rotation = Quaternion.Euler(0, 0, -master.transform.rotation.z);
        transform.rotate(new Vector3(0, 0, -master.transform.rotation.z));
    }
}
