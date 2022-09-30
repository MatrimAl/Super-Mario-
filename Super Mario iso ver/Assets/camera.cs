using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform Mario;
    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3((Mario.position.x + offset.x) * Time.deltaTime, (Mario.position.y + offset.y) * Time.deltaTime, offset.z);
    }
}
