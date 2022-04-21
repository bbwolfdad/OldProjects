// Dots.js
var numberOfDots = 0;
var MAXDOTS = 300;
var MAXSPEED = 10;
var refreshSpeed = 100;
var screenSizeX = 0;
var screenSizeY = 0;
var dotCount = 200;
var startingRadius = 5;
var lastRadius = 0;
var dotSizeIncrement = 10;
var jumpScale = 1.5;
var colorMax = 255;
var colorMin = 0;
var bodyElement;
var randomDirection = false;
var dotArray = [];
var divArray = [];
class Color {
    static green = "#00FF00";
    static blue = "#03dbfc";
    static red = "#fc0303";
    static yellow = "#fcec03";
    static white = "#FFFFFF";
    static purple = "#b503fc";
    static orange = "#ff9e03";
    static darkBlue = "#3103ff";
    static pink = "#ff9ef0";
    static black = "#000000";
    static colors = [this.green, this.blue, this.red, this.yellow, this.white, this.purple, this.orange, this.darkBlue, this.pink, this.black ];
    static pickColor(){
        var colorCount = this.colors.length;
        return this.colors[Math.floor(Math.random() * colorCount)];
    }
}

class Dot {
    constructor(radius, id, moveSpeedX, moveSpeedY, positionX, positionY){
        this.color = Color.pickColor();
        this.radius = radius;
        this.id = id;
        this.moveSpeedX = moveSpeedX;
        this.moveSpeedY = moveSpeedY;
        this.positionX = positionX;
        this.positionY = positionY;
        this.outOfBoundsCount = 0;
    }
    setElement(element){
        this.element = element;
    }
    output(){
        console.log("-----------------" + this.id + "------------------")
        console.log("id = " + this.id);
        console.log("color = " + this.color);
        console.log("radius = " + this.radius);
        console.log("moveSpeed = " + this.moveSpeedX);
        console.log("moveSpeed = " + this.moveSpeedY);
        console.log("positionX = " + this.positionX);
        console.log("positionY = " + this.positionY);
        console.log("element = " + this.element);
    }
    moveDot(){
        var changeX = 1;
        var changeY = 1;
        if( randomDirection ){
            changeX = Math.random() * 2;
            changeY = Math.random() * 2;
        }
        
        if( this.positionX < 0 || changeX < 1 ){
            this.moveSpeedX = this.moveSpeedX * -1;
        }
        if( this.positionY < 0 ||  changeY < 1 ){
            this.moveSpeedY = this.moveSpeedY * -1;
        }
        if(this.positionX + this.radius > screenSizeX){
            this.moveSpeedX = Math.floor( Math.random() * lastRadius + 1) * jumpScale * -1;
            this.positionX = screenSizeX - this.radius;
        }
        if(this.positionY + this.radius > screenSizeY  ){
            this.moveSpeedY = Math.floor( Math.random() * lastRadius + 1) * jumpScale * -1;
            this.positionY = screenSizeY - this.radius;
        }
        if(this.positionX < 0 || this.positionY < 0 || this.positionX + this.radius > screenSizeX || this.positionY + this.radius > screenSizeY ){
            this.outOfBoundsCount = this.outOfBoundsCount + 1;
        } else {
            this.outOfBoundsCount = 0;
        }
        if(this.outOfBoundsCount > 5 ){
            this.positionX = 0;
            this.positionY = 0;
        }
        this.positionX = this.positionX + this.moveSpeedX;
        this.positionY = this.positionY + this.moveSpeedY;
        this.element.style.left = this.positionX + "px";
        this.element.style.top = this.positionY + "px";
    }
    resetDotPosition(){
        this.positionX = screenSizeX/2;
        this.positionY = screenSizeX/2;
    }
}
class Div {
    constructor(element){
        this.element = element;
        this.positionX = element.offsetLeft;
        this.positionY = element.offsetTop;
        this.height = element.offsetHeight;
        this.width = element.offsetWidth;
        this.moveSpeedX = Math.floor( Math.random() * this.width/100 + 1) * -1;
        this.moveSpeedY = Math.floor( Math.random() * this.height/100 + 1) * -1;
        this.outOfBoundsCount = 0;
        this.boundsX = element.parentElement.scrollWidth;
        this.boundsY = element.parentElement.scrollHeight;
        this.redValue = Math.floor(Math.random() * colorMax);
        this.greenValue = Math.floor(Math.random() * colorMax);
        this.blueValue = Math.floor(Math.random() * colorMax);
    }
    output(){
        console.log("element = " + this.element);
        console.log("positionX = " + this.positionX);
        console.log("positionY = " + this.positionY);
        console.log("height = " + this.height);
        console.log("width = " + this.width);
        console.log("moveSpeedX = " + this.moveSpeedX);
        console.log("moveSpeedY = " + this.moveSpeedY);
        console.log("elemeoutOfBoundsCountnt = " + this.outOfBoundsCount);
    }
    moveDiv(){        
        if( this.positionX < 0 ){
            this.moveSpeedX = this.moveSpeedX * -1;
        }
        if( this.positionY < 0 ){
            this.moveSpeedY = this.moveSpeedY * -1;
        }
        if( this.positionX + this.width > this.boundsX ){
            this.moveSpeedX = Math.floor( Math.random() * this.width/100 + 1) * -1;
            this.positionX = this.boundsX - this.width;
        }
        if( this.positionY + this.height > this.boundsY ){
            this.moveSpeedY = Math.floor( Math.random() * this.height/100 + 1) * -1;
            this.positionY = this.boundsY - this.height;
        }
        if( this.positionX < 0 || this.positionY < 0 || this.positionX + this.width > this.boundsX || this.positionY + this.height > this.boundsY ){
            this.outOfBoundsCount = this.outOfBoundsCount + 1;
        } else {
            this.outOfBoundsCount = 0;
        }
        if(this.outOfBoundsCount > 5 ){
            this.positionX = 0;
            this.positionY = 0;
        }
        this.positionX = this.positionX + this.moveSpeedX;
        this.positionY = this.positionY + this.moveSpeedY;
        this.element.style.left = this.positionX + "px";
        this.element.style.top = this.positionY + "px";
        //this.element.style.color = "rgb(" + this.redValue + ", " + this.greenValue + ", " + this.blueValue + ");";
    }
    resetDivPosition(){
        this.positionX = this.boundsX/2;
        this.positionY = this.boundsY/2;
    }
}

