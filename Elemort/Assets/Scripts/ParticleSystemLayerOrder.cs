﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemLayerOrder : MonoBehaviour
{
    public int layerOrder;
    void Start()
    {
        ParticleSystem particleSys = GetComponent<ParticleSystem>();
        Renderer renderer = particleSys.GetComponent<Renderer>();
        renderer.sortingOrder = layerOrder;
    }
}
