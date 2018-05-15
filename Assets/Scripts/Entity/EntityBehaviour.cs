using Combat;
using UnityEngine;
namespace Entity{
//Class used to wrap Entity Data up together
public abstract class EntityBehaviour : MonoBehaviour {
    public virtual void Start () {
        currentHealth = MaxHealth;
        currentMana = MaxMana;
        _alive = true;
        rgb2d = GetComponent<Rigidbody2D>();
	}
    /// <summary>Used by attacker when entity is attacked, to calculate Damage taken by this entity </summary>
    /// <param name="AInfo"> The attacking data </param>
    public void RecieveAttack(Combat.AttackStats AInfo){
        Debug.Log(this.tag+" was attacked!");
        if(AInfo.Damage != 0){
            TakeDamage(AInfo.Damage);
        }
        if(AInfo.ForceToApply != 0){
            this.rgb2d.AddForce((AInfo.transform.position-this.transform.position).normalized*AInfo.ForceToApply*-1);
        }
    }
    public void TakeDamage(int Damage){
        //TODO: Implement Healthbar animation / update
        currentHealth -= Damage;
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
          Debug.Log(Damage+" was taken. Health is now: "+this.currentHealth);
        if(this.currentHealth <= 0){
            _alive = false;
            KillEntity();
        }
    }
    public virtual void CreateRangedAttack(Vector2 target){
        var newAttack = Instantiate(rangedAttack,(Vector2)this.transform.position+target.normalized,Quaternion.identity);
        newAttack.GetComponent<RangedAttack>().TargetVector = target;
    }

    public virtual void MoveEntity(Vector2 direction){
        rgb2d.AddForce(direction*moveSpeed);
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(this.MeleeAttack != null){
            Debug.Log(this.tag+" Attac!");
            other.gameObject.SendMessage("RecieveAttack", this.MeleeAttack.GetComponent<Combat.MeleeAttack>(),options:SendMessageOptions.DontRequireReceiver);
        }
        else{
            Debug.Log("No Melee Attack to use!");
        }
    }
    public void KillEntity(){
        //TODO: deal with Experience
        Destroy(this.gameObject);
    }
        [SerializeField]
        private int maxHealth;
        [SerializeField]
        private int currentHealth;
        [SerializeField]
        private int maxMana;
        [SerializeField]
        private int currentMana;
        [SerializeField]
        private bool _alive;
        [SerializeField]
        private int xp;
        [SerializeField]
        public float moveSpeed;
        [SerializeField]
        private Combat.DefenseStats defenseStats;
        [SerializeField]
        private GameObject meleeAttack;
        [SerializeField]
        private GameObject rangedAttack;
        [SerializeField]
        private RectTransform healthBar;
        [SerializeField]
        private Animator _animator;
    protected Rigidbody2D rgb2d;

        public int MaxHealth { get{return maxHealth;} set{maxHealth=value;} }
        public int CurrentHealth { get{return currentHealth;} set{currentHealth=value;} }
        public int MaxMana { get{return maxMana;} set{maxMana=value;} }
        public int CurrentMana { get{return currentHealth;} set{currentHealth=value;} }
        public int Xp { get{return xp;} set{xp=value;} }
        public DefenseStats DefenseInfo { get{return defenseStats;} set{defenseStats=value;} }
        public RectTransform HealthBar { get{return healthBar;} set{healthBar=value;} }
        public GameObject RangedAttack { get{return rangedAttack;} set{rangedAttack=value;} }
        public GameObject MeleeAttack{ get{return meleeAttack;} set{meleeAttack=value;} }
    }
}