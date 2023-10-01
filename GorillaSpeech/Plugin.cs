using BepInEx;
using Bepinject;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace GorillaSpeech
{
    [BepInDependency("dev.auros.bepinex.bepinject")]
    [BepInPlugin("com.bjrsinge.gorillatag.gorillaspeech", "GorillaSpeech", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static GameObject asset;
        public bool init;

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }

        void Awake()
        {
            Zenjector.Install<MainInstaller>().OnProject();
        }

        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        public void OnEnable()
        {
            if (init) { asset.SetActive(true); }
        }

        void OnDisable()
        {
            if (init) { asset.SetActive(false); }
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            var bundle = LoadAssetBundle("GorillaSpeech.Resources.speechballoonbundle");
            asset = Instantiate(bundle.LoadAsset<GameObject>("speechballoonthing"));
            init = true;
            asset.transform.localPosition = new Vector3(-0.4f, 0.4f, -0.2f);
            asset.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
            asset.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            asset.transform.SetParent(GorillaLocomotion.Player.Instance.headCollider.transform, false);
            asset.GetComponentInChildren<Text>().transform.localPosition = new Vector3(-0.013f, 0f, 0f);
            asset.GetComponentInChildren<Text>().transform.localEulerAngles = new Vector3(0f, 270f, 0f);
            asset.GetComponentInChildren<Text>().font = GorillaTagger.Instance.offlineVRRig.playerText.font;
            asset.GetComponentInChildren<Text>().text = "Change this text with ComputerInterface!";
            asset.GetComponentInChildren<Text>().color = Color.white;
        }
    }
}
