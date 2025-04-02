using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PissMeterManager : MonoBehaviour
{
    public PissMeter[] PissMeters {  get; private set; }

    private Slider[] _sliders;
    private int _maxPiss = 100;

    void Start()
    {
        _sliders = new Slider[4];
        for (int runs = 0; runs < _sliders.Length; runs++)
        {
            _sliders[runs] = GameObject.Find($"Player{runs + 1}Canvas").GetComponentInChildren<Slider>();
        }

        PissMeters = new PissMeter[4];
        for (int runs = 0; runs < PissMeters.Length; runs++)
        {
            PissMeters[runs] = new PissMeter(_sliders[runs]);
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
