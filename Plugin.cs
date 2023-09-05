using System.Linq;
using BepInEx;
using HarmonyLib;

namespace CutsceneSkip;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInProcess("Bomb Rush Cyberfunk.exe")]
public class Plugin : BaseUnityPlugin {
    public static Harmony Harmony = null!;

    private void Awake() {
        // Setup Harmony
        Harmony = new Harmony("CutsceneSkip.Harmony");

        var patches = typeof(Plugin).Assembly.GetTypes()
            .Where(m => m.GetCustomAttributes(typeof(HarmonyPatch), false).Length > 0)
            .ToArray();

        foreach (var patch in patches) {
            Harmony.PatchAll(patch);
        }
    }
}
