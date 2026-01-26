"""
Phase 2: create a USD stage from scratch with layers and prims.
"""

from __future__ import annotations

from pathlib import Path

from pxr import Sdf, Usd, UsdGeom


def create_world() -> int:
    phase_dir = Path(__file__).resolve().parent
    root_layer_path = phase_dir / "phase2_stage.usda"
    overrides_layer_path = phase_dir / "overrides.usda"

    root_layer = Sdf.Layer.CreateNew(str(root_layer_path))
    overrides_layer = Sdf.Layer.CreateNew(str(overrides_layer_path))
    root_layer.subLayerPaths.append(overrides_layer.identifier)

    stage = Usd.Stage.Open(root_layer)
    UsdGeom.SetStageUpAxis(stage, UsdGeom.Tokens.z)
    UsdGeom.SetStageMetersPerUnit(stage, 1.0)

    world = UsdGeom.Xform.Define(stage, "/World")
    stage.SetDefaultPrim(world.GetPrim())

    env = UsdGeom.Xform.Define(stage, "/World/Env")
    ground = UsdGeom.Xform.Define(stage, "/World/Env/Ground")
    UsdGeom.XformCommonAPI(ground).SetScale((10.0, 10.0, 0.1))

    stage.SetEditTarget(overrides_layer)
    UsdGeom.XformCommonAPI(env).SetTranslate((0.0, 0.0, 0.5))

    root_layer.Save()
    overrides_layer.Save()

    print(f"Wrote stage: {root_layer_path}")
    print(f"Wrote sublayer: {overrides_layer_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(create_world())
