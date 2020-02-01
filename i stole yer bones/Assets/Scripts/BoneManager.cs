﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoneManager : MonoBehaviour
{
    [SerializeField] List<insideBone> insideBones = new List<insideBone>();
    [SerializeField] Slider healthbar;
    Vector3 healthBarOrigin;
    
    public float health = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplosionManager());
        healthBarOrigin = healthbar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        int missingBones = GetNumMissingBones();
        if (missingBones == 0) {
            if (healthbar.transform.position != healthBarOrigin) healthbar.transform.position = healthBarOrigin;
            health += 0.0005f;
            StopCoroutine(Shake(healthbar.transform));
        }
        else
        {
            health -= missingBones * 0.0005f;
            StartCoroutine(Shake(healthbar.transform));
        }
        healthbar.value = health;
    }

    int GetNumMissingBones()
    {
        int missing = 0;
        foreach (insideBone bone in insideBones)
        {
            if (!bone.hasBone) missing++;
        }
        return missing;
    }

    IEnumerator ExplosionManager()
    {
        int explosionChance;
        while (true)
        {
            explosionChance = Random.Range(0, 10);
            if(explosionChance == 0)
            {
                int whoIsTheLuckyBone;
                do
                {
                    whoIsTheLuckyBone = Random.Range(0, 8);
                } while (!insideBones[whoIsTheLuckyBone].hasBone);
                insideBones[whoIsTheLuckyBone].Explode();
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    IEnumerator Shake(Transform t)
    {
        Vector3 position = t.position;
        while (true)
        {
            position.x += Random.Range(-0.01f, 0.01f);
            position.y += Random.Range(-0.01f, 0.01f);
            t.position = position;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
