////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2018 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using FlaxEngine;

namespace FlaxEditor.Content.Settings
{
    /// <summary>
    /// The physics simulation settings container. Allows to edit asset via editor.
    /// </summary>
    public sealed class PhysicsSettings : SettingsBase
    {
        /// <summary>
        /// The default gravity force value (in cm^2/s).
        /// </summary>
        [EditorOrder(0), EditorDisplay("Simulation"), Tooltip("The default gravity force value (in cm^2/s).")]
        public Vector3 DefaultGravity = new Vector3(0, -981.0f, 0);

        /// <summary>
        /// If enabled, any Raycast or other scene query that intersects with a Collider marked as a Trigger will returns with a hit. Individual raycasts can override this behavior.
        /// </summary>
        [EditorOrder(10), EditorDisplay("Simulation"), Tooltip("If enabled, any Raycast or other scene query that intersects with a Collider marked as a Trigger will returns with a hit. Individual raycasts can override this behavior.")]
        public bool QueriesHitTriggers = true;

        /// <summary>
        /// Triangles from triangle meshes (CSG) with an area less than or equal to this value will be removed from physics collision data. Set to less than or equal 0 to disable.
        /// </summary>
        [EditorOrder(20), EditorDisplay("Simulation"), Limit(-1, 10), Tooltip("Triangles from triangle meshes (CSG) with an area less than or equal to this value will be removed from physics collision data. Set to less than or equal 0 to disable.")]
        public float TriangleMeshTriangleMinAreaThreshold = 5.0f;

        /// <summary>
        /// Minimum relative velocity required for an object to bounce. A typical value for simulation stability is about 0.2 * gravity
        /// </summary>
        [EditorOrder(30), EditorDisplay("Simulation"), Limit(0), Tooltip("Minimum relative velocity required for an object to bounce. A typical value for simulation stability is about 0.2 * gravity")]
        public float BounceThresholdVelocity = 200.0f;

        /// <summary>
        /// Default friction combine mode, controls how friction is computed for multiple materials.
        /// </summary>
        [EditorOrder(40), EditorDisplay("Simulation"), Tooltip("Default friction combine mode, controls how friction is computed for multiple materials.")]
        public PhysicsCombineMode FrictionCombineMode = PhysicsCombineMode.Average;

        /// <summary>
        /// Default restitution combine mode, controls how restitution is computed for multiple materials.
        /// </summary>
        [EditorOrder(50), EditorDisplay("Simulation"), Tooltip("Default restitution combine mode, controls how restitution is computed for multiple materials.")]
        public PhysicsCombineMode RestitutionCombineMode = PhysicsCombineMode.Average;

        /// <summary>
        /// If true CCD will be ignored. This is an optimization when CCD is never used which removes the need for physx to check it internally.
        /// </summary>
        [EditorOrder(70), EditorDisplay("Simulation", "Disable CCD"), Tooltip("If true CCD will be ignored. This is an optimization when CCD is never used which removes the need for physx to check it internally.")]
        public bool DisableCCD;

		/// <summary>
		/// Enables adaptive forces to accelerate convergence of the solver. Can improve physics simulation performance but lead to artifacts.
		/// </summary>
		[EditorOrder(80), EditorDisplay("Simulation"), Tooltip("Enables adaptive forces to accelerate convergence of the solver. Can improve physics simulation performance but lead to artifacts.")]
        public bool EnableAdaptiveForce;

		/// <summary>
		/// The maximum allowed delta time (in seconds) for the physics simulation step.
		/// </summary>
		[EditorOrder(1000), EditorDisplay("Framerate"), Limit(0.0013f, 2.0f), Tooltip("The maximum allowed delta time (in seconds) for the physics simulation step.")]
        public float MaxDeltaTime = 1.0f / 10.0f;

        /// <summary>
        /// Whether to substep the physics simulation.
        /// </summary>
        [EditorOrder(1005), EditorDisplay("Framerate"), Tooltip("Whether to substep the physics simulation.")]
        public bool EnableSubstepping;

        /// <summary>
        /// Delta time (in seconds) for an individual simulation substep.
        /// </summary>
        [EditorOrder(1010), EditorDisplay("Framerate"), Limit(0.0013f, 1.0f), Tooltip("Delta time (in seconds) for an individual simulation substep.")]
        public float SubstepDeltaTime = 1.0f / 120.0f;

        /// <summary>
        /// The maximum number of substeps for physics simulation.
        /// </summary>
        [EditorOrder(1020), EditorDisplay("Framerate"), Limit(1, 16), Tooltip("The maximum number of substeps for physics simulation.")]
        public int MaxSubsteps = 5;

        /// <summary>
        /// The collision layers masks. Used to define layer-based collision detection.
        /// </summary>
        [EditorOrder(1040), EditorDisplay("Layers Matrix"), CustomEditor(typeof(FlaxEditor.CustomEditors.Dedicated.LayersMatrixEditor))]
        public uint[] LayerMasks = new uint[32];
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSettings"/> class.
        /// </summary>
        public PhysicsSettings()
        {
            for (int i = 0; i < 32; i++)
            {
                LayerMasks[i] = uint.MaxValue;
            }
        }
    }
}
