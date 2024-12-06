using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject blockPrefab;
    public Transform parentTransform;

    public void CreateBlock()
    {
        Instantiate(blockPrefab, parentTransform);
    }
}
