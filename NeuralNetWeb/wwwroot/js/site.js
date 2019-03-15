var canvas = document.getElementById('drawingCanvas');
var context = canvas.getContext('2d');
var width = canvas.width;
var height = canvas.height;
var previousPosition = { x: 0, y: 0 };

context.strokeStyle = "black";
context.lineCap = "round";
context.lineWidth = 15;
var shouldDraw = false;

canvas.addEventListener("mousedown",(function (e) {
    previousPosition = getPosition(e);
    shouldDraw = true;
}));

canvas.addEventListener("mouseup",(function (e) {
    shouldDraw = false;
}));

canvas.addEventListener("mouseleave", (function (e) {
    shouldDraw = false;
}));

canvas.addEventListener("mousemove",(function (e) {
    if (shouldDraw) {
        var currentPosition = getPosition(e);
        draw(currentPosition);
    }
}));

function getPosition(e) {
    var position = { x: e.clientX - canvas.offsetLeft, y: e.clientY - canvas.offsetTop };
    return position;
}
function clearCanvas() {
    console.log("clearing canvas");
    context.clearRect(0, 0, canvas.width, canvas.height);
}

function draw(currentPosition) {
    context.beginPath();
    context.moveTo(previousPosition.x, previousPosition.y);
    context.lineTo(currentPosition.x, currentPosition.y);
    previousPosition = currentPosition;

    context.stroke();
    context.closePath();
}


function identify() {  
    var dataURL = canvas.toDataURL(); // data:image/png;base64,BASE64DATAHERE
    var requestData = {
        ImageType: dataURL.substring(dataURL.indexOf(':') + 1, dataURL.indexOf(';')), // extracts 'image/png' or 'image/jpeg'
        ImageBase64Data: dataURL.substring(dataURL.indexOf(',') + 1) // just the base64 portion
    };
    var resultElement = document.getElementById('result');
    $.ajax({
        type: 'POST',
        url: 'api/imageidentification',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(requestData)
    }).done(function (response) {
        console.log(response);
        resultElement.innerText = response;
    }).fail(function (response) {
            console.log('failed: ' + response);
            resultElement.innerText = 'failed';
    });
}
