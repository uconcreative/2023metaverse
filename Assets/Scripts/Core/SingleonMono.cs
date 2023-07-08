using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    static protected T m_instance = null;
    private static bool _applicationIsQuitting = false;
    static public T getInstance()
    {
        if (_applicationIsQuitting)
        {
            return null;
        }

        if (null == m_instance)
        {
            m_instance = GameObject.FindObjectOfType<T>();
            if (null == m_instance)
            {
                GameObject go = new GameObject(typeof(T).ToString());
                m_instance = go.AddComponent<T>();
                Object.DontDestroyOnLoad(go);
            }

            m_bAlive = true;
        }
        return m_instance;
    }


    [SerializeField] private bool m_DontDestroy = false;

    static private bool m_bAlive = false;
    static public bool isAlive
    {
        get { return m_bAlive; }
    }

    protected virtual void OnDestroy()
    {
        if (null != m_instance && !m_DontDestroy)
        {
            m_instance = null;
            m_bAlive = false;
        }
    }

    protected virtual void OnApplicationQuit()
    {
        if (m_DontDestroy)
        {
            _applicationIsQuitting = true;
            m_instance = null;
            Destroy(gameObject);
        }
    }

    protected virtual void Awake()
    {
        if (null == m_instance)
        {
            m_instance = this as T;
            m_bAlive = true;
            if (m_DontDestroy)
            {
                Object.DontDestroyOnLoad(gameObject);
            }

        }
        else if (null != m_instance)
        {
            m_bAlive = true;
            if (m_DontDestroy)
            {
                Object.DontDestroyOnLoad(gameObject);
            }
        }
    }
}