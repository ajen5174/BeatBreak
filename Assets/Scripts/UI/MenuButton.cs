using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_text = null;
    [SerializeField] Material m_hoverMaterial = null;

    Material m_defaultMaterial = null;

    bool m_hovering = false;
    bool m_isGrowing = true;
    float m_growthSize = 15;
    float m_currentAddedSize = 0.0f;
    float m_startFontSize = 0.0f;
    float m_animationSpeed = 2.0f;

    private void Start()
    {
        m_defaultMaterial = m_text.fontMaterial;
        m_startFontSize = m_text.fontSize;
    }

    private void Update()
    {
        if(m_hovering)
        {
            if(m_isGrowing)
            {
                m_currentAddedSize += m_growthSize * Time.deltaTime * m_animationSpeed;
            }
            else
            {
                m_currentAddedSize -= m_growthSize * Time.deltaTime * m_animationSpeed;
            }
            if (m_currentAddedSize >= m_growthSize)
            {
                m_isGrowing = false;
            }
            if(m_currentAddedSize <= 0.0f)
            {
                m_isGrowing = true;
            }
            m_text.fontSize = m_startFontSize + m_currentAddedSize;
        }
    }

    public void OnPointerEnter()
    {
        m_text.fontMaterial = m_hoverMaterial;
        m_hovering = true;
        //m_text.fontSize += 15;
    }

    public void OnPointerExit()
    {
        m_text.fontMaterial = m_defaultMaterial;
        m_hovering = false;
        //m_text.fontSize -= 15;
        m_currentAddedSize = 0.0f;
        m_text.fontSize = m_startFontSize;


    }
}
