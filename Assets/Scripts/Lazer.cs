using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    //speed variable of 8
    // Start is called before the first frame update
    [SerializeField]
    private int _speed = 8; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //translate lazer up
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //if lazer position is > 8 on the Y
        //destroy it

        if (transform.position.y > 8f)
        {
            Destroy(this.gameObject);
        }

    }
}

