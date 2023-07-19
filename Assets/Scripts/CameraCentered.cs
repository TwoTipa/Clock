using System;
using UnityEngine;

public class CameraCentered : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position+offset, speed * Time.deltaTime);
        transform.LookAt(target);
    }
}