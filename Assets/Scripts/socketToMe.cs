using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;


public class socketToMe : MonoBehaviour
{
    // get the robot object
    public GameObject robot;

    void Start () {
        StartCoroutine(PostJSON ("{\"data\":\"90 90 90 90 90 90\"}"));
        // digital starting angles
        float[] start_digital_angles = new float[7];
        int count = 0;
        foreach (Transform child in robot.transform)
        {

            float rad = child.transform.localRotation.eulerAngles.x;
            // get he local angle
            // float local_rad = rad - child.transform.rotation.eulerAngles.x;


            if(count == 0) {
                rad = child.transform.localRotation.eulerAngles.y;
            }
            else if(count == 6) {
                rad = child.transform.localRotation.eulerAngles.z;
            }
            else if(count == 7) {
                rad = child.transform.localRotation.eulerAngles.z;
            }
            // string degree = ((rad * 180 / Mathf.PI)%360).ToString();
            

            start_digital_angles[count] = rad;
            // last_angle = rad;
            count++;
        }

        Debug.Log(string.Join( ",", start_digital_angles));
        
    }

    private void OnDestroy () {
        
    }

    // make a function to convert the angle to string
    public string angleToString (float rad) {
        string str = "";
        
        string degree = (rad * 180 / Mathf.PI).ToString();
        return degree;
    }

    // Update is called once per frame
    void Update()
    {
        // string list 
        string[] list = new string[7];
        // get each line of the robot's joint angle
        int count = 6;
        float last_angle = 0;
        foreach (Transform child in robot.transform)
        {
            float rad = child.transform.localRotation.eulerAngles.x;
            // get he local angle
            // float local_rad = rad - child.transform.rotation.eulerAngles.x;


            if(count == 0) {
                rad = child.transform.localRotation.eulerAngles.y;
            }
            else if(count == 6) {
                rad = child.transform.localRotation.eulerAngles.z;
            }
            else if(count == 7) {
                rad = child.transform.localRotation.eulerAngles.z;
            }
            string degree = ((rad * 180 / Mathf.PI)%90  + 90 ).ToString();
            

            list[count] = degree ;
            // last_angle = rad;
            count--;
        }

        Debug.Log(string.Join( ",", list));
        // StartCoroutine(PostJSON ("{\"data\":\"" + angle_str.join() + "\"}"));
    }

    private static IEnumerator PostJSON(string jsonString) {
    // test
        Debug.Log("(post json) called");

        string url = "https://hack-usu-robot-proxy.herokuapp.com/unity-update";

        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log ("(post json) before sending");
        yield return request.Send();
        Debug.Log ("(post json) after sending");

        if (request.error != null) {
            Debug.Log("request error: " + request.error);

        } else {
            Debug.Log("request success: " + request.downloadHandler.text);

        }
    }
}
