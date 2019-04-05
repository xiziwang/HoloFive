using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Sharing;
using HoloToolkit.Unity;

public class HoloFiveManager : MonoBehaviour
{
    public GameObject otherPlayerHand;
    public GameObject otherPlayerHead;

    // Use this for initialization
    void Start()
    {
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.HeadTransform] = this.OnHeadTransform;
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.HandTransform] = this.OnHandTransform;
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.HandStatus] = this.OnHandStatus;
    }

    // Update is called once per frame
    void Update()
    {
        Transform tm = Camera.main.transform;
        CustomMessages.Instance.SendHeadTransform(tm.position, tm.rotation, 0);
    }


    void OnHeadTransform(NetworkInMessage msg)
    {
        Debug.Log("### ### ### ### Head Transform Received");
        Vector3 poition = CustomMessages.Instance.ReadVector3(msg);
        Quaternion rotation = CustomMessages.Instance.ReadQuaternion(msg);
        this.AdjustTransform(otherPlayerHead, poition, rotation);
    }

    void OnHandTransform(NetworkInMessage msg)
    {
        Debug.Log("### ### ### ### Hand Transform Received");
        Vector3 poition = CustomMessages.Instance.ReadVector3(msg);
        Quaternion rotation = CustomMessages.Instance.ReadQuaternion(msg);
        this.AdjustTransform(otherPlayerHand, poition, rotation);
    }

    void OnHandStatus(NetworkInMessage msg)
    {
        int status = msg.ReadInt32();
        Debug.Log("### ### ### ### Hand Status Received: " + status);
        if (status == 1)
        {
            this.DisPlayOtherHand();
        }
        else if (status == 0)
        {
            this.HideOtherHand();
        }
    }

    void AdjustTransform(GameObject gameObj, Vector3 position, Quaternion rotation)
    {
        gameObj.transform.position = position;
        gameObj.transform.rotation = rotation;
    }

    void DisPlayOtherHand()
    {
        otherPlayerHand.SetActive(true);
    }

    void HideOtherHand()
    {
        otherPlayerHand.SetActive(false);
    }

}
