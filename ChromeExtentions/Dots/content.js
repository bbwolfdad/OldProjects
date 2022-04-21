chrome.runtime.onMessage.addListener(gotMessage);

var dotStarted = false;



function gotMessage(message, sender, sendResponse){
  console.log(message.txt);
  if (message.txt === "hello"){
    let divs = document.getElementsByTagName('div');
    for (elements of divs){
      //elements.style['background-color'] = '#ccffff';
    }
    changeWords(document.getElementsByTagName('body'));
    let bolds = document.getElementsByTagName('b');
    for (elements of bolds){
      elements.style['color'] = 'red';
    }
  }
  if( !dotStarted ){
    startDotAction();
    dotStarted = true;
  } else {
    repositionDots();
    repositionDivs();
  }
}

function changeWords(elementArray){
  for( elements of elementArray){
    let text = elements.innerHTML;
    text = text.replace(/dot/ig, "<b>dot</b>");
    text = text.replace(/dots/ig, "<b>dots</b>");
    elements.innerHTML = text;
  }
}
