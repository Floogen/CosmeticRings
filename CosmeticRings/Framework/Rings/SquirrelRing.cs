using CosmeticRings.Framework.Critters;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticRings.Framework.Rings
{
    internal class SquirrelRing : CustomRing
    {
        private SquirrelFollower _squirrel;

        internal override Ring RingObject { get; }

        internal SquirrelRing(Ring pairedRing)
        {
            RingObject = pairedRing;
        }

        internal override void HandleEquip(Farmer who, GameLocation location)
        {
            // Ensure we can force a character to appear
            if (location.characters is null)
            {
                return;
            }

            // Spawn rabbit
            _squirrel = new SquirrelFollower(who.getTileLocation());

            location.characters.Add(_squirrel);
        }

        internal override void HandleUnequip(Farmer who, GameLocation location)
        {
            if (_squirrel != null)
            {
                location.characters.Remove(_squirrel);
                _squirrel = null;
            }
        }

        internal override void HandleNewLocation(Farmer who, GameLocation location)
        {
            // Ensure we can force a character to appear
            if (location.characters is null)
            {
                return;
            }

            // Spawn rabbit
            if (_squirrel is null)
            {
                _squirrel = new SquirrelFollower(who.getTileLocation());
            }

            _squirrel.resetForNewLocation(who.getTileLocation());
            location.characters.Add(_squirrel);
        }

        internal override void HandleLeaveLocation(Farmer who, GameLocation location)
        {
            if (_squirrel != null)
            {
                location.characters.Remove(_squirrel);
            }
        }

        internal override void Update(Farmer who, GameLocation location)
        {

        }
    }
}
