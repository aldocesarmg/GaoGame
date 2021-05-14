using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Attack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject kunaiPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Attack"))
        {
            Instantiate(kunaiPrefab, firePoint.position, new Quaternion(-90, -90, 0, 0));
        }
    }
}
