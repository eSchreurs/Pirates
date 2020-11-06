using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionPanel : MonoBehaviour {
    //public Button upgradeBtn = 

    // Start is called before the first frame update
    void Start() {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    public void setBuildingInfo(GameObject building) {
        this.transform.Find("NameTXT").gameObject.GetComponent<Text>().text = building.name;
        this.transform.Find("LevelTXT").gameObject.GetComponent<Text>().text = "Level " + (building.GetComponent<Building>().level).ToString();
    }

    public void UpgradeBuilding() {
        GameObject buildingManager = GameObject.Find("BuildingManager");
        GameObject selectedBuilding = buildingManager.GetComponent<BuildingManager>().selectedBuilding;
        selectedBuilding.GetComponent<Building>().ChangeModel();
        this.setBuildingInfo(selectedBuilding);
    }
}
