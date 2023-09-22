using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour
{
    public void OnJointBreak()
    {
        if(Cannon.Instance.BulletQuantity > 0)
        {
            GameManager.Instance.JointCounter++;
        }
    }
}
