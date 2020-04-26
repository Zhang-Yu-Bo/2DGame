using UnityEditor;

public class AssetBundleLoader
{
    [MenuItem("Assets/AssetBundle Builders/Build All AssetBundles (Windows x64)")]
    static void CreateAssetBundles_win_x64()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles",
            BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows64);
    }
}
