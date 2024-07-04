using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
        [SerializeField]
        private float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        shooting();
    }

    void shooting()
    { 
            if (transform.position.y > 8f)
            {
                Destroy(this.gameObject);
            }


            transform.Translate(Vector3.up * speed * Time.deltaTime);     
    }
}

