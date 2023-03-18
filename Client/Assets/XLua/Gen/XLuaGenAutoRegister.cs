#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;
using System.Collections.Generic;
using System.Reflection;


namespace XLua.CSObjectWrap
{
    public class XLua_Gen_Initer_Register__
	{
        
        
        static void wrapInit0(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(object), SystemObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Object), UnityEngineObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector2), UnityEngineVector2Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector3), UnityEngineVector3Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector4), UnityEngineVector4Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Quaternion), UnityEngineQuaternionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Color), UnityEngineColorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray), UnityEngineRayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Bounds), UnityEngineBoundsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray2D), UnityEngineRay2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Time), UnityEngineTimeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GameObject), UnityEngineGameObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Component), UnityEngineComponentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Behaviour), UnityEngineBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Transform), UnityEngineTransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Resources), UnityEngineResourcesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TextAsset), UnityEngineTextAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Keyframe), UnityEngineKeyframeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationCurve), UnityEngineAnimationCurveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationClip), UnityEngineAnimationClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MonoBehaviour), UnityEngineMonoBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem), UnityEngineParticleSystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SkinnedMeshRenderer), UnityEngineSkinnedMeshRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Renderer), UnityEngineRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Light), UnityEngineLightWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Mathf), UnityEngineMathfWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<int>), SystemCollectionsGenericList_1_SystemInt32_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Debug), UnityEngineDebugWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.BaseClass), TutorialBaseClassWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.TestEnum), TutorialTestEnumWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.DerivedClass), TutorialDerivedClassWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.ICalc), TutorialICalcWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.DerivedClassExtensions), TutorialDerivedClassExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.LuaBehaviour), XLuaTestLuaBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Pedding), XLuaTestPeddingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.MyStruct), XLuaTestMyStructWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.MyEnum), XLuaTestMyEnumWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.NoGc), XLuaTestNoGcWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitForSeconds), UnityEngineWaitForSecondsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.BaseTest), XLuaTestBaseTestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo1Parent), XLuaTestFoo1ParentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo2Parent), XLuaTestFoo2ParentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo1Child), XLuaTestFoo1ChildWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo2Child), XLuaTestFoo2ChildWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo), XLuaTestFooWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.FooExtension), XLuaTestFooExtensionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.DerivedClass.TestEnumInner), TutorialDerivedClassTestEnumInnerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Animator), UnityEngineAnimatorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.StateMachineBehaviour), UnityEngineStateMachineBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Animation), UnityEngineAnimationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationState), UnityEngineAnimationStateWrap.__Register);
        
        }
        
        static void wrapInit1(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationEvent), UnityEngineAnimationEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorClipInfo), UnityEngineAnimatorClipInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorStateInfo), UnityEngineAnimatorStateInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorTransitionInfo), UnityEngineAnimatorTransitionInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MatchTargetWeightMask), UnityEngineMatchTargetWeightMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorControllerParameter), UnityEngineAnimatorControllerParameterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorOverrideController), UnityEngineAnimatorOverrideControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorUtility), UnityEngineAnimatorUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Avatar), UnityEngineAvatarWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SkeletonBone), UnityEngineSkeletonBoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanLimit), UnityEngineHumanLimitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanBone), UnityEngineHumanBoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanDescription), UnityEngineHumanDescriptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AvatarBuilder), UnityEngineAvatarBuilderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AvatarMask), UnityEngineAvatarMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanPose), UnityEngineHumanPoseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanPoseHandler), UnityEngineHumanPoseHandlerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanTrait), UnityEngineHumanTraitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RuntimeAnimatorController), UnityEngineRuntimeAnimatorControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundle), UnityEngineAssetBundleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleCreateRequest), UnityEngineAssetBundleCreateRequestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleManifest), UnityEngineAssetBundleManifestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleRecompressOperation), UnityEngineAssetBundleRecompressOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleRequest), UnityEngineAssetBundleRequestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BuildCompression), UnityEngineBuildCompressionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioLowPassFilter), UnityEngineAudioLowPassFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioHighPassFilter), UnityEngineAudioHighPassFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioReverbFilter), UnityEngineAudioReverbFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioConfiguration), UnityEngineAudioConfigurationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioClip), UnityEngineAudioClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioBehaviour), UnityEngineAudioBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioListener), UnityEngineAudioListenerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioReverbZone), UnityEngineAudioReverbZoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioDistortionFilter), UnityEngineAudioDistortionFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioEchoFilter), UnityEngineAudioEchoFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioChorusFilter), UnityEngineAudioChorusFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Microphone), UnityEngineMicrophoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioRenderer), UnityEngineAudioRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WebCamDevice), UnityEngineWebCamDeviceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WebCamTexture), UnityEngineWebCamTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ClothSphereColliderPair), UnityEngineClothSphereColliderPairWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ClothSkinningCoefficient), UnityEngineClothSkinningCoefficientWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Cloth), UnityEngineClothWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ClusterSerialization), UnityEngineClusterSerializationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SortingLayer), UnityEngineSortingLayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Application), UnityEngineApplicationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CachedAssetBundle), UnityEngineCachedAssetBundleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Cache), UnityEngineCacheWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Camera), UnityEngineCameraWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoundingSphere), UnityEngineBoundingSphereWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CullingGroupEvent), UnityEngineCullingGroupEventWrap.__Register);
        
        }
        
        static void wrapInit2(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.CullingGroup), UnityEngineCullingGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FlareLayer), UnityEngineFlareLayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ReflectionProbe), UnityEngineReflectionProbeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CrashReport), UnityEngineCrashReportWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ExposedPropertyResolver), UnityEngineExposedPropertyResolverWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoundsInt), UnityEngineBoundsIntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GeometryUtility), UnityEngineGeometryUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Plane), UnityEnginePlaneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Rect), UnityEngineRectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RectInt), UnityEngineRectIntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RectOffset), UnityEngineRectOffsetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.DynamicGI), UnityEngineDynamicGIWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BillboardAsset), UnityEngineBillboardAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BillboardRenderer), UnityEngineBillboardRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CustomRenderTextureManager), UnityEngineCustomRenderTextureManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Display), UnityEngineDisplayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SleepTimeout), UnityEngineSleepTimeoutWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Screen), UnityEngineScreenWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderBuffer), UnityEngineRenderBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Graphics), UnityEngineGraphicsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GL), UnityEngineGLWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ScalableBufferManager), UnityEngineScalableBufferManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FrameTiming), UnityEngineFrameTimingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FrameTimingManager), UnityEngineFrameTimingManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightmapData), UnityEngineLightmapDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightmapSettings), UnityEngineLightmapSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightProbes), UnityEngineLightProbesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HDROutputSettings), UnityEngineHDROutputSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Resolution), UnityEngineResolutionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderTargetSetup), UnityEngineRenderTargetSetupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.QualitySettings), UnityEngineQualitySettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RendererExtensions), UnityEngineRendererExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectTransformsToLDR), UnityEngineImageEffectTransformsToLDRWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectAllowedInSceneView), UnityEngineImageEffectAllowedInSceneViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectOpaque), UnityEngineImageEffectOpaqueWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectAfterScale), UnityEngineImageEffectAfterScaleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectUsesCommandBuffer), UnityEngineImageEffectUsesCommandBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Mesh), UnityEngineMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Projector), UnityEngineProjectorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Shader), UnityEngineShaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TrailRenderer), UnityEngineTrailRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LineRenderer), UnityEngineLineRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MaterialPropertyBlock), UnityEngineMaterialPropertyBlockWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderSettings), UnityEngineRenderSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Material), UnityEngineMaterialWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GraphicsBuffer), UnityEngineGraphicsBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.OcclusionPortal), UnityEngineOcclusionPortalWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.OcclusionArea), UnityEngineOcclusionAreaWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Flare), UnityEngineFlareWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LensFlare), UnityEngineLensFlareWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightBakingOutput), UnityEngineLightBakingOutputWrap.__Register);
        
        }
        
        static void wrapInit3(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.Skybox), UnityEngineSkyboxWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MeshFilter), UnityEngineMeshFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightProbeProxyVolume), UnityEngineLightProbeProxyVolumeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MeshRenderer), UnityEngineMeshRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightProbeGroup), UnityEngineLightProbeGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LineUtility), UnityEngineLineUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LOD), UnityEngineLODWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LODGroup), UnityEngineLODGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoneWeight), UnityEngineBoneWeightWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoneWeight1), UnityEngineBoneWeight1Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CombineInstance), UnityEngineCombineInstanceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Texture), UnityEngineTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Texture2D), UnityEngineTexture2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Cubemap), UnityEngineCubemapWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Texture3D), UnityEngineTexture3DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Texture2DArray), UnityEngineTexture2DArrayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CubemapArray), UnityEngineCubemapArrayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SparseTexture), UnityEngineSparseTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderTexture), UnityEngineRenderTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CustomRenderTextureUpdateZone), UnityEngineCustomRenderTextureUpdateZoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CustomRenderTexture), UnityEngineCustomRenderTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderTextureDescriptor), UnityEngineRenderTextureDescriptorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Hash128), UnityEngineHash128Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HashUtilities), UnityEngineHashUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HashUnsafeUtilities), UnityEngineHashUnsafeUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Logger), UnityEngineLoggerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Color32), UnityEngineColor32Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ColorUtility), UnityEngineColorUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GradientColorKey), UnityEngineGradientColorKeyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GradientAlphaKey), UnityEngineGradientAlphaKeyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Gradient), UnityEngineGradientWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FrustumPlanes), UnityEngineFrustumPlanesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Matrix4x4), UnityEngineMatrix4x4Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector2Int), UnityEngineVector2IntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector3Int), UnityEngineVector3IntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PlayerPrefsException), UnityEnginePlayerPrefsExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PlayerPrefs), UnityEnginePlayerPrefsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PropertyName), UnityEnginePropertyNameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Random), UnityEngineRandomWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ResourceRequest), UnityEngineResourceRequestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ResourcesAPI), UnityEngineResourcesAPIWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AsyncOperation), UnityEngineAsyncOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ExecuteAlways), UnityEngineExecuteAlwaysWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.DefaultExecutionOrder), UnityEngineDefaultExecutionOrderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Coroutine), UnityEngineCoroutineWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CustomYieldInstruction), UnityEngineCustomYieldInstructionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LayerMask), UnityEngineLayerMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RangeInt), UnityEngineRangeIntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ScriptableObject), UnityEngineScriptableObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.StackTraceUtility), UnityEngineStackTraceUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UnityException), UnityEngineUnityExceptionWrap.__Register);
        
        }
        
        static void wrapInit4(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.MissingComponentException), UnityEngineMissingComponentExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UnassignedReferenceException), UnityEngineUnassignedReferenceExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MissingReferenceException), UnityEngineMissingReferenceExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitForEndOfFrame), UnityEngineWaitForEndOfFrameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitForFixedUpdate), UnityEngineWaitForFixedUpdateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitForSecondsRealtime), UnityEngineWaitForSecondsRealtimeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitUntil), UnityEngineWaitUntilWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitWhile), UnityEngineWaitWhileWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.YieldInstruction), UnityEngineYieldInstructionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Security), UnityEngineSecurityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SerializeReference), UnityEngineSerializeReferenceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PreferBinarySerialization), UnityEnginePreferBinarySerializationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ComputeBuffer), UnityEngineComputeBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ComputeShader), UnityEngineComputeShaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Snapping), UnityEngineSnappingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.StaticBatchingUtility), UnityEngineStaticBatchingUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SystemInfo), UnityEngineSystemInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UnityEventQueueSystem), UnityEngineUnityEventQueueSystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Pose), UnityEnginePoseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.DrivenRectTransformTracker), UnityEngineDrivenRectTransformTrackerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RectTransform), UnityEngineRectTransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpriteRenderer), UnityEngineSpriteRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SecondarySpriteTexture), UnityEngineSecondarySpriteTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Sprite), UnityEngineSpriteWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Grid), UnityEngineGridWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GridLayout), UnityEngineGridLayoutWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Event), UnityEngineEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageConversion), UnityEngineImageConversionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Touch), UnityEngineTouchWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AccelerationEvent), UnityEngineAccelerationEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Gyroscope), UnityEngineGyroscopeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LocationInfo), UnityEngineLocationInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LocationService), UnityEngineLocationServiceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Compass), UnityEngineCompassWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Input), UnityEngineInputWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JsonUtility), UnityEngineJsonUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LocalizationAsset), UnityEngineLocalizationAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticlePhysicsExtensions), UnityEngineParticlePhysicsExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleCollisionEvent), UnityEngineParticleCollisionEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystemRenderer), UnityEngineParticleSystemRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystemForceField), UnityEngineParticleSystemForceFieldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WheelFrictionCurve), UnityEngineWheelFrictionCurveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SoftJointLimit), UnityEngineSoftJointLimitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SoftJointLimitSpring), UnityEngineSoftJointLimitSpringWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointDrive), UnityEngineJointDriveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointMotor), UnityEngineJointMotorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointSpring), UnityEngineJointSpringWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointLimits), UnityEngineJointLimitsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ControllerColliderHit), UnityEngineControllerColliderHitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Collision), UnityEngineCollisionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicMaterial), UnityEnginePhysicMaterialWrap.__Register);
        
        }
        
        static void wrapInit5(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.RaycastHit), UnityEngineRaycastHitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Rigidbody), UnityEngineRigidbodyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Collider), UnityEngineColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CharacterController), UnityEngineCharacterControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MeshCollider), UnityEngineMeshColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CapsuleCollider), UnityEngineCapsuleColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoxCollider), UnityEngineBoxColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SphereCollider), UnityEngineSphereColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ConstantForce), UnityEngineConstantForceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Joint), UnityEngineJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HingeJoint), UnityEngineHingeJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpringJoint), UnityEngineSpringJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FixedJoint), UnityEngineFixedJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CharacterJoint), UnityEngineCharacterJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ConfigurableJoint), UnityEngineConfigurableJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ContactPoint), UnityEngineContactPointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsScene), UnityEnginePhysicsSceneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsSceneExtensions), UnityEnginePhysicsSceneExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ArticulationDrive), UnityEngineArticulationDriveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ArticulationReducedSpace), UnityEngineArticulationReducedSpaceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ArticulationJacobian), UnityEngineArticulationJacobianWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ArticulationBody), UnityEngineArticulationBodyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Physics), UnityEnginePhysicsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RaycastCommand), UnityEngineRaycastCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpherecastCommand), UnityEngineSpherecastCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CapsulecastCommand), UnityEngineCapsulecastCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoxcastCommand), UnityEngineBoxcastCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsScene2D), UnityEnginePhysicsScene2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsSceneExtensions2D), UnityEnginePhysicsSceneExtensions2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Physics2D), UnityEnginePhysics2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ColliderDistance2D), UnityEngineColliderDistance2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ContactFilter2D), UnityEngineContactFilter2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Collision2D), UnityEngineCollision2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ContactPoint2D), UnityEngineContactPoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointAngleLimits2D), UnityEngineJointAngleLimits2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointTranslationLimits2D), UnityEngineJointTranslationLimits2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointMotor2D), UnityEngineJointMotor2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointSuspension2D), UnityEngineJointSuspension2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RaycastHit2D), UnityEngineRaycastHit2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsJobOptions2D), UnityEnginePhysicsJobOptions2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Rigidbody2D), UnityEngineRigidbody2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Collider2D), UnityEngineCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CircleCollider2D), UnityEngineCircleCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CapsuleCollider2D), UnityEngineCapsuleCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.EdgeCollider2D), UnityEngineEdgeCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoxCollider2D), UnityEngineBoxCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PolygonCollider2D), UnityEnginePolygonCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CompositeCollider2D), UnityEngineCompositeCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Joint2D), UnityEngineJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnchoredJoint2D), UnityEngineAnchoredJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpringJoint2D), UnityEngineSpringJoint2DWrap.__Register);
        
        }
        
        static void wrapInit6(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.DistanceJoint2D), UnityEngineDistanceJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FrictionJoint2D), UnityEngineFrictionJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HingeJoint2D), UnityEngineHingeJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RelativeJoint2D), UnityEngineRelativeJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SliderJoint2D), UnityEngineSliderJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TargetJoint2D), UnityEngineTargetJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FixedJoint2D), UnityEngineFixedJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WheelJoint2D), UnityEngineWheelJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Effector2D), UnityEngineEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AreaEffector2D), UnityEngineAreaEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BuoyancyEffector2D), UnityEngineBuoyancyEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PointEffector2D), UnityEnginePointEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PlatformEffector2D), UnityEnginePlatformEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SurfaceEffector2D), UnityEngineSurfaceEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsUpdateBehaviour2D), UnityEnginePhysicsUpdateBehaviour2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ConstantForce2D), UnityEngineConstantForce2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsMaterial2D), UnityEnginePhysicsMaterial2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ScreenCapture), UnityEngineScreenCaptureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpriteMask), UnityEngineSpriteMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.StreamingController), UnityEngineStreamingControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.IntegratedSubsystem), UnityEngineIntegratedSubsystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.IntegratedSubsystemDescriptor), UnityEngineIntegratedSubsystemDescriptorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Subsystem), UnityEngineSubsystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SubsystemDescriptor), UnityEngineSubsystemDescriptorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SubsystemManager), UnityEngineSubsystemManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PatchExtents), UnityEnginePatchExtentsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TextGenerationSettings), UnityEngineTextGenerationSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TextMesh), UnityEngineTextMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CharacterInfo), UnityEngineCharacterInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UICharInfo), UnityEngineUICharInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UILineInfo), UnityEngineUILineInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UIVertex), UnityEngineUIVertexWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Font), UnityEngineFontWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GridBrushBase), UnityEngineGridBrushBaseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CanvasGroup), UnityEngineCanvasGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RectTransformUtility), UnityEngineRectTransformUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Canvas), UnityEngineCanvasWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UISystemProfilerApi), UnityEngineUISystemProfilerApiWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RemoteSettings), UnityEngineRemoteSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RemoteConfigSettings), UnityEngineRemoteConfigSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WWWForm), UnityEngineWWWFormWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WheelHit), UnityEngineWheelHitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WheelCollider), UnityEngineWheelColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WindZone), UnityEngineWindZoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.AnimationTriggers), UnityEngineUIAnimationTriggersWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Button), UnityEngineUIButtonWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.CanvasUpdateRegistry), UnityEngineUICanvasUpdateRegistryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ColorBlock), UnityEngineUIColorBlockWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ClipperRegistry), UnityEngineUIClipperRegistryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Clipping), UnityEngineUIClippingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.DefaultControls), UnityEngineUIDefaultControlsWrap.__Register);
        
        }
        
        static void wrapInit7(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Dropdown), UnityEngineUIDropdownWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.FontData), UnityEngineUIFontDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.FontUpdateTracker), UnityEngineUIFontUpdateTrackerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Graphic), UnityEngineUIGraphicWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.GraphicRaycaster), UnityEngineUIGraphicRaycasterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.GraphicRegistry), UnityEngineUIGraphicRegistryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Image), UnityEngineUIImageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField), UnityEngineUIInputFieldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.AspectRatioFitter), UnityEngineUIAspectRatioFitterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.CanvasScaler), UnityEngineUICanvasScalerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ContentSizeFitter), UnityEngineUIContentSizeFitterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.GridLayoutGroup), UnityEngineUIGridLayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.HorizontalLayoutGroup), UnityEngineUIHorizontalLayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup), UnityEngineUIHorizontalOrVerticalLayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.LayoutElement), UnityEngineUILayoutElementWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.LayoutGroup), UnityEngineUILayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.LayoutRebuilder), UnityEngineUILayoutRebuilderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.LayoutUtility), UnityEngineUILayoutUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.VerticalLayoutGroup), UnityEngineUIVerticalLayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Mask), UnityEngineUIMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.MaskUtilities), UnityEngineUIMaskUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.MaskableGraphic), UnityEngineUIMaskableGraphicWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Navigation), UnityEngineUINavigationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.RawImage), UnityEngineUIRawImageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.RectMask2D), UnityEngineUIRectMask2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ScrollRect), UnityEngineUIScrollRectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Scrollbar), UnityEngineUIScrollbarWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Selectable), UnityEngineUISelectableWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Slider), UnityEngineUISliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.SpriteState), UnityEngineUISpriteStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.StencilMaterial), UnityEngineUIStencilMaterialWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Text), UnityEngineUITextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Toggle), UnityEngineUIToggleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ToggleGroup), UnityEngineUIToggleGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.VertexHelper), UnityEngineUIVertexHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.BaseMeshEffect), UnityEngineUIBaseMeshEffectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Outline), UnityEngineUIOutlineWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.PositionAsUV1), UnityEngineUIPositionAsUV1Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Shadow), UnityEngineUIShadowWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MatchRoomType), MatchRoomTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ModuleDefine), ModuleDefineWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(TeamType), TeamTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BattlePlayer), BattlePlayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FrameData), FrameDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(CSBattleFrame), CSBattleFrameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(SPBattleFrame), SPBattleFrameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BattleFrameConvert), BattleFrameConvertWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(SPBattleAllReady), SPBattleAllReadyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(CSBattleReady), CSBattleReadyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ICanCallClientBattleMsg), ICanCallClientBattleMsgWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PanelNames), PanelNamesWrap.__Register);
        
        }
        
        static void wrapInit8(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(ExampleGenConfig), ExampleGenConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LuaCallCs), LuaCallCsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.CSCallLua), TutorialCSCallLuaWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.ByFile), TutorialByFileWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.ByString), TutorialByStringWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.CustomLoader), TutorialCustomLoaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.Param1), TutorialParam1Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.Assets), WooAssetAssetsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsAsyncSupport), WooAssetAssetsAsyncSupportWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsInternal), WooAssetAssetsInternalWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.DefaultAssetStreamEncrypt), WooAssetDefaultAssetStreamEncryptWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.NoneAssetStreamEncrypt), WooAssetNoneAssetStreamEncryptWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetManifest), WooAssetAssetManifestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetOperation), WooAssetAssetOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsSetting), WooAssetAssetsSettingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.Asset), WooAssetAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetLoadArgs), WooAssetAssetLoadArgsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.ResourcesAsset), WooAssetResourcesAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.SceneAsset), WooAssetSceneAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.SceneAssetLoadArgs), WooAssetSceneAssetLoadArgsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.Bundle), WooAssetBundleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.BundleLoadArgs), WooAssetBundleLoadArgsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.WebRequestBundle), WooAssetWebRequestBundleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsVersion), WooAssetAssetsVersionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.LocalSetting), WooAssetLocalSettingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetExample), WooAssetAssetExampleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LAxis2D), LockStepMathLAxis2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LAxis3D), LockStepMathLAxis3DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LFloat), LockStepMathLFloatWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LMatrix33), LockStepMathLMatrix33Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LQuaternion), LockStepMathLQuaternionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LRect), LockStepMathLRectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LVector2), LockStepMathLVector2Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LVector2Int), LockStepMathLVector2IntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LVector3), LockStepMathLVector3Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LVector3Int), LockStepMathLVector3IntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LMath), LockStepMathLMathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.Random), LockStepMathRandomWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.Util.HashCodeExtension), LockStepMathUtilHashCodeExtensionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.CollisionHelper), LockStepLCollision2DCollisionHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.CollisionLayerConfig), LockStepLCollision2DCollisionLayerConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.Node), LockStepLCollision2DNodeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.QuadTree), LockStepLCollision2DQuadTreeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.Ray), LockStepLCollision2DRayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.RayHit), LockStepLCollision2DRayHitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.Bound), LockStepLCollision2DBoundWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.CircleShape), LockStepLCollision2DCircleShapeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.PolygonShape), LockStepLCollision2DPolygonShapeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.SectorShape), LockStepLCollision2DSectorShapeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.Shape), LockStepLCollision2DShapeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.LogicUnit), LockStepLCollision2DLogicUnitWrap.__Register);
        
        }
        
        static void wrapInit9(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.LogicWorld), LockStepLCollision2DLogicWorldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.MobaAssetsSetting), EasyMobaMobaAssetsSettingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.MobaAssetsUpdate), EasyMobaMobaAssetsUpdateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.MobaGame), EasyMobaMobaGameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.MobaModules), EasyMobaMobaModulesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.TcpClient), EasyMobaTcpClientWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.MobaPerfs), EasyMobaMobaPerfsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.MVCMap), EasyMobaMVCMapWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.NormalUIAsset), EasyMobaNormalUIAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.UpdatePanelView), EasyMobaUpdatePanelViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.UpdateUIAsset), EasyMobaUpdateUIAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.AttributeCalc), EasyMobaGameLogicAttributeCalcWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.BattleAttributeCollection), EasyMobaGameLogicBattleAttributeCollectionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Battle), EasyMobaGameLogicBattleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.BattleFactory), EasyMobaGameLogicBattleFactoryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Buff), EasyMobaGameLogicBuffWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.BuffCollection), EasyMobaGameLogicBuffCollectionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.BuffData), EasyMobaGameLogicBuffDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.BattleLogic), EasyMobaGameLogicBattleLogicWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.FrameCollection), EasyMobaGameLogicFrameCollectionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.MobaLogicWord), EasyMobaGameLogicMobaLogicWordWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.MobaUnit), EasyMobaGameLogicMobaUnitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.PlayerUnit), EasyMobaGameLogicPlayerUnitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.WallUnit), EasyMobaGameLogicWallUnitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.MapInitData), EasyMobaGameLogicMapInitDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.SkillCollection), EasyMobaGameLogicSkillCollectionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.SkillConfig), EasyMobaGameLogicSkillConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.SkillData), EasyMobaGameLogicSkillDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.SkillDirector), EasyMobaGameLogicSkillDirectorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.SkillEffectAttribute), EasyMobaGameLogicSkillEffectAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.SkillEffectData), EasyMobaGameLogicSkillEffectDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.TestSkillEffectData), EasyMobaGameLogicTestSkillEffectDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.BuffEffectData), EasyMobaGameLogicBuffEffectDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.SkillEffectExecutor), EasyMobaGameLogicSkillEffectExecutorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.BattleInput), EasyMobaGameLogicMonoBattleInputWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.CircleShapeComponent), EasyMobaGameLogicMonoCircleShapeComponentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.PlayerBornPlace), EasyMobaGameLogicMonoPlayerBornPlaceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.PolygonShapeComponent), EasyMobaGameLogicMonoPolygonShapeComponentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.MapInitCollection), EasyMobaGameLogicMonoMapInitCollectionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.BattleModePlayer), EasyMobaGameLogicMonoBattleModePlayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.LocalModePlayer), EasyMobaGameLogicMonoLocalModePlayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.NormalModePlayer), EasyMobaGameLogicMonoNormalModePlayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.RecordModePlayer), EasyMobaGameLogicMonoRecordModePlayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.MonoBattle), EasyMobaGameLogicMonoMonoBattleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.BattleView), EasyMobaGameLogicMonoBattleViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.ViewUnit), EasyMobaGameLogicMonoViewUnitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.Mono.PlayerUnitView), EasyMobaGameLogicMonoPlayerUnitViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Game), IFrameworkGameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Launcher), IFrameworkLauncherWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UnityEx), IFrameworkUnityExWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.Empty4Raycast), IFrameworkUIEmpty4RaycastWrap.__Register);
        
        }
        
        static void wrapInit10(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(IFramework.UI.MixedGroups), IFrameworkUIMixedGroupsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.UIItem), IFrameworkUIUIItemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.UIModule), IFrameworkUIUIModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.LoadItemAsyncOperation), IFrameworkUILoadItemAsyncOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.LoadPanelAsyncOperation), IFrameworkUILoadPanelAsyncOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.ShowPanelAsyncOperation), IFrameworkUIShowPanelAsyncOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.UIAsset), IFrameworkUIUIAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.UIAsyncOperation), IFrameworkUIUIAsyncOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.PanelPathCollect), IFrameworkUIPanelPathCollectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.ScriptMark), IFrameworkUIScriptMarkWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.UIEx), IFrameworkUIUIExWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.UIPanel), IFrameworkUIUIPanelWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.GuideMask), IFrameworkUIGuideMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.LoopScrollRect), IFrameworkUILoopScrollRectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.RedPointTree), IFrameworkUIRedPointTreeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.UGUIEventListener), IFrameworkUIUGUIEventListenerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.AtlasExample), IFrameworkUIAtlasExampleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.LoopExample), IFrameworkUILoopExampleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.SuperScrollView.LoopListView), IFrameworkUISuperScrollViewLoopListViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.SuperScrollView.LoopListViewItem), IFrameworkUISuperScrollViewLoopListViewItemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.MVC.MvcGroups), IFrameworkUIMVCMvcGroupsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.MVC.UIView), IFrameworkUIMVCUIViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Hotfix.Lua.LuaArgs), IFrameworkHotfixLuaLuaArgsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Hotfix.Lua.LuaEX), IFrameworkHotfixLuaLuaEXWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Hotfix.Lua.XLuaModule), IFrameworkHotfixLuaXLuaModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Hotfix.Lua.XluaMain), IFrameworkHotfixLuaXluaMainWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Hotfix.Lua.LuaGroups), IFrameworkHotfixLuaLuaGroupsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Hotfix.Lua.AssetsLoader), IFrameworkHotfixLuaAssetsLoaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Hotfix.Lua.LuaGame), IFrameworkHotfixLuaLuaGameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Singleton.MonoSingletonPath), IFrameworkSingletonMonoSingletonPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.CSCallLua.DClass), TutorialCSCallLuaDClassWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.Assets.AssetsGroupOperation), WooAssetAssetsAssetsGroupOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.Assets.InstantiateObjectOperation), WooAssetAssetsInstantiateObjectOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsInternal.AssetEncryptStream), WooAssetAssetsInternalAssetEncryptStreamWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsInternal.CopyBundleOperation), WooAssetAssetsInternalCopyBundleOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsInternal.Downloader), WooAssetAssetsInternalDownloaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsInternal.LoadManifestOperation), WooAssetAssetsInternalLoadManifestOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsInternal.CheckBundleVersionOperation), WooAssetAssetsInternalCheckBundleVersionOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsInternal.DownLoadBundleOperation), WooAssetAssetsInternalDownLoadBundleOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetManifest.AssetData), WooAssetAssetManifestAssetDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(WooAsset.AssetsVersion.VersionData), WooAssetAssetsVersionVersionDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LVector2Int.Mathf), LockStepMathLVector2IntMathfWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LVector3Int.Mathf), LockStepMathLVector3IntMathfWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.Math.LMath.LutAtan2Helper), LockStepMathLMathLutAtan2HelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.CollisionLayerConfig.LayerData), LockStepLCollision2DCollisionLayerConfigLayerDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LockStep.LCollision2D.LogicUnit.CollisionPart), LockStepLCollision2DLogicUnitCollisionPartWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.MapInitData.PolygonData), EasyMobaGameLogicMapInitDataPolygonDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EasyMoba.GameLogic.MapInitData.CircleData), EasyMobaGameLogicMapInitDataCircleDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.UIModule.ItemPool), IFrameworkUIUIModuleItemPoolWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.UIModule.ItemsPool), IFrameworkUIUIModuleItemsPoolWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.PanelPathCollect.Data), IFrameworkUIPanelPathCollectDataWrap.__Register);
        
        }
        
        static void wrapInit11(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(IFramework.UI.SuperScrollView.LoopListView.PrefabConfData), IFrameworkUISuperScrollViewLoopListViewPrefabConfDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UI.SuperScrollView.LoopListView.InitParam), IFrameworkUISuperScrollViewLoopListViewInitParamWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Hotfix.Lua.LuaEX.LuaTaskAwaiter), IFrameworkHotfixLuaLuaEXLuaTaskAwaiterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Hotfix.Lua.LuaGame.UnityModules), IFrameworkHotfixLuaLuaGameUnityModulesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.ModulePriority), IFrameworkModulePriorityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Ex), IFrameworkExWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.ArrayPoolArg), IFrameworkArrayPoolArgWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Unit), IFrameworkUnitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Module), IFrameworkModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.UpdateModule), IFrameworkUpdateModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.OnEnvironmentInitAttribute), IFrameworkOnEnvironmentInitAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Framework), IFrameworkFrameworkWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Log), IFrameworkLogWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Singleton.SingletonCollection), IFrameworkSingletonSingletonCollectionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Queue.FastPriorityQueueNode), IFrameworkQueueFastPriorityQueueNodeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Queue.StablePriorityQueueNode), IFrameworkQueueStablePriorityQueueNodeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Packets.Packet), IFrameworkPacketsPacketWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Packets.PacketReader), IFrameworkPacketsPacketReaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.Crypt), IFrameworkNetCryptWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.SocketToken), IFrameworkNetSocketTokenWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.SegmentOffset), IFrameworkNetSegmentOffsetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.SegmentToken), IFrameworkNetSegmentTokenWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.NetTool), IFrameworkNetNetToolWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.NetConnectionToken), IFrameworkNetNetConnectionTokenWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.LockWait), IFrameworkNetLockWaitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.LockParam), IFrameworkNetLockParamWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.WebSocket.SslHelper), IFrameworkNetWebSocketSslHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.WebSocket.WSConnectionItem), IFrameworkNetWebSocketWSConnectionItemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.KCP.BufferQueue), IFrameworkNetKCPBufferQueueWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.KCP.Kcp), IFrameworkNetKCPKcpWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.KCP.KcpClient), IFrameworkNetKCPKcpClientWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.KCP.KcpSocket), IFrameworkNetKCPKcpSocketWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.Http.HttpGet), IFrameworkNetHttpHttpGetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.Http.HttpGzip), IFrameworkNetHttpHttpGzipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.Http.HttpHeader), IFrameworkNetHttpHttpHeaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.Http.HttpPost), IFrameworkNetHttpHttpPostWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.Http.HttpPayload), IFrameworkNetHttpHttpPayloadWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Net.Http.HttpUri), IFrameworkNetHttpHttpUriWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.StringFormatter), IFrameworkSerializationStringFormatterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.BoolStringConverter), IFrameworkSerializationBoolStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.ByteStringConverter), IFrameworkSerializationByteStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.CharStringConverter), IFrameworkSerializationCharStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DateTimeStringConverter), IFrameworkSerializationDateTimeStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DecimalStringConverter), IFrameworkSerializationDecimalStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DoubleStringConverter), IFrameworkSerializationDoubleStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.FloatStringConverter), IFrameworkSerializationFloatStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.IntStringConverter), IFrameworkSerializationIntStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.LongStringConverter), IFrameworkSerializationLongStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.SByteStringConverter), IFrameworkSerializationSByteStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.ShortStringConverter), IFrameworkSerializationShortStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.StringConvert), IFrameworkSerializationStringConvertWrap.__Register);
        
        }
        
        static void wrapInit12(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.StringConverter), IFrameworkSerializationStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.StringStringConverter), IFrameworkSerializationStringStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.TimeSpanStringConverter), IFrameworkSerializationTimeSpanStringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.UInt16StringConverter), IFrameworkSerializationUInt16StringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.UInt32StringConverter), IFrameworkSerializationUInt32StringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.UInt64StringConverter), IFrameworkSerializationUInt64StringConverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.Xml), IFrameworkSerializationXmlWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DataTable.DataColumn), IFrameworkSerializationDataTableDataColumnWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DataTable.DataReadColumnIndexAttribute), IFrameworkSerializationDataTableDataReadColumnIndexAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DataTable.DataColumnNameAttribute), IFrameworkSerializationDataTableDataColumnNameAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DataTable.DataIgnoreAttribute), IFrameworkSerializationDataTableDataIgnoreAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DataTable.DataTableTool), IFrameworkSerializationDataTableDataTableToolWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DataTable.DataExplainer), IFrameworkSerializationDataTableDataExplainerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Serialization.DataTable.DataRow), IFrameworkSerializationDataTableDataRowWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Timer.TimerEntity), IFrameworkTimerTimerEntityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Timer.TimerModule), IFrameworkTimerTimerModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Recorder.OperationRecorderEx), IFrameworkRecorderOperationRecorderExWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Recorder.OperationRecorderModule), IFrameworkRecorderOperationRecorderModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Recorder.ActionGroupState), IFrameworkRecorderActionGroupStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Recorder.ActionState), IFrameworkRecorderActionStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Recorder.BaseState), IFrameworkRecorderBaseStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Recorder.CommandGroupState), IFrameworkRecorderCommandGroupStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Recorder.CommandState), IFrameworkRecorderCommandStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Message.MessageAwaiter), IFrameworkMessageMessageAwaiterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Message.MessageModule), IFrameworkMessageMessageModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Message.StringMessageModule), IFrameworkMessageStringMessageModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Message.MessageUrgency), IFrameworkMessageMessageUrgencyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Inject.InjectModule), IFrameworkInjectInjectModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Inject.InjectAttribute), IFrameworkInjectInjectAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.CoroutineAwaiter), IFrameworkCoroutineCoroutineAwaiterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.CoroutineModuleEx), IFrameworkCoroutineCoroutineModuleExWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.YieldInstruction), IFrameworkCoroutineYieldInstructionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.CoroutineModule), IFrameworkCoroutineCoroutineModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitForDays), IFrameworkCoroutineWaitForDaysWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitForFrame), IFrameworkCoroutineWaitForFrameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitForFrames), IFrameworkCoroutineWaitForFramesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitForHours), IFrameworkCoroutineWaitForHoursWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitForMilliseconds), IFrameworkCoroutineWaitForMillisecondsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitForMinutes), IFrameworkCoroutineWaitForMinutesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitForSeconds), IFrameworkCoroutineWaitForSecondsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitForTicks), IFrameworkCoroutineWaitForTicksWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitForTimeSpan), IFrameworkCoroutineWaitForTimeSpanWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitUtil), IFrameworkCoroutineWaitUtilWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IFramework.Coroutine.WaitWhile), IFrameworkCoroutineWaitWhileWrap.__Register);
        
        
        
        }
        
        static void Init(LuaEnv luaenv, ObjectTranslator translator)
        {
            
            wrapInit0(luaenv, translator);
            
            wrapInit1(luaenv, translator);
            
            wrapInit2(luaenv, translator);
            
            wrapInit3(luaenv, translator);
            
            wrapInit4(luaenv, translator);
            
            wrapInit5(luaenv, translator);
            
            wrapInit6(luaenv, translator);
            
            wrapInit7(luaenv, translator);
            
            wrapInit8(luaenv, translator);
            
            wrapInit9(luaenv, translator);
            
            wrapInit10(luaenv, translator);
            
            wrapInit11(luaenv, translator);
            
            wrapInit12(luaenv, translator);
            
            
            translator.AddInterfaceBridgeCreator(typeof(System.Collections.IEnumerator), SystemCollectionsIEnumeratorBridge.__Create);
            
            translator.AddInterfaceBridgeCreator(typeof(XLuaTest.IExchanger), XLuaTestIExchangerBridge.__Create);
            
            translator.AddInterfaceBridgeCreator(typeof(IFramework.Hotfix.Lua.ILuaTask), IFrameworkHotfixLuaILuaTaskBridge.__Create);
            
            translator.AddInterfaceBridgeCreator(typeof(Tutorial.CSCallLua.ItfD), TutorialCSCallLuaItfDBridge.__Create);
            
            translator.AddInterfaceBridgeCreator(typeof(XLuaTest.InvokeLua.ICalc), XLuaTestInvokeLuaICalcBridge.__Create);
            
        }
        
	    static XLua_Gen_Initer_Register__()
        {
		    XLua.LuaEnv.AddIniter(Init);
		}
		
		
	}
	
}
namespace XLua
{
	public partial class ObjectTranslator
	{
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ s_gen_reg_dumb_obj = new XLua.CSObjectWrap.XLua_Gen_Initer_Register__();
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ gen_reg_dumb_obj {get{return s_gen_reg_dumb_obj;}}
	}
	
