using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject());
        }
        else { DontDestroyOnLoad(transform.gameObject()); }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
