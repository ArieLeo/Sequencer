// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the Sequencer extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;

namespace SequencerModule {

    [CustomEditor(typeof(Sequencer))]
    [CanEditMultipleObjects]
    public sealed class SequencerEditor : Editor {

        #region FIELDS
        #endregion FIELDS

        #region UNITY MESSAGES
        #endregion UNITY MESSAGES

        #region METHODS

        [MenuItem("Component/Component Framework/Sequencer")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(Sequencer));
            }
        }

        #endregion METHODS
    }

}