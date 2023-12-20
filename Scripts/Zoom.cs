using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
        #region Inspector

        [SerializeField] private Camera cam;

        public float zoomSpeed = 0.5f;
        public float minZoom = 1f;
        public float maxZoom = 5f;

        public float dragSpeed = 2f;
        public float minX = -20f;
        public float maxX = 20f;
        public float minY = -20f;
        public float maxY = 20f;

        private float targetZoom;
        private float zoomVelocity;

        private Vector2? touchStart;

        #endregion

        private void Start()
        {
                // Set to full zoom on start
                targetZoom = 3.2f;
        }

        private void Update()
        {
                // Run methods
                HandleZoom();
                HandleDrag();

                // When zooming out center camera to avoid showing outside play area
                if (cam.orthographicSize > 2.1f)
                {
                        cam.transform.position = new Vector3(0 , 0 , cam.transform.position.z);
                }
        }

        void HandleZoom()
        {
                // If two fingers touching screen, check if zoom in or out and zoom the clamped amount
                if (Input.touchCount == 2)
                {
                        Touch touchZero = Input.GetTouch(0);
                        Touch touchOne = Input.GetTouch(1);

                        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                        float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                        float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                        float difference = currentMagnitude - prevMagnitude;

                        targetZoom -= difference * zoomSpeed;
                        targetZoom = Mathf.Clamp(targetZoom , minZoom , maxZoom);
                }
                Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize , targetZoom , ref zoomVelocity , 0.1f);
        }

        void HandleDrag()
        {
                // Touch and drage within area of play area
                if (Input.touchCount == 1)
                {
                        Touch touch = Input.GetTouch(0);

                        if (touch.phase == TouchPhase.Began)
                        {
                                touchStart = touch.position;
                        }
                        else if (touch.phase == TouchPhase.Moved && touchStart.HasValue)
                        {
                                Vector2 delta = touch.position - touchStart.Value;
                                Vector3 move = new Vector3(-delta.x , -delta.y , 0f) * dragSpeed * Time.deltaTime;

                                cam.transform.Translate(move);

                                if (cam.orthographicSize <= 2.5)
                                {
                                        cam.transform.position = new Vector3(
                                        Mathf.Clamp(cam.transform.position.x , -1.2f , 1.2f) ,
                                        Mathf.Clamp(cam.transform.position.y , -1.2f , 1.2f) ,
                                        cam.transform.position.z
                                        );
                                }
                                else if (cam.orthographicSize > 2.5)
                                {
                                        cam.transform.position = new Vector3(
                                        Mathf.Clamp(cam.transform.position.x , minX , maxX) ,
                                        Mathf.Clamp(cam.transform.position.y , minY , maxY) ,
                                        cam.transform.position.z
                                        );
                                }

                                touchStart = touch.position;
                        }
                        else if (touch.phase == TouchPhase.Ended)
                        {
                                touchStart = null;
                        }
                }
        }
}