	internal partial class InternalGlobals
    {
	    
		delegate UnityEngine.PhysicsScene __GEN_DELEGATE0( UnityEngine.SceneManagement.Scene scene);
		
		delegate UnityEngine.PhysicsScene2D __GEN_DELEGATE1( UnityEngine.SceneManagement.Scene scene);
		
		delegate int __GEN_DELEGATE2( int val);
		
		delegate int __GEN_DELEGATE3( byte val, ref  int idx);
		
		delegate int __GEN_DELEGATE4( short val, ref  int idx);
		
		delegate int __GEN_DELEGATE5( int val, ref  int idx);
		
		delegate int __GEN_DELEGATE6( long val, ref  int idx);
		
		delegate int __GEN_DELEGATE7( sbyte val, ref  int idx);
		
		delegate int __GEN_DELEGATE8( ushort val, ref  int idx);
		
		delegate int __GEN_DELEGATE9( uint val, ref  int idx);
		
		delegate int __GEN_DELEGATE10( ulong val, ref  int idx);
		
		delegate int __GEN_DELEGATE11( bool val, ref  int idx);
		
		delegate int __GEN_DELEGATE12( string val, ref  int idx);
		
		delegate string __GEN_DELEGATE13( string self);
		
		delegate string __GEN_DELEGATE14( string self);
		
