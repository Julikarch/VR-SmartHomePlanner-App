using UnityEngine;

namespace scripts
{
    public class LineConnector : MonoBehaviour
    {
        public GameObject startPoint;
        public GameObject endPoint;
        private LineRenderer lineRenderer;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
        }

        private void Update()
        {
            lineRenderer.SetPosition(0, startPoint.transform.position);
            lineRenderer.SetPosition(1, endPoint.transform.position);
        }
    }
}