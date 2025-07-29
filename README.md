# SvgResizer

Resize a svg file without losing anything, by:
- simply rewriting its `width` and `height`, if `viewBox` already exists;
- setting `viewBox` to `0 0 {width} {height}`, and then rewriting its `height` and `width`, if `viewBox` doesn't exist (like those exported by PowerPoint).
