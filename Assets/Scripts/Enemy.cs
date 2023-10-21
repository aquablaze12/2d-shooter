using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //if bottom of screen
        //respawn at top
        //with a new random x position

        if (transform.position.y < -6f)
        {
            float randomX = Random.Range(-8.5f, 8.5f);
            transform.position = new Vector3(randomX, 6.5f, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if other is Player

        if(other.tag == "Player")
        {
            //damage player
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
        


        //if other is lazer

        if(other.tag == "Lazer")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }

}
