using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PissMeterManager : MonoBehaviour
{
    public PissMeter[] PissMeters {  get; private set; }

    [SerializeField] private Slider[] sliders;
    private int _maxPiss = 100;

    void Start()
    {
        PissMeters = new PissMeter[1];
        for (int runs = 0; runs < PissMeters.Length; runs++)
        {
            PissMeters[runs] = new PissMeter(sliders[runs]);
        }

        FillAllPissMeters();
    }

    public void FillAllPissMeters()
    {
        foreach (var meter in PissMeters)
        {
            meter.AddPiss(_maxPiss);
        }
    }
}
