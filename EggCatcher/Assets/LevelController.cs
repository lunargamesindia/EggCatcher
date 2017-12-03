using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EggCatcher.Globals;
public class LevelController : MonoBehaviour
{
    public DOTweenAnimation level;
    public GameObject eggPrefab, pot;

    public float speed;
    public Vector3 stepY;

    public static LevelController levelController;
    public static GameObject eggInstance;

    private void Start()
    {
        levelController = this;
        Globals.Input = true;
    }
    public void OnPlayerInput()
    {
        if (Globals.Input)
        {
            Globals.Input = false;

            eggPrefab.transform.SetParent(null);
            if (eggPrefab.GetComponent<Rigidbody2D>() == null)
                eggPrefab.AddComponent<Rigidbody2D>();
            eggPrefab.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.up * speed, eggPrefab.transform.localPosition, ForceMode2D.Force);
            eggPrefab.GetComponent<Rigidbody2D>().AddTorque(torque: 0, mode: ForceMode2D.Force);
        }
    }
    public void OnMiss()
    {

    }
    public void OnHit()
    {
        level.DOPlayForward();
    }
}
