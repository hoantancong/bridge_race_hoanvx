using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObject
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnRemove()
    {
        //GetComponentInParent<Ground>().RemoveBrick(this);
        gameObject.transform.parent = null;
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
