using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float a;
    public float b;
    public float w;
    public float t;
    public bool launched;
    //public Vector2 origin;
    GameObject origin;

    void Awake()
    {
        origin = new GameObject("Bullet Container");
        this.transform.SetParent(origin.transform);
        a = 2f;
        b = 1f;
        w = 2f;
        launched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (launched)
        {
            t += Time.deltaTime;
            this.transform.localPosition = computePosition();
            this.transform.up = computeVelocity();
            if(w * t > Mathf.PI)
                Destroy(this.origin);
        }
    }

    bool isAcceptableDifference(float a, float b, float maxDiff)
    {
        float diff = Mathf.Abs(a - b);
        return diff < maxDiff;
    }

    // IV Quadrant not working
    //float computeTFromVelocity(Vector2 v)
    //{
    //    float[] possibleTs = new float[4];
    //    possibleTs[0] = Mathf.Asin(v.x);
    //    possibleTs[1] = Mathf.PI / 2 - possibleTs[0];
    //    possibleTs[2] = Mathf.Acos(v.y);
    //    possibleTs[3] = 2 * Mathf.PI - possibleTs[2];
    //    print("t0 = {" + possibleTs[0] + ", " + possibleTs[1] + ", " + possibleTs[2] + ", " + possibleTs[3] + "}");
    //    if (isAcceptableDifference(possibleTs[2], possibleTs[0], 0.01f) || isAcceptableDifference(possibleTs[2], possibleTs[1], 0.01f))
    //        return possibleTs[2];
    //    return possibleTs[3];
    //}

    public void Launch(Vector2 initialVelocity, Vector2 originPos, float a, float b)
    {
        this.origin.transform.position = originPos;
        this.a = a;
        this.b = b;

        float angle = -Vector2.SignedAngle(Vector2.up, initialVelocity);
        angle *= Mathf.PI / 180f;
        if (angle < 0)
            angle += 2 * Mathf.PI;
        //float t0 = computeTFromVelocity(v);
        //print("t0 = {" + angle + ", " + t0 + "}");
        t = angle;

        this.transform.localPosition = computePosition();
        setLaunchStatus(true);
    }

    public bool setLaunchStatus(bool newStatus)
    {
        this.launched = newStatus;
        if (!newStatus)
        {
            this.gameObject.SetActive(false);
        }
        return this.launched;
    }

    public Vector2 computePosition()
    {
        return new Vector2(-a * Mathf.Cos(w * t), b * Mathf.Sin(w * t));
    }

    public Vector2 computeVelocity()
    {
        return new Vector2(a * w * Mathf.Sin(w * t), b * w * Mathf.Cos(w * t));
    }
}
