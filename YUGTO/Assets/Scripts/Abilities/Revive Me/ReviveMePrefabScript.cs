using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReviveMePrefabScript : MonoBehaviour
{
    public void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }
}
