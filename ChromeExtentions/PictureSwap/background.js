chrome.action.onClicked.addListener(buttonClicked);

function buttonClicked(tab){
    console.log(tab);
    let msg = {
        txt: "hello"
    }
    chrome.tabs.sendMessage(tab.id, msg);
}