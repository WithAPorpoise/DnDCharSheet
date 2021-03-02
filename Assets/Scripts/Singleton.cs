using UnityEngine;

public class Singleton<T> : MonoBehaviourWithSetup where T : MonoBehaviourWithSetup
{
    private static bool m_ShuttingDown = false;
    private static object m_Lock = new object();
    private static T m_Instance;
    // Start is called before the first frame update

    public static T Instance{
        get{
            if(m_ShuttingDown){
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning null.");
                return null;
            }
            lock(m_Lock){
                if(m_Instance == null){
                    m_Instance = (T)FindObjectOfType(typeof(T));
                    if(m_Instance == null){
                        var singletonObject = new GameObject();
                        m_Instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return m_Instance;
            }
        }
    }

    protected override void Setup(){}
    private void OnApplicationQuit(){
        m_ShuttingDown = true;
    }

    private void OnDestroy() {
        m_ShuttingDown = true;
    }
}
