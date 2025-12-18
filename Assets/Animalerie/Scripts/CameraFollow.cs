using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float moveSpeed = 5.0f;      // Vitesse de déplacement de la caméra
    public float lookSpeedX = 2.0f;     // Sensibilité pour regarder à gauche/droite
    public float lookSpeedY = 2.0f;     // Sensibilité pour regarder haut/bas
    public Transform playerBody;        // Référence au corps du joueur pour le mouvement

    private float xRotation = 0.0f;     // Rotation verticale (haut/bas)
    
    void Update()
    {
        // Récupérer les déplacements horizontaux et verticaux
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Déplacer la caméra en fonction des touches (W, A, S, D)
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        transform.position += move * moveSpeed * Time.deltaTime;

        // Récupérer les mouvements de la souris pour la rotation
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;

        // Appliquer la rotation verticale de la caméra (haut/bas)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // Limite la rotation verticale

        // Appliquer la rotation de la caméra (verticale)
        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        
        // Rotation du corps du joueur horizontal (gauche/droite)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
