using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float horizontalInput;
    [Header("Settings")]
    [SerializeField] float rotationSpeed = 5;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Collect input data
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
