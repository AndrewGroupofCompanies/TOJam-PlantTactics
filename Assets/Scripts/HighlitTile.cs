using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlitTile : MonoBehaviour
{
    private float alpha = 0;
    private SpriteRenderer material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        alpha += 0.001f;

        if (alpha > 0.3f) {
            alpha = 0;
        }

        material.color =  new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