function startDotAction(){
    // grab body element
    bodyElement = document.getElementsByTagName("body")[0];
    divElements = document.getElementsByTagName("div");
    // initialize the screen size X and Y
    //screenSizeX = window.innerWidth;
    //screenSizeY = window.innerHeight;
    screenSizeX = bodyElement.clientWidth;
    screenSizeY = bodyElement.clientHeight;
    
    console.log("screenSizeX = " + screenSizeX);
    console.log("screenSizeY = " + screenSizeY);
    console.log("body clientHeight = " + bodyElement.clientHeight);
    console.log("refreshSpeed = " + refreshSpeed );
    console.log("dotCount = " + dotCount );
    console.log("startingRadius = " + startingRadius );
    console.log("dotSizeIncrement = " + dotSizeIncrement );
    console.log("jumpScale = " + jumpScale );
    console.log("randomDirection = " + randomDirection );
    console.log("divElements length = " + divElements.length);
    for(i = 0; i < divElements.length; i++){
        currentElement = divElements[i];
        currentDiv = new Div(currentElement);
        divArray.push(currentDiv);
        //currentDiv.output();
        setInterval( moveDiv, refreshSpeed, currentDiv);
    }
    // initialize radius
    lastRadius = startingRadius;
    // dot makeing function dotCount times
    for( i = 0; i < dotCount; i++){
        dotArray.push( makeDots(i, Math.floor(Math.random() * screenSizeX), Math.floor(Math.random() * screenSizeY)) );
    }
}
function makeDots(dotNumber, passedX, passedY){
    var zIndex = 700;
    var speedX = Math.floor( Math.random() * lastRadius + 1) * jumpScale;
    var speedY = Math.floor( Math.random() * lastRadius + 1) * jumpScale;
    if( jumpScale == 0 ){
        speedX = 1;
        speedY = 1;
    }
    var positionX = 0;
    var positionY = 0;
    if( passedX == null ){
        positionX = Math.floor(Math.random() * screenSizeX);
    } else {
        positionX = passedX;
    }
    if( passedY == null ){
        positionY = Math.floor(Math.random() * screenSizeY);
    } else {
        positionY = passedY;
    }
    if(dotNumber % 50 == 0){
        lastRadius = lastRadius + 1;
    }
    if(dotNumber % 3 == 0 ){
        speedX = speedX * -1;
    }
    if(dotNumber % 5 == 0 ){
        speedY = speedY * -1;
    }
    var dot = new Dot(lastRadius, "dot" + dotNumber, speedX, speedY, positionX, positionY);
    bodyElement.insertAdjacentHTML("afterbegin",
                                    "<div id=\'" + dot.id + "\'" +
                                    " style=\'position:absolute;" +
                                    " top:"  + dot.positionY + "px;" +
                                    " left:" + dot.positionX + "px;" +
                                    " width:" + dot.radius + "px;" +
                                    " height:" + dot.radius + "px;" +
                                    " z-index:" + zIndex + ";" +
                                    "  background-color:" + dot.color + ";" +
                                    "color:white;\' >" +
                                    //dotNumber +
                                     "</div>")
    var dotElement = document.getElementById(dot.id);
    //dot.output();
    dot.setElement(dotElement);
    //dot.output();
    var timerId = setInterval( moveDot, refreshSpeed, dot);
    return dot;
}
function moveDot(dot){
    dot.moveDot();
}

function screenResize(){
    // reset the screen size X and Y
    screenSizeX = window.innerWidth;
    screenSizeY = window.innerHeight;
}

function clickForDot(e){
    if(dotCount % 10 == 0){
        lastRadius = lastRadius + dotSizeIncrement;
    }
    if (dotCount < MAXDOTS){
        dotCount = dotCount + 1;
        makeDots(dotCount, Math.floor(screenSizeX/2), Math.floor(screenSizeY/2));
    } else {
        console.log("Max dot count(" + dotCount + ") reached.");
    }
}

function repositionDots(){
    dotArray.forEach(element => {
        element.resetDotPosition();
    });
}
function repositionDivs(){
    divArray.forEach(element => {
        element.resetDivPosition();
        element.output();
    });
}

function moveDiv(div){
    div.moveDiv();
}
