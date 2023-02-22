using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG_NewBuildingSystem
{
    public class BuildingSystem : MonoBehaviour
    {
        public List<Building> buildings = new List<Building>();

        [Header("Other")] 
        [SerializeField] private LayerMask ground;
        [SerializeField] private Camera playerCam;
        [SerializeField] private BuildingSoundsControl _sounds;
        
        [Header("KeyCodes")]
        [SerializeField] private KeyCode[] buildKeys = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9};
        


        [Header("Checks")] 
        private bool isGrounded;
        private bool isBuilding;
        private bool haveMoney;
        private bool isColliding;
        private bool isBuildable;
        

        private int index;

      
       


        private void FixedUpdate()
        {
            #region Preview Moving
            if (isBuilding)
            {
                Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10, ground))
                {
                    buildings[index].preview.transform.position = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
               
                
                }

                if (Input.GetKey(KeyCode.R))
                {
                    buildings[index].preview.transform.Rotate(0, 3f, 0);
                }
           
           
            }
            #endregion
        }
        void Update()
        {
            #region Checks
            isGrounded = Physics.Raycast(buildings[index].preview.transform.position, Vector3.down, 1f);
            isColliding = Physics.CheckBox(buildings[index].preview.transform.position, transform.localScale, Quaternion.identity, LayerMask.GetMask("Buildable", "Building", "Castle", "Enemy", "Player"));
            haveMoney = buildings[index].cost <= Currency.Coins;
            if (isGrounded && !isColliding && haveMoney && isBuilding)
            {
                isBuildable = true;
            }
            else
            {
                isBuildable = false;
            }
            #endregion

            buildings[index].PreviewMeshRenderer.material = !isBuildable ? buildings[index].cantBuild : buildings[index].canBuild;
            if (Input.GetKeyDown(buildKeys[0]))
            {
                SetupBuild(0);
            }
           
            if (Input.GetKeyDown(buildKeys[1]))
            {
                SetupBuild(1);
            }

            #region build

            if (Input.GetButtonDown("Fire1") && isBuildable)
            {
                Building building = buildings[index];
                building.Build();
                isBuilding = false;
                _sounds.PlayBuildingSound();
            }
            else if (Input.GetButtonDown("Fire1") && !isBuildable && isBuilding)
            {
                _sounds.PlayErrorSound();
            }

            #endregion

        }
        
        
        #region Setup Build
        private void SetupBuild(int i)
        {
            Building building = buildings[i];
            index = i;
                if (isBuilding)
                {
                    building.HidePreview();
                    isBuilding = false;
                }
                else
                {
                    building.ShowPreview();
                    isBuilding = true;
                }

             
        }
        #endregion
    }
    
    #region Building Class
    [Serializable]
    public class Building 
    {
        public GameObject building;
        [Header("Preview")]
        public Material canBuild;
        public Material cantBuild;
        public MeshRenderer PreviewMeshRenderer;
        public GameObject preview;
        [Header("Meshes")]
        public Mesh previewMesh;
        public MeshFilter previewFilter;
        public MeshFilter rangePreviewFilter;
        public Mesh rangePreviewMesh;
        [Header("Price")]
        public int cost;

        public void Build()
        {
            GameObject curBuilding = building;
            MonoBehaviour.Instantiate(curBuilding, preview.transform.position, preview.transform.rotation);
            Currency.PayCoins(cost);
            HidePreview();
        }
        
        public void ShowPreview()
        {
            preview.gameObject.SetActive(true);
            previewFilter.mesh = previewMesh;
            rangePreviewFilter.mesh = rangePreviewMesh;
            
            
        }
        
        public void HidePreview()
        {
            preview.gameObject.SetActive(false);
            preview.transform.rotation = Quaternion.identity;
        }
    }
    #endregion

}
