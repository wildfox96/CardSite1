var indentX = 75;
var indentY = 100;

var editedCard;

function indexOf(array, id) {
    $.each(array, function (i, item) {
        if (Object.deepEquals(item.Id, id)) {
            return i;
        }
    });
    return -1;
}

function changeRectPosition(layer) {
    if (layer.x < indentX || layer.x > indentX + 450
        || layer.y < indentY || layer.y > indentY + 250) {
        deleteRect(layer.id);
    } else {
        changeRect(layer.id, layer.color, layer.x, layer.y, layer.width, layer.height);
    }
}

function deleteRect(id) {
    var index = indexOf(editedCard.Rectangles, id);
    alert(index);
    editedCard.Rectangles.splice(index, 1);
}

function changeRect(id, color, x, y, width, height) {
    var index = indexOf(editedCard.Rectangles, id);
    alert(index);
    editedCard.Rectangles[index].X = x;
}

function drawRect(rectId, color, x, y, width, height) {
    $("#workspace").drawRect({
        id: rectId,
        fillStyle: color,
        x: x,
        y: y,
        width: width,
        height: height,
        layer: true,
        draggable: true,
        dragstop: function (layer) {
            changeRectPosition(layer);
        },
        dragcancel: function (layer) {
            changeRectPosition(layer);
        }
    });
}

function drawText(textId, color, x, y, fontSize, text) {
    $("#workspace").drawText({
        id: textId,
        fillStyle: color,
        x: x,
        y: y,
        fontSize: fontSize,
        text: text,
        layer: true,
        draggable: true
    });
}

function showCard(card) {
    editedCard = card;
    drawCard();
    drawCardComponents();
}

function drawCard() {
    $("#workspace").drawRect({
        shadowColor: '#000',
        shadowBlur: 10,
        fillStyle: editedCard.Color,
        x: 225 + indentX,
        y: 125 + indentY,
        width: 450,
        height: 250,
        layer: true
    });
}

function drawCardComponents() {
    $.each(editedCard.Rectangles, function (i, rect) {
        drawRect(rect.Id, rect.Color, rect.X * 2 + indentX, rect.Y * 2 + indentY, rect.Width * 2, rect.Height * 2);
    });
    $.each(editedCard.TextBoxs, function (i, text) {
        drawText(text.Id, text.Color, text.X * 2 + indentX, text.Y * 2 + indentY, 12 * 2, text.Text);
    });
}

function showWorkSpace() {
    var cellSize = 15;
    var x = 0;
    var y = 0;
    var width = $("#workspace").width();
    var height = $("#workspace").height();
    while (x <= width) {
        $("#workspace").drawLine({
            strokeStyle: 'black',
            strokeWidth: 0.1,
            x1: x, y1: 0,
            x2: x, y2: height,
            layer: true
        });
        x += cellSize;
    }
    while (y <= height) {
        $("#workspace").drawLine({
            strokeStyle: 'black',
            strokeWidth: 0.1,
            x1: 0, y1: y,
            x2: width, y2: y,
            layer: true
        });
        y += cellSize;
    }
}








