using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player : MonoBehaviour
{
    [SerializeField]
    public float speed = 3.5f;   
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float firerate = 0.5f;
    private float canfire = -1f;
    [SerializeField]
    private int lives = 3;
    private spawnmanager Spawnmanager; 
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        Spawnmanager = GameObject.Find("spawnmanager").GetComponent<spawnmanager>();
        if (Spawnmanager == null)
        {
            Debug.LogError("The spawn manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Calculatemovment();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canfire)
        {
           shooting();
        }
            
    }

    void Calculatemovment()
    {
        float horazontalinput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * horazontalinput * speed * Time.deltaTime);

        float verticallinput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticallinput * speed * Time.deltaTime);



        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -1, 8), 0);



        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void shooting()
    {
            canfire = Time.time + firerate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }


    public void damage()
    {

        lives--;

        if (lives < 1)
        {
             if (Spawnmanager != null)
            {
                Spawnmanager.onplayerdeath();
            }
            
            Destroy(gameObject);
        }
    }



}  
