using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CannonThrower : MonoBehaviour
{
    private float rotationY;
    private Slider rotationYSlider;
    public TextMeshProUGUI rotationYText;

    void Start()
    {
        rotationYSlider = GameObject.FindGameObjectWithTag("YSlider").GetComponent<Slider>();
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        rotationYText.text = rotationYSlider.value.ToString("0");
    }

    public void YSliderValueChange(float value)
    {
        rotationY = rotationYSlider.value;
    }
}
