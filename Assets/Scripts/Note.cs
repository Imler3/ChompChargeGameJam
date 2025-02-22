using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Note : MonoBehaviour
{
    public float speed = 2f;
    private void Update()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

}
