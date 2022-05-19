﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BanditCube : MonoBehaviour {

    public List<GameObject> Connections;
    public float reward = -.1f;
    public int index;
    private MeshRenderer meshRenderer;
    private Material resetMaterial;

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        resetMaterial = meshRenderer.material;
    }

    public void OnTriggerStay(Collider other)
    {
        if (Connections.Contains(other.gameObject)) return;
        Connections.Add(other.gameObject);        
    }

    public BanditCube ChoosePath(int path)
    {
        if (path < 0 || path >= Connections.Count) return Connections[0].GetComponent<BanditCube>();
        return Connections[path].GetComponent<BanditCube>();
    }

    public void SetMaterial(Material agentMaterial)
    {        
        meshRenderer.material = agentMaterial;        
    }

    public void ResetMaterial()
    {
        meshRenderer.material = resetMaterial;
    }
}
