using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ReceptorMeterUI : MonoBehaviour
{
    [SerializeField] private Receptor receptor;

    public ClothingSO.clothingCategory category;

    [Tooltip("How many points needed to fill the meter")]
    [SerializeField] private float meterFillAmount = 60.0f;

    private Image meter;
    public bool done;

    public event Action<ClothingSO.clothingCategory> OnMeterFull;

    // Start is called before the first frame update
    void Start()
    {
        meter = GetComponent<Image>();
        done = false;
        meter.type = Image.Type.Filled;
        meter.fillAmount = 0.0f;

        // listen to meter's update score
        receptor.OnHit += UpdateMeter;
    }

    private void UpdateMeter(float score)
    {
        meter.fillAmount += (score / meterFillAmount);
        if (meter.fillAmount >= 1.0f)
        {
            meter.fillAmount = 1.0f;    // reset
            if (!done)
            {
                OnMeterFull?.Invoke(category);  // invoke event = clothing manager listens
                done = true;
            }
        }
    }
}
