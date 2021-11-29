using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class SpawnableObject:MonoBehaviour,IProceduralSpawnable
{
    private float width;
    public float Width
    {
        get { return width; }
    }
    private float height;
    public float Height
    {
        get { return height; }
    }
    
    public float StartX
    {
        get { return transform.position.x - width / 2f; }
    }
    public float StartY
    {
        get { return transform.position.y - height / 2f; }
    }

    public float EndX
    {
        get { return transform.position.x + width / 2f; }
    }
    public float EndY
    {
        get { return transform.position.y + height / 2f; }
    }
    private void Start()
    {
     RectTransform rectTransform = (RectTransform) transform;
     width = rectTransform.rect.width;
     height = rectTransform.rect.height;
    }

 
    
}
