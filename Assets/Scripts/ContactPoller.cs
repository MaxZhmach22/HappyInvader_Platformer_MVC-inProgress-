using UnityEngine;

namespace HappyInvaders
{
    public class ContactPoller
    {

        private ContactPoint2D[] _contacs = new ContactPoint2D[10];

        private const float _collTreshold = 0.6f;
        private int _contactCount;
        private Collider2D _collider2D;

        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }


        public ContactPoller(Collider2D collider)
        {
            _collider2D = collider;
        }

        public void Update()
        {
            IsGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;

            _contactCount = _collider2D.GetContacts(_contacs);

            for (int i = 0; i < _contactCount; i++)
            {
                if (_contacs[i].normal.y > _collTreshold) IsGrounded = true;
                if (_contacs[i].normal.x > _collTreshold) HasLeftContact = true;
                if (_contacs[i].normal.x > -_collTreshold) HasRightContact = true;
            }
        }
    }
}
