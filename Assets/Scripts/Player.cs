using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public or private
    //data types(int, float, bool, string)
    //every variable has a name
    //optional value assigned
    [SerializeField]
    private float _speed = 4.5f;
    [SerializeField]
    private GameObject _lazerPrefab;
    private Vector3 _lazerOffset = new Vector3(0, 0.8f, 0);
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLazer();
        }
    }

    void CalculateMovement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLazer()
    {
            _canFire = Time.time + _fireRate;
            Instantiate(_lazerPrefab, transform.position + _lazerOffset, Quaternion.identity);
    }
}
