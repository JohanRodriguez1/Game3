using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabObstacle;

    private Vector3 GeneratorPosition = new Vector3(21,0,0);
    private float DelayTime = 2f;
    private float IntervalRepeat;

    private PlayerController ControllScript;

    // Start is called before the first frame update
    void Start()
    {
        ControllScript = GameObject.Find("Character").GetComponent<PlayerController>();
        Invoke("ObstacleGenerate", DelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ObstacleGenerate()
    {
        IntervalRepeat = Random.Range(1.25f, 2.25f);
        if (!ControllScript.GameOver)
        {
            Instantiate(_prefabObstacle, GeneratorPosition, _prefabObstacle.transform.rotation);
            Invoke("ObstacleGenerate", IntervalRepeat);
        }
    }
}
