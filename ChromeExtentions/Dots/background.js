console.log("background here");
chrome.browserAction.onClicked.addListener(buttonClicked);

function buttonClicked(tab){
    console.log(tab);
    let msg = {
        txt: "dot time"
    }
    chrome.tabs.sendMessage(tab.id, msg);
}