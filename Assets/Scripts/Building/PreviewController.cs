using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewController : MonoBehaviour
{
    [Header("Meshes")]
    public MeshRenderer meshRenderer;
    public MeshFilter previewMeshFilter;
    public MeshCollider previewCollider;
    [SerializeField] private Mesh[] meshes;
    [Header("Preview")] 
    public GameObject preview;
    
    [Header("Materials")]
    [SerializeField] private Material canBuild;
    [SerializeField] private Material cantBuild;
   
    [Header("Other Scripts")]
    [SerializeField] private Currency _currency;
    [SerializeField] private BuildingPlacementControl _control;
    
    
    [HideInInspector] public bool isBuildable = true;
    [HideInInspector] public bool haveEnoughMoney;
    
    public bool IsGrounded = false; 


    private void Start()
    {
        preview.SetActive(false);
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Buildable"))
        {
            isBuildable = false;
            meshRenderer.material = cantBuild;
         
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Buildable"))
        {
            isBuildable = true;
            meshRenderer.material = canBuild;
        
        }
    }
  
    
       
    

    private void FixedUpdate()
    {
        if (_currency.coins < _control.cost && isBuildable)
        {
            isBuildable = false;
            haveEnoughMoney = false;
            meshRenderer.material = cantBuild;
        }
        else if (_currency.coins >= _control.cost && isBuildable)
        {
            isBuildable = true;
            haveEnoughMoney = true;
            meshRenderer.material = canBuild;
        }


    }


    public void ShowPreview()
    {
        previewMeshFilter.mesh = meshes[_control.index];
        previewCollider.sharedMesh = meshes[_control.index];
        preview.SetActive(true);
        
    }

    public void HidePreview()
    {
        preview.SetActive(false);
        preview.transform.rotation = Quaternion.identity;
        _control.currentBuilding = null;
    }
}
