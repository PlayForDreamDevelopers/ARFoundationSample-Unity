using System;
using UnityEngine;
using YVR.Core;

public class MeshMgr : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        YVRMeshTracking.instance.CreateMeshDetector();
    }

    private void OnDestroy()
    {
        YVRMeshTracking.instance.DestroyMeshDetector();
    }
}
