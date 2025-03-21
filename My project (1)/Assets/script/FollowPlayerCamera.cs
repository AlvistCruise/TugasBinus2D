using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform player; // Objek pemain

    void Start()
    {
        // Mencari pemain jika belum diatur
        if (player == null)
        {
            FindPlayer();
        }

        // Mengatur kamera untuk mengikuti pemain
        if (player != null)
        {
            SetCameraFollow();
        }
        else
        {
            Debug.LogError("Pemain tidak ditemukan!");
        }
    }

    void FindPlayer()
    {
        // Mencari pemain dengan tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void SetCameraFollow()
    {
        // Jika menggunakan skrip CameraFollow
        CameraFollow cameraFollow = GetComponent<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.target = player;
        }
        else
        {
            Debug.LogWarning("CameraFollow tidak ditemukan pada kamera.");
        }
    }

    // Fungsi ini dapat dipanggil dari skrip lain untuk mengatur pemain secara manual
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
        SetCameraFollow();
    }
}