using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool isSelected = false;
    public bool canBuild = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col) {
        if (col.gameObject.name != "Grid") {
            this.GetComponent<Renderer>().material.color = Color.red;
            this.canBuild = false;
        }
    }
    void OnTriggerExit(Collider col) {
        if (isSelected) {
            this.GetComponent<Renderer>().material.color = Color.green;
            this.canBuild = true;
        } else {
            this.GetComponent<Renderer>().material.color = Color.white;
            this.canBuild = true;
        }
    }
}
