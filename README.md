# Windows 10 Virtual Desktop Switcher

Tiny utility to simplify switching to the next/previous Windows 10 virtual desktop from a hotkey, script or command line. Also, can show the Windows Application Switcher.

## Command-Line Arguments

Use with arguments below (not case-sensitive) to immediately perform the shift and exit:

`/L` Shifts left to previous desktop, by sending the Ctrl+Win+Left key combo
`/R` Shifts right to next desktop, by sending the Ctrl+Win+Right key combo
`/A` Shows the Windows Application Switcher with all desktops, by sending the Ctrl+Tab combo

## Integration with Other .NET Projects

If you have a project this would work in and don't want to include the source code directly, you can directly call the `public static` methods of this assembly in your code. After adding a project reference to this assembly, you can call the methods like:
```
// Shift to the previous desktop (left)
ShiftDesktop.ShiftForm.ShiftDesktopLeft();

// Shift to the next desktop (right)
ShiftDesktop.ShiftForm.ShiftDesktopRight();

// Show the Windows Application Switcher
ShiftDesktop.ShiftForm.ShowApplicationSwitcher();
```

## Using with a Mouse

I originally wrote this as a way to assign these functions to the thumb-wheel on my Logitech MX Revolution mouse. I had looked at UberOptions and a few scripting solutions, but it's near-impossible to script a Windows key combination (purposely, I imagine). Now I can shift between virtual desktops without moving my hand off the mouse. 

If you're interested in doing the same, here's how:
1. Compile this project to an .exe
2. Create shortcuts to that .exe with the command-line arguments in the shortcut. Maybe you can skip this step, if your mouse software is good at passing along arguments. Mine wasn't.
3. In the mouse-configuration software, choose to run a program as the button/wheel's action, and browse to the shortcut you created above.

## License

Under the MIT License, you can do pretty much whatever you want with this code (modify, distribute, sublicense, for personal or commercial use), so long as you include the original copyright and license notice in all copies of the software/source.