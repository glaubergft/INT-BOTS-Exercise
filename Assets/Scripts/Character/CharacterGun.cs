using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGun : MonoBehaviourPun
{
    #region Serialized Fields

    [SerializeField]
    private Transform characterCamera;

    [SerializeField]
    private Transform launcher;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float fireRate = 0.25f;

    #endregion

    #region Private Variables

    private float lastFire = 0;

    private PhotonView view;

    #endregion

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && lastFire + fireRate <= Time.time)
        {
            lastFire = Time.time;
            Shoot();
        }
    }

    internal void Shoot()
    {
        GameObject instance = Instantiate(projectile, launcher.position, launcher.rotation);
        instance.transform.position = launcher.position;
        instance.transform.forward = characterCamera.forward;
    }

}
