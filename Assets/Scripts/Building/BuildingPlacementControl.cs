using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementControl : MonoBehaviour
{ 
    #region Variables
    [Header("Building Prefabs")]
    [SerializeField] private GameObject[] building;
    
    [Header("Coordinates")]
    [SerializeField] private float[] objectY;
   
    [Header("Others")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Camera playerCamera;
    
    [Header("Other Scripts")]
    [SerializeField] private PreviewController _previewControl;
    [SerializeField] private Currency _currency;

    #region Private and Hidden Variables
   
    private Dictionary<string, int> prices = new Dictionary<string, int>();
    [HideInInspector] public int cost;
    [HideInInspector] public byte index = 0;
    [HideInInspector] public bool isBuilding = false;
    [HideInInspector] public GameObject currentBuilding;
   
    #endregion Private and Hidden Variables
   
    #endregion Variables
    
    #region Dictionary Data Setup
    private void Start()
    {
        prices.Add("Cylinder", 50);
        prices.Add("Fence", 100);

    }
    #endregion Dictionary Data Setup    
    

    void Update()
    {
        #region Building Placement
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BuildSetup(0);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          BuildSetup(1);
        }
        
       
        if (Input.GetButtonDown("Fire1") && isBuilding && _previewControl.isBuildable && _previewControl.haveEnoughMoney )
        {
            Instantiate(currentBuilding, _previewControl.preview.transform.position, _previewControl.preview.transform.rotation);
            _currency.coins -= cost;
            isBuilding = false;
            _previewControl.HidePreview();
        }
        #endregion Building Placement
        
        #region Preview Moving
        if (isBuilding)
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, groundLayer))
            {
                _previewControl.preview.transform.position = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
               
                
            }

            if (Input.GetKey(KeyCode.R))
            {
                _previewControl.preview.transform.Rotate(0, 0.5f, 0);
            }
           
           
        }
        #endregion Preview Moving
        
        
    }

    void BuildSetup(byte index)
    {
        if (!isBuilding)
        {
            isBuilding = true;
            this.index = index;
            currentBuilding = building[index];
            cost = prices[building[index].name];
            _previewControl.ShowPreview();
        }
        else if (isBuilding)
        {
            _previewControl.HidePreview();
            isBuilding = false;
        }
    }
    
}
