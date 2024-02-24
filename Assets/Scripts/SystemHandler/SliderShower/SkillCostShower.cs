using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SkillCostShower : MonoBehaviour
{
    [SerializeField] Slider SkillCostSlider;
    [SerializeField] Image SkillCostSliderFillIm;
    float skill1Ratio; float skill2Ratio; float skill3Ratio; float skill4Ratio; float skill5Ratio;

    void Start()
    {
        // �X�L��1����5�̃R�X�g���C�ő�R�X�g�ɐ�߂銄�����v�Z�B
        skill1Ratio = SkillParamsSO.Entity.Skill1Cost / (float)SkillParamsSO.Entity.CostMaxAmount;
        skill2Ratio = SkillParamsSO.Entity.Skill2Cost / (float)SkillParamsSO.Entity.CostMaxAmount;
        skill3Ratio = SkillParamsSO.Entity.Skill3Cost / (float)SkillParamsSO.Entity.CostMaxAmount;
        skill4Ratio = SkillParamsSO.Entity.Skill4Cost / (float)SkillParamsSO.Entity.CostMaxAmount;
        skill5Ratio = SkillParamsSO.Entity.Skill5Cost / (float)SkillParamsSO.Entity.CostMaxAmount;
    }

    void Update()
    {
        SkillCostSlider.value = GameManager.Instance.Cost / (float)SkillParamsSO.Entity.CostMaxAmount;
        ChangeSliderFillColor();
    }

    // �g����悤�ɂȂ��Ă���X�L���ɉ����āC�X���C�_�[�̐F��ς���B
    void ChangeSliderFillColor()
    {
        if (SkillCostSlider.value >= skill5Ratio)
        {
            SkillCostSliderFillIm.color = SkillParamsSO.Entity.Skill5Color;
        }
        else if (SkillCostSlider.value >= skill4Ratio)
        {
            SkillCostSliderFillIm.color = SkillParamsSO.Entity.Skill4Color;
        }
        else if (SkillCostSlider.value >= skill3Ratio)
        {
            SkillCostSliderFillIm.color = SkillParamsSO.Entity.Skill3Color;
        }
        else if (SkillCostSlider.value >= skill2Ratio)
        {
            SkillCostSliderFillIm.color = SkillParamsSO.Entity.Skill2Color;
        }
        else if (SkillCostSlider.value >= skill1Ratio)
        {
            SkillCostSliderFillIm.color = SkillParamsSO.Entity.Skill1Color;
        }
        else
        {
            SkillCostSliderFillIm.color = Color.yellow;
        }
    }
}