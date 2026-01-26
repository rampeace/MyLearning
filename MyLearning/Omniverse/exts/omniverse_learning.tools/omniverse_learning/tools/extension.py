import os
import runpy
import sys
from typing import Optional

import carb
import omni.ext
import omni.kit.app
import omni.kit.menu.utils as menu_utils
import omni.kit.notification_manager as notification_manager
import omni.ui as ui
import omni.usd

WORLD_LOBBY_PATH = (
    r"C:\Users\ramk\source\repos\MyLearning\MyLearning\Omniverse\sandbox"
    r"\Collected_World_Lobby\World_Lobby.usd"
)


# Functions and vars are available to other extension as usual in python: `example.python_ext.some_public_function(x)`
def some_public_function(x: int):
    print("[omniverse_learning.tools] some_public_function was called with x: ", x)
    return x ** x


# Any class derived from `omni.ext.IExt` in top level module (defined in `python.modules` of `extension.toml`) will be
# instantiated when extension gets enabled and `on_startup(ext_id)` will be called. Later when extension gets disabled
# on_shutdown() is called.
class Omniverse_learningToolsExtension(omni.ext.IExt):
    # ext_id is current extension id. It can be used with extension manager to query additional information, like where
    # this extension is located on filesystem.
    def __init__(self):
        super().__init__()
        self._ext_id: Optional[str] = None
        self._menu_items: list[menu_utils.MenuItemDescription] = []
        self._validation_window: Optional[ui.Window] = None

    def on_startup(self, ext_id):
        self._ext_id = ext_id
        print("[omniverse_learning.tools] omniverse_learning tools startup")
        self._menu_items = []
        self._register_run_menu_items()

    def _register_run_menu_items(self):
        self._menu_items = [
            menu_utils.MenuItemDescription(
                name="Validator",
                sub_menu=[
                    menu_utils.MenuItemDescription(
                        name="Open Validator",
                        onclick_fn=self._open_validation_window,
                    )
                ],
            ),
            menu_utils.MenuItemDescription(
                name="Load World Lobby",
                onclick_fn=self._load_world_lobby,
            ),
            menu_utils.MenuItemDescription(
                name="USD",
                sub_menu=[
                    menu_utils.MenuItemDescription(
                        name="Create New World",
                        onclick_fn=self._create_new_world,
                    )
                ],
            ),
            menu_utils.MenuItemDescription(
                name="Python Scripts",
                onclick_fn=self._run_all_scripts,
            )
        ]
        menu_utils.add_menu_items(self._menu_items, "Run")

    def _open_validation_window(self):
        if self._validation_window is None:
            self._validation_window = ui.Window(
                "Asset Validation",
                width=360,
                height=240,
                visible=True,
                dock_preference=ui.DockPreference.LEFT,
            )
            with self._validation_window.frame:
                with ui.VStack(spacing=8):
                    ui.Label("Scene Validator", height=24)
                    ui.Label(
                        "Run checks for naming, units, materials, and textures.",
                        word_wrap=True,
                    )
                    ui.Separator()
                    with ui.HStack(spacing=8):
                        ui.Button("Run Validation", clicked_fn=self._run_validation)
                        ui.Button("Close", clicked_fn=self._close_validation_window)
        else:
            self._validation_window.visible = True

    def _run_validation(self):
        notification_manager.post_notification(
            "Validation is not implemented yet.",
            duration=3,
            status=notification_manager.NotificationStatus.INFO,
        )

    def _close_validation_window(self):
        if self._validation_window is not None:
            self._validation_window.visible = False

    def _run_all_scripts(self):
        scripts_dir = self._scripts_dir()
        if not os.path.isdir(scripts_dir):
            notification_manager.post_notification(
                "No scripts folder found.",
                duration=3,
                status=notification_manager.NotificationStatus.WARNING,
            )
            return

        script_paths = [
            os.path.join(scripts_dir, name)
            for name in sorted(os.listdir(scripts_dir))
            if name.endswith(".py")
        ]
        if not script_paths:
            notification_manager.post_notification(
                "No Python scripts found.",
                duration=3,
                status=notification_manager.NotificationStatus.WARNING,
            )
            return

        notification_manager.post_notification(
            f"Running {len(script_paths)} scripts...",
            duration=3,
            status=notification_manager.NotificationStatus.INFO,
        )
        for path in script_paths:
            self._run_script(path)

    def _load_world_lobby(self):
        if not os.path.isfile(WORLD_LOBBY_PATH):
            notification_manager.post_notification(
                f"World Lobby not found: {WORLD_LOBBY_PATH}",
                duration=5,
                status=notification_manager.NotificationStatus.WARNING,
            )
            return

        omni.usd.get_context().open_stage(WORLD_LOBBY_PATH)
        notification_manager.post_notification(
            "Loading World Lobby...",
            duration=3,
            status=notification_manager.NotificationStatus.INFO,
        )

    def _create_new_world(self):
        if self._ext_id is None:
            raise RuntimeError("Extension id not set before world creation.")
        repo_root = self._repo_root()
        phase2_dir = os.path.join(repo_root, "phase2")
        if not os.path.isdir(phase2_dir):
            notification_manager.post_notification(
                f"Phase 2 folder not found: {phase2_dir}",
                duration=5,
                status=notification_manager.NotificationStatus.WARNING,
            )
            return

        if repo_root not in sys.path:
            sys.path.append(repo_root)

        try:
            from phase2.main import create_world
            result = create_world()
        except Exception:
            carb.log_error("[omniverse_learning.tools] Create New World failed.")
            notification_manager.post_notification(
                "Create New World failed. Check logs for details.",
                duration=5,
                status=notification_manager.NotificationStatus.ERROR,
            )
            return

        status = (
            notification_manager.NotificationStatus.INFO
            if result == 0
            else notification_manager.NotificationStatus.WARNING
        )
        notification_manager.post_notification(
            "Create New World completed.",
            duration=3,
            status=status,
        )

    def _scripts_dir(self):
        if self._ext_id is None:
            raise RuntimeError("Extension id not set before scripts lookup.")
        manager = omni.kit.app.get_app().get_extension_manager()
        ext_path = manager.get_extension_path(self._ext_id)
        return os.path.join(ext_path, "scripts")

    def _repo_root(self):
        manager = omni.kit.app.get_app().get_extension_manager()
        ext_path = manager.get_extension_path(self._ext_id)
        return os.path.dirname(os.path.dirname(ext_path))

    def _run_script(self, path):
        if not os.path.isfile(path):
            carb.log_warn(f"[omniverse_learning.tools] Script not found: {path}")
            return
        notification_manager.post_notification(
            f"Running script: {os.path.basename(path)}",
            duration=3,
            status=notification_manager.NotificationStatus.INFO,
        )
        carb.log_info(f"[omniverse_learning.tools] Running script: {path}")
        try:
            runpy.run_path(path, run_name="__main__")
        except Exception:
            carb.log_error(f"[omniverse_learning.tools] Script failed: {path}")
            raise

    def on_shutdown(self):
        if self._menu_items:
            menu_utils.remove_menu_items(self._menu_items, "Run")
            self._menu_items = []
        print("[omniverse_learning.tools] omniverse_learning tools shutdown")
