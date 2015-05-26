function drawRect(cardId, color, x, y, width, height) {
    $("#" + cardId).drawRect({
        fillStyle: color,
        x: x, 
        y: y, 
        width: width, 
        height: height,
        layer: true
    });
}

function drawText(cardId, color, x, y, fontSize, text) {
    $("#" + cardId).drawText({
        fillStyle: color,
        x: x, 
        y: y, 
        fontSize: fontSize,
        text: text,
        layer: true
    });
}

function showCard(card) {
    drawCard(card, 2);
}

function showCardPreview(card) {
    drawCard(card, 1);
}

function drawCard(card, size) {
    $.each(card.Rectangles, function (i, rect) {
        drawRect(card.Id, rect.Color, rect.X * size, rect.Y * size, rect.Width * size, rect.Height * size);
    });
    $.each(card.TextBoxs, function (i, text) {
        drawText(card.Id, text.Color, text.X * size, text.Y * size, 12 * size, text.Text);
    });
}