using System;
using System.Collections;
using System.Collections.Generic;
using scripst;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using TMPro;
using static DebugUIBuilder;
using UnityEngine.Video;

namespace scripts
{
    public class ObjectSpawnerOwn : MonoBehaviour
    {

        public static List<SpawnedObject> objekte = new List<SpawnedObject>();

        [SerializeField]
        public GameObject Visuals;
        [SerializeField]
        public Camera Kamera;
        [SerializeField]
        public AutomationManagerBottom automationManagerBottom;

        [SerializeField]
        public GameObject LampSettings;
        [SerializeField]
        public GameObject AirSensorSettings;
        [SerializeField]
        public GameObject AirPurifierSettings;
        [SerializeField]
        public GameObject SpeakerSettings;
        [SerializeField]
        public GameObject BlindsSettings;
        [SerializeField]
        public GameObject ControlSystemSettings;
        [SerializeField]
        public GameObject AirConditionerSettings;
        [SerializeField]
        public GameObject LightswitchSettings;
        [SerializeField]
        public GameObject RolloswitchSettings;
        [SerializeField]
        public GameObject MotionsensorSettings;
        [SerializeField]
        public GameObject TVSettings;
        [SerializeField]
        public GameObject CoffeeSettings;

        [SerializeField]
        public AudioClip Audio1;
        [SerializeField]
        public AudioClip Audio2;
        [SerializeField]
        public AudioClip Audio3;
        [SerializeField]
        public AudioClip Audio4;
        [SerializeField]
        public AudioClip AudioVideo;

        [SerializeField]
        public AudioSource CreateSound;


        [SerializeField]
        public bool test = false;
        [SerializeField]
        public GameObject testGO;


        [SerializeField]
        public bool testLamp = false;
        [SerializeField]
        public GameObject testLA;
        [SerializeField]
        public bool testBlind = false;
        [SerializeField]
        public GameObject testBL;


        [SerializeField]
        public bool testSpeaker = false;
        [SerializeField]
        public GameObject testSpeakerG;
        [SerializeField]
        public bool testPurifier = false;
        [SerializeField]
        public GameObject testPurifierG;
        // [SerializeField]
        // public bool testBlind = false;
        // [SerializeField]
        // public bool testBlind = false;

        public void Update()
        {
            if (test)
            {
                //GameObject test = Instantiate(LampSettings, Visuals.transform);
                //GameObject test = Instantiate(ControlSystemSettings, Visuals.transform);
                //Toggle[] toggles = test.GetComponentsInChildren<Toggle>();
                //foreach (Toggle t in toggles)
                //{
                //    switch (t.name)
                //    {
                //        case "DateToggle":
                //            Debug.Log("DateToggle");
                //            break;
                //        case "ClockToggle":
                //            Debug.Log("ClockToggle");
                //            break;
                //        case "CalendarToggle":
                //            Debug.Log("CalendarToggle");
                //            break;
                //        case "ControlToggle":
                //            Debug.Log("ControlToggle");
                //            break;
                //        default:
                //            Debug.Log(t.name);
                //            break;
                //    }
                //}
                //test.transform.parent = Visuals.transform;
                //Visuals.SetActive(false);
                //Visuals.SetActive(true);
                TrySpawnObject(new Vector3(0, 0, 0), testGO, new Quaternion(0,0,0,0));
            }
            if (testLamp)
            {
                testLamp = false;
                TrySpawnObject(Vector3.zero, testLA, new Quaternion(0,0,0,0));
            }
            if (testBlind)
            {
                testBlind = false;
                TrySpawnObject(Vector3.zero, testBL, new Quaternion(0,0,0,0));
            }
            if(testSpeaker){
                testSpeaker = false;
                TrySpawnObject(Vector3.zero, testSpeakerG, new Quaternion(0,0,0,0));
            }
            if(testPurifier){
                testPurifier = false;
                TrySpawnObject(Vector3.zero, testPurifierG, new Quaternion(0,0,0,0));
            }
        }

        [SerializeField]
        [Tooltip("The camera that objects will face when spawned. If not set, defaults to the main camera.")]
        Camera m_CameraToFace;

        /// <summary>
        /// The camera that objects will face when spawned. If not set, defaults to the <see cref="Camera.main"/> camera.
        /// </summary>
        public Camera cameraToFace
        {
            get
            {
                EnsureFacingCamera();
                return m_CameraToFace;
            }
            set => m_CameraToFace = value;
        }

        [SerializeField]
        [Tooltip("The list of prefabs available to spawn.")]
        List<GameObject> m_ObjectPrefabsLight = new List<GameObject>();

        /// <summary>
        /// The list of prefabs available to spawn.
        /// </summary>
        public List<GameObject> objectPrefabsLight
        {
            get => m_ObjectPrefabsLight;
            set => m_ObjectPrefabsLight = value;
        }

        [SerializeField]
        [Tooltip("The list of prefabs available to spawn.")]
        List<GameObject> m_ObjectPrefabsRollo = new List<GameObject>();

        /// <summary>
        /// The list of prefabs available to spawn.
        /// </summary>
        public List<GameObject> objectPrefabsRollo
        {
            get => m_ObjectPrefabsRollo;
            set => m_ObjectPrefabsRollo = value;
        }

        [SerializeField]
        [Tooltip("The list of prefabs available to spawn.")]
        List<GameObject> m_ObjectPrefabsSensor = new List<GameObject>();

