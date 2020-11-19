using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public int level = 1;
    public GameObject[] levels;
    public bool isSelected = false;
    public bool isPlaced = false;
    public bool canBuild = true;
    public GameObject selectedBuilding;
    public GameObject buildingManager;

    // Start is called before the first frame update
    void Start() {

    }

    void Awake() {
        buildingManager = GameObject.Find("BuildingManager");
    }

    // Update is called once per frame
    void Update() {

    }

    void OnMouseDown() {
        GameObject canvas = GameObject.Find("Canvas");
        Transform constructionPanel = canvas.transform.Find("ConstructionPanel");
        GameObject selectedBuilding = buildingManager.GetComponent<BuildingManager>().selectedBuilding;
        if (selectedBuilding == null || selectedBuilding.GetComponent<Building>().isPlaced == true) {
            if (selectedBuilding != null) {
               selectedBuilding.GetComponent<Renderer>().material.color = Color.white;
            }
            buildingManager.GetComponent<BuildingManager>().selectedBuilding = this.gameObject;
            this.isSelected = true;
            this.GetComponent<Renderer>().material.color = Color.green;
            constructionPanel.gameObject.GetComponent<ConstructionPanel>().setBuildingInfo(this.gameObject);
            constructionPanel.gameObject.SetActive(true);
        }

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
    public void ChangeModel() {
        if (level < levels.Length) {
            level++;
            Debug.Log("level " + level + " / " + levels.Length);
            Mesh mesh = levels[level - 1].GetComponent<MeshFilter>().sharedMesh;
            this.GetComponent<MeshFilter>().mesh = Instantiate(mesh);
        }
    }
}
