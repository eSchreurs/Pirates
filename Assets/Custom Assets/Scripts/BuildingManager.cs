using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public GameObject selectedBuilding;
    public GameObject constructionPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame .
    void Update() {
        if (selectedBuilding != null && selectedBuilding.GetComponent<Building>().isPlaced == false) {
            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && hit.collider.name == "Grid") {
                selectedBuilding.transform.position = Vector3.MoveTowards(selectedBuilding.transform.position, hit.point, 10f);
                if (Input.GetMouseButtonDown(0)) {
                    if (selectedBuilding.GetComponent<Building>().canBuild == true) {
                        selectedBuilding.GetComponent<Building>().isSelected = false;
                        selectedBuilding.GetComponent<Building>().isPlaced = true;
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

        if (Input.GetMouseButtonDown(0) && selectedBuilding != null) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.tag != "Building") {
                selectedBuilding.GetComponent<Building>().isSelected = false;
                selectedBuilding.GetComponent<Renderer>().material.color = Color.white;
                constructionPanel.SetActive(false);
                selectedBuilding = null;
            }
        }
    }

    public void CreateBuilding(GameObject building) {
        var v3 = Input.mousePosition;
        v3.z = 10;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        selectedBuilding = Instantiate(building, v3, Quaternion.identity);
        selectedBuilding.name = building.name;
        selectedBuilding.GetComponent<Renderer>().material.color = Color.green;
        selectedBuilding.GetComponent<Building>().isSelected = true;
    }


}
