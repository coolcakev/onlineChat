function createChatElement(chat) {
    let divForChat = document.createElement("div");
    divForChat.id = chat.id
    let linkforChat = document.createElement("a");
    linkforChat.href = "#"
    linkforChat.innerText = chat.title
    linkforChat.onclick = () => clickOnChat(linkforChat)
    divForChat.appendChild(linkforChat)
    return divForChat
}
function joinChatButton(chat) {
    let placeChatId ="MyChats"
    showChatFromHub(chat, placeChatId)
    joinChat(chat);
}
function joinChat(chat) {
    let model = {
        ChatId: chat.id
    }  
    ChatHub.invokeFunctionJoinGroup(chat.id.toString())
    ApiMessage.joinUser(model,chat)    
}
function showMessageFromHub(message) {
    let messageElement = document.getElementById("AllMassage");
    var model = {
        message: message
    }
    $.ajax({
        type: "Post",
        url: `/Message/ShowMessage`,
        data: JSON.stringify(message),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            messageElement.insertAdjacentHTML("afterbegin", data)
        }
    });
  

}
function sendMessage(chat) {
    let messege = document.getElementById("UserMessage");
    if (messege.value == "") {
        setValidationInElement(messege, "is-invalid", "Messege is empty");
        return
    }
    let model = {
        ChatId: Number(chat.ChatId),
        Message: messege.value
    }
    messege.value = ""
    $.ajax({
        type: "Post",
        url: `/Account/SendMessage`,
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            let result = JSON.parse(data);
            ChatHub.invokeFunctionSendMessage(`${result.ChatId}`, result.Message, result.User)
        }
    });

}
