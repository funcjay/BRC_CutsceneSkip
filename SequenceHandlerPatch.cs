using HarmonyLib;
using Reptile;

namespace CutsceneSkip;

[HarmonyPatch(typeof(SequenceHandler))]
public class SequenceHandlerPatch {
    [HarmonyPostfix]
    [HarmonyPatch("StartEnteringSequence")]
    public static void StartEnteringSequence(SequenceHandler __instance) {
        // Force this var to SequenceHandler.SkipState.IDLE (1)
        Traverse.Create(__instance).Field<int>("skipTextActiveState").Value = 1;
    }
}
