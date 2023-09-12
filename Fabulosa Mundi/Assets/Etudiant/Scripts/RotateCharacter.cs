using System.Collections;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    private CharacterController characterController;
    public float turnSpeed = 360f;  // Vitesse de rotation en degrés par seconde
    public float turnDuration = 1.0f; // Durée de la rotation en secondes

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))  // Remplacez "R" par la touche que vous voulez utiliser pour déclencher la rotation
        {
            StartCoroutine(RotateOverTime(Quaternion.Euler(0, 90, 0)));
            Debug.Log("Touche R appuyée");// 90 degrés autour de l'axe Y
        }
    }

    IEnumerator RotateOverTime(Quaternion rotation)
    {
        Debug.Log("Début de la rotation");

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * rotation;
        float elapsedTime = 0;

        while (elapsedTime < turnDuration)
        {
            float t = elapsedTime / turnDuration;
            t = t * t * (3f - 2f * t); // Utilisation d'une courbe d'accélération

            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;

            // Applique un mouvement nul pour que le CharacterController valide la rotation.
            characterController.Move(Vector3.zero);

            yield return null;
        }

        transform.rotation = endRotation;
    }
}



