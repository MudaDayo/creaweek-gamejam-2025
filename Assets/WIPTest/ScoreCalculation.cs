using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreCalculation : MonoBehaviour
{
    public Renderer rend;
    private Texture2D image;
    private Vector4 scores;
    private Vector4 percents;
    private float totalPixels;

    public float refreshRate = 0.5f;
    private float timer = 0;

    void Start()
    {
        if (rend == null)
            rend = GetComponent<Renderer>();

        image = rend.material.GetTexture("_Map") as Texture2D;


        if (image == null)
        {
            Debug.LogError("No image assigned!");
            return;
        }

        totalPixels = image.width * image.height;

        GetScores();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > refreshRate)
        {
            GetScores();
            GetPercents();
            timer = 0;
        }
    }

    public Vector4 GetScores()
    {
        Color32[] pixels = image.GetPixels32();
        scores = new Vector4(
            pixels.Count(p => p.r == 255 && p.g == 0 && p.b == 0 && p.a == 255),
            pixels.Count(p => p.r == 0 && p.g == 255 && p.b == 0 && p.a == 255),
            pixels.Count(p => p.r == 0 && p.g == 0 && p.b == 255 && p.a == 255),
            pixels.Count(p => p.a == 0)
        );

        //Debug.Log("scores: " + scores);

        return scores;
    }

    public Vector4 GetPercents()
    {
        percents = (scores / totalPixels) * 100f;
        Debug.Log("score percents: " + percents);
        return percents;
    }

    public int GetFirstPlayer()
    {
        // get biggest value from scores
        float maxValue = GetHighestPercent();

        if (percents.x == maxValue)
            return 1;
        else if (percents.y == maxValue)
            return 2;
        else if (percents.z == maxValue)
            return 3;
        else return 4;
    }

    public float GetHighestPercent()
    {
        float maxValue = percents.x;

        if (percents.y > maxValue)
            maxValue = percents.y;
        if (percents.z > maxValue)
            maxValue = percents.z;
        if (percents.w > maxValue)
            maxValue = percents.w;

        return maxValue;
    }
}
