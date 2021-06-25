using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class DayNight : MonoBehaviour
{
    [SerializeField] Gradient directionalLightGradient;
    [SerializeField] Gradient ambientLightGradient;

    [SerializeField, Range(1, 3600)] float timeDayInSeconds = 60;
    [SerializeField, Range(0f,1f)] float timeProgress;

    [SerializeField] Light dirLight;
       

    Vector3 defaultAngles;
    // Start is called before the first frame update
    void Start() => defaultAngles = dirLight.transform.localEulerAngles;


    // Update is called once per frame
    void Update()
    {

        if (Application.isPlaying)
            timeProgress += Time.deltaTime / timeDayInSeconds;

        if (timeProgress > 1f)
            timeProgress = 0f;

        if (timeProgress<0.8f && dirLight.intensity<0.9)
        {
            dirLight.intensity += Time.deltaTime/4;
        }
        else if(timeProgress > 0.8f && dirLight.intensity > 0.7)
        {
            dirLight.intensity -= Time.deltaTime/3;
        }
        dirLight.color = directionalLightGradient.Evaluate(timeProgress);
     
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);

        //dirLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 90, defaultAngles.x, defaultAngles.z);
    }

}
