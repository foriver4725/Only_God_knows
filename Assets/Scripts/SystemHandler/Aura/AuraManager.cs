using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AuraManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI logText;
    [SerializeField] AudioClip auraNormalSE;
    [SerializeField] AudioClip auraUnLuckySE;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.Instance.IsGetAura)
        {
            GameManager.Instance.IsGetAura = false;

            // �R�X�g�𑝂₷�B
            GameManager.Instance.Cost += AuraParamsSO.Entity.AuraCostIncreaseAmount;

            if (AuraParamsSO.Entity.AuraSelectNumber == 0)
            {
                #region �m���Ɋ�Â��I�[���̌��ʂ������_���Ɍ��肵�C���O��\�����C��������B
                int p = Random.Range(0, 100);

                if (0 <= p && p < AuraParamsSO.Entity.Aura1P)
                {
                    Aura1();
                }
                else
                {
                    p -= AuraParamsSO.Entity.Aura1P;

                    if (0 <= p && p < AuraParamsSO.Entity.Aura2P)
                    {
                        Aura2();
                    }
                    else
                    {
                        p -= AuraParamsSO.Entity.Aura2P;

                        if (0 <= p && p < AuraParamsSO.Entity.Aura3P)
                        {
                            Aura3();
                        }
                        else
                        {
                            p -= AuraParamsSO.Entity.Aura3P;

                            if (0 <= p && p < AuraParamsSO.Entity.Aura4P)
                            {
                                Aura4();
                            }
                            else
                            {
                                p -= AuraParamsSO.Entity.Aura4P;

                                if (0 <= p && p < AuraParamsSO.Entity.Aura5P)
                                {
                                    Aura5();
                                }
                                else
                                {
                                    p -= AuraParamsSO.Entity.Aura5P;

                                    if (0 <= p && p < AuraParamsSO.Entity.Aura6P)
                                    {
                                        Aura6();
                                    }
                                    else
                                    {
                                        p -= AuraParamsSO.Entity.Aura6P;

                                        if (0 <= p && p < AuraParamsSO.Entity.Aura7P)
                                        {
                                            Aura7();
                                        }
                                        else
                                        {
                                            p -= AuraParamsSO.Entity.Aura7P;

                                            if (0 <= p && p < AuraParamsSO.Entity.Aura8P)
                                            {
                                                Aura8();
                                            }
                                            else
                                            {
                                                p -= AuraParamsSO.Entity.Aura8P;

                                                if (0 <= p && p < AuraParamsSO.Entity.Aura9P)
                                                {
                                                    Aura9();
                                                }
                                                else
                                                {
                                                    p -= AuraParamsSO.Entity.Aura9P;

                                                    if (0 <= p && p < AuraParamsSO.Entity.Aura10P)
                                                    {
                                                        Aura10();
                                                    }
                                                    else
                                                    {
                                                        p -= AuraParamsSO.Entity.Aura10P;

                                                        if (0 <= p && p < AuraParamsSO.Entity.AuraLuckyP)
                                                        {
                                                            AuraLucky();
                                                        }
                                                        else
                                                        {
                                                            p -= AuraParamsSO.Entity.AuraLuckyP;

                                                            if (0 <= p && p < AuraParamsSO.Entity.AuraUnLuckyP)
                                                            {
                                                                AuraUnLucky();
                                                            }
                                                            else
                                                            {
                                                                Debug.Log("�m���̑��a��100%�ɂȂ��Ă��܂���");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            #region �e�X�g�p�F�I�[�����w�肷��B
            else if (AuraParamsSO.Entity.AuraSelectNumber == 1)
            {
                Aura1();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 2)
            {
                Aura2();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 3)
            {
                Aura3();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 4)
            {
                Aura4();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 5)
            {
                Aura5();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 6)
            {
                Aura6();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 7)
            {
                Aura7();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 8)
            {
                Aura8();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 9)
            {
                Aura9();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 10)
            {
                Aura10();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == 100)
            {
                AuraLucky();
            }
            else if (AuraParamsSO.Entity.AuraSelectNumber == -100)
            {
                AuraUnLucky();
            }
            #endregion
        }
    }

    #region ���O��\���C�I�[���̌��ʂ𔭓�(8��Lucky�́CSE����)
    void Aura1()
    {
        if (!GameManager.Instance.IsAura1Doing)
        {
            GameManager.Instance.IsAura1Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura1Detail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraNormalSE);
            // 3�b�ԑS�Ă̑��l�̑�����10���₷
            int[] vars = AuraParamsSO.Entity.Aura1Vars;
            StartCoroutine(DoAura1(vars[0], vars[1]));
        }
    }

    void Aura2()
    {
        if (!GameManager.Instance.IsAura2Doing)
        {
            GameManager.Instance.IsAura2Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura2Detail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraNormalSE);
            // �S�Ă̑��l��HP��1���₷
            int[] vars = AuraParamsSO.Entity.Aura2Vars;
            foreach (GameObject villager in GameManager.Instance.VillagerInstances)
            {
                villager.GetComponent<Villager>().HP += vars[0];
            }

            GameManager.Instance.IsAura2Doing = false;
        }
    }

    void Aura3()
    {
        if (!GameManager.Instance.IsAura3Doing)
        {
            GameManager.Instance.IsAura3Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura3Detail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraNormalSE);
            // 3�b�ԑS�Ă̑��l���]���r����_���[�W��H���Ȃ��Ȃ�
            int[] vars = AuraParamsSO.Entity.Aura3Vars;
            StartCoroutine(DoAura3(vars[0]));
        }
    }

    void Aura4()
    {
        if (!GameManager.Instance.IsAura4Doing)
        {
            GameManager.Instance.IsAura4Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura4Detail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraNormalSE);
            // 2�b�ԃ]���r�����l���瓦����悤�ɂȂ�
            int[] vars = AuraParamsSO.Entity.Aura4Vars;
            StartCoroutine(DoAura4(vars[0]));
        }
    }

    void Aura5()
    {
        if (!GameManager.Instance.IsAura5Doing)
        {
            GameManager.Instance.IsAura5Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura5Detail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraNormalSE);
            // �S�Ẵ]���r��HP��1���炷
            int[] vars = AuraParamsSO.Entity.Aura5Vars;
            foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
            {
                zombie.GetComponent<Zombie>().HP -= vars[0];
            }

            GameManager.Instance.IsAura5Doing = false;
        }
    }

    void Aura6()
    {
        if (!GameManager.Instance.IsAura6Doing)
        {
            GameManager.Instance.IsAura6Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura6Detail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraNormalSE);
            // 3�b�ԑS�Ẵ]���r�̓������~�߂�
            int[] vars = AuraParamsSO.Entity.Aura6Vars;
            StartCoroutine(DoAura6(vars[0]));
        }
    }

    void Aura7()
    {
        if (!GameManager.Instance.IsAura7Doing)
        {
            GameManager.Instance.IsAura7Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura7Detail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraNormalSE);
            // �R�X�g��10�񕜂���
            int[] vars = AuraParamsSO.Entity.Aura7Vars;
            GameManager.Instance.Cost += vars[0];

            GameManager.Instance.IsAura7Doing = false;
        }
    }

    void Aura8()
    {
        if (!GameManager.Instance.IsAura8Doing)
        {
            GameManager.Instance.IsAura8Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura8Detail, AuraParamsSO.Entity.AuraLogShowTime));

            // �ً}����𔭓�����
            int[] vars = AuraParamsSO.Entity.Aura8Vars;
            GameManager.Instance.IsSkill1Used = true;

            GameManager.Instance.IsAura8Doing = false;
        }
    }

    void Aura9()
    {
        if (!GameManager.Instance.IsAura9Doing)
        {
            GameManager.Instance.IsAura9Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura9Detail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraNormalSE);
            // ���l�ƃ]���r�̈ʒu�����ւ���
            int[] vars = AuraParamsSO.Entity.Aura9Vars;

            // �����c���Ă��鑺�l�ƃ]���r�̃C���X�^���X���i�[
            List<GameObject> remainVillagers = new List<GameObject>();
            foreach (GameObject villager in GameManager.Instance.VillagerInstances)
            {
                if (villager.activeSelf)
                {
                    remainVillagers.Add(villager);
                }
            }
            List<GameObject> remainZombies = new List<GameObject>();
            foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
            {
                if (zombie.activeSelf)
                {
                    remainZombies.Add(zombie);
                }
            }

            // �ʒu�����ւ���(�Q�[���J�n���ɐ����������Ԃŕ]��)
            int minChangeNum = Mathf.Min(remainVillagers.Count, remainZombies.Count);
            for (int i = 0; i < minChangeNum; i++)
            {
                (remainVillagers[i].transform.position, remainZombies[i].transform.position) = (remainZombies[i].transform.position, remainVillagers[i].transform.position);
            }

            GameManager.Instance.IsAura9Doing = false;
        }
    }

    void Aura10()
    {
        if (!GameManager.Instance.IsAura10Doing)
        {
            GameManager.Instance.IsAura10Doing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.Aura10Detail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraNormalSE);
            // �����N����Ȃ�
            int[] vars = AuraParamsSO.Entity.Aura10Vars;

            GameManager.Instance.IsAura10Doing = false;
        }
    }

    void AuraLucky()
    {
        if (!GameManager.Instance.IsAuraLuckyDoing)
        {
            GameManager.Instance.IsAuraLuckyDoing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.AuraLuckyDetail, AuraParamsSO.Entity.AuraLogShowTime));

            // �T�����q�[�����O�t�@�C�A�𔭓�����
            int[] vars = AuraParamsSO.Entity.AuraLuckyVars;
            GameManager.Instance.IsSkill5Used = true;

            GameManager.Instance.IsAuraLuckyDoing = false;
        }
    }

    void AuraUnLucky()
    {
        if (!GameManager.Instance.IsAuraUnLuckyDoing)
        {
            GameManager.Instance.IsAuraUnLuckyDoing = true;

            StartCoroutine(LogShow(AuraParamsSO.Entity.AuraUnLuckyDetail, AuraParamsSO.Entity.AuraLogShowTime));

            audioSource.PlayOneShot(auraUnLuckySE);
            // 10�b�ԑS�Ă̑��l���]���r�Ɍ������Ă����悤�ɂȂ�
            int[] vars = AuraParamsSO.Entity.AuraUnLuckyVars;
            StartCoroutine(DoAuraUnLucky(vars[0]));
        }
    }
    #endregion

    // ���O��\��
    IEnumerator LogShow(string text, float period)
    {
        logText.text = text;

        yield return new WaitForSeconds(period);

        logText.text = "";

        yield break;
    }

    // 3�b�ԑS�Ă̑��l�̑�����10���₷
    IEnumerator DoAura1(int period, int plusSpeed)
    {
        foreach (GameObject villager in GameManager.Instance.VillagerInstances)
        {
            villager.GetComponent<Villager>().Speed += plusSpeed;
        }

        yield return new WaitForSeconds(period);

        foreach (GameObject villager in GameManager.Instance.VillagerInstances)
        {
            villager.GetComponent<Villager>().Speed = VZParamsSO.Entity.VillagerSpeed;
        }

        GameManager.Instance.IsAura1Doing = false;
        yield break;
    }

    // 3�b�ԑS�Ă̑��l���]���r����_���[�W��H���Ȃ��Ȃ�
    IEnumerator DoAura3(int period)
    {
        foreach (GameObject villager in GameManager.Instance.VillagerInstances)
        {
            villager.GetComponent<Villager>().IsDamagableFromZombie = false;
        }

        yield return new WaitForSeconds(period);

        foreach (GameObject villager in GameManager.Instance.VillagerInstances)
        {
            villager.GetComponent<Villager>().IsDamagableFromZombie = true;
        }

        GameManager.Instance.IsAura3Doing = false;
        yield break;
    }

    // 2�b�ԃ]���r�����l���瓦����悤�ɂȂ�
    IEnumerator DoAura4(int period)
    {
        foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
        {
            zombie.GetComponent<Zombie>().IsFromVillager = true;
        }

        yield return new WaitForSeconds(period);

        foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
        {
            zombie.GetComponent<Zombie>().IsFromVillager = false;
        }

        GameManager.Instance.IsAura4Doing = false;
        yield break;
    }

    // 3�b�ԑS�Ẵ]���r�̓������~�߂�
    IEnumerator DoAura6(int period)
    {
        foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
        {
            zombie.GetComponent<Zombie>().Speed = 0;
        }

        yield return new WaitForSeconds(period);

        foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
        {
            zombie.GetComponent<Zombie>().Speed = VZParamsSO.Entity.ZombieSpeed;
        }

        GameManager.Instance.IsAura6Doing = false;
        yield break;
    }

    // 10�b�ԑS�Ă̑��l���]���r�Ɍ������Ă����悤�ɂȂ�
    IEnumerator DoAuraUnLucky(int period)
    {
        foreach (GameObject villager in GameManager.Instance.VillagerInstances)
        {
            villager.GetComponent<Villager>().IsToZombie = true;
        }

        yield return new WaitForSeconds(period);

        foreach (GameObject villager in GameManager.Instance.VillagerInstances)
        {
            villager.GetComponent<Villager>().IsToZombie = false;
        }

        GameManager.Instance.IsAuraUnLuckyDoing = false;
        yield break;
    }
}