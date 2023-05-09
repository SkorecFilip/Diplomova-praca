using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;

}
public class DetektorG : MonoBehaviour
{
    [Header("Threshold value")] public float threshold = 0.1f;
    [Header("Hand Skeleton")] public OVRSkeleton skeleton;
    [Header("List of Gestures")] public List<Gesture> gestures;
    private List<OVRBone> fingerbones = null;
    [Header("DebugMode")] public bool debugMode = true;
    private bool hasStarted = false;
    private bool hasRecognize = false;
    private bool done = false;
    [Header("Not Recognized Event")] public UnityEvent notRecognize;

    void Start()
    {
        StartCoroutine(DelayRoutine(2.5f, Initialize));
    }

    public IEnumerator DelayRoutine(float delay, Action actionToDo)
    {
        yield return new WaitForSeconds(delay);
        actionToDo.Invoke();
    }

    public void Initialize()
    {
        SetSkeleton();
        hasStarted = true;
    }
    public void SetSkeleton()
    {
        fingerbones = new List<OVRBone>(skeleton.Bones);
    }

    void Update()
    {
        if (debugMode && Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }

        if (hasStarted.Equals(true))
        {           
            Gesture currentGesture = Recognize();
            hasRecognize = !currentGesture.Equals(new Gesture());
            if (hasRecognize)
            {
                done = true;
                currentGesture.onRecognized?.Invoke();
            }
            else
            {
                if (done)
                {
                    Debug.Log("Not Recognized");
                    done = false;
                    notRecognize?.Invoke();
                }
            }
        }
    }

    void Save()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();
        foreach (OVRBone bone in fingerbones)
        {
            if (bone.Id.Equals(OVRSkeleton.BoneId.Body_LeftHandIndexTip))
            {
                
            }
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }
        g.fingerDatas = data;
        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;
        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerbones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerbones[i].Transform.position);            
                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);
                if (distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }
                sumDistance += distance;
            }
            if (!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }
        return currentGesture;
    }

}
