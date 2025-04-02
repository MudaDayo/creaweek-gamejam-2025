using UnityEngine;

public class PissingAction : MonoBehaviour
{
    [SerializeField] private GameObject pissPrefab; // The prefab to spawn
    [SerializeField] private Camera playerCamera;  // The camera to determine the direction
    [SerializeField] private Transform spawnPoint; // The point where the prefab will spawn

    void Update()
    {
        // Check if the "Piss" input action is triggered
        if (Input.GetButtonDown("Piss"))
        {
            SpawnPiss();
        }
    }

    private void SpawnPiss()
    {
        if (pissPrefab != null && playerCamera != null && spawnPoint != null)
        {
            // Instantiate the prefab at the spawn point
            GameObject spawnedPiss = Instantiate(pissPrefab, spawnPoint.position, Quaternion.identity);

            // Aim the prefab in the direction the camera is looking
            spawnedPiss.transform.forward = playerCamera.transform.forward;
        }
        else
        {
            Debug.LogWarning("PissPrefab, PlayerCamera, or SpawnPoint is not assigned.");
        }
    }
}
