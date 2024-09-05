# Unity Scene Reference


A simple script which creates a SceneReference class, allowing Unity developers to drag and drop scene assets into exposed fields in the inspector. This circumvents using icky string names or build indexes and will dynamically access the same scene asset even when its build index or string name is changed.

### Installation & Use
1. Download SceneReference.cs
2. Place SceneReference.cs anywhere in the Assets folder, except the Editor folder.
3. Use the SceneReference as a type in a script, for example: private SceneReference myScene; 
4. See ChangeScenesDemo.cs for a simple implementation.
