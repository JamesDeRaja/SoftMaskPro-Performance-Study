using UnityEngine;

public class PerfLabController : MonoBehaviour
{
    public enum Scenario { A_Baseline_NoMask, B_SingleMask, C_StackedMasks_FillRate, D_ForcedRedraw_Rebuild }
    public Scenario activeScenario = Scenario.A_Baseline_NoMask;

    [Header("Scenario Roots (enable one at a time)")]
    public GameObject scenarioA;
    public GameObject scenarioB;
    public GameObject scenarioC;
    public GameObject scenarioD;

    [Header("Forced Redraw Driver (Scenario D)")]
    public RedrawStressDriver redrawDriver;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;
    }

    void Start() => ApplyScenario(activeScenario);

    void Update()
    {
        // F1-F4 switch
        if (Input.GetKeyDown(KeyCode.F1)) ApplyScenario(Scenario.A_Baseline_NoMask);
        if (Input.GetKeyDown(KeyCode.F2)) ApplyScenario(Scenario.B_SingleMask);
        if (Input.GetKeyDown(KeyCode.F3)) ApplyScenario(Scenario.C_StackedMasks_FillRate);
        if (Input.GetKeyDown(KeyCode.F4)) ApplyScenario(Scenario.D_ForcedRedraw_Rebuild);
    }

    void ApplyScenario(Scenario s)
    {
        activeScenario = s;

        scenarioA.SetActive(s == Scenario.A_Baseline_NoMask);
        scenarioB.SetActive(s == Scenario.B_SingleMask);
        scenarioC.SetActive(s == Scenario.C_StackedMasks_FillRate);
        scenarioD.SetActive(s == Scenario.D_ForcedRedraw_Rebuild);

        if (redrawDriver != null)
            redrawDriver.enabled = (s == Scenario.D_ForcedRedraw_Rebuild);
    }
}