﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {
    public GameObject chopstick;
    public float throwDelay = 0.5f;

    private float lastThrow;

    private void Start()
    {
        lastThrow = Time.time;
    }

    void Update ()
    {
		if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ThrowStick();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            ThrowStick();
        }
	}

    void ThrowStick()
    {
        float currentTime = Time.time;
        if (currentTime - lastThrow >= throwDelay)
        {
            GameObject clone;
            clone = Instantiate(chopstick, gameObject.transform.position, gameObject.transform.rotation);
            clone.SetActive(true);
            StartCoroutine(Delay());
            lastThrow = Time.time;
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(throwDelay);
    }
}
