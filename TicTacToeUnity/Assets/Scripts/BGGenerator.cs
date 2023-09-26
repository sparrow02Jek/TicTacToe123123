using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BGGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public float _frequence;
    public GameObject point1, point2;
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    IEnumerator spawn()
    {
        while (true)
        {
            _frequence = Random.Range(0, 4);
            yield return new WaitForSeconds(_frequence);
            float _x = Random.Range(point1.transform.position.x, point2.transform.position.x);
            float _y = Random.Range(point1.transform.position.y, point2.transform.position.y);
            GameObject _obj = Instantiate(objects[Random.Range(0, objects.Length)], new Vector2(_x, _y), Quaternion.identity);
            Destroy(_obj, _frequence + 1f);
        }
    }
}
