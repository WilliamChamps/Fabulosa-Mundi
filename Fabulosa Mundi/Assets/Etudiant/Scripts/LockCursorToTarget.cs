using UnityEngine;

public class LockCursorToTarget : MonoBehaviour
{
    public GameObject target; // Assignez votre GameObject "Target" ici depuis l'inspecteur
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Assurez-vous d'avoir une caméra principale dans votre scène
        Cursor.lockState = CursorLockMode.None; // Assurez-vous que le curseur est visible et non verrouillé au début
    }

    void Update()
    {
        if (target != null)
        {
            // Trouver la position à l'écran du "target"
            Vector3 targetScreenPosition = mainCamera.WorldToScreenPoint(target.transform.position);

            // Déplacer le curseur vers la position de l'écran du "target"
            Cursor.visible = false; // Cachez le curseur
            Cursor.lockState = CursorLockMode.Locked; // Verrouillez le curseur au centre de l'écran

            // Remettre le curseur à sa position d'origine
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Vector2 cursorPos = new Vector2(targetScreenPosition.x, Screen.height - targetScreenPosition.y);
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            Cursor.SetCursor(null, cursorPos, CursorMode.Auto);
        }
    }
}

