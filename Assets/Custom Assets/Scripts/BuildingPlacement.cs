using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    private GameObject selectedBuilding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame .
    void Update()
    {
        if (selectedBuilding != null) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.name == "Grid") {
                selectedBuilding.transform.position = Vector3.MoveTowards(selectedBuilding.transform.position, hit.point, 10f);

                if (Input.GetMouseButtonDown(0)) {
                    if (selectedBuilding.GetComponent<Building>().canBuild == true) {
                        selectedBuilding.GetComponent<Building>().isSelected = false;
                        selectedBuilding.GetComponent<Renderer>().material.color = Color.white;
                        Debug.Log(selectedBuilding.transform.name + " created!");
                        selectedBuilding = null;
                    } else {
                        selectedBuilding.GetComponent<Building>().isSelected = false;
                        Debug.Log("Can not build " + selectedBuilding.transform.name + " here...");
                    }
                }
            }
        }
    }

    public void SelectBuilding(GameObject building) {
        var v3 = Input.mousePosition;
        v3.z = 10;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        selectedBuilding = Instantiate(building, v3, Quaternion.identity);
        selectedBuilding.layer = 2;
        selectedBuilding.GetComponent<Renderer>().material.color = Color.green;
        selectedBuilding.GetComponent<Building>().isSelected = true;
    }

}
