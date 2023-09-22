using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public static Cannon Instance { get; private set; }

    private float rotationZ;
    private float force;

    [Header("Bullet")]
    [SerializeField] private Transform spawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Slider forceSlider;
    [SerializeField] private Slider weightSlider;
    [SerializeField] private int bulletQuantity;
    public TextMeshProUGUI bulletText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI forceText;
    public TextMeshProUGUI rotationZText;

    public int BulletQuantity { get { return bulletQuantity; } }

    private Slider rotationZSlider;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        rotationZSlider = GameObject.FindGameObjectWithTag("ZSlider").GetComponent<Slider>();
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(-90, 0, rotationZ);

        bulletText.text = "BULLETS: " + bulletQuantity.ToString("0");
        forceText.text = force.ToString("0");
        weightText.text = weightSlider.value.ToString("0");
        rotationZText.text = rotationZSlider.value.ToString("0");
    }

    public void ZSliderValueChange(float value)
    {
        rotationZ = rotationZSlider.value;
    }

    public void ForceSliderChange(float value)
    {
        force = forceSlider.value;
    }

    public void WeightSliderChange(float value)
    {
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.mass = weightSlider.value;
    }

    public void Shoot()
    {
        GameObject bulletClone = Instantiate(bullet, spawn.position, transform.rotation);

        Rigidbody bulletRbLeft = bulletClone.GetComponent<Rigidbody>();

        bulletRbLeft.AddRelativeForce(Vector3.left * force, ForceMode.Impulse);

        Destroy(bulletClone, 4);
        bulletQuantity--;
    }
}