        /// <summary>
        /// The list of prefabs available to spawn.
        /// </summary>
        public List<GameObject> objectPrefabsSensor
        {
            get => m_ObjectPrefabsSensor;
            set => m_ObjectPrefabsSensor = value;
        }

        [SerializeField]
        [Tooltip("The list of prefabs available to spawn.")]
        List<GameObject> m_ObjectPrefabsControl = new List<GameObject>();

        /// <summary>
        /// The list of prefabs available to spawn.
        /// </summary>
        public List<GameObject> objectPrefabsControl
        {
            get => m_ObjectPrefabsControl;
            set => m_ObjectPrefabsControl = value;
        }

        [SerializeField]
        [Tooltip("Optional prefab to spawn for each spawned object. Use a prefab with the Destroy Self component to make " +
            "sure the visualization only lives temporarily.")]
        GameObject m_SpawnVisualizationPrefab;

        /// <summary>
        /// Optional prefab to spawn for each spawned object.
        /// </summary>
        /// <remarks>Use a prefab with <see cref="DestroySelf"/> to make sure the visualization only lives temporarily.</remarks>
        public GameObject spawnVisualizationPrefab
        {
            get => m_SpawnVisualizationPrefab;
            set => m_SpawnVisualizationPrefab = value;
        }

        [SerializeField]
        [Tooltip("The index of the prefab to spawn. If outside the range of the list, this behavior will select " +
            "a random object each time it spawns.")]
        int m_ListOptionIndex = 0;

        [SerializeField]
        [Tooltip("The index of the prefab to spawn. If outside the range of the list, this behavior will select " +
            "a random object each time it spawns.")]
        int m_SpawnOptionIndex = 0;

        /// <summary>
        /// The index of the prefab to spawn. If outside the range of <see cref="objectPrefabs"/>, this behavior will
        /// select a random object each time it spawns.
        /// </summary>
        /// <seealso cref="isSpawnOptionRandomized"/>
        public int spawnOptionIndex
        {
            get => m_SpawnOptionIndex;
            set => m_SpawnOptionIndex = value;
        }

        /// <summary>
        /// Whether this behavior will select a random object from <see cref="objectPrefabs"/> each time it spawns.
        /// </summary>
        /// <seealso cref="spawnOptionIndex"/>
        /// <seealso cref="RandomizeSpawnOption"/>
        //public bool isSpawnOptionRandomized => m_SpawnOptionIndex < 0 || m_SpawnOptionIndex >= m_ObjectPrefabs.Count;

        [SerializeField]
        [Tooltip("Whether to only spawn an object if the spawn point is within view of the camera.")]
        bool m_OnlySpawnInView = true;

        /// <summary>
        /// Whether to only spawn an object if the spawn point is within view of the <see cref="cameraToFace"/>.
        /// </summary>
        public bool onlySpawnInView
        {
            get => m_OnlySpawnInView;
            set => m_OnlySpawnInView = value;
        }

        [SerializeField]
        [Tooltip("The size, in viewport units, of the periphery inside the viewport that will not be considered in view.")]
        float m_ViewportPeriphery = 0.15f;

        /// <summary>
        /// The size, in viewport units, of the periphery inside the viewport that will not be considered in view.
        /// </summary>
        public float viewportPeriphery
        {
            get => m_ViewportPeriphery;
            set => m_ViewportPeriphery = value;
        }

        [SerializeField]
        [Tooltip("When enabled, the object will be rotated about the y-axis when spawned by Spawn Angle Range, " +
            "in relation to the direction of the spawn point to the camera.")]
        bool m_ApplyRandomAngleAtSpawn = true;

        /// <summary>
        /// When enabled, the object will be rotated about the y-axis when spawned by <see cref="spawnAngleRange"/>
        /// in relation to the direction of the spawn point to the camera.
        /// </summary>
        public bool applyRandomAngleAtSpawn
        {
            get => m_ApplyRandomAngleAtSpawn;
            set => m_ApplyRandomAngleAtSpawn = value;
        }

        [SerializeField]
        [Tooltip("The range in degrees that the object will randomly be rotated about the y axis when spawned, " +
            "in relation to the direction of the spawn point to the camera.")]
        float m_SpawnAngleRange = 45f;

        /// <summary>
        /// The range in degrees that the object will randomly be rotated about the y axis when spawned, in relation
        /// to the direction of the spawn point to the camera.
        /// </summary>
        public float spawnAngleRange
        {
            get => m_SpawnAngleRange;
            set => m_SpawnAngleRange = value;
        }

        [SerializeField]
        [Tooltip("Whether to spawn each object as a child of this object.")]
        bool m_SpawnAsChildren;

        /// <summary>
        /// Whether to spawn each object as a child of this object.
        /// </summary>
        public bool spawnAsChildren
        {
            get => m_SpawnAsChildren;
            set => m_SpawnAsChildren = value;
        }

        /// <summary>
        /// Event invoked after an object is spawned.
        /// </summary>
        /// <seealso cref="TrySpawnObject"/>
        public event Action<GameObject> objectSpawned;

        /// <summary>
        /// See <see cref="MonoBehaviour"/>.
        /// </summary>
        void Awake()
        {
            EnsureFacingCamera();
        }

        void EnsureFacingCamera()
        {
            if (m_CameraToFace == null)
                m_CameraToFace = Camera.main;
        }

