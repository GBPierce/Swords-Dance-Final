using UnityEngine;

public class PlayerAttackAnimator : MonoBehaviour {

    [Header("Sword anchor")]
    public GameObject weaponAnchor;
    
    [Header("Sword swing proerties")]
    [Range(-360, 360)] public int swingAngle;
    [Range(0, 100)] public int swingFactor;
    [Range(0, 100)] public int pullFactor;

    private bool shouldAttack = false;

    private void Update() {
        // If no attack call is comming in & sword is pulled all the way in, no further action has to be taken
        if (!shouldAttack && weaponAnchor.transform.localRotation == Quaternion.identity) { return; }

        // If the sword reached the it's max. outter angle, draw it back in
        if (weaponAnchor.transform.localRotation == Quaternion.Euler(new Vector3(0, 0, swingAngle))) { shouldAttack = false; }

        /* Sword swing */
        if (shouldAttack) // Swing the sword outwards
            weaponAnchor.transform.localRotation = Quaternion.Lerp(weaponAnchor.transform.localRotation, Quaternion.Euler(new Vector3(0, 0, swingAngle)), swingFactor * Time.deltaTime);
        else  // Draw the sword back int
            weaponAnchor.transform.localRotation = Quaternion.Lerp(weaponAnchor.transform.localRotation, Quaternion.Euler(new Vector3(0, 0, 0)), pullFactor * Time.deltaTime);   
    }

    // Start attack animation
    public void PlayAttackAnimation() {
        shouldAttack = true;
    }
}
