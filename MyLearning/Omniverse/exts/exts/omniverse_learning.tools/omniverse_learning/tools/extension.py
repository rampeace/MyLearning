import os
import runpy

import carb
import omni.ext
import omni.kit.app
import omni.kit.menu.utils as menu_utils
import omni.kit.notification_manager as notification_manager


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
    def on_startup(self, ext_id):
        self._ext_id = ext_id
        print("[omniverse_learning.tools] omniverse_learning tools startup")
        self._menu_items = []
        self._register_run_menu_items()

    def _register_run_menu_items(self):
        script_items = self._build_script_menu_items()
        script_items.insert(
            0,
            menu_utils.MenuItemDescription(
                name="Ping Python Scripts",
                onclick_fn=self._ping_scripts_menu,
            ),
        )
        if not script_items:
            script_items = [
                menu_utils.MenuItemDescription(
                    name="No scripts found",
                    enabled=False,
                )
            ]

        self._menu_items = [
            menu_utils.MenuItemDescription(
                name="Python Scripts",
                sub_menu=script_items,
            )
        ]
        menu_utils.add_menu_items(self._menu_items, "Run")

    def _ping_scripts_menu(self):
        message = "Python Scripts menu pinged."
        carb.log_warn(f"[omniverse_learning.tools] {message}")
        notification_manager.post_notification(
            message,
            duration=3,
            status=notification_manager.NotificationStatus.INFO,
        )

    def _build_script_menu_items(self):
        items = []
        scripts_dir = self._scripts_dir()
        if not os.path.isdir(scripts_dir):
            return items

        for name in sorted(os.listdir(scripts_dir)):
            if not name.endswith(".py"):
                continue
            path = os.path.join(scripts_dir, name)
            label = os.path.splitext(name)[0].replace("_", " ").title()
            items.append(
                menu_utils.MenuItemDescription(
                    name=label,
                    onclick_fn=lambda p=path: self._run_script(p),
                )
            )
        return items

    def _scripts_dir(self):
        manager = omni.kit.app.get_app().get_extension_manager()
        ext_path = manager.get_extension_path(self._ext_id)
        return os.path.join(ext_path, "scripts")

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
