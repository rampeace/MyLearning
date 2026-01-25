# Omniverse Kit API Reference (80/20)

## Discovery patterns
- Namespace = domain: `omni.usd` (stage ops), `omni.ui` (UI), `omni.kit.*` (app/tools), `carb.*` (core/logging).
- Context pattern: `omni.usd.get_context()` is the main entry for stage operations.
- Manager pattern: `omni.kit.app.get_app().get_*_manager()` for system services.
- Module = extension: many modules map to an extension of the same name.
- Command pattern: `omni.kit.commands.execute("CommandName", **kwargs)` for built-in actions.
- UI pattern: `omni.ui.Window` -> containers (`VStack/HStack`) -> widgets (`Button/Label/Input`).
- Logging pattern: `carb.log_info`, `carb.log_warn`, `carb.log_error`.

## 80/20 API set (most used)
- `omni.ext.IExt` for extension lifecycle (`on_startup`, `on_shutdown`).
- `omni.usd.get_context()` to open/save stages and access the active stage.
- `omni.usd.get_context().get_stage()` to get the current `Usd.Stage`.
- `Usd.Stage` traversal (`GetPrimAtPath`, `Traverse`, `GetDefaultPrim`).
- `Usd.Prim` attributes and relationships (`GetAttribute`, `CreateAttribute`, `GetRelationship`).
- `omni.kit.app.get_app()` for app services and extension manager.
- `omni.kit.menu.utils` for adding/removing menu items.
- `omni.kit.notification_manager` for user notifications.
- `omni.kit.commands.execute(...)` for built-in commands.
- `omni.ui` basics (`Window`, `VStack`, `HStack`, `Label`, `Button`, `StringField`).
- `carb.log_info/warn/error` for logging.
- `omni.kit.selection.get_selected_prim_paths()` for selection workflows.

## Common imports
```python
import carb
import omni.ext
import omni.kit.app
import omni.kit.commands
import omni.kit.menu.utils as menu_utils
import omni.kit.notification_manager as notification_manager
import omni.kit.selection
import omni.ui as ui
import omni.usd

from pxr import Usd
```
