using System.IO;
using UnityEditor;
using UnityEditor.Android;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Rendering;

public static class BuildAndroid
{
	public static void Build()
	{
		string home = System.Environment.GetEnvironmentVariable("HOME");
		AndroidExternalToolsSettings.sdkRootPath = home + "/Android/Sdk";
		AndroidExternalToolsSettings.ndkRootPath = home + "/Android/Sdk/ndk/27.2.12479018";
		var t = NamedBuildTarget.Android;
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetScriptingBackend(t, ScriptingImplementation.IL2CPP);
		PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
		PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel24;
		PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel34;
		PlayerSettings.SetManagedStrippingLevel(t, ManagedStrippingLevel.Disabled);
		PlayerSettings.SetApplicationIdentifier(t, "com.zzoo.dokdo");
		PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.Android, false);
		PlayerSettings.SetGraphicsAPIs(BuildTarget.Android, new[] { GraphicsDeviceType.OpenGLES3 });
		PlayerSettings.Android.useCustomKeystore = false;
		PlayerSettings.Android.bundleVersionCode = 142;
		PlayerSettings.bundleVersion = "1.4.2";
		EditorUserBuildSettings.buildAppBundle = false;
		EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
		var scenes = new System.Collections.Generic.List<string>();
		foreach (var s in EditorBuildSettings.scenes) if (s.enabled) scenes.Add(s.path);
		Directory.CreateDirectory("Builds");
		var opts = new BuildPlayerOptions { scenes = scenes.ToArray(), locationPathName = "Builds/dokdo.apk", target = BuildTarget.Android, targetGroup = BuildTargetGroup.Android };
		var report = BuildPipeline.BuildPlayer(opts);
		Debug.Log("BUILD RESULT: " + report.summary.result + " errors=" + report.summary.totalErrors);
		EditorApplication.Exit(report.summary.result == BuildResult.Succeeded ? 0 : 1);
	}
}
