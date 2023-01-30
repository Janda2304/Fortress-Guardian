using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementControl : MonoBehaviour
{
    [SerializeField] private GameObject[] building;
   [SerializeField] private GameObject[] buildingPreview;
   [SerializeField] private LayerMask groundLayer;
   [SerializeField] private Camera playerCamera;
   private Currency _currency;
   private GameObject currentBuilding;
   private int index = 0;
   private bool isBuilding;



   private bool IsBuildable()
   {
       //a raycast to check if the building can be placed by checking if the building is overlapping with another building
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, groundLayer))
            {
                if (hit.collider.gameObject.CompareTag("Buildable"))
                {
                    return true;
                }
            }
            return false;
   }


   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && currentBuilding == null)
        {
           Build(building[0], buildingPreview[0]);

        }
        else if(Input.GetKeyDown(KeyCode.Q) && currentBuilding != null)
        {
           CancelBuild(buildingPreview[0]);
        }
       
        if (Input.GetButtonDown("Fire1") && isBuilding && IsBuildable())
        {
            Instantiate(building[index], buildingPreview[0].transform.position, Quaternion.identity);
            CancelBuild(buildingPreview[0]);
        }
         
      
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
             
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
             
        }
        
        if (isBuilding)
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, groundLayer))
            {
                buildingPreview[index].transform.position = new Vector3(hit.point.x, 2.849f, hit.point.z);
               
                
            }
           
           
        }
        
        
        void Build(GameObject _building, GameObject buildPreview)
        {
            currentBuilding = _building;
            buildPreview.SetActive(true);
            isBuilding = true;
        }
        
        void CancelBuild(GameObject buildPreview)
        {
            currentBuilding = null;
            buildPreview.SetActive(false);
            isBuilding = false;
        }
    }
}
