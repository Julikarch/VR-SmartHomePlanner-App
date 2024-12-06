using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlindController : MonoBehaviour
{
        public UnityEvent heightUsed;
        public float savedHeight = 100;

        private bool animating = false;

        [SerializeField] public Slider Height;

        public void heightUsedMethod(){
            heightUsed.Invoke();
        }

        public float GetHeight(){
            int i = this.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("down");
            return this.gameObject.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(i);
        }

        Coroutine coroutine = null;

        public void ChangeBlinds(float value){
            if(animating){
                StopCoroutine(coroutine);
                animating = false;
            }
            if(value < 0){
                coroutine = StartCoroutine(ControlBlind(savedHeight));
            } else {
                coroutine = StartCoroutine(ControlBlind(0));
            }
        }
        private IEnumerator ControlBlind(float value){
            animating = true;
            float timeElapsed = 0f;
            float durationBlinds = 5f;
            int i = this.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("down");
            float startValue = this.gameObject.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(i);

            while (timeElapsed < durationBlinds)
            {
                float newValue = Mathf.Lerp(startValue, value, timeElapsed / durationBlinds);
                this.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(i, newValue);
                Height.value = newValue;
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            this.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(i, value);
            Height.value = value;
            heightUsedMethod();
            animating = false;
            yield return null;
        }

        public void saveHeight(){
            savedHeight = actualHeight;
        }
        
        private float actualHeight = 0f;

        public void changeHeight(float value){
            if(animating){
                return;
            }
            int i = this.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("down");
            this.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(i, value);
            actualHeight = value;
            heightUsedMethod();
        }

        public void changeWidth(float value){
            int i = this.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("side");
            this.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(i, value);
        }
}
