using UnityEngine;

public class RefillPiss : MonoBehaviour
{
    private PissMeterManager _meterManager;

    private void Start()
    {
        _meterManager = FindAnyObjectByType<PissMeterManager>();
    }

    private void OnMouseDown()
    {
        _meterManager.FillAllPissMeters();
    }
}
