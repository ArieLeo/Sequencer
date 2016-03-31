// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the Sequencer extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace SequencerModule {

    [Serializable]
    public class SequenceSlots {

        [SerializeField]
        private UnityEvent action;

        [SerializeField]
        private float delayOffset;

        public UnityEvent Action {
            get { return action; }
            set { action = value; }
        }

        public float DelayOffset {
            get { return delayOffset; }
            set { delayOffset = value; }
        }
    }

    public sealed class Sequencer : MonoBehaviour {

        #region CONSTANTS

        public const string Version = "v0.1.0";
        public const string Extension = "Sequencer";
        public const string Description = "";

        #endregion CONSTANTS

        #region DELEGATES
        #endregion DELEGATES

        #region EVENTS
        #endregion EVENTS

        #region FIELDS

#pragma warning disable 0414
        /// <summary>
        ///     Allows identify component in the scene file when reading it with
        ///     text editor.
        /// </summary>
        [SerializeField]
        [HideInInspector]
        private string componentName = "Sequencer";
#pragma warning restore 0414

        CompositeDisposable disposables = new CompositeDisposable();

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private string comment = "Comment";

        [SerializeField]
        private List<SequenceSlots> sequenceSlots;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Comment {
            get { return comment; }
            set { comment = value; }
        }

        public List<SequenceSlots> SequenceSlots {
            get { return sequenceSlots; }
            set { sequenceSlots = value; }
        }

        public CompositeDisposable Disposables {
            get { return disposables; }
            set { disposables = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void Awake() { }

        private void FixedUpdate() { }

        private void LateUpdate() { }

        private void OnEnable() {
            CreateSequence();
        }

        private void Reset() { }

        private void Start() {
            CreateSequence();
        }

        public void CreateSequence() {
            // Absolute time when the slot's action should be executed.
            var absoluteTime = 0f;

            foreach (var slot in SequenceSlots) {
                // Avoid clousure.
                var _slot = slot;

                absoluteTime += slot.DelayOffset;

                Observable.Timer(TimeSpan.FromSeconds(absoluteTime))
                    .Subscribe(_ => _slot.Action.Invoke()).AddTo(Disposables);
            }
        }

        private void Update() { }

        private void OnValidate() { }

        private void OnDisable() {
            Disposables.Clear();
        }

        private void OnDestroy() { }

        #endregion UNITY MESSAGES

        #region EVENT INVOCATORS
        #endregion INVOCATORS

        #region EVENT HANDLERS
        #endregion EVENT HANDLERS

        #region METHODS
        #endregion METHODS

    }

}