using UnityEngine;

public class LockCursorToTarget : MonoBehaviour
{
    public GameObject target; // Assignez votre GameObject "Target" ici depuis l'inspecteur
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Assurez-vous d'avoir une cam�ra principale dans votre sc�ne
        Cursor.lockState = CursorLockMode.None; // Assurez-vous que le curseur est visible et non verrouill� au d�but
    }

    void Update()
    {
        if (target != null)
        {
            // Trouver la position � l'�cran du "target"
            Vector3 targetScreenPosition = mainCamera.WorldToScreenPoint(target.transform.position);

            // D�placer le curseur vers la position de l'�cran du "target"
            Cursor.visible = false; // Cachez le curseur
            Cursor.lockState = CursorLockMode.Locked; // Verrouillez le curseur au centre de l'�cran

            // Remettre le curseur � sa position d'origine
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Vector2 cursorPos = new Vector2(targetScreenPosition.x, Screen.height - targetScreenPosition.y);
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            Cursor.SetCursor(null, cursorPos, CursorMode.Auto);
        }
    }
}

