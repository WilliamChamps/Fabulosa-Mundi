using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCamera : MonoBehaviour
{
    public Camera CamNormal;
    public Camera CamFPS;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CamFPS.depth = 0;
            CamNormal.depth = -1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CamFPS.depth = -1;
            CamNormal.depth = 0;
        }
    }
}
