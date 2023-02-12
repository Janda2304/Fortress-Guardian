using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG_BuildingSystem
{
    public class TowerRangePreview : MonoBehaviour
    {
        public MeshRenderer meshRenderer;
        public MeshFilter meshFilter;
        [SerializeField] private Mesh[] rangeMeshes;
        [SerializeField] private PreviewController _preview;
        [SerializeField] private BuildingPlacementControl _control;
        [SerializeField] private Material rangeMaterial;

        

        public void ShowRange()
        {
            meshFilter.mesh = rangeMeshes[_control.index];
            meshRenderer.material = rangeMaterial;
            meshRenderer.gameObject.SetActive(true);

        }

        public void HideRange()
        {
            meshRenderer.gameObject.SetActive(false);
        }
    }
}

