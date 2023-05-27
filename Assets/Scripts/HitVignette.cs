using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HitVignette : MonoBehaviour
{
    PostProcessVolume _volume;
    Vignette _vignette;
    float _initIntensity;
    Color _initColor;
    [SerializeField]
    private float _intensity = 0.5f, _timeStep = 0.2f, _time = 1f;
    [SerializeField]
    private Color _color = Color.red;

    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings<Vignette>(out _vignette);
        _initIntensity = _vignette.intensity.value;
        _initColor = _vignette.color.value;
    }

    public void Hit()
    {
        StartCoroutine(HitCooldown());
    }

    private IEnumerator HitCooldown()
    {
        _vignette.intensity.value = _intensity;
        _vignette.color.value = _color;
        int steps = (int) (_time / _timeStep);
        float intensityStep = (_intensity - _initIntensity) / steps;
        float colorStep = 1f / steps;
        float lerpFactor = 0f;

        while (_vignette.intensity.value > _initIntensity)
        {
            lerpFactor += colorStep;
            _vignette.intensity.value -= intensityStep;
            _vignette.color.value = Color.Lerp(_color, _initColor, lerpFactor);
            yield return new WaitForSeconds(_timeStep);
        }
        
        _vignette.intensity.value = _initIntensity;
        _vignette.color.value = _initColor;
    }
}