		delegate IFramework.IAwaiter __GEN_DELEGATE15( IFramework.Hotfix.Lua.ILuaTask target);
		
		delegate bool __GEN_DELEGATE16( string path);
		
		delegate bool __GEN_DELEGATE17( string path);
		
		delegate bool __GEN_DELEGATE18( string path);
		
		delegate string __GEN_DELEGATE19( string path,  string toCombinePath);
		
		delegate string __GEN_DELEGATE20( string path,  string[] paths);
		
		delegate string __GEN_DELEGATE21( string path);
		
		delegate void __GEN_DELEGATE22( string path);
		
		delegate System.Collections.Generic.IEnumerable<System.Type> __GEN_DELEGATE23( System.Type self);
		
		delegate System.Collections.Generic.IEnumerable<System.Type> __GEN_DELEGATE24( System.Type self);
		
		delegate bool __GEN_DELEGATE25( System.Type self,  System.Type Interface);
		
		delegate bool __GEN_DELEGATE26( System.Type self,  System.Type genericType);
		
		delegate System.Collections.Generic.IList<System.Type> __GEN_DELEGATE27( System.Type t);
		
		delegate System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo> __GEN_DELEGATE28( System.Type self,  System.Reflection.Assembly assembly);
		
		delegate string __GEN_DELEGATE29( string self);
		
