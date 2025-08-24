# 🟦 Unity Cube Interaction & Player Movement Demo

## Project Description

This Unity project demonstrates interactive cube manipulation and player movement systems supporting multiple input methods (keyboard, mouse, mobile touch, and joystick). The project is designed for learning and prototyping input handling, movement, and basic UI integration in Unity.

## Features

- **Cube Interaction**  
  - Rotate and move a cube using keyboard, mouse, or mobile touch.
  - Pinch-to-zoom and drag-to-move support on mobile devices.
  - Mouse drag and rotation controls.

- **Player Movement**  
  - Move and jump with keyboard or on-screen joystick.
  - Toggle between walking and running speeds.
  - UI buttons for jump and run actions.
  - Smooth jump animation.

- **Multi-Platform Input**  
  - Keyboard, mouse, and mobile touch support.
  - Integrated joystick system (using Joystick Pack).

- **UI Integration**  
  - Toggle, button, and joystick UI elements for mobile controls.

- **Extensible Architecture**  
  - Modular scripts for easy extension and customization.

## How to Play / Controls

### Desktop
- **Cube Controls**
  - Rotate: Arrow keys or WASD
  - Mouse drag: Rotate cube
  - Right mouse button: Drag to move cube

- **Player Controls**
  - Move: Arrow keys or WASD
  - Run: Hold `R`
  - Jump: Press `Space`

### Mobile
- **Cube Controls**
  - Single touch: Rotate cube
  - Two-finger drag: Move cube
  - Pinch: Zoom cube

- **Player Controls**
  - On-screen joystick for movement
  - Toggle for running
  - Button for jumping

## Dependencies

- **Unity**: Recommended version 2019.4 or newer
- **.NET Framework**: 4.7.1 (per project settings)
- **Joystick Pack**: For mobile joystick controls
- **TextMesh Pro**: For advanced UI text rendering

## Installation & Setup

1. **Clone or Download** this repository.
2. **Open in Unity Hub**:  
   - Select the project folder.
   - Use Unity 2019.4 or newer for best compatibility.
3. **Install Required Packages**:  
   - Open __Window > Package Manager__ and ensure TextMesh Pro is installed.
   - Import Joystick Pack if not already present.
4. **Open Main Scene**:  
   - Navigate to `Assets/Scenes` and open the main scene.
5. **Play**:  
   - Press the Play button in the Unity Editor to test controls.

## Contributing

Contributions are welcome!  
- Fork the repository and submit pull requests.
- Report issues or suggest features via GitHub Issues.

## Known Issues & Future Improvements

- Some scripts use legacy naming (`Old` suffix); refactoring recommended.
- UI elements may require adjustment for different screen sizes.
- No advanced gameplay or scoring system implemented.
- Multiplayer and AI features are not included.

