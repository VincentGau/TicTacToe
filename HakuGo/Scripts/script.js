document.onclick = function (ev) {
    var oEvent = ev || event;
    var x = oEvent.clientX;
    var y = oEvent.clientY;
    alert(oEvent.clientX + '，' + oEvent.clientY);//     IE浏览器兼容

    var posX = Math.floor((x - topleftX + 15) / 30);
    var posY = Math.floor((y - topleftY + 15) / 30);
    console.log(posX + ' - ' + posY);

    if (x < w / 2 - 240 || x > w / 2 + 240) {
        alert("Out of bound");
    }
    else if (y < 130 || y > 580) {
        alert("out of bound");
    }
    else {
        var board = document.getElementById("chessboard");
        var newChess = document.createElement('div');
        var margintop = 1.5 + 6.53 * posY;
        var marginleft = 1.5 + 6.53 * posX;
        var content = '<div class="chess black" style="margin-top:' + margintop + '%; margin-left:' + marginleft + '%;">1</div >';
        newChess.innerHTML = content;
        board.appendChild(newChess);
    }
    
};

var w = document.documentElement.clientWidth;
var h = document.documentElement.clientHeight;

var topleftX = w / 2 - 31*7;
var topleftY = 133;
console.log(topleftX + " - " + topleftY)
//alert(w + " " + h);