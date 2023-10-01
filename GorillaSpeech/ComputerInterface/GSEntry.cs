using System;
using ComputerInterface.Interfaces;

namespace GorillaSpeech
{
    public class GSEntry : IComputerModEntry
    {
        public string EntryName => "GorillaSpeech";
        public Type EntryViewType => typeof(GorillaSpeechView);
    }
}