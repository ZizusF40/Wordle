import subprocess
import os
import sys
import ctypes
from pathlib import Path

def show_error_message(message):
    """
    Displays an error message in a Windows message box.
    """
    ctypes.windll.user32.MessageBoxW(0, message, "Error", 0x10)  # 0x10 is the icon for an error

try:
    # Determine if the script is running as a PyInstaller executable
    if getattr(sys, 'frozen', False):
        # If running as an executable, use the executable's directory
        script_dir = Path(sys.executable).parent.resolve()
    else:
        # If running as a script, use the script's directory
        script_dir = Path(__file__).parent.resolve()

    # Construct the path to the executable
    path_to_exe = script_dir / "Data" / "PresentationLayer.exe"

    # Check if the executable exists
    if not path_to_exe.exists():
        error_message = f"Executable not found at: {path_to_exe}"
        show_error_message(error_message)
        sys.exit(1)

    # Launch the executable
    process = subprocess.Popen(["start", "/B", str(path_to_exe)], shell=True, creationflags=subprocess.CREATE_NO_WINDOW)
except Exception as e:
    error_message = f"Failed to launch executable: {e}"
    show_error_message(error_message)