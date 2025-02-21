using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// This script requires Movement and ManaSystem components to function.
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(ManaSystem))]
public class WukongAbilityW : MonoBehaviour
{
    [Header("Ability Values")]
    public KeyCode abilityKey = KeyCode.W; // The key to activate the ability.
    public float cooldown = 18f; // Time in seconds before the ability can be used again.
    public float manaCost = 40f; // The mana cost to use the ability.
    public float invisibilityDuration = 1.5f; // How long the invisibility effect lasts.

    public GameObject clonePrefab; // Prefab for the clone that will be spawned.

    [Header("Material")]
    public Material originalMaterial; // The original material of the player.
    public Material transparentMaterial; // The material used to make the player invisible.

    [Header("UI Elements")]
    public Image abilityImageMain; // Main UI element for the ability.
    public Image abilityImageGreyed; // UI element shown when the ability is on cooldown.
    public Text abilityText; // Text displaying the cooldown.
    public Image screenDarkeningOverlay; // Overlay to darken the screen when ability is active.

    private ManaSystem manaSystem; // Reference to the ManaSystem component.
    private bool isCooldown = false; // Tracks whether the ability is on cooldown.
    private float currentCooldown; // The current cooldown time remaining.
    private Renderer[] renderers; // Array of renderers for changing materials.

    void Awake()
    {
        manaSystem = GetComponent<ManaSystem>();
        CacheRenderers();
        InitializeUI();
    }

    void Update()
    {
        HandleInput();
        UpdateCooldown();
        UpdateUI();
    }

    // Caches renderers in child objects for efficient material changes.
    private void CacheRenderers()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    // Checks for player input to activate the ability.
    private void HandleInput()
    {
        if (Input.GetKeyDown(abilityKey) && !isCooldown && manaSystem.CanAffordAbility(manaCost))
        {
            ActivateAbility();
        }
    }

    // Activates the ability, managing mana cost, cooldown, and effects.
    private void ActivateAbility()
    {
        manaSystem.UseAbility(manaCost);
        StartCooldown();
        StartCoroutine(BecomeInvisible(invisibilityDuration));
        SpawnClone();
        PushPlayerForward();
    }

    // Simulates a dash or leap by moving the player forward.
    private void PushPlayerForward()
    {
        float pushDistance = 1.0f;
        transform.position += transform.forward * pushDistance;
    }

    // Makes the player invisible for a specified duration.
    private IEnumerator BecomeInvisible(float duration)
    {
        screenDarkeningOverlay.enabled = true;
        SetMaterials(transparentMaterial);
        yield return new WaitForSeconds(duration);
        SetMaterials(originalMaterial);
        screenDarkeningOverlay.enabled = false;
    }

    // Changes the material of all child renderers to simulate invisibility.
    private void SetMaterials(Material material)
    {
        foreach (var renderer in renderers)
        {
            renderer.material = material;
        }
    }

    // Spawns a clone at the player's current position.
    private void SpawnClone()
    {
        if (clonePrefab)
        {
            Instantiate(clonePrefab, transform.position, transform.rotation);
        }
    }

    // Initiates the cooldown period, preventing immediate reuse of the ability.
    private void StartCooldown()
    {
        isCooldown = true;
        currentCooldown = cooldown;
        UpdateUI();
    }

    // Manages the cooldown timer and updates the UI accordingly.
    private void UpdateCooldown()
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;
            isCooldown = currentCooldown > 0;
            UpdateUI();
        }
    }

    // Updates the UI elements based on the ability's availability and cooldown.
    private void UpdateUI()
    {
        if (abilityImageGreyed)
        {
            abilityImageGreyed.color = isCooldown ? Color.grey : Color.white;
            abilityImageGreyed.fillAmount = isCooldown ? currentCooldown / cooldown : 0;
            abilityImageMain.color = manaSystem.CanAffordAbility(manaCost) ? Color.white : Color.red;
        }
        abilityText.text = isCooldown ? Mathf.Ceil(currentCooldown).ToString() : "";
    }

    // Initializes UI elements to their default state.
    private void InitializeUI()
    {
        if (abilityImageGreyed) abilityImageGreyed.color = Color.white;
        abilityText.text = "";
    }
}
