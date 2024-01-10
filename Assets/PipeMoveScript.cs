using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 5;
    public float time_passed = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("PipeMoveSpeed", 5);
    }

    // Update is called once per frame
    void Update()
    {
        time_passed += Time.deltaTime;
        transform.position = transform.position + (Vector3.left * PlayerPrefs.GetFloat("PipeMoveSpeed") * Time.deltaTime);
        
        if(time_passed > 10)
        {
            time_passed = 0;
            PlayerPrefs.SetFloat("PipeMoveSpeed", PlayerPrefs.GetFloat("PipeMoveSpeed") + 1);
            Debug.Log(PlayerPrefs.GetFloat("PipeMoveSpeed"));
        }

        if (transform.position.x < -40)
        {
            Destroy(gameObject);
        }
    }
}
