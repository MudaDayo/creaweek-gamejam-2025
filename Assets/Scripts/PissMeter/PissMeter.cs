using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PissMeter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public float PissAmount {  get; private set; }  = 0;

    private void FindSlider()
    {
        if (_slider == null)
        {
            _slider = gameObject.GetComponent<Slider>();
            Debug.Log(_slider.name);
        }
    }

    public void AddPiss(int pissAmount)
    {
        FindSlider();

        PissAmount += pissAmount;
        PissAmount = Mathf.Clamp(PissAmount, 0, 100);
        _slider.value = PissAmount;
    }

    public void RemovePiss(float pissAmount)
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
