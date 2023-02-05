using UnityEngine;

public class PreviewController : MonoBehaviour
{
    [Header("Meshes")]
    public MeshRenderer meshRenderer;
    public MeshFilter previewMeshFilter;
    [SerializeField] private Mesh[] meshes;
    [Header("Preview")] 
    public GameObject preview;
    
    [Header("Materials")]
    [SerializeField] private Material canBuild;
    [SerializeField] private Material cantBuild;
   
    [Header("Other Scripts")]
    [SerializeField] private Currency _currency;
    [SerializeField] private BuildingPlacementControl _control;
   
    
    [Header("bools")]
    [HideInInspector] public bool isColliding = false;
    [HideInInspector] public bool haveEnoughMoney = true;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isBuildable;
   

    
    private void Start()
    {
        preview.SetActive(false);
    }


  
    
    

    private void Update()
    {
        var position = transform.position;
        isGrounded = Physics.Raycast(position, Vector3.down, 1f);
        isColliding = Physics.CheckBox(position, transform.localScale, Quaternion.identity, LayerMask.GetMask("Buildable", "Building", "Castle"));
        haveEnoughMoney = _currency.coins >= _control.cost;
        
        if (!isColliding && haveEnoughMoney && isGrounded)
        {
            isBuildable = true;
            meshRenderer.material = canBuild;
        }
        else
        {
            isBuildable = false;
            meshRenderer.material = cantBuild;
          
        }


    }


    public void ShowPreview()
    {
        previewMeshFilter.mesh = meshes[_control.index];
        preview.SetActive(true);
        
    }

    public void HidePreview()
    {
        preview.SetActive(false);
        preview.transform.rotation = Quaternion.identity;
        _control.currentBuilding = null;
    }
}


