﻿using Elarion.Saved.Variables.References;
using UnityEngine;

namespace Elarion.Utility.Input {

    public abstract class InputValidator : ScriptableObject {

        public StringReference error;

        public bool canBeEmpty = true;

        public StringReference errorOnEmpty;

        public bool ValidateInput(string input, out string error) {
            if(string.IsNullOrEmpty(input)) {
                if(canBeEmpty) {
                    error = null;
                    return true;
                }

                error = errorOnEmpty.Value;
                return false;
            }

            return ValidateInputImpl(input, out error);
        }

        protected abstract bool ValidateInputImpl(string input, out string error);

    }
}