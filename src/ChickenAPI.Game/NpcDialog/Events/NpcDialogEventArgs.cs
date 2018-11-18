﻿using ChickenAPI.Game.Events;

namespace ChickenAPI.Game.NpcDialog.Events
{
    public class NpcDialogEventArgs : ChickenEventArgs
    {
        public long DialogId { get; set; }

        public long Type { get; set; }

        public long Value { get; set; }

        public long NpcId { get; set; }
    }
}