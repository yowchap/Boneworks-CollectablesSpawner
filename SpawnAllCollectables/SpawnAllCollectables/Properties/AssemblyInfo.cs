using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(YOWC.SpawnAllCollectables.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(YOWC.SpawnAllCollectables.BuildInfo.Company)]
[assembly: AssemblyProduct(YOWC.SpawnAllCollectables.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + YOWC.SpawnAllCollectables.BuildInfo.Author)]
[assembly: AssemblyTrademark(YOWC.SpawnAllCollectables.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(YOWC.SpawnAllCollectables.BuildInfo.Version)]
[assembly: AssemblyFileVersion(YOWC.SpawnAllCollectables.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(YOWC.SpawnAllCollectables.Main), YOWC.SpawnAllCollectables.BuildInfo.Name, YOWC.SpawnAllCollectables.BuildInfo.Version, YOWC.SpawnAllCollectables.BuildInfo.Author, YOWC.SpawnAllCollectables.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONEWORKS")]