chrome.runtime.onMessage.addListener(gotMessage);
let picArray = [
  "Arrow.jpg",
  "DisapointedDad-1.jpg",
  "DisapointedDad-2.jpg",
  "DisapointedDad-3.jpg",
  "DisapointedDad-4.jpg",
  "SuspiciosDad-1.jpg"
];

function gotMessage(message, sender, sendResponse){
  console.log(message.txt);
  if (message.txt === "hello"){
    let divs = document.getElementsByTagName('div');
    for (elements of divs){
      //elements.style['background-color'] = '#ccffff';
    }
    changeWords(document.getElementsByTagName('p'));
    changeWords(document.getElementsByTagName('h1'));
    changeWords(document.getElementsByTagName('h2'));
    changeWords(document.getElementsByTagName('h3'));
    changeWords(document.getElementsByTagName('span'));
    //changeWords(document.getElementsByTagName('div'));
    changeWords(document.getElementsByName('#text'));
    changePicLinks(document.getElementsByTagName('img'))
    let bolds = document.getElementsByTagName('b');
    for (elements of bolds){
      elements.style['color'] = 'red';
    }
  }
}
function changePicLinks(elementArray){
  for(elements of elementArray){
    let picIndex = Math.floor(Math.random() * picArray.length);
    elements.src = chrome.runtime.getURL("pics/" + picArray[picIndex]);
    elements.backgroundImage = chrome.runtime.getURL("pics/" + picArray[picIndex]);
  }
}

function changeWords(elementArray){
  for( elements of elementArray){
    let text = elements.innerHTML;
    text = text.replace(/autumn/ig, "<b>Autumn C Downing</b>");
    text = text.replace(/fall/ig, "<b>Autumn C Downing</b>");
    text = text.replace(/fortnite/ig, "<b>Fork-Knife</b>");
    text = text.replace(/star wars/ig, "<b>Star Trek</b>");
    text = text.replace(/starwars/ig, "<b>Star Trek</b>");
    text = text.replace(/skywalker/ig, "<b>Big Baby</b>");
    text = text.replace(/right/ig, "<b>left</b>");
    text = text.replace(/\.com/ig, "<b>.internet</b>");
    text = text.replace(/cat/ig, "<b>Evil</b>");
    text = text.replace(/covid/ig, "<b>Pikachu</b>");
    elements.innerHTML = text;
  }
}