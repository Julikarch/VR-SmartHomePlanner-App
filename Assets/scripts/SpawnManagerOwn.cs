using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.BuildingBlocks;
using Meta.XR.MRUtilityKit;
using scripst;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace scripts
{
    public class SpawnManagerOwn : MonoBehaviour
    {
        // [SerializeField]
        // TMP_Dropdown m_ObjectSelectorDropdown;

        // [SerializeField]
        // TMP_Dropdown m_TypeSelectorDropdown;

        // [SerializeField]
        // Button m_DestroyObjectsButton;

        // [SerializeField]
        // Button m_StartProgramming;

        // [SerializeField]
        // Button m_AddButton;

        // [SerializeField]
        // Toggle m_ShowMesh;

        // [SerializeField]
        // RoomMeshController m_MeshController;

        [SerializeField]
        Transform player;

        [SerializeField]
        float distance = 1;

        [SerializeField]
        bool test = false;

        [SerializeField]
        public TutorialManager tutorialManager;

        [SerializeField]
        public GameObject tutorial;

        [SerializeField]
        public Button ShowMenu;
        [SerializeField]
        public GameObject Menu;

        [SerializeField]
        public Button ShowAutomation;
        [SerializeField]
        public GameObject Automation;

        private bool tutorialShown = false;

        EventSystem eventSystem;
        OVRCameraRig _cameraRig;
        EffectMesh globalMeshEffectMesh = null;

        // [SerializeField] private Slider _lightIntensitySlider;
        // [SerializeField] private Light _sceneMaterial;
        // [SerializeField] private OVRPassthroughLayer _passthroughLayer;
        // [SerializeField] private Slider _passthroughBrightnessSlider;
        // [SerializeField] private Slider _passthroughBrightnessSlider2;
        // [SerializeField] private TMP_Dropdown _geometryDropDown;

        // [SerializeField] private Slider _lightIntensitySlider1;
        // [SerializeField] private Material _sceneMaterial1;
        // [SerializeField] private OVRPassthroughLayer _passthroughLayer1;
        // [SerializeField] private Slider _passthroughBrightnessSlider1;
        // [SerializeField] private Slider _lightBlendFactor;

        // [SerializeField] public Material glow;

        private EffectMesh[] effectMeshes;

        private const string HighLightAttenuationShaderPropertyName = "_HighLightAttenuation";
        private const string HighLightOpaquenessShaderPropertyName = "_HighlightOpacity";

        ObjectSpawnerOwn m_Spawner;

        private void Start()
        {
            eventSystem = gameObject.GetComponent<EventSystem>();
//#if UNITY_EDITOR
//            OVRTelemetry.Start(TelemetryConstants.MarkerId.LoadSceneDebugger).Send();
//#endif
            globalMeshEffectMesh = GetGlobalMeshEffectMesh();
            if (!_cameraRig)
            {
                _cameraRig = FindObjectOfType<OVRCameraRig>();
            }
        }

        [SerializeField] private GameObject _objects;
        [SerializeField] private bool showAutomationMenu;


        private void Update()
        {
            
            if (test)
            {
                test = false;
               OnAddButton(_objects);
            }
            if(showAutomationMenu){
                showAutomationMenu = false;
                OnShowAutomation();
            }
        }

        void OnEnable()
        {
            m_Spawner = GetComponent<ObjectSpawnerOwn>();
            m_Spawner.spawnAsChildren = true;
            // OnObjectSelectorDropdownValueChanged(m_ObjectSelectorDropdown.value);
            // m_ObjectSelectorDropdown.onValueChanged.AddListener(OnObjectSelectorDropdownValueChanged);
            // m_DestroyObjectsButton.onClick.AddListener(OnDestroyObjectsButtonClicked);
            // m_StartProgramming.onClick.AddListener(OnStartProgramming);
            // m_ShowMesh.onValueChanged.AddListener(OnChangeMesh);
            // //m_AddButton.onClick.AddListener(OnAddButton);
            // _geometryDropDown.onValueChanged.AddListener(GeometrySettingsChanged);
            // _passthroughBrightnessSlider.onValueChanged.AddListener(
            //     (brightness) =>
            //     {
            //         //_passthroughLayer.SetBrightnessContrastSaturation(brightness);
            //         _sceneMaterial.intensity = brightness;
            //     }
            // );
            // _lightIntensitySlider.onValueChanged.AddListener(
            //     (val) => { _sceneMaterial.range = val; }
            // );
            // _passthroughBrightnessSlider1.onValueChanged.AddListener(
            //     (brightness) =>
            //     {
            //         _passthroughLayer.SetBrightnessContrastSaturation(brightness);
            //     }
            // );
            // _lightBlendFactor.onValueChanged.AddListener(
            //     (val) => { _sceneMaterial1.SetFloat(HighLightOpaquenessShaderPropertyName, val); }
            // );
            // _lightIntensitySlider1.onValueChanged.AddListener(
            //     (val) => { _sceneMaterial1.SetFloat(HighLightAttenuationShaderPropertyName, val); }
            // );
            // effectMeshes = FindObjectsOfType<EffectMesh>();

            // _passthroughBrightnessSlider2.onValueChanged.AddListener((var) => { Camera.main.backgroundColor = new Color(0, 0, 0, var); });

            ShowMenu.onClick.AddListener(OnShowMenu);
            ShowAutomation.onClick.AddListener(OnShowAutomation);
        }

        void OnDisable()
        {
            // m_ObjectSelectorDropdown.onValueChanged.RemoveListener(OnObjectSelectorDropdownValueChanged);
            // m_DestroyObjectsButton.onClick.RemoveListener(OnDestroyObjectsButtonClicked);
            // m_StartProgramming.onClick.RemoveListener(OnStartProgramming);
            // m_ShowMesh.onValueChanged.RemoveListener(OnChangeMesh);
        }

        void OnObjectSelectorDropdownValueChanged(int value)
        {
            m_Spawner.spawnOptionIndex = value;
        }

        void OnDestroyObjectsButtonClicked()
        {
            foreach (Transform child in m_Spawner.transform)
            {
                Destroy(child.gameObject);
            }
        }

        void OnStartProgramming()
        {
        }

        public void OnShowMenu()
        {
            Menu.SetActive(!Menu.activeInHierarchy);
            Vector3 pos = player.position + Vector3.forward * distance;
            pos.y = 1f;
            Menu.transform.position = pos;
        }

        public void OnShowAutomation()
        {
            if(tutorialShown){
                Automation.SetActive(!Automation.activeInHierarchy);
                Vector3 pos = player.position + Vector3.forward * distance;
                pos.y = 1f;
                Automation.transform.position = pos;
            } else {
                tutorialShown = true;
                Menu.SetActive(false);
                tutorial.SetActive(true);
                tutorial.transform.Find("CoachingCardRoot/Card 9 Automation").gameObject.SetActive(true);
            }
        }

        public void OnAddButton(GameObject gameObject)
        {
            m_Spawner.TrySpawnObject(player.position + Vector3.forward * distance, gameObject, player.rotation);
        }

        void OnChangeMesh(bool arg0)
        {
            // m_MeshController.enabled = arg0;
        }

        private EffectMesh GetGlobalMeshEffectMesh()
        {
            EffectMesh[] effectMeshes = FindObjectsByType<EffectMesh>(FindObjectsSortMode.None);
            foreach (EffectMesh effectMesh in effectMeshes)
            {
                if ((effectMesh.Labels & MRUKAnchor.SceneLabels.GLOBAL_MESH) != 0)
                {
                    return effectMesh;
                }
            }
            return null;
        }

        public void ToggleGeometryDropDown()
        {
            bool globalMeshExists = MRUK.Instance && MRUK.Instance.GetCurrentRoom() && MRUK.Instance.GetCurrentRoom().GlobalMeshAnchor;
            // _geometryDropDown.interactable = globalMeshExists;
        }


        private void GeometrySettingsChanged(int optionSelected)
        {
            if (optionSelected == 1)
            {
                foreach (var effectMesh in effectMeshes)
                {
                    if ((effectMesh.Labels & MRUKAnchor.SceneLabels.GLOBAL_MESH) == 0)
                    {
                        effectMesh.DestroyMesh();
                    }
                    else
                    {
                        effectMesh.CreateMesh();
                    }
                }
            }
            else if (optionSelected == 0)
            {
                foreach (var effectMesh in effectMeshes)
                {
                    if ((effectMesh.Labels & MRUKAnchor.SceneLabels.GLOBAL_MESH) != 0)
                    {
                        effectMesh.DestroyMesh(LabelFilter.FromEnum(effectMesh.Labels));
                    }
                    else
                    {
                        effectMesh.CreateMesh();
                    }
                }
            } else
            {
                foreach (var effectMesh in effectMeshes)
                {
                    if ((effectMesh.Labels & MRUKAnchor.SceneLabels.GLOBAL_MESH) != 0 && (effectMesh.Labels & MRUKAnchor.SceneLabels.FLOOR) != 0)
                    {
                        effectMesh.DestroyMesh(LabelFilter.FromEnum(effectMesh.Labels));
                    }
                    else
                    {
                        effectMesh.CreateMesh();
                    }
                }
            }
            //_oppyController.Respawn();

        }
    }
}
