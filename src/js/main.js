var colourPicker = new iro.ColorPicker("#colourPicker", {
    color: { r: 255, g: 0, b: 0 },
    css: {
        "#swatch": {
            "background-color": "$color"
        }
    }
});

function SubmitColour() {
    var red = colourPicker.color.rgb.r;
    var green = colourPicker.color.rgb.g;
    var blue = colourPicker.color.rgb.b;

    $.ajax({
        headers: {
            'Content-Type': 'application/json'
        },
        type: "POST",
        url: "api/lamp",
        data: JSON.stringify({
            red: red,
            green: green,
            blue: blue
        }),
        success: null,
        dataType: 'application/json'
    });
}