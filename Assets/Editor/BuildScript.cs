using UnityEditor;

public static class BuildScript {
    public static void BuildIOS() {
        string[] scenes = { "Assets/Scenes/Main.unity" }; // thay tên scene nếu cần
        BuildPlayerOptions options = new BuildPlayerOptions {
            scenes = scenes,
            locationPathName = "build/ios",
            target = BuildTarget.iOS,
            options = BuildOptions.None
        };
        BuildPipeline.BuildPlayer(options);
    }
}
