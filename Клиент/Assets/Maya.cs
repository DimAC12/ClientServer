using Assets.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maya : MonoBehaviour
{
    bool isMaya;
    [SerializeField] Material materialDefauld;
    [SerializeField] Material materialMaya;
    [SerializeField] GameObject corpus;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetMaya()
    {
        corpus.GetComponent<MeshRenderer>().material = materialMaya;
    }

    public void NotMaya()
    {
        corpus.GetComponent<MeshRenderer>().material = materialDefauld;
    }
}
