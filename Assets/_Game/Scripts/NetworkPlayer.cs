using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform cabeza;
    public Transform manoIzquierda;
    public Transform manoDerecha;

    PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            cabeza.gameObject.SetActive(false);
            manoIzquierda.gameObject.SetActive(false);
            manoDerecha.gameObject.SetActive(false);

            MapPosition(cabeza, XRNode.Head);
            MapPosition(manoIzquierda, XRNode.Head);
            MapPosition(manoDerecha, XRNode.Head);
        }

        
    }

    public void MapPosition(Transform target, XRNode nodo)
    {
        InputDevices.GetDeviceAtXRNode(nodo).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 pos);
        InputDevices.GetDeviceAtXRNode(nodo).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rot);

        target.position = pos;
        target.rotation = rot;
    }
}
