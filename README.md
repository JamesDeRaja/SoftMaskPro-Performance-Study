# SoftMaskPro – Unity UI Rendering Performance Study

## Overview

This project is an empirical performance analysis of soft masking in Unity UI under controlled load conditions.

Rather than modifying a UI tool superficially, this repository builds a reproducible profiling harness to measure the real CPU and GPU cost of soft masking in modern Unity (URP).

The focus is deterministic bottleneck isolation, overdraw amplification analysis, and frame-time stability under UI stress.

---

## Objective

Soft masking in Unity UI introduces additional fragment processing and can significantly amplify overdraw in layered interface scenarios.

This project investigates:

* How soft masks affect fragment cost
* Fill-rate saturation under layered transparency
* Canvas rebuild CPU spikes
* Early-Z limitations in UI rendering
* Dirty mask optimization effects
* Frame-time variance under stress

The goal is to quantify these effects using profiler-validated measurements rather than assumptions.

---

## Test Environment

* Unity 6
* Universal Render Pipeline (URP)
* Desktop profiling
* Mock HMD configuration (for XR-aligned testing conditions)
* MSAA configurable (disabled/enabled for comparison)

All tests are reproducible and isolated from unrelated systems.

---

## Experimental Design

The project includes controlled scenes designed to isolate specific variables:

### 1. Baseline UI Scene

Minimal UI elements without soft masking to establish baseline CPU and GPU frame times.

### 2. SoftMask Stress Scene

Multiple layered masked elements to simulate worst-case overdraw amplification.

Measured:

* GPU frame time
* Draw calls
* SetPass calls
* Overdraw heatmap behavior

### 3. Dynamic Layout Stress

Frequent UI invalidation to measure:

* Canvas rebuild spikes
* Main thread CPU impact
* Layout recalculation cost

### 4. Dirty Mask Optimization Validation

Testing selective mask invalidation to reduce unnecessary redraw cost.

---

## Measurement Methodology

All measurements were captured using:

* Unity Profiler (CPU + GPU timeline)
* Frame Debugger
* Overdraw visualization mode
* Deterministic test toggles

Each experiment isolates one variable at a time to avoid cross-system noise.

Frame time comparisons are reported in milliseconds, not FPS, to preserve accuracy.

---

## Key Observations

* Soft masking increases fragment cost under heavy overlap scenarios.
* Overdraw scales non-linearly with stacked transparency.
* Canvas rebuild spikes dominate CPU cost when layout invalidation is frequent.
* UI rendering bypasses many early-Z optimizations, amplifying fill-rate pressure.
* Optimization via controlled invalidation reduces CPU spikes but does not eliminate fragment cost.

---

## Architectural Notes

The project is structured as a controlled Unity harness:

```
SoftMaskPro-Performance-Study/
├── Assets/
├── Packages/
├── ProjectSettings/
├── README.md
└── LICENSE
```

All unnecessary upstream repository artifacts were removed to maintain clarity and authorship integrity.

---

## License Notice

This project contains modified components derived from **SoftMaskForUGUI** (MIT License).

Original Author: Coffee

All performance experiments, optimization validation, profiling harness design, and analysis are authored by:

James De Raja
Senior Real-Time Performance Engineer

---

## Why This Project Exists

Most UI performance discussions rely on anecdotal experience.

This repository demonstrates:

* Measured engineering
* Controlled experimentation
* Deterministic bottleneck isolation
* Systems-level thinking in rendering pipelines

This project complements the XR Performance Stress Lab by focusing specifically on UI fill-rate and masking behavior.

---

## Author

James De Raja
Senior Real-Time Performance Engineer
Unity Rendering | Frame Pacing | XR Optimization | CPU/GPU Bottleneck Analysis
[Website](james.alphaden.club)   [Portfolio](https://www.linkedin.com/in/james-de-raja/)
