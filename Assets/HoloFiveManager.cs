using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Sharing;
using HoloToolkit.Unity;

public class HoloFiveManager : MonoBehaviour
{
    public GameObject otherPlayerHand;
    public GameObject otherPlayerHead;
    public GameObject localPlayerHand;

    public bool LocalHandDetected { get; set; }
    public bool OtherHandDetected { get; set; }

    // Use this for initialization
    void Start()
    {
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.HeadTransform] = this.OnHeadTransform;
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.HandTransform] = this.OnHandTransform;
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.HandStatus] = this.OnHandStatus;
        OtherHandDetected = false;
        this.HideOtherHead();
        this.HideOtherHand();
    }

    // Update is called once per frame
    void Update()
    {
        // send self head transform
        Transform cameraTM = Camera.main.transform;
        CustomMessages.Instance.SendHeadTransform(cameraTM.position, cameraTM.rotation, 0);

        Transform handTM = localPlayerHand.transform;
        CustomMessages.Instance.SendHandTransform(handTM.position, handTM.rotation, 0);
    }


    void OnHeadTransform(NetworkInMessage msg)
    {
        //read user id etc of the front of the message
        msg.ReadInt32();
        msg.ReadInt32();

        Vector3 position = CustomMessages.Instance.ReadVector3(msg);
        Quaternion rotation = CustomMessages.Instance.ReadQuaternion(msg);
        this.AdjustTransform(otherPlayerHead, position, rotation);

        this.DisplayOtherHead();
    }

    void OnHandTransform(NetworkInMessage msg)
    {
        //read user id etc of the front of the message
        msg.ReadInt32();
        msg.ReadInt32();

        Vector3 position = CustomMessages.Instance.ReadVector3(msg);
        Quaternion rotation = CustomMessages.Instance.ReadQuaternion(msg);
        this.AdjustTransform(otherPlayerHand, position, rotation);
    }

    void OnHandStatus(NetworkInMessage msg)
    {
        //read user id etc of the front of the message
        msg.ReadInt32();
        msg.ReadInt32();

        int status = msg.ReadInt32();
        //Debug.Log("### ### ### ### Hand Status Received: " + status);
        if (status == 1)
        {
            this.OtherHandDetected = true;
            this.DisPlayOtherHand();
        }
        else if (status == 0)
        {
            this.OtherHandDetected = false;
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

    void DisplayOtherHead()
    {
        otherPlayerHead.SetActive(true);
    }

    void HideOtherHead()
    {
        otherPlayerHead.SetActive(false);
    }
}