		delegate string __GEN_DELEGATE30( string self,  string toPrefix);
		
		delegate string __GEN_DELEGATE31( string self,  string toAppend);
		
		delegate string __GEN_DELEGATE32( string self,  string[] toAppend);
		
		delegate void __GEN_DELEGATE33( System.Action action,  IFramework.IEnvironment env);
		
		delegate void __GEN_DELEGATE34( System.Action action,  IFramework.IEnvironment env);
		
		delegate void __GEN_DELEGATE35( System.Action action,  IFramework.IEnvironment env);
		
		delegate void __GEN_DELEGATE36( System.Action action,  IFramework.IEnvironment env);
		
		delegate void __GEN_DELEGATE37( System.Action action,  IFramework.EnvironmentType envType);
		
		delegate void __GEN_DELEGATE38( System.Action action,  IFramework.EnvironmentType envType);
		
		delegate void __GEN_DELEGATE39( System.Action action,  IFramework.EnvironmentType envType);
		
		delegate void __GEN_DELEGATE40( System.Action action,  IFramework.EnvironmentType envType);
		
		delegate string __GEN_DELEGATE41( string value,  System.Text.Encoding encoding);
		
		delegate string __GEN_DELEGATE42( string value,  System.Text.Encoding encoding);
		
		delegate IFramework.Recorder.CommandState __GEN_DELEGATE43( IFramework.Recorder.IOperationRecorderModule t);
		
