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
    [SerializeField]
    private GameObject _tripleshotprefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    private Vector3 _lazerOffset = new Vector3(0, 1.05f, 0);
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _isTripleShotActive = false;



   //variable for isTripleShotActive


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
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

        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleshotprefab, transform.position + _lazerOffset, Quaternion.identity);

        }
        else if (_isTripleShotActive == false)
        {
            Instantiate(_lazerPrefab, transform.position + _lazerOffset, Quaternion.identity);
        }
        
        //if space pressed
        //if tripple shot active is true
            //fire 3 lasers

        //else if, fire 1 laser

        //instantiate 3 lasers (triple shot)
    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
         StartCoroutine("TripleShotDown");
       
        //triple shot active becomes true
        //start the power down coroutine for triple shot
    }

    IEnumerator TripleShotDown()
    {
        while(_isTripleShotActive == true)
        {
            yield return new WaitForSeconds(5);
            _isTripleShotActive = false;
        }

    }
    //ieneuemrator triple hot down routine
    //wait 5 sec
    //set the triple shot to false
}
