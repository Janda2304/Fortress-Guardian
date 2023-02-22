using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FG_NewBuildingSystem;
using FG_Saving;
using UnityEngine;


[CreateAssetMenu(fileName = "New Building Data", menuName = "Building Data")]
public class BuildingData : ScriptableObject
{
  public List<string> savedBuildings = new List<string>();
  public List<Vector3> savedBuildingPositions = new List<Vector3>();
  public List<Quaternion> savedBuildingRotations = new List<Quaternion>();
  public List<float> savedBuildingHealth = new List<float>();


  public void SaveData()
  {
    savedBuildings.Clear();
    savedBuildingPositions.Clear();
    savedBuildingRotations.Clear();
    savedBuildingHealth.Clear();
    
    SaveManage.buildings = GameObject.FindGameObjectsWithTag("Building").ToList();
    foreach (var building in SaveManage.buildings)
    {
      savedBuildings.Add(building.GetComponent<BuildingBehaviour>().buildingName);
      savedBuildingPositions.Add(building.transform.position);
      savedBuildingRotations.Add(building.transform.rotation);
      savedBuildingHealth.Add(building.GetComponent<BuildingBehaviour>().health);
      
    }
  }
  
}
