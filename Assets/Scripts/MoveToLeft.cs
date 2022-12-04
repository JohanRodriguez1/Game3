using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    [SerializeField] private float _velocity = 7f;
    
    private float LeftLimit = -8f;
    private PlayerController ControllScript;

    // Start is called before the first frame update
    void Start()
    {
        ControllScript = GameObject.Find("Character").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ControllScript.GameOver)
        {
            transform.Translate(Vector3.left * _velocity * Time.deltaTime);
        }
        if (transform.position.x < LeftLimit && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
