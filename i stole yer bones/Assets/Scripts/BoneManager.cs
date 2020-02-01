using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoneManager : MonoBehaviour
{
    [SerializeField] List<insideBone> insideBones = new List<insideBone>();
    [SerializeField] Slider healthbar;

    public float health = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplosionManager());
    }

    // Update is called once per frame
    void Update()
    {
        int missingBones = GetNumMissingBones();
        health -= missingBones * 0.01f;


        healthbar.value = health;
    }

    int GetNumMissingBones()
    {
        int missing = 0;
        foreach (insideBone bone in insideBones)
        {
            if (bone.hasBone) missing++;
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
}
