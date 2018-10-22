var colorPicker = new iro.ColorPicker("#colourPicker", {
    color: { r: 255, g: 0, b: 0 },
    css: {
        "#swatch": {
            "background-color": "$color"
        }
    }
});