using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    class GameCollider
    {
        Game game;
        public GameCollider(Game game)
        {
            this.game = game;
        }
        public List<Fireable> CollidingFirables()
        {
            List<Fireable> fireables = new List<Fireable>();
            AddCollidingFirables(fireables, game.Player.Fireables);
            foreach (Enemy enemy in game.Enemies)
            {
                AddCollidingFirables(fireables, enemy.Fireables);
            }
            AddCollidingFirables(fireables, game.FreeFireables);
            return fireables;
        }
        private void AddCollidingFirables(List<Fireable> fireables, List<Fireable> combatantFirables)
        {
            foreach (Fireable fireable in combatantFirables)
            {
                GameObject gameObject = fireable.CurrentCell.NextCell(fireable.FiringDirection).CurrentGameObject;
                if (gameObject.GameObjectType == GameObjectType.PLAYER || gameObject.GameObjectType == GameObjectType.ENEMY)
                {
                    fireables.Add(fireable);
                }
            }
        }
    }
}
