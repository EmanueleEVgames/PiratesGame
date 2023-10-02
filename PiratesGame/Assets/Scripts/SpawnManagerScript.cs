using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    [SerializeField]
    GameObject obj1;

    [SerializeField]
    GameObject obj2;

    [SerializeField]
    GameObject obj3;

    [SerializeField]
    Transform swanPoint1;

    [SerializeField]
    Transform swanPoint2;

    public List<GameObject> objList = new List<GameObject>();


    IEnumerator SpawnBackground()
    {
        while (true)
        {
            //Instantiate(obj1, swanPoint1.position, Quaternion.identity); ;
            //yield return new WaitForSeconds(5f);

            int randomNum = UnityEngine.Random.Range(0, objList.Count);
            //Debug.Log("OGGETTO: " + randomNum);
            GameObject rObj = objList[randomNum];
            Instantiate(rObj, swanPoint1.position, Quaternion.identity); ;

            randomNum = UnityEngine.Random.Range(0, objList.Count);
            //Debug.Log("OGGETTO: " + randomNum);
            GameObject rObj2 = objList[randomNum];
            Instantiate(rObj2, swanPoint2.position, Quaternion.identity); ;

            yield return new WaitForSeconds(5f);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBackground());
    }

    // Update is called once per frame
    void Awake()
    {
        objList.Add(obj1); 
        objList.Add(obj2);
    }
}
