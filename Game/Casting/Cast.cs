using System.Collections.Generic;


namespace unit06_game.Game.Casting
{
    /// <summary>
    /// <para>A collection of actors.</para>
    /// <para>
    /// The responsibility of a cast is to keep track of a collection of actors. It has methods for 
    /// adding, removing and getting them by a group name.
    /// </para>
    /// </summary>
    public class Cast
    {
        private Dictionary<string, List<Actor>> actors = new Dictionary<string, List<Actor>>();
        private Dictionary<string, List<Enemy>> enemies = new Dictionary<string, List<Enemy>>();
        private Dictionary<string, List<Tower>> towers = new Dictionary<string, List<Tower>>();
        private Dictionary<string, List<Display>> displays = new Dictionary<string, List<Display>>();

        /// <summary>
        /// Constructs a new instance of Cast.
        /// </summary>
        public Cast()
        {
        }

        /// <summary>
        /// Adds the given actor to the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="actor">The actor to add.</param>
        public void AddActor(string group, Actor actor)
        {
            if (!actors.ContainsKey(group))
            {
                actors[group] = new List<Actor>();
            }

            if (!actors[group].Contains(actor))
            {
                actors[group].Add(actor);
            }
        }
        public void AddEnemy(string group, Enemy enemy)
        {
            if (!enemies.ContainsKey(group))
            {
                enemies[group] = new List<Enemy>();
            }
            if (!enemies[group].Contains(enemy))
            {
                enemies[group].Add(enemy);
            }
        }
        /// <summary>
        /// Adds a tower to the cast.
        /// </summary>
        /// <param name="group">The group name.</param>
        public void AddTower(string group, Tower tower)
        {
            if (!towers.ContainsKey(group))
            {
                towers[group] = new List<Tower>();
            }
            if (!towers[group].Contains(tower))
            {
                towers[group].Add(tower);
            }
        }

        /// <summary>
        /// Gets the actors in the given group. Returns an empty list if there aren't any.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The list of actors.</returns>
        public List<Actor> GetActors(string group)
        {
            List<Actor> results = new List<Actor>();
            if (actors.ContainsKey(group))
            {
                results.AddRange(actors[group]);
            }
            return results;
        }
        public List<Enemy> GetEnemies(string group)
        {
            List<Enemy> results = new List<Enemy>();
            if (enemies.ContainsKey(group))
            {
                results.AddRange(enemies[group]);
            }
            return results;
        }
        // <summary>
        /// Gets all the towers in the cast.
        /// </summary>
        /// <returns>A list of all actors.</returns>
        public List<Tower> GetTowers(string group)
        {
            List<Tower> results = new List<Tower>();
            if (towers.ContainsKey(group))
            {
                results.AddRange(towers[group]);
            }
            return results;
        }   
        public List<Display> GetDisplays(string group)
        {
            List<Display> results = new List<Display>();
            if (displays.ContainsKey(group))
            {
                results.AddRange(displays[group]);
            }
            return results;
        }   

        /// <summary>
        /// Gets all the actors in the cast.
        /// </summary>
        /// <returns>A list of all actors.</returns>
        public List<Actor> GetAllActors()
        {
            List<Actor> results = new List<Actor>();
            foreach (List<Actor> result in actors.Values)
            {
                results.AddRange(result);
            }
            return results;
        }

        /// <summary>
        /// Gets the first actor in the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The first actor.</returns>
        public Actor GetFirstActor(string group)
        {
            Actor result = null;
            if (actors.ContainsKey(group))
            {
                if (actors[group].Count > 0)
                {
                    result = actors[group][0];
                }
            }
            return result;
        }

        public Enemy GetFirstEnemy(string group)
        {
            Enemy result = null;
            if (enemies.ContainsKey(group))
            {
                if (enemies[group].Count > 0)
                {
                    result = enemies[group][0];
                }
            }
            return result;
        }
        /// <summary>
        /// Gets the first actor in the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The first actor.</returns>
        public Actor GetSecondActor(string group)
        {
            Actor result = null;
            if (actors.ContainsKey(group))
            {
                if (actors[group].Count > 0)
                {
                    result = actors[group][1];
                }
            }
            return result;
        }

        public Actor GetThirdActor(string group)
        {
            Actor result = null;
            if (actors.ContainsKey(group))
            {
                if (actors[group].Count > 0)
                {
                    result = actors[group][2];
                }
            }
            return result;
        }

        /// <summary>
        /// Removes the given actor from the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="actor">The actor to remove.</param>
        public void RemoveActor(string group, Actor actor)
        {
            if (actors.ContainsKey(group))
            {
                actors[group].Remove(actor);
            }
        }
        public void RemoveEnemy(string group, Enemy enemy)
        {
            if (enemies.ContainsKey(group))
            {
                enemies[group].Remove(enemy);
            }
        }

    }
}