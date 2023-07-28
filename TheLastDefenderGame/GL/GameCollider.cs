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
        public bool CollisionWithPlayer()
        {
            Player player = game.Player;
            GameCell nextCell;
            GameObjectType type;
            foreach (var value in Enum.GetValues(typeof(GameDirection)))
            {
                nextCell = player.CurrentCell.NextCell((GameDirection)value);
                type = nextCell.CurrentGameObject.GameObjectType;
                if (type == GameObjectType.ENEMY || type == GameObjectType.FIREABLE)
                {
                    return true;
                }

            }
            return false;
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
        public int FireableCollisionsWithEnemy()
        {
            int score = 0;
            for (int i = 0; i < game.Enemies.Count; i++)
            {
                Enemy enemy = game.Enemies[i];
                GameCell nextCell;
                GameObjectType type;
                foreach (var value in Enum.GetValues(typeof(GameDirection)))
                {
                    nextCell = enemy.CurrentCell.NextCell((GameDirection)value);
                    type = nextCell.CurrentGameObject.GameObjectType;
                    if (type == GameObjectType.FIREABLE)
                    {
                        if (enemy.GetType() == typeof(Tank))
                        {
                            score += 3;
                        }
                        else if (enemy.GetType() == typeof(Cannon))
                        {
                            score += 1;
                        }
                        Fireable fireable = (Fireable)nextCell.CurrentGameObject;
                        fireable.OwningCombatant.RemoveFireable(fireable);
                        enemy.Health -= 30;
                        if (enemy.Health <= 0)
                        {
                            game.RemoveEnemy(enemy);
                        }
                        i--;
                    }

                }
            }
            return score;
        }
    }
}
