using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject objectToToggle;
    public Transform firstPersonView;
    public Transform thirdPersonView;
    public GameObject cameraHolder;

    private Transform currentView;

    // Start is called before the first frame update
    void Start()
    {
        // Initialisation
        currentView = thirdPersonView;
    }

    // Update is called once per frame
    void Update()
    {
        // Basculer la vue lorsque la touche "V" est appuyée
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (currentView == thirdPersonView)
            {
                currentView = firstPersonView;
            }
            else
            {
                currentView = thirdPersonView;
            }
        }

        // Mise à jour de la position et de la rotation de la caméra
        cameraHolder.transform.position = Vector3.Lerp(cameraHolder.transform.position, currentView.position, Time.deltaTime * 5);
        cameraHolder.transform.rotation = Quaternion.Lerp(cameraHolder.transform.rotation, currentView.rotation, Time.deltaTime * 5);
    }

    public void Toggle()
    {
        if (objectToToggle != null)
        {
            bool isActive = objectToToggle.activeSelf;
            objectToToggle.SetActive(!isActive);
        }
    }
}

