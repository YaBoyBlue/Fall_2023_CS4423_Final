using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField]
    private GameObject actorParent;
    [SerializeField]
    private GameObject transformObject;
    [SerializeField]
    private Transform transformComponent;

    // Start is called before the first frame update
    void Start()
    {
        transformObject = new GameObject("Transform");
        transformObject.transform.SetParent(actorParent.transform);
        transformComponent = transformObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transformComponent.position.x, transformComponent.position.y, transform.position.z);
    }
}
