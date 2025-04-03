using UnityEngine;

public class PISSMETERENABLER : MonoBehaviour
{
    // Reference to the PissMeterManager
    public PissMeterManager pissMeterManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (pissMeterManager != null)
        {
            pissMeterManager.enabled = true;
        }
        else
        {
            Debug.LogWarning("PissMeterManager is not assigned.");
        }
    }
}