        /// <summary>
        /// Attempts to spawn an object from <see cref="objectPrefabs"/> at the given position. The object will have a
        /// yaw rotation that faces <see cref="cameraToFace"/>, plus or minus a random angle within <see cref="spawnAngleRange"/>.
        /// </summary>
        /// <param name="spawnPoint">The world space position at which to spawn the object.</param>
        /// <param name="spawnNormal">The world space normal of the spawn surface.</param>
        /// <returns>Returns <see langword="true"/> if the spawner successfully spawned an object. Otherwise returns
        /// <see langword="false"/>, for instance if the spawn point is out of view of the camera.</returns>
        /// <remarks>
        /// The object selected to spawn is based on <see cref="spawnOptionIndex"/>. If the index is outside
        /// the range of <see cref="objectPrefabs"/>, this method will select a random prefab from the list to spawn.
        /// Otherwise, it will spawn the prefab at the index.
        /// </remarks>
        /// <seealso cref="objectSpawned"/>
        //public bool TrySpawnObject(Vector3 spawnPoint, Vector3 spawnNormal)
        [SerializeField]
        public void TrySpawnObject(Vector3 spawnPoint, GameObject objectToSpawn, Quaternion rotation)
        {
            //if (m_OnlySpawnInView)
            //{
            //    var inViewMin = m_ViewportPeriphery;
            //    var inViewMax = 1f - m_ViewportPeriphery;
            //    var pointInViewportSpace = cameraToFace.WorldToViewportPoint(spawnPoint);
            //    if (pointInViewportSpace.z < 0f || pointInViewportSpace.x > inViewMax || pointInViewportSpace.x < inViewMin ||
            //        pointInViewportSpace.y > inViewMax || pointInViewportSpace.y < inViewMin)
            //    {
            //        return false;
            //    }
            //}

            int objectIndex = m_SpawnOptionIndex;
            spawnPoint.y = 1;
            GameObject newObject = Instantiate(objectToSpawn, spawnPoint, rotation);
            AddObjectToLlist(newObject);
            if(newObject.name.StartsWith("standing")){
                newObject.transform.eulerAngles = new Vector3(-90, 0, 0);// = new Quaternion(-0.25f, newObject.transform.rotation.y, newObject.transform.rotation.z, newObject.transform.rotation.w);
            } else if(newObject.name.StartsWith("tv_new")){
                newObject.transform.eulerAngles = new Vector3(-90, 180, 0);
            } else if(newObject.name.StartsWith("Air Sensor") || newObject.name.StartsWith("machineend") || newObject.name.StartsWith("lightswitch")){
                newObject.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if(newObject.name.StartsWith("tv_new")){
                foreach(Canvas c in newObject.GetComponentsInChildren<Canvas>()){
                    c.worldCamera = Camera.main;
                }
            } else {
                newObject.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
            }


            //var objectIndex = isSpawnOptionRandomized ? Random.Range(0, m_ObjectPrefabs.Count) : m_SpawnOptionIndex;
            //var newObject = Instantiate(m_ObjectPrefabs[objectIndex]);
            if (m_SpawnAsChildren)
                newObject.transform.parent = transform;

            newObject.transform.position = spawnPoint ;
            CreateSound.Play();
            //EnsureFacingCamera();

            //var facePosition = m_CameraToFace.transform.position;
            //var forward = facePosition - spawnPoint;
            //BurstMathUtility.ProjectOnPlane(forward, spawnNormal, out var projectedForward);
            //newObject.transform.rotation = Quaternion.LookRotation(projectedForward, spawnNormal);

            //if (m_ApplyRandomAngleAtSpawn)
            //{
            //    var randomRotation = UnityEngine.Random.Range(-m_SpawnAngleRange, m_SpawnAngleRange);
            //    newObject.transform.Rotate(Vector3.up, randomRotation);
            //}

            //if (m_SpawnVisualizationPrefab != null)
            //{
            //    var visualizationTrans = Instantiate(m_SpawnVisualizationPrefab).transform;
            //    visualizationTrans.position = spawnPoint;
            //    visualizationTrans.rotation = newObject.transform.rotation;
            //}

            objectSpawned?.Invoke(newObject);
            //return true;
        }

        private void AddObjectToLlist(GameObject gameObject)
        {
            SpawnedObject spawnedObject = new SpawnedObject()
            {
                gameObject = gameObject
            };
            int anzahl = 1;
            GameObject newObject = null;
            switch (gameObject.tag)
            {
                case "AirPurifier":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.AIRPURIFIER)).Count + 1;
                    spawnedObject.name = "Air Purifier " + anzahl;
                    spawnedObject.objectType = TypVonObject.AIRPURIFIER;
                    newObject = Instantiate(AirPurifierSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    // {
                    //     AirPurifierToggleChanged(gameObject, newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>());
                    // });
                    // newObject.transform.Find("Content/Background/VisibleHot").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    // {
                    //     AirPurifierHotToggleChanged(gameObject, newObject.transform.Find("Content/Background/VisibleHot").gameObject.GetComponentInChildren<Toggle>());
                    // });
                    // newObject.GetComponentInChildren<Slider>().onValueChanged.AddListener(delegate
                    // {
                    //     AirPurifierIntensityChanged(gameObject, newObject.GetComponentInChildren<Slider>());
                    // });
                    break;
                case "AirSensor":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.AIRSENSOR)).Count + 1;
                    spawnedObject.name = "Air Sensor " + anzahl;
                    spawnedObject.objectType = TypVonObject.AIRSENSOR;
                    newObject = Instantiate(AirSensorSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.transform.Find("Content/Background/Simulate").gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
                    // {
                    //     AirSensorSimulateButtonClicked(gameObject, newObject.transform.Find("Content/Background/Simulate").gameObject.GetComponentInChildren<Button>());
                    // });
                    //newObject.GetComponentInChildren<Slider>().onValueChanged.AddListener(delegate
                    //{

                    //});
                    break;
                case "ControlSystem":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.CONTROLSYSTEM)).Count + 1;
                    spawnedObject.name = "Control System " + anzahl;
                    spawnedObject.objectType = TypVonObject.CONTROLSYSTEM;
                    newObject = Instantiate(ControlSystemSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // Toggle[] toggles = newObject.GetComponentsInChildren<Toggle>();
                    // foreach(Toggle t in toggles)
                    // {
                    //     switch (t.name)
                    //     {
                    //         case "DateToggle":
                    //             t.onValueChanged.AddListener(delegate
                    //             {
                    //                 ControlSystemToggleChanged(gameObject, t, newObject.transform.Find("Content/Select/hinweis").gameObject, calendar: true);
                    //             });
                    //             break;
                    //         case "ClockToggle":
                    //             t.onValueChanged.AddListener(delegate
                    //             {
                    //                 ControlSystemToggleChanged(gameObject, t, newObject.transform.Find("Content/Select/hinweis").gameObject, clock: true);
                    //             });
                    //             break;
                    //         case "CalendarToggle":
                    //             t.onValueChanged.AddListener(delegate
                    //             {
                    //                 ControlSystemToggleChanged(gameObject, t, newObject.transform.Find("Content/Select/hinweis").gameObject, weather: true);
                    //             });
                    //             break;
                    //         case "ControlToggle":
                    //             t.onValueChanged.AddListener(delegate
                    //             {
                    //                 ControlSystemToggleChanged(gameObject, t, newObject.transform.Find("Content/Select/hinweis").gameObject, current: true);
                    //             });
                    //             break;
                    //         case "TVToggle":
                    //             t.onValueChanged.AddListener(delegate
                    //             {
                    //                 ControlSystemToggleChanged(gameObject, t, newObject.transform.Find("Content/Select/hinweis").gameObject, tv: true);
                    //             });
                    //             break;
                    //         case "AudioToggle":
                    //             t.onValueChanged.AddListener(delegate
                    //             {
                    //                 ControlSystemToggleChanged(gameObject, t, newObject.transform.Find("Content/Select/hinweis").gameObject, audio: true);
                    //             });
                    //             break;
                    //         default:
                    //             break;
                    //     }
                    // }
                    // newObject.transform.Find("Content/Select").gameObject.SetActive(false);
                    break;
                case "Speaker":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.SPEAKER)).Count + 1;
                    spawnedObject.name = "Speaker " + anzahl;
                    spawnedObject.objectType = TypVonObject.SPEAKER;
                    newObject = Instantiate(SpeakerSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.GetComponentInChildren<TMP_Dropdown>().onValueChanged.AddListener(delegate
                    // {
                    //     SpeakerDropdownChanged(gameObject, newObject.GetComponentInChildren<TMP_Dropdown>());
                    // });
                    // newObject.GetComponentInChildren<Slider>().onValueChanged.AddListener(delegate
                    // {
                    //     SpeakerSliderChanged(gameObject, newObject.GetComponentInChildren<Slider>());
                    // });
                    // newObject.transform.Find("Content/Background/Play").gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
                    // {
                    //     SpeakerButtonChanged(gameObject);
                    // });
                    // newObject.transform.Find("Content/AudioOutput").gameObject.SetActive(false);
                    break;
                case "Lamp":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.LAMP)).Count + 1;
                    spawnedObject.name = "Lamp " + anzahl;
                    spawnedObject.objectType = TypVonObject.LAMP;
                    newObject = Instantiate(LampSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.transform.Find("Content/First").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    // {
                    //     LampToggleChanged(gameObject, newObject.transform.Find("Content/First").gameObject.GetComponentInChildren<Toggle>());
                    // });
                    // Slider[] sliders1 = newObject.GetComponentsInChildren<Slider>();
                    // foreach(Slider s in sliders1)
                    // {
                    //     switch (s.name)
                    //     {
                    //         case "SliderRed":
                    //             s.onValueChanged.AddListener(delegate
                    //             {
                    //                 LampSliderRedChanged(gameObject, s);
                    //             });
                    //             break;
                    //         case "SliderGreen":
                    //             s.onValueChanged.AddListener(delegate
                    //             {
                    //                 LampSliderGreenChanged(gameObject, s);
                    //             });
                    //             break;
                    //         case "SliderBlue":
                    //             s.onValueChanged.AddListener(delegate
                    //             {
                    //                 LampSliderBlueChanged(gameObject, s);
                    //             });
                    //             break;
                    //         case "SliderIntensity":
                    //             s.onValueChanged.AddListener(delegate
                    //             {
                    //                 LampSliderIntensityChanged(gameObject, s);
                    //             });
                    //             break;
                    //         default:
                    //             break;
                    //     }
                    // }
                    // newObject.transform.Find("Content/Background").gameObject.SetActive(false);
                    break;
                case "Blinds":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.BLIND)).Count + 1;
                    spawnedObject.name = "Blinds " + anzahl;
                    spawnedObject.objectType = TypVonObject.BLIND;
                    newObject = Instantiate(BlindsSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // Slider[] sliders = newObject.GetComponentsInChildren<Slider>();
                    // foreach(Slider s in sliders)
                    // {
                    //     switch (s.name)
                    //     {
                    //         case "SliderWidth":
                    //             s.onValueChanged.AddListener(delegate
                    //             {
                    //                 BlindSliderWidthChanged(gameObject, s);
                    //             });
                    //             break;
                    //         case "SliderHeight":
                    //             s.onValueChanged.AddListener(delegate
                    //             {
                    //                 BlindSliderHeightChanged(gameObject, s);
                    //             });
                    //             break;
                    //         default:
                    //             break;
                    //     }
                    // }
                    // spawnedObject.height = 1f;
                    // Button[] buttons = newObject.GetComponentsInChildren<Button>();
                    // foreach(Button b in buttons)
                    // {
                    //     switch (b.name)
                    //     {
                    //         case "SaveButton":
                    //             b.onClick.AddListener(delegate
                    //             {
                    //                 BlindSaveButtonClicked(gameObject, newObject.GetComponentInChildren<Button>(), spawnedObject);
                    //             });
                    //             break;
                    //         case "TestButton":
                    //             b.onClick.AddListener(delegate
                    //             {
                    //                 BlindTestButtonClicked(gameObject, newObject.GetComponentInChildren<Button>(), spawnedObject);
                    //             });
                    //             break;
                    //         default:
                    //             break;
                    //     }
                    // }

                        
                    break;
                case "AirConditioner":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.AIRCONDITIONER)).Count + 1;
                    spawnedObject.name = "Air Conditioner " + anzahl;
                    spawnedObject.objectType = TypVonObject.AIRCONDITIONER;
                    newObject = Instantiate(AirConditionerSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    // {
                    //     AirConditionerToggleChanged(gameObject, newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>());
                    // });
                    // newObject.GetComponentInChildren<Slider>().onValueChanged.AddListener(delegate
                    // {
                    //     AirConditionerIntensityChanged(gameObject, newObject.GetComponentInChildren<Slider>());
                    // });
                    break;
                case "lightswitch":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.LIGHTSWITCH)).Count + 1;
                    spawnedObject.name = "Light Switch " + anzahl;
                    spawnedObject.objectType = TypVonObject.LIGHTSWITCH;
                    newObject = Instantiate(LightswitchSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.transform.Find("Content/Background/Visible").GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    // {
                    //     LightswitchToggleChanged(gameObject, newObject.transform.Find("Content/Background/Visible").GetComponentInChildren<Toggle>());
                    // });
                    break;
                case "rolloswitch":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.BLINDSWITCH)).Count + 1;
                    spawnedObject.name = "Blind Switch " + anzahl;
                    spawnedObject.objectType = TypVonObject.BLINDSWITCH;
                    newObject = Instantiate(RolloswitchSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    // {
                    //     RolloswitchToggleChanged(gameObject, newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>());
                    // });
                    break;
                case "motionsensor":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.MOTIONSENSOR)).Count + 1;
                    spawnedObject.name = "Motion Sensor " + anzahl;
                    spawnedObject.objectType = TypVonObject.MOTIONSENSOR;
                    newObject = Instantiate(MotionsensorSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    // {
                    //     MotionsensorToggleChanged(gameObject, newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>());
                    // });
                    break;
                case "tv":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.TV)).Count + 1;
                    spawnedObject.name = "TV " + anzahl;
                    spawnedObject.objectType = TypVonObject.TV;
                    newObject = Instantiate(TVSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    // {
                    //     TVToggleChanged(gameObject, newObject.transform.Find("Content/Background/Visible").gameObject.GetComponentInChildren<Toggle>());
                    // });
                    // newObject.transform.Find("Content/Background/HorizontalPlay").gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
                    // {
                    //     TVPlayButtonClicked(gameObject, newObject.transform.Find("Content/Background/HorizontalPlay").gameObject.GetComponentInChildren<Button>());
                    // });
                    // newObject.transform.Find("Content/AudioOutput").gameObject.GetComponentInChildren<TMP_Dropdown>().onValueChanged.AddListener(delegate
                    // {
                    //     TVAudioOutputDropdownChanged(gameObject, newObject.transform.Find("Content/AudioOutput").gameObject.GetComponentInChildren<TMP_Dropdown>());
                    // });
                    // newObject.transform.Find("Content/AudioOutput").gameObject.SetActive(false);
                    // gameObject.GetComponent<tvHelper>().audioClip = AudioVideo;
                    // // gameObject.GetComponentInChildren<Canvas>().worldCamera = Kamera;
                    // gameObject.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
                    break;
                case "coffee":
                    anzahl = objekte.FindAll(t => t.objectType.Equals(TypVonObject.COFFEE)).Count + 1;
                    spawnedObject.name = "Coffee Machine " + anzahl;
                    spawnedObject.objectType = TypVonObject.COFFEE;
                    newObject = Instantiate(CoffeeSettings, Visuals.transform);
                    newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>().onValueChanged.AddListener(delegate
                    {
                        LampToggleChanged(gameObject, newObject.transform.Find("Content/First/Visible").gameObject.GetComponentInChildren<Toggle>());
                    });
                    // newObject.transform.Find("Content/Background/HorizontalBrew").gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
                    // {
                    //     CoffeeBrewButtonClicked(gameObject, newObject.transform.Find("Content/Background/HorizontalBrew").gameObject.GetComponentInChildren<Button>());
                    // });
                    break;
                default:
                    spawnedObject = null;
                    break;
            }

            if(gameObject.tag == "Lamp"){
                gameObject.transform.Find("UI/Canvas/HorizontalDelete").gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
                {
                    DeleteObject(gameObject, newObject);
                });
            } else {
                gameObject.transform.Find("UI/Canvas/HorizontalDelete").gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
                {
                    DeleteObject(gameObject, newObject);
                });
            }

            if(spawnedObject != null && newObject != null)
            {
                gameObject.transform.Find("UI/Canvas/TextLabel").gameObject.GetComponent<TMP_Text>().text = spawnedObject.name;
                newObject.transform.Find("Content/First/TextLabel").gameObject.GetComponent<TMP_Text>().text = spawnedObject.name;
                // TMP_Text[] texts = newObject.GetComponentsInChildren<TMP_Text>();
                // foreach(TMP_Text t in texts)
                // {
                //     if (t.transform.parent.name.Equals("Text"))
                //     {
                //         t.text = spawnedObject.name;
                //     }
                // }
                objekte.Add(spawnedObject);
                newObject.transform.parent = Visuals.transform;
                // settings.Add(new SpawnedSettingObject()
                // {
                //     gameObject = newObject,
                //     name = ""
                // });
                Visuals.SetActive(false);
                Visuals.SetActive(true);
            }
        }
        private void LampToggleChanged(GameObject gameObject, Toggle toggle)
        {
            gameObject.transform.Find("UI").gameObject.SetActive(toggle.isOn);
        }
        private void DeleteObject(GameObject gameObject, GameObject SettingObject)
        {
            SpawnedObject spawnedObject = objekte.Find(t => t.gameObject.Equals(gameObject));
            objekte.Remove(spawnedObject);
            List<AutomationPanelObjects> toRemove = new List<AutomationPanelObjects>();
            foreach(AutomationPanelObjects item in AutomationManagerBottom.AutomationPanels){
                foreach(ReiheAutomation item1 in item.Reihen){
                    if(item1.secondObject == spawnedObject.name){
                        toRemove.Add(item);
                    }
                }
            }
            foreach(AutomationPanelObjects item in toRemove){
                automationManagerBottom.DeleteAutomation(item);
            }
            Destroy(gameObject);
            Destroy(SettingObject);
            Visuals.SetActive(false);
            Visuals.SetActive(true);
        }

        // private void AirSensorSimulateButtonClicked(GameObject gameObject, Button btn)
        // {
        //     if(gameObject.GetComponentInChildren<AirSensorHelperWert>().wertSimulieren)
        //     {
        //         gameObject.GetComponentInChildren<AirSensorHelperWert>().wertSimulieren = false;
        //         gameObject.GetComponentInChildren<AirSensorHelperWert>().wertSimulierenUeber = false;
        //         btn.GetComponentInChildren<TMP_Text>().text = "Simulate normal PM2,5 values";
        //     } else
        //     {
        //         gameObject.GetComponentInChildren<AirSensorHelperWert>().wertSimulieren = true;
        //         gameObject.GetComponentInChildren<AirSensorHelperWert>().wertSimulierenUeber = false;
        //         btn.GetComponentInChildren<TMP_Text>().text = "Simulate higher PM2,5 values";
        //     }

        // }

        // private void CoffeeBrewButtonClicked(GameObject gameObject, Button button)
        // {
        //     throw new NotImplementedException();
        // }

        // private void TVPlayButtonClicked(GameObject gameObject, Button button)
        // {
        //     var a = FindObjectsOfType<ControlSystemHelper>();
        //     if(gameObject.GetComponent<VideoPlayer>().isPlaying)
        //     {
        //         gameObject.GetComponent<tvHelper>().StopVideo();
        //         foreach(ControlSystemHelper item in a)
        //         {
        //             item.TVOn("Stopped");
        //         }
        //     } else
        //     {
        //         gameObject.GetComponent<tvHelper>().PlayVideo();
        //         foreach(ControlSystemHelper item in a)
        //         {
        //             item.TVOn("Playing");
        //         }
        //     }
        // }

        // private void TVToggleChanged(GameObject gameObject, Toggle toggle)
        // {
        //     gameObject.transform.Find("Canvas").gameObject.SetActive(toggle.isOn);
        // }

        // private void TVAudioOutputDropdownChanged(GameObject gameObject, TMP_Dropdown tMP_Dropdown)
        // {
        //     if(tMP_Dropdown.options[tMP_Dropdown.value].text != "TV"){
        //         SpawnedObject audio = objekte.Find(t => t.name.Equals(tMP_Dropdown.options[tMP_Dropdown.value].text));
        //         if(audio == null){
        //             return;
        //         }
        //         gameObject.GetComponent<tvHelper>().audioSource = audio.gameObject.GetComponent<AudioSource>();
        //     }
        // }

        public static List<SpawnedSettingObject> settings = new List<SpawnedSettingObject>();


        // private void MotionsensorToggleChanged(GameObject gameObject, Toggle toggle)
        // {
        //     if(toggle.isOn){
        //         gameObject.GetComponentInChildren<motionDetected>().Usable();
        //     } else {
        //         gameObject.GetComponentInChildren<motionDetected>().Movable();
        //     }
        // }

        // private void RolloswitchToggleChanged(GameObject gameObject, Toggle toggle)
        // {
        //     gameObject.GetComponent<touchControllerRollo>().IsEnabled = toggle.isOn;
        // }

        // private void LightswitchToggleChanged(GameObject gameObject, Toggle toggle)
        // {
        //     if(!toggle.isOn){
        //         //Bewegen ist möglich, klicken nicht
        //         gameObject.GetComponent<touchControllerLight>().Movable();
        //     } else {
        //         //Klicken ist möglich, bewegen nicht.
        //         gameObject.GetComponent<touchControllerLight>().Usable();
        //     }
        // }

        // [SerializeField]
        // public int durationBlinds = 5; 

        // private void BlindTestButtonClicked(GameObject gameObject, Button button, SpawnedObject spawnedObject)
        // {
        //     StartCoroutine(LerpBlind(gameObject, spawnedObject));
        // }

        // IEnumerator LerpBlind(GameObject gameObject, SpawnedObject spawnedObject)
        // {
        //     float timeElapsed = 0;

        //     int i = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("down");
        //     gameObject.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(i, 0);
        //     float startValue = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().GetBlendShapeWeight(i);

        //     while (timeElapsed < durationBlinds)
        //     {
        //         gameObject.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(i, Mathf.Lerp(startValue, spawnedObject.height, timeElapsed / durationBlinds));
        //         timeElapsed += Time.deltaTime;

        //         yield return null;
        //     }

        //     gameObject.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(i, spawnedObject.height);
        // }

        // private void BlindSaveButtonClicked(GameObject gameObject, Button button, SpawnedObject spawnedObject)
        // {
        //     int i = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("down");
        //     spawnedObject.height = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().GetBlendShapeWeight(i);
        //     gameObject.GetComponent<BlindController>().savedHeight = spawnedObject.height;
        //     int i1 = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("side");
        //     spawnedObject.width = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().GetBlendShapeWeight(i1);
        // }

        // private void BlindSliderHeightChanged(GameObject gameObject, Slider s)
        // {
        //     gameObject.GetComponent<BlindController>().ChangeBlinds(s.value);
        // }

        // private void BlindSliderWidthChanged(GameObject gameObject, Slider s)
        // {
        //     int i = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("side");
        //     gameObject.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(i, s.value);
        // }
        // // private void LampToggleChanged(GameObject gameObject, Toggle toggle)
        // // {
        // //     gameObject.GetComponentInChildren<Light>().enabled = toggle.isOn;
        // //     gameObject.GetComponentInChildren<LightHelper>().enabledUsedMethod();
        // // }
        // private void LampSliderIntensityChanged(GameObject gameObject, Slider slider)
        // {
        //     gameObject.GetComponentInChildren<Light>().intensity = slider.value;
        // }

        // private void LampSliderRedChanged(GameObject gameObject, Slider s)
        // {
        //     gameObject.GetComponentInChildren<Light>().color = new Color(s.value, gameObject.GetComponentInChildren<Light>().color.g, gameObject.GetComponentInChildren<Light>().color.b);
        // }

        // private void LampSliderBlueChanged(GameObject gameObject, Slider s)
        // {
        //     gameObject.GetComponentInChildren<Light>().color = new Color(gameObject.GetComponentInChildren<Light>().color.r, gameObject.GetComponentInChildren<Light>().color.g, s.value);
        // }

        // private void LampSliderGreenChanged(GameObject gameObject, Slider s)
        // {
        //     gameObject.GetComponentInChildren<Light>().color = new Color(gameObject.GetComponentInChildren<Light>().color.r, s.value, gameObject.GetComponentInChildren<Light>().color.b);
        // }

        // private void LampSliderRangeChanged(GameObject gameObject, Slider s)
        // {
        //     gameObject.GetComponentInChildren<Light>().range = s.value;
        // }

        // private void SpeakerButtonChanged(GameObject gameObject)
        // {
        //     var a = FindObjectsOfType<ControlSystemHelper>();
        //     if (gameObject.GetComponent<AudioSource>().isPlaying)
        //     {
        //         gameObject.GetComponent<AudioSource>().Stop();
        //         gameObject.GetComponent<SpeakerHelper>().playpauseUsedMethod();
        //         foreach(ControlSystemHelper c in a)
        //         {
        //             c.AudioOn("Stopped");
        //         }
        //     } else
        //     {
        //         gameObject.GetComponent<AudioSource>().Play();
        //         gameObject.GetComponent<SpeakerHelper>().playpauseUsedMethod();
        //         foreach(ControlSystemHelper c in a)
        //         {
        //             c.AudioOn("Playing");
        //         }
        //     }
        // }

        // private void SpeakerSliderChanged(GameObject gameObject, Slider slider)
        // {
        //     gameObject.GetComponent<AudioSource>().volume = slider.value;
        // }

        // private void SpeakerDropdownChanged(GameObject gameObject, TMP_Dropdown dropdown)
        // {
        //     var a = FindObjectsOfType<ControlSystemHelper>();
        //     switch (dropdown.value)
        //     {
        //         case 0:
        //             gameObject.GetComponent<AudioSource>().clip = Audio1;
        //             break;
        //         case 1:
        //             gameObject.GetComponent<AudioSource>().clip = Audio2;
        //             break;
        //         case 2:
        //             gameObject.GetComponent<AudioSource>().clip = Audio3;
        //             break;
        //         case 3:
        //             gameObject.GetComponent<AudioSource>().clip = Audio4;
        //             break;
        //         default:
        //             gameObject.GetComponent<AudioSource>().clip = null;
        //             break;
        //     }
        //     foreach(ControlSystemHelper c in a)
        //     {
        //         c.AudioChanged(dropdown.options[dropdown.value].text);
        //     }
        // }

        // private void ControlSystemToggleChanged(GameObject gameObject1, Toggle t, GameObject gameObject2, bool tv = false, bool audio = false, bool clock = false, bool current = false, bool weather = false, bool calendar = false)
        // {
        //     if(t.isOn){
        //         if(gameObject1.GetComponentInChildren<ControlSystemHelper>().activeField >= 4){
        //             gameObject2.SetActive(true);
        //             StartCoroutine(dismissHinweis(gameObject2));
        //         } else {
        //             gameObject1.GetComponentInChildren<ControlSystemHelper>().activeField++;
        //             if(tv){
        //                 gameObject1.transform.Find("Canvas/Background/TV").gameObject.SetActive(t.isOn);
        //             } else if(audio){
        //                 gameObject1.transform.Find("Canvas/Background/Audio").gameObject.SetActive(t.isOn);
        //             } else if(clock){
        //                 gameObject1.transform.Find("Canvas/Background/Clock").gameObject.SetActive(t.isOn);
        //             } else if(current){
        //                 gameObject1.transform.Find("Canvas/Background/Current").gameObject.SetActive(t.isOn);
        //             } else if(weather){
        //                 gameObject1.transform.Find("Canvas/Background/Weather").gameObject.SetActive(t.isOn);
        //             } else if(calendar){
        //                 gameObject1.transform.Find("Canvas/Background/Calendar").gameObject.SetActive(t.isOn);
        //             }
        //         }
        //     } else {
        //         gameObject1.GetComponentInChildren<ControlSystemHelper>().activeField--;
        //         if(tv){
        //             gameObject1.transform.Find("Canvas/Background/TV").gameObject.SetActive(t.isOn);
        //         } else if(audio){
        //             gameObject1.transform.Find("Canvas/Background/Audio").gameObject.SetActive(t.isOn);
        //         } else if(clock){
        //             gameObject1.transform.Find("Canvas/Background/Clock").gameObject.SetActive(t.isOn);
        //         } else if(current){
        //             gameObject1.transform.Find("Canvas/Background/Current").gameObject.SetActive(t.isOn);
        //         } else if(weather){
        //             gameObject1.transform.Find("Canvas/Background/Weather").gameObject.SetActive(t.isOn);
        //         } else if(calendar){
        //             gameObject1.transform.Find("Canvas/Background/Calendar").gameObject.SetActive(t.isOn);
        //         }
        //     }
        // }

        // private IEnumerator dismissHinweis(GameObject hinweis){
        //     yield return new WaitForSeconds(3);
        //     hinweis.SetActive(false);
        // }

        // private void AirPurifierIntensityChanged(GameObject gameObject, Slider slider)
        // {
        //     //TODO
        // }

        // private void AirPurifierToggleChanged(GameObject gameObject, Toggle toggle)
        // {
        //     if (toggle.isOn)
        //     {
        //         gameObject.GetComponent<AirPurifierHelper>().ActivateShader();
        //         gameObject.GetComponent<PlayConditioner>().StartAudio();
        //     } else
        //     {
        //         gameObject.GetComponent<AirPurifierHelper>().DeactivateShader();
        //         gameObject.GetComponent<PlayConditioner>().EndAudio();
        //     }
        // }

        // private void AirPurifierHotToggleChanged(GameObject gameObject, Toggle toggle)
        // {
        //     if (toggle.isOn)
        //     { // Heating
        //         gameObject.GetComponent<AirPurifierHelper>().cooling = false;
        //         gameObject.GetComponent<AirPurifierHelper>().heating = true;
        //     } else
        //     { // Cooling
        //         gameObject.GetComponent<AirPurifierHelper>().cooling = true;
        //         gameObject.GetComponent<AirPurifierHelper>().heating = false;
        //     }
        // }

        // private void AirConditionerIntensityChanged(GameObject gameObject, Slider slider)
        // {
        //     //TODO
        // }

        // private void AirConditionerToggleChanged(GameObject gameObject, Toggle toggle)
        // {
        //     if(toggle.isOn)
        //     {
        //         gameObject.transform.Find("AirFlow").gameObject.SetActive(true);
        //         gameObject.transform.Find("AirFlow1").gameObject.SetActive(true);
        //         gameObject.GetComponent<Animator>().SetBool("Close", false);
        //         gameObject.GetComponent<Animator>().SetBool("Open", true);
        //         gameObject.GetComponent<PlayConditioner>().StartAudio();
        //     } else
        //     {
        //         gameObject.transform.Find("AirFlow").gameObject.SetActive(false);
        //         gameObject.transform.Find("AirFlow1").gameObject.SetActive(false);
        //         gameObject.GetComponent<Animator>().SetBool("Open", false);
        //         gameObject.GetComponent<Animator>().SetBool("Close", true);
        //         gameObject.GetComponent<PlayConditioner>().EndAudio();
        //     }
        // }
    }

    public class SpawnedSettingObject
    {
        public GameObject gameObject;
        public string name;

        public SpawnedSettingObject(GameObject gameObject, string name)
        {
            this.gameObject = gameObject;
            this.name = name;
        }
    }
}
