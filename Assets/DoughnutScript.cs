using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DoughnutScript : MonoBehaviour
{
    public float time_passed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_passed += Time.deltaTime;
        transform.position = transform.position + (Vector3.left * PlayerPrefs.GetFloat("DoughnutMoveSpeed") * Time.deltaTime);

        if (time_passed > 10)
        {
            time_passed = 0;
            PlayerPrefs.SetFloat("DoughnutMoveSpeed", PlayerPrefs.GetFloat("DoughnutMoveSpeed") + 1);
        }

        if (transform.position.x < -40)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
