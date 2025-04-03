using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PissMeterManager : MonoBehaviour
{
    public PissMeter[] PissMeters {  get; private set; }

    public Slider[] _sliders;
    private int _maxPiss = 100;

    void Start()
    {
        _sliders = new Slider[4];
        PissMeters = new PissMeter[4];
        var players = GameObject.FindGameObjectsWithTag("Player");
    }

    public void RemovePissFromMeter(float pissAmount, int pissMeterIndex)
{
    PissMeters[pissMeterIndex].RemovePiss(pissAmount);
}

public void AddPissToMeter(int pissAmount, int pissMeterIndex)
{
    PissMeters[pissMeterIndex].AddPiss(pissAmount);
}

public int CheckPissMeter(int pissMeterIndex){
    return (int)PissMeters[pissMeterIndex].GetPiss();
}
}
