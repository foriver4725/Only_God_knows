using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    [SerializeField] GameObject dirt;
    [SerializeField] AudioClip skillUse3SE;
    GameObject dirtInstance;
    AudioSource audioSource;
    int[] vars;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 合図が送られ，かつ実行中でないなら
        if (GameManager.Instance.IsSkill3Used)
        {
            GameManager.Instance.IsSkill3Used = false;

            if (!GameManager.Instance.IsSkill3Doing)
            {
                GameManager.Instance.IsSkill3Doing = true;

                vars = SkillParamsSO.Entity.Skill3Vars;
                // 中央に土塊を生成する。
                audioSource.PlayOneShot(skillUse3SE);
                dirtInstance = Instantiate(dirt, new Vector3(0, 1.5f, 0), Quaternion.identity);
                StartCoroutine(Dirt());
            }
        }
    }

    IEnumerator Dirt()
    {
        // 登場時にすべてのゾンビの体力を5減らす。
        foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
        {
            zombie.GetComponent<Zombie>().HP -= vars[0];
        }

        // 登場から3秒経過した時に90%の確率で1度だけランダムなゾンビを倒し，その後自分自身を破壊する。
        yield return new WaitForSeconds(vars[1]);

        for (int i = 0; i < vars[3]; i++)
        {
            int p = Random.Range(0, 100);
            if (p <= vars[2] - 1)
            {
                GameObject zombie;

                while (GameManager.Instance.ZombieNumber > 0)
                {
                    int zombieNum = GameManager.Instance.ZombieInstances.Length;
                    zombie = GameManager.Instance.ZombieInstances[Random.Range(0, zombieNum)];
                    if (zombie.tag == "Zombie")
                    {
                        zombie.GetComponent<Zombie>().HP = 0;
                        break;
                    }
                }
            }
        }

        audioSource.PlayOneShot(skillUse3SE);
        Destroy(dirtInstance);
        GameManager.Instance.IsSkill3Doing = false;
        yield break;
    }
}
