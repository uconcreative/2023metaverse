using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAxisY : MonoBehaviour
{
    public float updownSpeed = 2f;
    public float limitY_1 = 0f;
    public float limitY_2 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpDownUpdate());
    }

    private IEnumerator UpDownUpdate()
    {
        float _value = 0f;

        while (true)
        {
            yield return null;

            if (transform.localPosition.y >= limitY_1)
            {
                _value = -updownSpeed;
            }
            else if (transform.localPosition.y <= limitY_2)
            {
                _value = updownSpeed;
            }

            transform.Translate(0, _value, 0);
        }
    }
}
