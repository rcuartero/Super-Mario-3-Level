using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectList;

    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(0, objectList.Length);
        GameObject item = Instantiate(objectList[randomNum], gameObject.transform);
        item.transform.position = transform.position;
    }
}
