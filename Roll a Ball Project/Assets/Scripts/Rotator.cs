using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badRotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(80, -50, 35) * Time.deltaTime);
    }
}
