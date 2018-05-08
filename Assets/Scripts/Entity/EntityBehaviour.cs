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
        //TODO: Implement Healthbar animation / update
        Debug.Log(this.tag+" was attacked!");
        this.currentHealth -= AInfo.Damage;
        Debug.Log(AInfo.Damage+" was taken. Health is now: "+this.currentHealth);
        if(this.currentHealth <= 0){
            _alive = false;
        }
    }
    public virtual void CreateRangedAttack(Vector2 target){
        var newAttack = Instantiate(rangedAttack,(Vector2)this.transform.position+target.normalized,Quaternion.identity);
        newAttack.GetComponent<RangedAttack>().TargetVector = target;
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

    public virtual void Update(){
        if(!_alive){
            Destroy(this.gameObject);
            // TODO apply Experience to player
        }
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