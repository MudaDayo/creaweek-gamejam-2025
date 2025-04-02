using UnityEngine;

public class AddPiss : MonoBehaviour
{
    private PissMeterManager _meterManager;

    private void Start()
    {
        _meterManager = FindAnyObjectByType<PissMeterManager>();
    }

    private void OnMouseDown()
    {
        _meterManager.PissMeters[0].AddPiss(10);
    }
}
