using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;


public class socketToMe : MonoBehaviour
{
    // get the robot object
    public GameObject robot;

    // make a stop watch to measure the time
    private System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

    void Start () {
        StartCoroutine(PostJSON ("{\"data\":\"90 90 90 90 90 90\"}"));
        stopWatch.Start();
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
            // if (count < 0) {
            //     break;
            // }
        }
        // get the 1st  6 elements of the list
        // list.take(6);
        if(stopWatch.ElapsedMilliseconds > 1000) {
            Debug.Log(string.Join( ",", list.Take(6)));
            StartCoroutine(PostJSON ("{\"data\":\"" + string.Join( " ", list.Take(6))+ "\"}"));
            stopWatch.Restart();
        }
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
