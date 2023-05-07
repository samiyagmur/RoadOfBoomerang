﻿using Scripts.Level.Data.ValueObject;
using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Scripts.Level.Controller
{
    public class BoomerangMovementController : MonoBehaviour
    {
        public bool IsActivate { get; set; }

        private BoomerangData _boomerangData;

        private Transform _target;

        List<Vector3[]> waypoints;


        Vector3[] waypoints1 = new[]
        {
            new Vector3(3.042855f, 1.576073f, 2.527859f),
            new Vector3(3.22991f, 1.600395f, 6.395806f),
            new Vector3(1.193167f, 2.328041f, 9.702092f),
            new Vector3(-0.5539322f, 2.910147f, 10.61282f),
            Vector3.zero
        };

        Vector3[] waypoints2 = new[]
        {
            new Vector3(-2.516079f, 2.496094f, -1.866241f),
            new Vector3(-5.835547f, 2.492188f, -2.287019f),
            new Vector3(-8.640733f, 2.488281f, -0.9779322f),
            new Vector3(-9.575794f, 2.484375f, 0.7986854f),
            new Vector3(-9.342029f, 2.480469f, 3.790883f),
            new Vector3(-6.162819f, 2.476563f, 4.866204f),
            Vector3.zero
        };

        Vector3[] waypoints3 = new[]
        {
            new Vector3(4.074979f, 2.496094f, -0.907101f),
            new Vector3(5.914858f, 2.492188f, -3.30452f),
            new Vector3(4.688271f, 2.488281f, -4.754122f),
            new Vector3(1.733312f, 2.484375f, -6.594001f),
            new Vector3(-2.55974f, 2.480469f, -6.649756f),
            Vector3.zero
        };

        internal void SetData(BoomerangData boomerangData, Transform target)
        {
            _boomerangData = boomerangData;

            _target = target;
        }


        public void TriggerAction()
        {
            waypoints = new List<Vector3[]> { waypoints1, waypoints2, waypoints3 };

            int selectedWayPoint = SelectWaypoint();


            waypoints[selectedWayPoint][waypoints[selectedWayPoint].Length-1] = _target.position + new Vector3(0, 1.25f, 0);

            Rotate();

            Move(waypoints[selectedWayPoint]);

            if (IsActivate) return;

        }

        private int SelectWaypoint()
        {
            return Random.Range(0, 3);
        }

        private void Rotate()
        {
            transform.DORotate(new Vector3(0, 360 * _boomerangData.rotations, 0), _boomerangData.duration, RotateMode.WorldAxisAdd)
                .SetLoops(-1, LoopType.Restart);
        }

        private void Move(Vector3[] waypoints)
        {
            Debug.Log(_target);

            transform.DOPath(waypoints,1.2f).SetEase(Ease.InOutSine);
        }

    }
}