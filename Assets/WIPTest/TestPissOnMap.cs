using UnityEngine;

public class TestPissOnMap : MonoBehaviour
{
    private Texture2D _tex;
    public int width = 2048;
    public int height = 2048;

    private float timer = 0;
    void Start()
    {
        _tex = new Texture2D(width, height, TextureFormat.RGBA32, false);
        GetComponent<Renderer>().material.SetTexture("_Map", _tex);

        ClearPiss();
    }
    //void Update()
    //{
    //    timer += Time.deltaTime;

    //    if (timer > 0.5f)
    //    {
    //        Vector2 randPos = new Vector2(Random.Range(0, width), Random.Range(0, height));
    //        DrawCircle(randPos, 50, new Color(1, 0, 0, 0));
    //        timer = 0;
    //    }
    //}

    public void ClearPiss()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                _tex.SetPixel(x, y, new Color(0, 0, 0, 1));
            }
        }
    }

    public Vector2 ConvertPos(Vector3 worldPos)
    {
        worldPos.x -= transform.localScale.x / 2;
        worldPos.z -= transform.localScale.y / 2;

        Vector2 UVpos = new Vector2();
        UVpos.x = worldPos.x/transform.localScale.x * width;
        UVpos.y = worldPos.z/transform.localScale.y * height;

        return UVpos;
    }
    public void DrawCircle(Vector2 pos, int rad, Color clr)
    {
        int cx = (int)pos.x;
        int cy = (int)pos.y;

        for (int y = -rad; y <= rad; y++)
        {
            for (int x = -rad; x <= rad; x++)
            {
                if (x * x + y * y <= rad * rad)
                {
                    _tex.SetPixel(cx + x, cy + y, clr);
                }
            }
        }
        _tex.Apply();
    }
    public void DrawCircle(Vector3 worldPos, int rad, Color clr)
    {
        DrawCircle(ConvertPos(worldPos), rad, clr);
    }
}