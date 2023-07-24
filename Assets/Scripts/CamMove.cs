using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Vector3 plusPos;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        CamPosSet();
    }

    private void CamPosSet()
    {
        transform.position = player.transform.position + plusPos;
    }

    private void Init()
    {
        
    }

    
}
