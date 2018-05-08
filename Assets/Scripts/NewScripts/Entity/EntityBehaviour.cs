using Combat;
using UnityEngine;
namespace Entity{
//Class used to wrap Entity Data up together
public abstract class EntityBehaviour : MonoBehaviour {
    public virtual void Start () {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
        _alive = true;
        rgb2d = GetComponent<Rigidbody2D>();
	}
    /// <summary>
    /// Used by attacker when entity is attacked, to calculate Damage taken by this entity
    /// </summary>
    /// <param name="AInfo"> The attacking data </param>
    public void RecieveAttack(Combat.AttackStats AInfo){
        Debug.Log(this.tag+" was attacked!");
        this.CurrentHealth -= AInfo.Damage;
        if(this.CurrentHealth <= 0){
            _alive = false;
        }
    }
    public virtual void CreateAttack(Vector2 target){
        var spawn = (target - (Vector2)transform.position).normalized;
        var newAttack = Instantiate(rangedAttack,(Vector2)transform.position+spawn,Quaternion.identity);
        newAttack.GetComponent<RangedAttack>().TargetVector = target;
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
        private Combat.DefenseStats defenseInfo;
        [SerializeField]
        private GameObject meleeAttack;
        [SerializeField]
        private GameObject rangedAttack;
        [SerializeField]
        private RectTransform healthBar;
        [SerializeField]
        private Animator _animator;
    protected Rigidbody2D rgb2d;

        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }
        public int Xp { get; set; }
        public DefenseStats DefenseInfo { get; set; }
        public RectTransform HealthBar { get; set; }
        public GameObject RangedAttack { get; set; }
        public GameObject MeleeAttack{get; set;}
    }
}