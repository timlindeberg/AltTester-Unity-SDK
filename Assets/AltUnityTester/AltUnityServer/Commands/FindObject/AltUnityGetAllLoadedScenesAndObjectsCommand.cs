using Altom.AltUnityDriver;

namespace Assets.AltUnityTester.AltUnityServer.Commands
{
    class AltUnityGetAllLoadedScenesAndObjectsCommand : AltUnityBaseClassFindObjectsCommand
    {

        public AltUnityGetAllLoadedScenesAndObjectsCommand(params string[] paramters) : base(paramters) { }

        public override string Execute()
        {
            System.Collections.Generic.List<AltUnityObjectLight> foundObjects = new System.Collections.Generic.List<AltUnityObjectLight>();
            for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
            {
                var scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);
                foundObjects.Add(new AltUnityObjectLight(scene.name));
                foreach (UnityEngine.GameObject rootGameObject in UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).GetRootGameObjects())
                {
                    foundObjects.Add(AltUnityRunner._altUnityRunner.GameObjectToAltUnityObjectLight(rootGameObject));
                    foundObjects.AddRange(GetAllChildren(rootGameObject));
                }
            }
            var doNotDestroyOnLoadObjects = AltUnityRunner.GetDontDestroyOnLoadObjects();
            if (doNotDestroyOnLoadObjects.Length != 0)
            {
                foundObjects.Add(new AltUnityObjectLight("DontDestroyOnLoad"));
            }
            foreach (var destroyOnLoadObject in AltUnityRunner.GetDontDestroyOnLoadObjects())
            {
                foundObjects.Add(AltUnityRunner._altUnityRunner.GameObjectToAltUnityObjectLight(destroyOnLoadObject));
                foundObjects.AddRange(GetAllChildren(destroyOnLoadObject));
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(foundObjects);

        }
        private System.Collections.Generic.List<AltUnityObjectLight> GetAllChildren(UnityEngine.GameObject gameObject)
        {
            System.Collections.Generic.List<AltUnityObjectLight> children = new System.Collections.Generic.List<AltUnityObjectLight>();
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i).gameObject;
                children.Add(AltUnityRunner._altUnityRunner.GameObjectToAltUnityObjectLight(child));
                children.AddRange(GetAllChildren(child));
            }
            return children;
        }
    }
}