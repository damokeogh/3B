﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    private void OnTriggerExit (Collider other) {
        if (other.gameObject.CompareTag ("UFO")) {
            other.gameObject.GetComponent<UFOController>().Reset();
        } else {
            Destroy (other.gameObject);
        }
    }
}