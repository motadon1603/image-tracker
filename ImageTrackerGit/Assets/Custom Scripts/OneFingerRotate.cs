using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneFingerRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        float rotationX = Input.GetAxis("Mouse X") * 100 * Mathf.Deg2Rad;
        transform.Rotate(Vector3.down, -rotationX, Space.World);
    }

}
