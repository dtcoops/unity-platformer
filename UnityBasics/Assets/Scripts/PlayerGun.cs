using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) == true)
        {
            Debug.Log("Right Mouse Clicked");
            GameObject gameObject = Instantiate(bullet, this.transform.position, this.transform.rotation);

        }
    }
}
