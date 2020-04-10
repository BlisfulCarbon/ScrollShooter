using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed = 0.2f;
    public Renderer bgRend;
    private void Update()
    {
        bgRend.material.mainTextureOffset = new Vector2(0, Time.time * speed);
    }
}
