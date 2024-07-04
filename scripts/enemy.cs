using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       


        if (transform.position.y <= -4.5f) 
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 10.5f, 0);

        }

        transform.position += Vector3.down * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  if (other.tag == "Player")
        {
            player Player = other.transform.GetComponent<player>();

            if(Player != null)
            {
                Player.damage();
            }

            Destroy(this.gameObject);
        }


        if (other.tag == "laser")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    
}