		delegate IFramework.Recorder.ActionState __GEN_DELEGATE44( IFramework.Recorder.IOperationRecorderModule t);
		
		delegate IFramework.Recorder.CommandGroupState __GEN_DELEGATE45( IFramework.Recorder.IOperationRecorderModule t);
		
		delegate IFramework.Recorder.ActionGroupState __GEN_DELEGATE46( IFramework.Recorder.IOperationRecorderModule t);
		
		delegate IFramework.Coroutine.ICoroutine __GEN_DELEGATE47( IFramework.Coroutine.ICoroutine self,  System.Action action);
		
	    static InternalGlobals()
		{
		    extensionMethodMap = new Dictionary<Type, IEnumerable<MethodInfo>>()
			{
			    
				{typeof(UnityEngine.SceneManagement.Scene), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE0(UnityEngine.PhysicsSceneExtensions.GetPhysicsScene)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE1(UnityEngine.PhysicsSceneExtensions2D.GetPhysicsScene2D)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(int), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE2(LockStep.Math.LMath.Abs)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE5(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(byte), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE3(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(short), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE4(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(long), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE6(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(sbyte), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE7(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(ushort), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE8(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(uint), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE9(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(ulong), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE10(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(bool), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE11(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(string), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE12(LockStep.Math.Util.HashCodeExtension.GetHash)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE13(IFramework.UnityEx.ToAbsPath)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE14(IFramework.UnityEx.ToAssetsPath)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE16(IFramework.Ex.ExistFile)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE17(IFramework.Ex.IsDirectory)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE18(IFramework.Ex.RemoveEmptyDirectory)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE19(IFramework.Ex.CombinePath)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE20(IFramework.Ex.CombinePath)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE21(IFramework.Ex.ToRegularPath)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE22(IFramework.Ex.MakeDirectoryExist)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE29(IFramework.Ex.ToUnixLineEndings)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE30(IFramework.Ex.AppendHead)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE31(IFramework.Ex.Append)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE32(IFramework.Ex.Append)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE41(IFramework.Net.Crypt.ToSha1Base64)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE42(IFramework.Net.Crypt.ToMd5)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(IFramework.Hotfix.Lua.ILuaTask), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE15(IFramework.Hotfix.Lua.LuaEX.GetAwaiter)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(System.Type), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE23(IFramework.Ex.GetSubTypesInAssembly)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE24(IFramework.Ex.GetSubTypesInAssemblys)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE25(IFramework.Ex.IsExtendInterface)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE26(IFramework.Ex.IsSubclassOfGeneric)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE27(IFramework.Ex.GetTypeTree)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE28(IFramework.Ex.GetExtensionMethods)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(System.Action), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE33(IFramework.Framework.BindEnvUpdate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE34(IFramework.Framework.UnBindEnvUpdate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE35(IFramework.Framework.BindEnvDispose)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE36(IFramework.Framework.UnBindEnvDispose)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE37(IFramework.Framework.BindEnvUpdate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE38(IFramework.Framework.UnBindEnvUpdate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE39(IFramework.Framework.BindEnvDispose)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE40(IFramework.Framework.UnBindEnvDispose)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(IFramework.Recorder.IOperationRecorderModule), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE43(IFramework.Recorder.OperationRecorderEx.AllocateCommand)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE44(IFramework.Recorder.OperationRecorderEx.AllocateAction)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE45(IFramework.Recorder.OperationRecorderEx.AllocateCommandGroup)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE46(IFramework.Recorder.OperationRecorderEx.AllocateActionGroup)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(IFramework.Coroutine.ICoroutine), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE47(IFramework.Coroutine.CoroutineModuleEx.OnCompelete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
			};
			
			genTryArrayGetPtr = StaticLuaCallbacks.__tryArrayGet;
            genTryArraySetPtr = StaticLuaCallbacks.__tryArraySet;
		}
	}
}
