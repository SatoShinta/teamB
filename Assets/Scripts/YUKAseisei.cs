using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUKAseisei : MonoBehaviour
{
    [SerializeField, Header("床のオブジェクト")] GameObject YUKA;
    // Start is called before the first frame update
    void Start()
    {
        for (int xi = -6; xi < 6; xi++)
        {
            for(int yi = -4; yi < 5; yi++)
            {
                
                Instantiate(YUKA, new Vector3(xi,yi,0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
