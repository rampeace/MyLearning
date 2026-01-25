# Omniverse Learning

This folder is my personal workspace for learning NVIDIA Omniverse.
I use it to capture notes, experiments, and small prototypes as I
explore the tools, APIs, and workflows.

## Intent
- Keep everything related to Omniverse learning in one place.
- Track progress over time with lightweight notes and examples.
- Make it easy to revisit and build on earlier experiments.

## What goes here
- Notes and summaries from docs, videos, or courses.
- Small demo projects or scripts.
- Configuration snippets and troubleshooting tips.
- Sandbox scene copies stored locally (ignored by git).

## What does not go here
- Large binary assets (store elsewhere and link if needed).
- Work-in-progress items unrelated to Omniverse.

## Roadmap (planned extensions and automation)
- Asset validation tools (naming, units, materials, missing textures).
- Batch processing pipelines (convert, optimize, publish USD files).
- Scene setup automation (standard lighting, cameras, layouts, templates).
- UI panels for artist workflows (one-click fixes, presets, review tools).
- Integration hooks (auto-export to DCCs, sync metadata, publish assets).

## First project: asset validation (task breakdown)
- Define validation rules (naming, allowed prim types, unit scale, required metadata, material bindings).
- Build a scanner to walk the stage and collect prims/materials/textures/references.
- Detect issues (invalid names, missing material bindings, missing or invalid texture paths, unit mismatch).
- Report output (console summary + JSON/CSV with prim paths and issue codes).
- Fix options (optional) like auto-rename, apply default material, relink textures, normalize units.
- UX surface (menu action; optional UI panel with Run + filters).
- Test data (sample stages that include each failure case).

## Sample content
- Download: https://docs.omniverse.nvidia.com/usd/latest/usd_content_samples/sample_content.html
- Local sandbox copy: `sandbox/` (ignored by git).
