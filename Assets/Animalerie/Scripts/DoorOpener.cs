using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Transform playerCamera;   // La référence à la MainCamera (ou une caméra spécifiée)
    public float openDistance = 5f;  // Distance à partir de laquelle la porte s'ouvre
    public float rotationSpeed = 2f; // Vitesse de la rotation de la porte
    private bool isPlayerNear = false;  // Détection si la caméra est proche

    private float maxAngle = 90f;    // Angle d'ouverture maximum de la porte
    private float currentAngle = 0f; // Angle actuel de la porte

    void Update()
    {
        // Calculer la distance entre la porte et la caméra
        float distance = Vector3.Distance(transform.position, playerCamera.position);

        // Si la caméra est proche, la porte s'ouvre
        if (distance <= openDistance)
        {
            isPlayerNear = true;
        }
        else
        {
            isPlayerNear = false;
        }

        // Rotation de la porte
        if (isPlayerNear)
        {
            // Si la caméra est proche, on ouvre la porte
            currentAngle = Mathf.MoveTowards(currentAngle, maxAngle, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Si la caméra s'éloigne, la porte se referme
            currentAngle = Mathf.MoveTowards(currentAngle, 0f, rotationSpeed * Time.deltaTime);
        }

        // Appliquer la rotation autour de l'axe Z
        transform.localRotation = Quaternion.Euler(0f, currentAngle, 0f);
    }
}
