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
        PissMeters = new PissMeter[4];
        var players = GameObject.FindGameObjectsWithTag("Player");
        for (int runs = 0; runs < players.Length; runs++)
        {           
            var pissMeter = players[runs].transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
            _sliders[runs] = pissMeter.GetComponent<Slider>();
            pissMeter.AddComponent<PissMeter>();
            
            PissMeters[runs] = pissMeter.GetComponent<PissMeter>();
        }

        FillAllPissMeters();
        Debug.Log("All piss meters initialized and filled to max.");
    }

    public void FillAllPissMeters()
    {
        Debug.Log("Filling all piss meters to max.");
        foreach (var meter in PissMeters)
        {
            meter.AddPiss(_maxPiss);
        }
    }
}
