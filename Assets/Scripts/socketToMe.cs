using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System;

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
        string[] list = new string[6];
        list[0] = "90";
        list[1] = "90";
        list[2] = "90";
        list[3] = "90";
        list[4] = "90";
        list[5] = "90";
        // get each line of the robot's joint angle
        int count = 5;
        float last_angle = 0;
        foreach (Transform child in robot.transform)
        {
            if (count == -1) {
                break;
            }
            float rad = child.transform.rotation.eulerAngles.x;
            // get he local angle
            // float local_rad = rad - child.transform.rotation.eulerAngles.x;
            /*
                5: end effector
                4: wrist
                3: top elbow
                2: middle elbow
                1: bottom elbow
                0: base
            */

            if(count == 0 || count == 4) {
                rad = child.transform.rotation.eulerAngles.y;
            }
            else if(count == 5) {

                // rad = child.transform.localRotation.eulerAngles.y;
                rad = 0;
            }


            string degree = ((rad + 90) % 360).ToString();
            
            // if (count == 6)
            if (count != 5){
                list[count] = degree ;
            } else {
                list[count] = "90";
            }
            // last_angle = rad;
            count --;
            // if (count < 0) {
            //     break;
            // }
        }

        // reverse the array

        if(stopWatch.ElapsedMilliseconds > 1000) {
<<<<<<< HEAD
            Debug.Log(string.Join( ",", list.Reverse().Take(6)));
            //StartCoroutine(PostJSON ("{\"data\":\"" + string.Join( " ", list.Reverse())+ "\"}"));
=======
            Debug.Log(string.Join( ",", list));
            StartCoroutine(PostJSON ("{\"data\":\"" + string.Join( " ", list)+ "\"}"));
>>>>>>> b02bd9f49b000de451b8864a5bc247d414c9e258
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
