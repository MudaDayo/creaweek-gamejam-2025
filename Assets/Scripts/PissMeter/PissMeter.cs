using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PissMeter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float PissAmount = 100f;
    private PissMeterManager _pissMeterManager;
    public ThirdPersonController _thirdPersonController;
    private void Start()
    {
        PissAmount = 100f;
        _pissMeterManager = GameObject.FindGameObjectWithTag("PissMeterManager")?.GetComponent<PissMeterManager>();
        _pissMeterManager._sliders[_thirdPersonController.playerID - 1] = _slider;
        if (_pissMeterManager == null)
        {
            Debug.LogError("PissMeterManager not found in the scene.");
        }
    }

    void Update()
    {
        if(_slider.value != PissAmount)
        {
            _slider.value = PissAmount;
        }
    }

    public void AddPiss(int pissAmount)
    {
        PissAmount += pissAmount;
        PissAmount = Mathf.Clamp(PissAmount, 0, 100);
        _slider.value = PissAmount;
    }

    public void RemovePiss(float pissAmount)
    {
        Debug.Log($"Removing {pissAmount} from {this}");
        PissAmount -= pissAmount;
        PissAmount = Mathf.Clamp(PissAmount, 0, 100);
        _slider.value = PissAmount;
    }

    public void SetPiss(int pissAmount)
    {
        PissAmount = pissAmount;
        PissAmount = Mathf.Clamp(PissAmount, 0, 100);
        _slider.value = PissAmount;
    }
}
