using UnityEngine;

namespace RPG
{
    class Splashscreen
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
