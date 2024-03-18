using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropdownController : MonoBehaviour {

    void OnValueChanged(int value){
        Debug.Log("Value: " + value);
    }
}
