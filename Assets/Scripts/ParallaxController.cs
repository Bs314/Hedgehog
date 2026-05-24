using UnityEngine;

public class ParallaxController : MonoBehaviour
{

    public float parallaxModifier= 2f;
    
    public Transform cam;          // Cinemachine’in takip ettiği kamera
    private Vector3 lastCamPos;    // Önceki kamera pozisyonu

    void Start()
    {
        if (cam == null)
            cam = Camera.main.transform;

        lastCamPos = cam.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cam.position - lastCamPos;

        // Z konumuna göre hız belirle
        float parallaxFactor = -parallaxModifier/transform.position.z;  
        // Yakın (z küçük) => büyük hareket, uzak (z büyük) => küçük hareket

        transform.position += new Vector3(delta.x * parallaxFactor, delta.y * parallaxFactor, 0);

        lastCamPos = cam.position;
    }
}
