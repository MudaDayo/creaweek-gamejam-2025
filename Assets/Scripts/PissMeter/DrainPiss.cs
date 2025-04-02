using UnityEngine;

public class DrainPiss : MonoBehaviour
{
    private PissMeterManager _meterManager;

    private void Start()
    {
        _meterManager = FindAnyObjectByType<PissMeterManager>();
    }

    private void OnMouseDown()
    {
        _meterManager.PissMeters[0].RemovePiss(10);
    }
}
