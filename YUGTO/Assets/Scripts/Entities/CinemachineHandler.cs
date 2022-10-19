using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineHandler : MonoBehaviour
{
    public CinemachineTargetGroup targetbrain;
    public Transform[] targetTransforms;

    Cinemachine.CinemachineTargetGroup target;

    private void Start()
    {
        targetTransforms = GetComponentsInChildren<Transform>();
        StartCoroutine("LateStart");
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(2);

        // Find Players in Scene
        foreach(Transform trans in targetTransforms)
        {
            targetbrain.AddMember(trans, 1f, 5f);
        }
    }


}
