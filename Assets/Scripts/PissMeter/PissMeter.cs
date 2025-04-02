using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PissMeter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public int PissAmount {  get; private set; }

    public PissMeter(Slider slider)
    {
        _slider = slider;
    }

    public void AddPiss(int pissAmount)
    {
        PissAmount += pissAmount;
        PissAmount = Mathf.Clamp(PissAmount, 0, 100);
        _slider.value = PissAmount;
    }

    public void RemovePiss(int pissAmount)
    {
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
